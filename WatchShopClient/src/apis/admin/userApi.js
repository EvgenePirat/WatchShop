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
                method: "GET",
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            providesTags: ["Users"],
        }),
        updateUser: builder.mutation({
            query: (user) => ({
                url:`${user.id}`,
                method: "PUT",
                body: user,
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Users"],
        }),
        deleteUser: builder.mutation({
            query: (id) => ({
                url:`${id}`,
                method: "DELETE",
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Users"],
        }),
        subscriptionLetters: builder.mutation({
            query: (user) => ({
                url:`subscription/${user.email}&${user.isActive}`,
                method: "PUT",
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Users"],
        })
    }),
});

export const {useGetUsersQuery, useGetUserByIdQuery, useAddNewUserMutation, useUpdateUserMutation, useDeleteUserMutation, useSubscriptionLettersMutation} = userApi;

export default userApi;