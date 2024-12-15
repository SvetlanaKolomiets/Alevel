import apiClient from "../client";

export const getById = (id: string) => apiClient({
  path: `users/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient({
  path: `users?page=${page}`,
  method: 'GET'
})

export const createUser = async (userData: any) => {
  try {
    const response = await apiClient({
      path: `users`,
      method: 'POST',
      data: userData
    });
    return response.data;
  } catch (e) {
    throw new Error('Failed to create user: ' + e);
  }
};

export const updateUser = async (id: string, userData: any) => {
  try {
    const response = await apiClient({
      path: `users/${id}`,
      method: 'PUT',
      data: userData
    });
    return response.data;
  } catch (e) {
    throw new Error('Failed to update user: ' + e);
  }
};