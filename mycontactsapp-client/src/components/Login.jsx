import { useState } from 'react';
import axios from 'axios';
import PropTypes from 'prop-types';

const Login = ({ onLoginSuccess }) => {
  const [user, setUser] = useState({
    Email: '',
    Password: '',
  });

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://localhost:8000/users/login', user);
      localStorage.setItem('token', response.data.token);
      onLoginSuccess();
    } catch (error) {
      console.error('Login error:', error);
      // Optionally, handle login failure (e.g., showing an error message)
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          name="Email"
          value={user.Email}
          onChange={handleChange}
          placeholder="Email"
        />
        <input
          type="password"
          name="Password"
          value={user.Password}
          onChange={handleChange}
          placeholder="Password"
        />
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

Login.propTypes = {
  onLoginSuccess: PropTypes.func.isRequired
};

export default Login;
