import React, {ReactElement, FC} from "react";
import {
    Card,
    CardContent,
    CardMedia,
    CircularProgress,
    Container,
    Grid,
    Typography
} from '@mui/material'
import UserStore from "./UserStore";
import { observer } from "mobx-react";

const User: FC<any> = (): ReactElement => {

    const store = UserStore;

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {store.isLoading ? (
                    <CircularProgress />
                ) : (
                    <>
                        <Card sx={{ maxWidth: 250 }}>
                            <CardMedia
                                component="img"
                                height="250"
                                image={store.user?.avatar}
                                alt={store.user?.email}
                            />
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                    {store.user?.email}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {store.user?.first_name} {store.user?.last_name}
                                </Typography>
                            </CardContent>
                        </Card>
                    </>
                )}
            </Grid>
        </Container>
    );
};

export default observer(User);