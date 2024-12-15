import { Button, FormControl, FormHelperText, Input, InputLabel } from '@mui/material';
import CreateUserStore from '../CreateUserStore';
import { observer } from 'mobx-react';

const UserForm = () => {
  const store = CreateUserStore;

  return (
    <form onSubmit={store.handleSubmit}>
      <FormControl fullWidth>
        <InputLabel htmlFor="name">Name</InputLabel>
        <Input
          id="name"
          name="name"
          value={store.name}
          onChange={store.handleChange}
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
          value={store.job}
          onChange={store.handleChange}
          aria-describedby="job-helper-text"
          required
        />
        <FormHelperText id="job-helper-text">Enter user's job</FormHelperText>
      </FormControl>
      <Button type="submit" variant="contained" color="primary" disabled={store.loading}>
        {store.loading ? 'Creating...' : 'Create User'}
      </Button>
    </form>
  );
};

export default observer(UserForm);
