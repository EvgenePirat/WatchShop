import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const brendApi = createApi({
  reducerPath: "brendApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:7103/api/brend/"
  }),
  tagTypes: ["Brends"],
  endpoints: (builder) => ({
    getBrends: builder.query({
      query: () => ({
        url: "all",
        method: "GET",
        
      }),
      providesTags: ["Brends"],
    }),
    getBrendById: builder.query({
      query: (id) => ({
        url: `${id}`,
        method: "GET"
      }),
      providesTags: ["Brends"],
    }),
    addNewBrend: builder.mutation({
      query: (newBrend) => ({
        url: "",
        method: "POST",
        body: newBrend,
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        }
      }),
      invalidatesTags: ["Brends"]
    }),
    updateBrend: builder.mutation({
      query: (brend) => ({
        url: `${brend.id}`,
        method: "PUT",
        body: brend,
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        }
      }),
      invalidatesTags: ["Brends"]
    }),
    deleteBrend: builder.mutation({
      query: (id) => ({
        url: `${id}`,
        method: "DELETE",
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        }
      }),
      invalidatesTags: ["Brends"]
    })
  }),
});

export const { 
  useGetBrendsQuery, 
  useGetBrendByIdQuery, 
  useAddNewBrendMutation, 
  useUpdateBrendMutation, 
  useDeleteBrendMutation 
} = brendApi;

export default brendApi;