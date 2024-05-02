import React, { FormEvent, useState } from 'react';
import { Button, FormControl, FormHelperText, Input, InputLabel } from '@mui/material';
import { createUser } from '../../../api/modules/users';

const UserForm = () => {
  const [userData, setUserData] = useState({ name: '', job: '' });
  const [loading, setLoading] = useState(false);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };


  const handleSubmit = async (event: FormEvent) => {
    event.preventDefault();
    try {
      setLoading(true);
      await createUser(userData);
      alert(`User ${userData.name} with job ${userData.job} created successfully!`);
      setUserData({ name: '', job: '' });
    } catch (error) {
      console.error('Failed to create user:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormControl fullWidth>
        <InputLabel htmlFor="name">Name</InputLabel>
        <Input
          id="name"
          name="name"
          value={userData.name}
          onChange={handleChange}
          aria-describedby="name-helper-text"
          required
        />
        <FormHelperText id="name-helper-text">Enter user's name</FormHelperText>
      </FormControl>
      <FormControl fullWidth>
        <InputLabel htmlFor="job">Job</InputLabel>
        <Input
          id="job"
          name="job"
          value={userData.job}
          onChange={handleChange}
          aria-describedby="job-helper-text"
          required
        />
        <FormHelperText id="job-helper-text">Enter user's job</FormHelperText>
      </FormControl>
      <Button type="submit" variant="contained" color="primary" disabled={loading}>
        {loading ? 'Creating...' : 'Create User'}
      </Button>
    </form>
  );
};

export default UserForm;
