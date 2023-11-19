import { useState } from 'react';
import PropTypes from 'prop-types';
import DeleteContactButton from './DeleteContactButton';

const Contact = ({ contact, categories, subcategories, onDeleteSuccess }) => {
  const [showDetails, setShowDetails] = useState(false);

  // Find the category and subcategory names based on their IDs
  const categoryName = categories.find(cat => cat.id === contact.categoryId)?.name;
  const subcategoryName = subcategories.find(sub => sub.id === contact.subcategoryId)?.name;

  return (
    <div>
      <h3>{contact.firstName} {contact.lastName}</h3>
      <p>{contact.email}</p>
      <button onClick={() => setShowDetails(!showDetails)}>
        {showDetails ? 'Hide Details' : 'Show Details'}
      </button>

      {showDetails && (
        <div>
          {/* Display category and subcategory names instead of IDs */}
          <p>Category: {categoryName || 'Unknown'}</p>
          <p>Subcategory: {subcategoryName || 'Unknown'}</p>
          <p>Phone Number: {contact.phoneNumber}</p>
          <p>Birthdate: {new Date(contact.birthdate).toLocaleDateString()}</p>
        </div>
      )}

      <DeleteContactButton contactId={contact.id} onDeleteSuccess={onDeleteSuccess} />
    </div>
  );
};

Contact.propTypes = {
  contact: PropTypes.shape({
    id: PropTypes.number.isRequired,
    firstName: PropTypes.string.isRequired,
    lastName: PropTypes.string.isRequired,
    email: PropTypes.string.isRequired,
    categoryId: PropTypes.number.isRequired,
    subcategoryId: PropTypes.number.isRequired,
    phoneNumber: PropTypes.number.isRequired,
    birthdate: PropTypes.string.isRequired,
  }).isRequired,
  categories: PropTypes.arrayOf(PropTypes.shape({
    id: PropTypes.number.isRequired,
    name: PropTypes.string.isRequired
  })).isRequired,
  subcategories: PropTypes.arrayOf(PropTypes.shape({
    id: PropTypes.number.isRequired,
    name: PropTypes.string.isRequired
  })).isRequired,
  onDeleteSuccess: PropTypes.func.isRequired,
};

export default Contact;
