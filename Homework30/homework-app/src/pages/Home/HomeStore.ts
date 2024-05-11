import { makeAutoObservable, runInAction } from "mobx";
import { IUser } from "../../interfaces/users";
import * as userApi from "../../api/modules/users";

class HomeStore {
    users: IUser[] = [];
    totalPages = 0;
    currentPage = 1;
    isLoading = false;
    tabValue = 0;

    constructor() {
        makeAutoObservable(this);
        runInAction(this.prefetchData);
    }

    async changePage(page: number) {
        this.currentPage = page;
        await this.prefetchData();
    }

    prefetchData = async () => {
        try {
            this.isLoading = true;
            const res = await userApi.getByPage(this.currentPage)
            this.users = res.data;
            this.totalPages = res.total_pages;
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message)
            }
        }
        this.isLoading = false;
    };

    setTabValue(value: number) {
        this.tabValue = value;
    };

    handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
        this.setTabValue(newValue);
    };
}

export default new HomeStore;
