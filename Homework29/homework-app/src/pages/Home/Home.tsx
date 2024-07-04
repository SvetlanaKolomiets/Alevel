// Home.tsx

import React, { ReactElement, FC, useEffect, useState } from "react";
import { Box, CircularProgress, Container, Grid, Pagination, Tab, Tabs } from '@mui/material'
import * as userApi from "../../api/modules/users"
import { IUser } from "../../interfaces/users";
import UserCard from "./components/UserCard";
import UserForm from "./components/UserForm";
import UpdateUserForm from "./components/UpdateUserForm";

const Home: FC<any> = (): ReactElement => {
    const [users, setUsers] = useState<IUser[] | null>(null);
    const [totalPages, setTotalPages] = useState<number>(0);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [tabValue, setTabValue] = useState<number>(0);

    useEffect(() => {
        const getUser = async () => {
            try {
                setIsLoading(true);
                const res = await userApi.getByPage(currentPage);
                setUsers(res.data);
                setTotalPages(res.total_pages);
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message);
                }
            }
            setIsLoading(false);
        };
        getUser();
    }, [currentPage]);

    const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
        setTabValue(newValue);
    };

    return (
        <Container>
            <Tabs value={tabValue} onChange={handleTabChange}>
                <Tab label="Users" />
                <Tab label="Create User" />
                <Tab label="Update User" />
            </Tabs>
            {tabValue === 0 && (
                <Box>
                    <Grid container spacing={4} justifyContent="center" my={4}>
                        {isLoading ? (
                            <CircularProgress />
                        ) : (
                            <>
                                {users?.map((item) => (
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
                        <Pagination count={totalPages} page={currentPage} onChange={(event, page) => setCurrentPage(page)} />
                    </Box>
                </Box>
            )}
            {tabValue === 1 && (
                <Box mt={4}>
                    <UserForm />
                </Box>
            )}
            {tabValue === 2 && (
                <Box mt={4}>
                    <UpdateUserForm />
                </Box>
            )}
        </Container>
    );
};

export default Home;
