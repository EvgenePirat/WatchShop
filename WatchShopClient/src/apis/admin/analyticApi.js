import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const analyticApi = createApi({
    reducerPath:"analyticApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/analytic/",
        prepareHeaders: (headers, api) => {
            const token = localStorage.getItem("token");
            token && headers.append("Authorization", "Bearer " + token);
        },
    }),
    tagTypes: ["Analystics"],
    endpoints: (builder) => ({
        getSalesStatistics: builder.query({
            query: () => ({
                url:"",
                method: "GET"
            }),
            providesTags: ["Analystics"],
        })
    }),
});

export const {useGetSalesStatisticsQuery} = analyticApi;

export default analyticApi;