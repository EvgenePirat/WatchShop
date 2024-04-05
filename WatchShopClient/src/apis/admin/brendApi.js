import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const brendApi = createApi({
    reducerPath:"brendApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/brend/"
    }),
    tagTypes: ["Brends"],
    endpoints: (buiilder) => ({
        getBrends: buiilder.query({
            query: () => ({
                url:"all",
                method: "GET"
            }),
            providesTags: ["Brends"],
        }),
        getBrendById: buiilder.query({
            query: (id) => ({
                url:`${id}`,
                method: "GET"
            }),
            providesTags: ["Brends"],
        })

    }),
});

export const {useGetBrendsQuery, useGetBrendByIdQuery} = brendApi;

export default brendApi;