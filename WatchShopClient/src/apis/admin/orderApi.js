import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const orderApi = createApi({
    reducerPath:"orderApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/order/"
    }),
    tagTypes: ["Orders"],
    endpoints: (builder) => ({
        getOrders: builder.query({
            query: () => ({
                url:"all",
                method: "GET"
            }),
            providesTags: ["Orders"],
        }),
        getOrderById: builder.query({
            query: (id) => ({
                url:`${id}`,
                method: "GET"
            }),
            providesTags: ["Orders"],
        }),
        getOrdersByUsername: builder.query({
            query: (username) => ({
                url:`user/${username}`,
                method: "GET"
            }),
            providesTags: ["Orders"],
        }),
        addNewOrder: builder.mutation({
            query: (order) => ({
                url: "",
                method:"POST",
                body: order,
            }),
            invalidatesTags:["Orders"]
        }),
        updateOrderStatus: builder.mutation({
            query: (id, newOrderStatus) => ({
                url:`status/${id}&${newOrderStatus}`,
                method: "PUT"
            }),
            invalidatesTags:["Orders"],
        }),
        deleteOrder: builder.mutation({
            query: (id) => ({
                url:`${id}`,
                method: "DELETE"
            }),
            invalidatesTags:["Orders"],
        })
    }),
});

export const {useGetOrdersQuery, useGetOrderByIdQuery, useGetOrdersByUsernameQuery, useAddNewOrderMutation, useUpdateOrderStatusMutation, useDeleteOrderMutation} = orderApi;

export default orderApi;