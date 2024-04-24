import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const paymentApi = createApi({
    reducerPath:"paymentApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/payment/"
    }),
    tagTypes: ["Payments"],
    endpoints: (builder) => ({
        makePayment: builder.mutation({
            query: (carttotal) => ({
                url: `${carttotal}`,
                method:"POST"
            }),
            invalidatesTags: ["Payments"]
        })
    }),
});

export const { useMakePaymentMutation} = paymentApi;

export default paymentApi;