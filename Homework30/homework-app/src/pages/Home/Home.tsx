import React, { FC, ReactElement} from "react";
import { Box, CircularProgress, Container, Grid, Pagination, Tab, Tabs } from '@mui/material';
import { observer } from "mobx-react-lite";
import HomeStore from "./HomeStore";
import UserCard from "./components/UserCard";
import UserForm from "./components/UserForm";
import UpdateUserForm from "./components/UpdateUserForm";
import { IUser } from "../../interfaces/users";



const Home: FC<any> = (): ReactElement => {

    const store = HomeStore;

    return (
        <Container>
            <Tabs value={store.tabValue} onChange={store.handleTabChange}>
                <Tab label="Users" />
                <Tab label="Create User" />
                <Tab label="Update User" />
            </Tabs>
            {store.tabValue === 0 && (
                <Box>
                    <Grid container spacing={4} justifyContent="center" my={4}>
                        {store.isLoading ? (
                            <CircularProgress />
                        ) : (
                            <>
                                {store.users?.map((item: IUser) => (
                                    <Grid key={item.id} item lg={2} md={3} xs={6}>
                                        <UserCard {...item} />
                                    </Grid>
                                ))}
                            </>
                        )}
                    </Grid>
                    <Box
                        sx={{
                            display: 'flex',
                            justifyContent: 'center'
                        }}
                    >
                        <Pagination count={store.totalPages} page={store.currentPage} onChange={ async (event, page)=> await store.changePage(page)} />
                    </Box>
                </Box>
            )}
            {store.tabValue === 1 && (
                <Box mt={4}>
                    <UserForm />
                </Box>
            )}
            {store.tabValue === 2 && (
                <Box mt={4}>
                    <UpdateUserForm />
                </Box>
            )}
        </Container>
    );
};

export default observer(Home);
