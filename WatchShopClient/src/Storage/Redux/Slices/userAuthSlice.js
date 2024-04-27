import {createSlice } from "@reduxjs/toolkit";

const initialState = {
    id: "",
    username: "",
    role: ""
};

export const userAuthSlice = createSlice({
    name: "userAuth",
    initialState: initialState,
    reducers: {
        setLoggedInUser: (state,action) => {
            state.id = action.payload.id;
            state.username = action.payload.username;
            state.role = action.payload.role;
        },
    },
})

export const {setLoggedInUser} = userAuthSlice.actions;
export const userAuthReducer = userAuthSlice.reducer;