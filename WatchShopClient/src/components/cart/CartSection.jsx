import React, { useContext } from 'react'
import CartItemTable from './CartItemTable'
import { WatchContext } from '../../context/WatchContext'
import { Link } from 'react-router-dom'

const CartSection = () => {
    const {
        subTotal, 
        finalPrice, 
        cartItems,
        handleQuantityChange,
        handleRemoveItem,
    } = useContext(WatchContext)
  return (
    <div className="container">
        <div className="cart-section">
            <div className="cart-left inner-cart">
                <div className="cart-area">
                    <div className="cart__body">
                        <div className="table-responsive">
                            <CartItemTable cartArray={cartItems} remove={handleRemoveItem} quantity={handleQuantityChange}/>
                        </div>
                    </div>
                </div>
            </div>

            <div className="cart-checkout-area">
                <h4 className="cart-checkout-area__title">Billing Summary</h4>

                <ul className="checkout-summary">
                    <li>
                        <span className="checkout-summary__key">Subtotal</span>
                        <span className="checkout-summary__value"><span>$</span>{subTotal}</span>
                    </li>

                    <li className="cart-checkout-total">
                        <span className="checkout-summary__key">Total</span>
                        <span className="checkout-summary__value"><span>$</span>{finalPrice}</span>
                    </li>
                </ul>


                <Link to="/checkout" className="fz-1-banner-btn cart-checkout-btn">Proceed to checkout</Link>
            </div>
        </div>
    </div>
  )
}

export default CartSection