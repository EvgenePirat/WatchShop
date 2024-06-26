import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const watchApi = createApi({
    reducerPath:"watchApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/watch/"
    }),
    tagTypes: ["Watches"],
    endpoints: (builder) => ({
        getWatches: builder.query({
            query: () => ({
                url:"all",
                method: "GET"
            }),
            providesTags: ["Watches"],
        }),
        getWatchCharacteristics: builder.query({
            query: () => ({
                url:"characteristic",
                method: "GET",
                providesTags: ["Watches"],
            })
        }),
        getWatchByNameModel: builder.query({
            query: (nameModel) => ({
                url:`${nameModel}`,
                method: "GET"
            }),
            providesTags: ["Watches"],
        }),
        addNewWatch: builder.mutation({
            query: (newWatch) => ({
                url: "",
                method:"POST",
                body: newWatch,
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Watches"]
        }),
        updateWatch: builder.mutation({
            query: (watch) => ({
                url:`${watch.id}`,
                method: "PUT",
                body: watch,
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Watches"]
        }),
        deleteWatch: builder.mutation({
            query: (id) => ({
                url:`${id}`,
                method: "DELETE",
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            }),
            invalidatesTags:["Watches"]
        })
    }),
});

export const {useGetWatchesQuery, useGetWatchCharacteristicsQuery, useGetWatchByNameModelQuery, useAddNewWatchMutation, useUpdateWatchMutation, useDeleteWatchMutation} = watchApi;

export default watchApi;