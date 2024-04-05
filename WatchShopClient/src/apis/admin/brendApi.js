import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const brendApi = createApi({
    reducerPath:"brendApi",
    baseQuery: fetchBaseQuery({
        baseUrl:""
    })
})