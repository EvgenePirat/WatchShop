import { configureStore } from "@reduxjs/toolkit";
import brendApi from "../../apis/admin/brendApi";
import watchApi from "../../apis/admin/watchApi";
import userApi from "../../apis/admin/userApi";
import authApi from "../../apis/admin/authApi";
import { watchItemReducer } from "./Slices/watchItemClise";
import commentApi from "../../apis/admin/commentApi";
import { userAuthReducer } from "./Slices/userAuthSlice";


const store = configureStore({
    reducer:{
        watchItemsStore : watchItemReducer,
        userAuthStore : userAuthReducer,
        [brendApi.reducerPath] : brendApi.reducer,
        [watchApi.reducerPath] : watchApi.reducer,
        [userApi.reducerPath] : userApi.reducer,
        [authApi.reducerPath] : authApi.reducer,
        [commentApi.reducerPath] : commentApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(brendApi.middleware).concat(watchApi.middleware).concat(userApi.middleware).concat(authApi.middleware).concat(commentApi.middleware)
});

export default store;