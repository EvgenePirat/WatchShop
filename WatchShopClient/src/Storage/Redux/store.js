import { configureStore } from "@reduxjs/toolkit";
import brendApi from "../../apis/admin/brendApi";
import watchApi from "../../apis/admin/watchApi";


const store = configureStore({
    reducer:{
        [brendApi.reducerPath] : brendApi.reducer,
        [watchApi.reducerPath] : watchApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(brendApi.middleware).concat(watchApi.middleware)
});

export default store;