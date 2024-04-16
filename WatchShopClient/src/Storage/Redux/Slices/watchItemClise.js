import {createSlice } from "@reduxjs/toolkit";

const initialState = {
    watchItems: [],
};

export const watchItemsSlice = createSlice({
    name: "WatchItems",
    initialState: initialState,
    reducers: {
        setWatchItems: (state,action) => {
            state.watchItems = action.payload;
        },
    },
})

export const {setWatchItems} = watchItemsSlice.actions;
export const watchItemReducer = watchItemsSlice.reducer;