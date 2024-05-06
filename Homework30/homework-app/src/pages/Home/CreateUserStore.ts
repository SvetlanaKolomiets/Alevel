import React, { FormEvent } from 'react';
import { Button, FormControl, FormHelperText, Input, InputLabel } from '@mui/material';
import { createUser } from '../../api/modules/users';
import { makeAutoObservable, observable, action } from 'mobx';

class UserFormStore {
  name = '';
  job = '';
  loading = false;

  constructor() {
    makeAutoObservable(this);
  }

  handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    if (name === 'name') {
      this.name = value;
    } else if (name === 'job') {
      this.job = value;
    }
  };

  handleSubmit = async (event: FormEvent) => {
    event.preventDefault();
    try {
      this.loading = true;
      await createUser({ name: this.name, job: this.job });
      alert(`User ${this.name} with job ${this.job} created successfully!`);
      this.name = '';
      this.job = '';
    } catch (error) {
      console.error('Failed to create user:', error);
    } finally {
      this.loading = false;
    }
  };
}

export default new UserFormStore();