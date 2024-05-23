import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const orderApi = createApi({
    reducerPath:"orderApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/order/",
        prepareHeaders: (headers, api) => {
            const token = localStorage.getItem("token");
            token && headers.append("Authorization", "Bearer " + token);
        }
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
            query: (updateStatus) => ({
                url:`status/${updateStatus.id}&${updateStatus.status}`,
                method: "PUT"
            }),
            invalidatesTags:["Orders"]
        }),
        updateShipment: builder.mutation({
            query: (updateShipment) => ({
                url:`shipment/${updateShipment.id}`,
                method: "PUT",
                body: updateShipment
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

export const {useGetOrdersQuery, useGetOrderByIdQuery, useGetOrdersByUsernameQuery, useAddNewOrderMutation, useUpdateOrderStatusMutation,useUpdateShipmentMutation, useDeleteOrderMutation} = orderApi;

export default orderApi;