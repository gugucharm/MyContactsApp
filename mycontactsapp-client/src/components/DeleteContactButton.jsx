import PropTypes from 'prop-types';

const DeleteContactButton = ({ contactId, onDeleteSuccess }) => {
  const token = localStorage.getItem('token');

  const handleDelete = async () => {
    if (token) {
      try {
        const response = await fetch(`http://localhost:8000/contacts/${contactId}`, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
          }
        });

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        onDeleteSuccess(contactId);
      } catch (error) {
        console.error('Error deleting contact:', error);
      }
    } else {
      console.log('User not logged in.');
    }
  };

  return (
    token && <button onClick={handleDelete}>Delete Contact</button>
  );
};

DeleteContactButton.propTypes = {
  contactId: PropTypes.number.isRequired,
  onDeleteSuccess: PropTypes.func.isRequired
};

export default DeleteContactButton;
