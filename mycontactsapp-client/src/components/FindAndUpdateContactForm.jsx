import { useState } from 'react';
import UpdateContactForm from './UpdateContactForm';
import axios from 'axios';
import PropTypes from 'prop-types';

const FindAndUpdateContactForm = ({ onContactUpdated }) => {
  const [emailToFind, setEmailToFind] = useState('');
  const [contactData, setContactData] = useState(null);

  const handleEmailInputChange = (e) => {
    setEmailToFind(e.target.value);
  };

  const handleFindContact = async () => {
    try {
      const response = await axios.get(`http://localhost:8000/contacts/findByEmail/${emailToFind}`, {
        headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` }
      });
      setContactData(response.data);
    } catch (error) {
      console.error('Error finding contact:', error);
    }
  };

  return (
    <div>
      <input 
        type="email" 
        value={emailToFind} 
        onChange={handleEmailInputChange} 
        placeholder="Enter contact's email"
      />
      <button onClick={handleFindContact}>Find and update Contact</button>

      {contactData && (
        <UpdateContactForm 
          contactId={contactData.id}
          initialData={contactData}
          onContactUpdated={onContactUpdated}
        />
      )}
    </div>
  );
};

FindAndUpdateContactForm.propTypes = {
    onContactUpdated: PropTypes.func.isRequired
};
  

export default FindAndUpdateContactForm;
