import {createSlice } from "@reduxjs/toolkit";

const initialState = {
    brendItems: [],
};

export const brendItemsSlice = createSlice({
    name: "BrendItems",
    initialState: initialState,
    reducers: {
        setBrendItems: (state,action) => {
            state.brendItems = action.payload;
        },
    },
})

export const {setBrendItems} = brendItemsSlice.actions;
export const brendItemReducer = brendItemsSlice.reducer;