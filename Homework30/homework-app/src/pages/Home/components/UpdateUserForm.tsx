import { Button, FormControl, FormHelperText, Input, InputLabel } from '@mui/material';
import { observer } from 'mobx-react';
import UpdateUserStore from '../UpdateUserStore';

const UpdateUserForm = () => {

  const store = UpdateUserStore;

  return (
    <form onSubmit={store.handleSubmit}>
      <FormControl fullWidth>
        <InputLabel htmlFor="id">ID</InputLabel>
        <Input
          id="id"
          name="id"
          type="number"
          value={store.id}
          onChange={store.handleChange}
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
          value={store.name}
          onChange={store.handleChange}
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
          value={store.job}
          onChange={store.handleChange}
          aria-describedby=""
          required
        />
        <FormHelperText id="job-helper-text">Enter user's job</FormHelperText>
      </FormControl>
      <Button type="submit" variant="contained" color="primary" disabled={store.loading}>
        {store.loading ? 'Updating...' : 'Update User'}
      </Button>
    </form>
  );
};

export default observer(UpdateUserForm);