import {createSlice } from "@reduxjs/toolkit";

const initialState = {
    userItems: [],
};

export const userItemsSlice = createSlice({
    name: "UserUtems",
    initialState: initialState,
    reducers: {
        setUserItems: (state,action) => {
            state.userItems = action.payload;
        },
    },
})

export const {setUserItems} = userItemsSlice.actions;
export const userItemReducer = userItemsSlice.reducer;