import { configureStore } from "@reduxjs/toolkit";
import brendApi from "../../apis/admin/brendApi";
import watchApi from "../../apis/admin/watchApi";
import userApi from "../../apis/admin/userApi";
import authApi from "../../apis/admin/authApi";
import { watchItemReducer } from "./Slices/watchItemClise";
import commentApi from "../../apis/admin/commentApi";
import { userAuthReducer } from "./Slices/userAuthSlice";
import orderApi from "../../apis/admin/orderApi";
import { userItemReducer } from "./Slices/userItemSlice";
import messageApi from "../../apis/admin/messageApi";
import paymentApi from "../../apis/admin/paymentApi";


const store = configureStore({
    reducer:{
        watchItemsStore : watchItemReducer,
        userAuthStore : userAuthReducer,
        userItemsStore : userItemReducer,
        [brendApi.reducerPath] : brendApi.reducer,
        [paymentApi.reducerPath] : paymentApi.reducer,
        [watchApi.reducerPath] : watchApi.reducer,
        [userApi.reducerPath] : userApi.reducer,
        [authApi.reducerPath] : authApi.reducer,
        [commentApi.reducerPath] : commentApi.reducer,
        [orderApi.reducerPath] : orderApi.reducer,
        [messageApi.reducerPath] : messageApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(brendApi.middleware).concat(paymentApi.middleware).concat(messageApi.middleware).concat(watchApi.middleware).concat(userApi.middleware).concat(authApi.middleware).concat(commentApi.middleware).concat(orderApi.middleware)
});

export default store;