import { useState, useEffect } from 'react';
import Login from './components/Login';
import Register from './components/Register';
import Contact from './components/Contact';
import AddContactForm from './components/AddContactForm';
import FindAndUpdateContactForm from './components/FindAndUpdateContactForm';

function App() {
  const [showRegister, setShowRegister] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [contacts, setContacts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [subcategories, setSubcategories] = useState([]);

  const toggleRegister = () => setShowRegister(!showRegister);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    setIsLoggedIn(false);
  };

  const handleDeleteSuccess = (deletedContactId) => {
    setContacts(contacts.filter(contact => contact.id !== deletedContactId));
  };

  const handleContactAdded = () => {
    fetchContacts(); // Re-fetch contacts to update the list with the new contact
  };

  const handleContactUpdated = () => {
    fetchContacts();
  };

  const fetchContacts = async () => {
    try {
      const response = await fetch('http://localhost:8000/contacts', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const data = await response.json();
      setContacts(data);
    } catch (error) {
      console.error('Error fetching contacts:', error);
    }
  };

  const fetchCategoriesAndSubcategories = async () => {
    try {
      const categoriesResponse = await fetch('http://localhost:8000/categories', {
        headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` }
      });
      const subcategoriesResponse = await fetch('http://localhost:8000/subcategories', {
        headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` }
      });

      if (!categoriesResponse.ok || !subcategoriesResponse.ok) {
        throw new Error('Error fetching categories or subcategories');
      }

      const categoriesData = await categoriesResponse.json();
      const subcategoriesData = await subcategoriesResponse.json();

      setCategories(categoriesData);
      setSubcategories(subcategoriesData);
    } catch (error) {
      console.error('Error:', error);
    }
  };

  useEffect(() => {
    fetchContacts();
    fetchCategoriesAndSubcategories();
  }, []);

  return (
    <div>
      {!isLoggedIn ? (
        <>
          {!showRegister ? (
            <>
              <Login onLoginSuccess={handleLoginSuccess} />
              <button onClick={toggleRegister}>Dont have an account? Register</button>
            </>
          ) : (
            <>
              <Register />
              <button onClick={toggleRegister}>Already have an account? Log in</button>
            </>
          )}
        </>
      ) : (
        <>
          <button onClick={handleLogout}>Logout</button>
          <AddContactForm 
            categories={categories}
            subcategories={subcategories}
            onContactAdded={handleContactAdded} 
          />
          <FindAndUpdateContactForm 
          onContactUpdated={handleContactUpdated}
          />
        </>
      )}

      <div>
        <h2>Contacts</h2>
        {contacts.map(contact => (
          <Contact 
            key={contact.id} 
            contact={contact} 
            categories={categories}
            subcategories={subcategories}
            onDeleteSuccess={handleDeleteSuccess} 
          />
        ))}
      </div>
    </div>
  );
}

export default App;
