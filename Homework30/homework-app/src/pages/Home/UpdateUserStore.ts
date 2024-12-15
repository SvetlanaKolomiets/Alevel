import { makeAutoObservable } from 'mobx';
import { updateUser } from '../../api/modules/users';

class UpdateUserStore {
  id = '';
  name = '';
  job = '';
  loading = false;

  constructor() {
    makeAutoObservable(this);
  }

  handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    if (name === 'id') {
      this.id = value;
    } else if (name === 'name') {
      this.name = value;
    } else if (name === 'job') {
      this.job = value;
    }
  };

  handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    try {
      this.loading = true;
      await updateUser(this.id, { name: this.name, job: this.job });
      alert(`User ${this.name} with job ${this.job} updated successfully!`);
      this.id = '';
      this.name = '';
      this.job = '';
    } catch (error) {
      console.error('Failed to update user:', error);
    } finally {
      this.loading = false;
    }
  };
}

export default new UpdateUserStore();
