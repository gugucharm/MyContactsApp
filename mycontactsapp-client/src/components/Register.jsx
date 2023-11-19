import { useState } from 'react';
import axios from 'axios';

const Register = () => {
  const [user, setUser] = useState({
    FirstName: '',
    LastName: '',
    Email: '',
    Password: '',
  });

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://localhost:8000/users/register', user);
      console.log(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h2>Register</h2>
      <form onSubmit={handleSubmit}>
        {/* Input fields for FirstName, LastName, Email, and Password */}
        <input type="text" name="FirstName" value={user.FirstName} onChange={handleChange} placeholder="First Name" />
        <input type="text" name="LastName" value={user.LastName} onChange={handleChange} placeholder="Last Name" />
        <input type="email" name="Email" value={user.Email} onChange={handleChange} placeholder="Email" />
        <input type="password" name="Password" value={user.Password} onChange={handleChange} placeholder="Password" />
        <button type="submit">Register</button>
      </form>
    </div>
  );
};

export default Register;
