import React, { ReactElement, FC } from "react";
import { Container, Grid, CircularProgress, Card, CardContent, Typography } from '@mui/material';
import { observer } from "mobx-react";
import ResourceStore from "./ResourceStore";

const Resource: FC<any> = (): ReactElement => {
    const store = ResourceStore;

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {store.isLoading ? (
                    <CircularProgress />
                ) : (
                    store.resource ? (
                        <Card key={store.resource.id} sx={{ maxWidth: 250 }}>
                            <div
                                style={{
                                    height: 250,
                                    backgroundColor: store.resource.color
                                }}
                            />
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                    {store.resource.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {store.resource.year} {store.resource.color}
                                </Typography>
                            </CardContent>
                        </Card>
                    ) : (
                        <Typography variant="body1" color="text.secondary">No resource found</Typography>
                    )
                )}
            </Grid>
        </Container>
    );
};

export default observer(Resource);
