import { configureStore } from "@reduxjs/toolkit";
import brendApi from "../../apis/admin/brendApi";
import watchApi from "../../apis/admin/watchApi";
import userApi from "../../apis/admin/userApi";
import authApi from "../../apis/admin/authApi";


const store = configureStore({
    reducer:{
        [brendApi.reducerPath] : brendApi.reducer,
        [watchApi.reducerPath] : watchApi.reducer,
        [userApi.reducerPath] : userApi.reducer,
        [authApi.reducerPath] : authApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(brendApi.middleware).concat(watchApi.middleware).concat(userApi.middleware).concat(authApi.middleware)
});

export default store;