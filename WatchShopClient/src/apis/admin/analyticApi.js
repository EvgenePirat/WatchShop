import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const analyticApi = createApi({
    reducerPath:"analyticApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/analytic/"
    }),
    endpoints: (builder) => ({
        getSalesStatistics: builder.query({
            query: () => ({
                url:"",
                method: "GET"
            })
        })
    }),
});

export const {useGetSalesStatisticsQuery} = analyticApi;

export default analyticApi;