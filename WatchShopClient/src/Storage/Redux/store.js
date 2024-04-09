import { configureStore } from "@reduxjs/toolkit";
import brendApi from "../../apis/admin/brendApi";


const store = configureStore({
    reducer:{
        [brendApi.reducerPath] : brendApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(brendApi.middleware)
});

export default store;