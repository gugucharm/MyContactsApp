import { useState } from 'react';
import axios from 'axios';
import PropTypes from 'prop-types';

const AddContactForm = ({ onContactAdded }) => {
  const [contact, setContact] = useState({
    firstName: '',
    lastName: '',
    email: '',
    categoryName: '',
    subcategoryName: '',
    phoneNumber: '',
    birthdate: ''
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setContact({ ...contact, [name]: value });
  };

  const formatISODate = (dateString) => {
    if (!dateString) return null;
    const date = new Date(dateString);
    return date.toISOString();
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem('token');
    if (!token) {
      console.log('User not logged in.');
      return;
    }

    let categoryId, subcategoryId;
    switch (contact.categoryName.toLowerCase()) {
      case 'sluzbowy': categoryId = 1; break;
      case 'prywatny': categoryId = 2; break;
      case 'inny': categoryId = 3; break;
      default: categoryId = null; break;
    }

    switch (contact.subcategoryName.toLowerCase()) {
      case 'none': subcategoryId = 1; break;
      case 'szef': subcategoryId = 2; break;
      case 'klient': subcategoryId = 3; break;
      default: subcategoryId = null; break;
    }

    const contactData = {
      FirstName: contact.firstName,
      LastName: contact.lastName,
      Email: contact.email,
      CategoryId: categoryId,
      SubcategoryId: subcategoryId,
      PhoneNumber: parseInt(contact.phoneNumber, 10),
      Birthdate: formatISODate(contact.birthdate)
    };

    console.log('Sending contact data:', contactData);

    try {
      await axios.post('http://localhost:8000/contacts', contactData, {
        headers: { 'Authorization': `Bearer ${token}` }
      });

      onContactAdded();
      setContact({
        firstName: '',
        lastName: '',
        email: '',
        categoryName: '',
        subcategoryName: '',
        phoneNumber: '',
        birthdate: ''
      });
    } catch (error) {
      console.error('Error creating contact:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" name="firstName" value={contact.firstName} onChange={handleInputChange} placeholder="First Name" />
      <input type="text" name="lastName" value={contact.lastName} onChange={handleInputChange} placeholder="Last Name" />
      <input type="email" name="email" value={contact.email} onChange={handleInputChange} placeholder="Email" />
      <input type="tel" name="phoneNumber" value={contact.phoneNumber} onChange={handleInputChange} placeholder="Phone Number" />
      <input type="date" name="birthdate" value={contact.birthdate} onChange={handleInputChange} />

      <input type="text" name="categoryName" value={contact.categoryName} onChange={handleInputChange} placeholder="Category Name" />
      <input type="text" name="subcategoryName" value={contact.subcategoryName} onChange={handleInputChange} placeholder="Subcategory Name" />

      <button type="submit">Add Contact</button>
    </form>
  );
};

AddContactForm.propTypes = {
  onContactAdded: PropTypes.func.isRequired
};

export default AddContactForm;
