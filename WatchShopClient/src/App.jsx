
import { Routes, Route } from "react-router-dom"
import WatchShop from "./pages/WatchShop"
import Shop from "./pages/Shop"
import ShopDetails from "./pages/ShopDetails"
import About from "./pages/About"
import Wishlist from "./pages/Wishlist"
import Cart from "./pages/Cart"
import Account from "./pages/Account"
import Checkout from "./pages/Checkout"
import Contact from "./pages/Contact"
import Error from "./pages/Error"
import Admin from "./admin/pages/Admin"
import Home from '../src/admin/pages/Home'
import UserList from '../src/admin/pages/users/UserList'
import BrendList from "./admin/pages/brends/BrendList"
import CreateBrend from "./admin/pages/brends/CreateBrend"
import Brend from "./admin/pages/brends/Brend"
import WatchList from "./admin/pages/watches/WatchList"
import Watch from "./admin/pages/watches/Watch"
import CreateWatch from "./admin/pages/watches/CreateWatch"
import User from "./admin/pages/users/User"
import CreateUser from "./admin/pages/users/CreateUser"
import CommentList from "./admin/pages/comments/CommentList"
import Login from "./pages/Login"
import Register from "./pages/Register"
import { useEffect } from "react"
import { setLoggedInUser } from "./Storage/Redux/Slices/userAuthSlice"
import { jwtDecode } from "jwt-decode";
import OrderList from "./admin/pages/orders/OrderList"
import Order from "./admin/pages/orders/Order"
import { useGetUsersQuery } from '../src/apis/admin/userApi';
import { useDispatch } from 'react-redux';
import { setUserItems } from '../src/Storage/Redux/Slices/userItemSlice';
import Payment from "./pages/Payment"

function App() {

  
  const dispatch = useDispatch();

  const { data, isLoading } = useGetUsersQuery();

  useEffect(() => {
    if (!isLoading && data) {
      dispatch(setUserItems(data.result));
    }
  }, [isLoading, data]);

  useEffect(() => {
    const localToken = localStorage.getItem("token");
    if (localToken) {
      const { exp } = jwtDecode(localToken);
      const expirationTime = exp * 1000; 

      if (Date.now() >= expirationTime) {
        localStorage.removeItem("token");
      } else {
        const { username, id, role } = jwtDecode(localToken);
        dispatch(setLoggedInUser({ id, username, role }));
      }
    }
  }, []);

  return (
      <Routes>
        <Route path="/" element={<WatchShop />} />
        <Route path="/shop/:filter?" element={<Shop />} />
        <Route path="/shopDetails" element={<ShopDetails />} />
        <Route path="/about" element={<About />} />
        <Route path="/wishlist" element={<Wishlist />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/account" element={<Account />} />
        <Route path="/login" element={<Login />} />
        <Route path="/registration" element={<Register />} />
        <Route path="/checkout" element={<Checkout />} />
        <Route path="/payment" element={<Payment />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/admin" element={<Admin />}>
          <Route index element={<Home />} />
          <Route path="comments" element={<CommentList />} />
          <Route path="orders" element={<OrderList />} />
          <Route path="order/:id" element={<Order />} />
          <Route path="users" element={<UserList />} />
          <Route path="user/:id" element={<User />} />
          <Route path="user/create" element={<CreateUser />} />
          <Route path="brends" element={<BrendList />} />
          <Route path="brend/:id" element={<Brend />} />
          <Route path="brend/create" element={<CreateBrend />} />
          <Route path="watches" element={<WatchList />} />
          <Route path="watch/:id" element={<Watch />} />
          <Route path="watch/create" element={<CreateWatch />} />
        </Route>
        <Route path="*" element={<Error />} />
      </Routes>
  )
}

export default App
