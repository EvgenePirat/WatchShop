
import { BrowserRouter as Router,Routes,Route} from "react-router-dom"
import DoorShop from "./pages/DoorShop"
import JewelleryShop from "./pages/JewelleryShop"
import CakeShop from "./pages/CakeShop"
import Shop from "./pages/Shop"
import ShopDetails from "./pages/ShopDetails"
import About from "./pages/About"
import Faq from "./pages/Faq"
import Wishlist from "./pages/Wishlist"
import Cart from "./pages/Cart"
import Account from "./pages/Account"
import Checkout from "./pages/Checkout"
import Blog from "./pages/Blog"
import BlogDetails from "./pages/BlogDetails"
import Contact from "./pages/Contact"
import Error from "./pages/Error"
import Admin from "./admin/pages/Admin"
import Home from '../src/admin/pages/Home'
import UserList from '../src/admin/pages/users/UserList'
import UserEdit from "./admin/pages/users/UserEdit"
import BrendList from "./admin/pages/brends/BrendList"
import CreateBrend from "./admin/pages/brends/CreateBrend"
import Brend from "./admin/pages/brends/Brend"
import WatchList from "./admin/pages/watches/WatchList"
import Watch from "./admin/pages/watches/Watch"
import CreateWatch from "./admin/pages/watches/CreateWatch"

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/doorShop" element={<DoorShop/>}/>
        <Route path="/" element={<JewelleryShop/>}/>
        <Route path="/cakeShop" element={<CakeShop/>}/>
        <Route path="/shop" element={<Shop/>}/>
        <Route path="/shopDetails" element={<ShopDetails/>}/>
        <Route path="/about" element={<About/>}/>
        <Route path="/faq" element={<Faq/>}/>
        <Route path="/wishlist" element={<Wishlist/>}/>
        <Route path="/cart" element={<Cart/>}/>
        <Route path="/account" element={<Account/>}/>
        <Route path="/checkout" element={<Checkout/>}/>
        <Route path="/blog" element={<Blog/>}/>
        <Route path="/blogDetails" element={<BlogDetails/>}/>
        <Route path="/contact" element={<Contact/>}/>
        <Route path="/admin" element={<Admin />}>
            <Route index element={<Home />} />
            <Route path="users" element={<UserList />} />
            <Route path="user/:id" element={<UserEdit />} />
            <Route path="brends" element={<BrendList />} />
            <Route path="brend/:id" element={<Brend />} />
            <Route path="brend/create" element={<CreateBrend />} />
            <Route path="watches" element={<WatchList />} />
            <Route path="watch/:id" element={<Watch />} />
            <Route path="watch/create" element={<CreateWatch />} />
        </Route>
        <Route path="*" element={<Error/>}/>
      </Routes>
    </Router>
  )
}

export default App
