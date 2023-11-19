import { useState, useEffect } from 'react';
import axios from 'axios';
import PropTypes from 'prop-types';

const UpdateContactForm = ({ contactId, initialData, onContactUpdated }) => {
  const [contact, setContact] = useState(initialData);
  const [categoryName, setCategoryName] = useState('');
  const [subcategoryName, setSubcategoryName] = useState('');

  useEffect(() => {
    setContact(initialData);
    if (initialData) {
      setCategoryName(initialData.categoryName || '');
      setSubcategoryName(initialData.subcategoryName || '');
    }
  }, [initialData]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setContact({ ...contact, [name]: value });
  };

  const handleCategoryChange = (e) => {
    setCategoryName(e.target.value);
  };

  const handleSubcategoryChange = (e) => {
    setSubcategoryName(e.target.value);
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

    let categoryId = categoryName === 'sluzbowy' ? 1 : categoryName === 'prywatny' ? 2 : categoryName === 'inny' ? 3 : 0;
    let subcategoryId = subcategoryName === 'szef' ? 2 : subcategoryName === 'klient' ? 3 : subcategoryName === 'none' ? 1 : 0;
    const phoneNumberInt = parseInt(contact.phoneNumber, 10) || 0;

    const updatedData = {
      firstName: contact.firstName,
      lastName: contact.lastName,
      email: contact.email,
      categoryId: categoryId,
      subcategoryId: subcategoryId,
      phoneNumber: phoneNumberInt,
      birthdate: formatISODate(contact.birthdate)
    };

    try {
      await axios.put(`http://localhost:8000/contacts/${contactId}`, updatedData, {
        headers: { 'Authorization': `Bearer ${token}` }
      });

      onContactUpdated();
    } catch (error) {
      console.error('Error updating contact:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" name="firstName" value={contact.firstName} onChange={handleInputChange} placeholder="First Name" />
      <input type="text" name="lastName" value={contact.lastName} onChange={handleInputChange} placeholder="Last Name" />
      <input type="email" name="email" value={contact.email} onChange={handleInputChange} placeholder="Email" />
      <input type="tel" name="phoneNumber" value={contact.phoneNumber} onChange={handleInputChange} placeholder="Phone Number" />
      <input type="date" name="birthdate" value={contact.birthdate.split('T')[0]} onChange={handleInputChange} />
      <input type="text" name="categoryName" value={categoryName} onChange={handleCategoryChange} placeholder="Category Name" />
      <input type="text" name="subcategoryName" value={subcategoryName} onChange={handleSubcategoryChange} placeholder="Subcategory Name" />

      <button type="submit">Update Contact</button>
    </form>
  );
};

UpdateContactForm.propTypes = {
  contactId: PropTypes.number.isRequired,
  initialData: PropTypes.object.isRequired,
  onContactUpdated: PropTypes.func.isRequired
};

export default UpdateContactForm;
