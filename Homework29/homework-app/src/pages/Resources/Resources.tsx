import React, {ReactElement, FC, useEffect, useState} from "react";
import {Box, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import * as resourceApi from "../../api/modules/resources"
import {IResource} from "../../interfaces/resources";
import ResourceCard from "./components";

const Resources: FC<any> = (): ReactElement => {
    const [resources, setResources] = useState<IResource[] | null>(null)
    const [totalPages, setTotalPages] = useState<number>(0)
    const [currentPage, setCurrentPage] = useState<number>(1)
    const [isLoading, setIsLoading] = useState<boolean>(false)

    useEffect(() => {
        const getResource = async () => {
            try {
                setIsLoading(true)
                const res = await resourceApi.getByPage(currentPage)
                setResources(res.data)
                setTotalPages(res.total_pages)
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            setIsLoading(false)
        }
        getResource()
    }, [currentPage])

  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {resources?.map((item) => (
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
              <Pagination count={totalPages} page={currentPage} onChange={ (event, page)=> setCurrentPage(page)} />
          </Box>
      </Container>
  );
};

export default Resources;