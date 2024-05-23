import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const commentApi = createApi({
    reducerPath:"commentApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/comment/"
    }),
    tagTypes: ["Comments"],
    endpoints: (builder) => ({
        getComments: builder.query({
            query: () => ({
                url:"all",
                method: "GET"
            }),
            providesTags: ["Comments"],
        }),
        getCommentById: builder.query({
            query: (id) => ({
                url:`${id}`,
                method: "GET"
            }),
            providesTags: ["Comments"],
        }),
        getCommentByUserName: builder.query({
            query: (username) => ({
                url:`user/${username}`,
                method: "GET"
            }),
            providesTags: ["Comments"],
        }),
        getCommentByWatchNameModel: builder.query({
            query: (nameModel) => ({
                url:`watch/${nameModel}`,
                method: "GET"
            }),
            providesTags: ["Comments"],
        }),
        addNewComment: builder.mutation({
            query: (newComment) => ({
                url: "",
                method:"POST",
                body: newComment,
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Comments"]
        }),
        updateComment: builder.mutation({
            query: (comment) => ({
                url:`${comment.id}`,
                method: "PUT",
                body: comment,
            }),
            invalidatesTags:["Comments"],
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`,
            }
        }),
        deleteComment: builder.mutation({
            query: (id) => ({
                url:`${id}`,
                method: "DELETE"
            }),
            invalidatesTags:["Comments"],
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`,
            }
        })
    }),
});

export const {useGetCommentsQuery, useGetCommentByIdQuery,useGetCommentByUserNameQuery, useGetCommentByWatchNameModelQuery , useAddNewCommentMutation, useUpdateCommentMutation, useDeleteCommentMutation} = commentApi;

export default commentApi;