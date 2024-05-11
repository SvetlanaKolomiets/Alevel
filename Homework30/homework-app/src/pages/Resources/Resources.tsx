import React, {ReactElement, FC} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import {IResource} from "../../interfaces/resources";
import ResourceCard from "./components";
import ResourcesStore from "./ResourcesStore";
import { observer } from "mobx-react";

const Resources: FC<any> = (): ReactElement => {
    const store = ResourcesStore;

  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {store.isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {store.resources?.map((item: IResource) => (
                          <Grid key={item.id} item lg={2} md={3} xs={6}>
                              <ResourceCard {...item} />
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
              <Pagination count={store.totalPages} page={store.currentPage} onChange={ (event, page)=> store.changePage(page)} />
          </Box>
      </Container>
  );
};

export default observer(Resources);