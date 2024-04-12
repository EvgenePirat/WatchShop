import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const authApi = createApi({
    reducerPath:"authApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/authenticate/"
    }),
    tagTypes: ["Users"],
    endpoints: (builder) => ({
        registerNewUser: builder.mutation({
            query: (newUser) => ({
                url: "register",
                method:"POST",
                body: newUser,
            }),
            invalidatesTags: ["Users"]
        }),
        login: builder.mutation({
            query: (user) => ({
                url: "login",
                method:"POST",
                body: user,
            })
        })
    }),
});

export const { useRegisterNewUserMutation, useLoginMutation} = authApi;

export default authApi;