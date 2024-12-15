import { makeAutoObservable } from 'mobx';
import * as userApi from '../../api/modules/users';
import { IUser } from '../../interfaces/users';

class UserStore {
    user: IUser | null = null;
    isLoading = false;

    constructor() {
        makeAutoObservable(this);
    }

    async getUserById(id: string) {
        try {
            this.isLoading = true;
            const res = await userApi.getById(id);
            this.user = res.data;
        } catch (error) {
            console.error('Failed to get user:', error);
        } finally {
            this.isLoading = false;
        }
    }
}

export default new UserStore();
