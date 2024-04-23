import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const messageApi = createApi({
    reducerPath:"messageApi",
    baseQuery: fetchBaseQuery({
        baseUrl:"https://localhost:7103/api/message/"
    }),
    endpoints: (builder) => ({
        postMessageTelegram: builder.mutation({
            query: (message) => ({
                url: "",
                method:"POST",
                body: message,
            })
        }),
    })
});

export const { usePostMessageTelegramMutation} = messageApi;

export default messageApi;