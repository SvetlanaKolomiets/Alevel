import React, { FormEvent, useState } from 'react';
import { Button, FormControl, FormHelperText, Input, InputLabel } from '@mui/material';
import { updateUser } from '../../../api/modules/users';

const UpdateUserForm = () => {
  const [userData, setUserData] = useState({ id: '', name: '', job: '' });
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
      const response = await updateUser(userData.id, { name: userData.name, job: userData.job });
      alert(`User ${response.data.name} with job ${response.data.job} updated successfully!`);
      setUserData({ id: '', name: '', job: '' });
    } catch (error) {
      console.error('Failed to update user:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormControl fullWidth>
        <InputLabel htmlFor="id">ID</InputLabel>
        <Input
          id="id"
          name="id"
          type="number"
          value={userData.id}
          onChange={handleChange}
          aria-describedby=""
          required
          inputProps={{ min: 1, max: 12 }}
        />
        <FormHelperText id="id-helper-text">Enter user's ID (1 to 12)</FormHelperText>
      </FormControl>
      <FormControl fullWidth>
        <InputLabel htmlFor="name">Name</InputLabel>
        <Input
          id="name"
          name="name"
          value={userData.name}
          onChange={handleChange}
          aria-describedby=""
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
          aria-describedby=""
          required
        />
        <FormHelperText id="job-helper-text">Enter user's job</FormHelperText>
      </FormControl>
      <Button type="submit" variant="contained" color="primary" disabled={loading}>
        {loading ? 'Updating...' : 'Update User'}
      </Button>
    </form>
  );
};

export default UpdateUserForm;
