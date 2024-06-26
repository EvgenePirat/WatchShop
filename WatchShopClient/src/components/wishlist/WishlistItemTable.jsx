import { useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import { Link } from 'react-router-dom'
import defaultCartImage from '../../../public/assets/images/card-img-1.png'

const WishlistItemTable = ({wishlistArray,removeItem}) => {
    const {addToCartFromWishlist} = useContext(WatchContext)
  return (
    <div className='wishlist-table'>
       <table >
        <tbody>
            <tr>
                <th>Product</th>
                <th>price</th>
                <th>action</th>
                <th>remove</th>
            </tr>
            {wishlistArray.length === 0 ? (
                    <tr className='no-item-msg'>
                        <td className='no-item-msg-text'>No items in the wishlist.</td>
                    </tr>
                ) : (
                    wishlistArray.map((item) => (
                        <tr key={item.id}>
                            <td>
                                <div className="cart-product">
                                    <div className="cart-product__img">
                                        <img src={item.images.length > 0 ? item.images[0].path : defaultCartImage}  alt="Product Image"/>
                                    </div>
                                </div>
                            </td>
                            <td>${item.isDiscounted ? item.discountPrice : item.price}</td>
                            <td>
                                <div className="fz-wishlist-action">
                                    <button 
                                    className="fz-add-to-cart-btn fz-1-banner-btn fz-wishlist-action-btn"
                                    onClick={() => addToCartFromWishlist(item)}
                                    >Add to cart</button>
                                </div>
                            </td>
                            <td>
                                <button
                                    className="item-remove-btn"
                                    onClick={() => removeItem(item.id)}
                                >
                                    <i className="fa-light fa-xmark"></i>
                                </button>

                            </td>
                        </tr>
                    ))
                )}

        </tbody>
    </table> 
    </div>
    
  )
}

export default WishlistItemTable