import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const userApi = createApi({
    reducerPath:"userApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/user/"
    }),
    tagTypes: ["Users"],
    endpoints: (builder) => ({
        getUsers: builder.query({
            query: () => ({
                url:"all",
                method: "GET"
            }),
            providesTags: ["Users"],
        }),
        getUserById: builder.query({
            query: (id) => ({
                url:`${id}`,
                method: "GET"
            }),
            providesTags: ["Users"],
        }),
        updateUser: builder.mutation({
            query: (user) => ({
                url:`${user.id}`,
                method: "PUT",
                body: user,
            }),
            invalidatesTags:["Users"],
        }),
        deleteUser: builder.mutation({
            query: (id) => ({
                url:`${id}`,
                method: "DELETE"
            }),
            invalidatesTags:["Users"],
        })
    }),
});

export const {useGetUsersQuery, useGetUserByIdQuery, useAddNewUserMutation, useUpdateUserMutation, useDeleteUserMutation} = userApi;

export default userApi;