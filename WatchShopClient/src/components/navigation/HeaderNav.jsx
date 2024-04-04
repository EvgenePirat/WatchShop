import React from 'react'
import { Link } from 'react-router-dom'

const HeaderNav = ({position}) => {
  return (
    <nav className="fz-header-nav">
        <ul className={`align-items-center ${position}`}>
            <li className="fz-dropdown fz-nav-item">
                <a role="button" className="fz-nav-link"><span>home</span> <i className="fa-regular fa-plus"></i></a>

                <ul className="fz-submenu">
                    <li><Link to="/" className="fz-nav-link fz-submenu-nav-link">Door Shop</Link></li>
                    <li><Link to="/jewelleryShop" className="fz-nav-link fz-submenu-nav-link">Jewellery Shop</Link></li>
                    <li><Link to="/cakeShop" className="fz-nav-link fz-submenu-nav-link">Cake Shop</Link></li>
                </ul>
            </li>
            <li className="fz-dropdown fz-nav-item">
                <a role="button" className="fz-nav-link"><span>shop</span> <i className="fa-regular fa-plus"></i></a>

                <ul className="fz-submenu">
                    <li><Link to="/shop" className="fz-nav-link fz-submenu-nav-link">Shop</Link></li>
                    <li><Link to="/shopDetails" className="fz-nav-link fz-submenu-nav-link">Shop details</Link></li>
                </ul>
            </li>
            <li className="fz-dropdown fz-nav-item">
                <a role="button" className="fz-nav-link"><span>pages</span> <i className="fa-regular fa-plus"></i></a>

                <ul className="fz-submenu">
                    <li><Link to="/about" className="fz-nav-link fz-submenu-nav-link">About</Link></li>
                    <li><Link to="/faq" className="fz-nav-link fz-submenu-nav-link">FAQ</Link></li>
                    <li><Link to="/wishlist" className="fz-nav-link fz-submenu-nav-link">Wishlist</Link></li>
                    <li><Link to="/cart" className="fz-nav-link fz-submenu-nav-link">Cart</Link></li>
                    <li><Link to="/account" className="fz-nav-link fz-submenu-nav-link">Account</Link></li>
                    <li><Link to="/checkout" className="fz-nav-link fz-submenu-nav-link">Checkout</Link></li>
                </ul>
            </li>
            <li className="fz-dropdown fz-nav-item">
                <a role="button" className="fz-nav-link">blog <i className="fa-regular fa-plus"></i></a>

                <ul className="fz-submenu">
                    <li><Link to="/blog" className="fz-nav-link fz-submenu-nav-link">Blog</Link></li>
                    <li><Link to="/blogDetails" className="fz-nav-link fz-submenu-nav-link">Blog-details</Link></li>
                </ul>
            </li>
            <li className="fz-nav-item"><Link to="/contact" className="fz-nav-link">Contact</Link></li>
            <li className="fz-nav-item"><Link to="/admin/" className="fz-nav-link">Admin</Link></li>
        </ul>
    </nav>
  )
}

export default HeaderNav