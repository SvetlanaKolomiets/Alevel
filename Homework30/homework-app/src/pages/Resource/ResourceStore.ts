import { makeAutoObservable } from 'mobx';
import * as resourceApi from '../../api/modules/resources';
import { IResource } from '../../interfaces/resources';

class ResourceStore {
    resource: IResource | null = null;
    isLoading = false;

    constructor() {
        makeAutoObservable(this);
    }

    async getResourceById(id: string) {
        try {
            this.isLoading = true;
            const res = await resourceApi.getById(id);
            this.resource = res.data;
        } catch (error) {
            console.error('Failed to get resource:', error);
        } finally {
            this.isLoading = false;
        }
    }
}

export default new ResourceStore();