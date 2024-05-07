import React from 'react';
import { createUser } from '../../api/modules/users';
import { makeAutoObservable } from 'mobx';

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

  handleSubmit = async (event: React.FormEvent) => {
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