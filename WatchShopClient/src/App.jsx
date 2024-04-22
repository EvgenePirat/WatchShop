
import { Routes, Route } from "react-router-dom"
import WatchShop from "./pages/WatchShop"
import Shop from "./pages/Shop"
import ShopDetails from "./pages/ShopDetails"
import About from "./pages/About"
import Faq from "./pages/Faq"
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
import { useDispatch } from "react-redux"
import { useEffect } from "react"
import { setLoggedInUser } from "./Storage/Redux/Slices/userAuthSlice"
import { jwtDecode } from "jwt-decode";

function App() {

  const dispatch = useDispatch();

  useEffect(() => {
    const localToken = localStorage.getItem("token");
    if (localToken) {
      const { username, id, email, role } = jwtDecode(localToken);
      dispatch(setLoggedInUser({ id, username, email, role }));
    }
  }, [])

  return (
      <Routes>
        <Route path="/" element={<WatchShop />} />
        <Route path="/shop/:filter?" element={<Shop />} />
        <Route path="/shopDetails" element={<ShopDetails />} />
        <Route path="/about" element={<About />} />
        <Route path="/faq" element={<Faq />} />
        <Route path="/wishlist" element={<Wishlist />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/account" element={<Account />} />
        <Route path="/login" element={<Login />} />
        <Route path="/registration" element={<Register />} />
        <Route path="/checkout" element={<Checkout />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/admin" element={<Admin />}>
          <Route index element={<Home />} />
          <Route path="comments" element={<CommentList />} />
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
