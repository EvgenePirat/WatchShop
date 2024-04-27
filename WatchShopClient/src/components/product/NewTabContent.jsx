import React, { useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import { Link, useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux'

const NewTabContent = () => {

    const watchItems = useSelector((state) => state.watchItemsStore.watchItems);

    const navigate = useNavigate();

    const handleClick = (item) => {
        navigate('/shopDetails', { state: { item } });
    }

    const {
        addToWishlist,
        addToCart,
    } = useContext(WatchContext)
  return (
    <div className="row gy-4 gx-3 justify-content-center">
        {watchItems.filter((item) => item.state === "NEW").slice(0, 8).map((item) => (
            <div className="col-xl-3 col-md-4 col-6 col-xxs-12" key={item.id}>
                <div className="fz-2-single-product">
                    <div className="fz-2-single-product-img">
                        <img src={item.images.length > 0 && item.images[0].path} alt={item.nameModel} className='img-cart-most-popular-watch' />

                        <div className="fz-2-single-product-actions">
                            <button 
                            className="fz-add-to-cart-btn"
                            onClick={() => addToCart(item.id)}
                            >Add to cart</button>
                            <button 
                            className="fz-add-to-wishlist"
                            onClick={() => {
                                addToWishlist(item.id)
                                }}
                            >{item.isInWishlist? (<i className="fa-solid fa-heart"></i>):(<i className="fa-regular fa-heart"></i>)}</button>
                        </div>
                    </div>
                    <div className="fz-2-single-product-txt">
                        <span className="fz-2-single-product-category"><Link to={{ pathname: '/shop', search: `?filter=${item.brend.name}` }}>{item.brend.name}</Link></span>
                        <h5 className="fz-2-single-product-title"><p onClick={() => handleClick(item)}>{item.nameModel}</p></h5>
                        <span className="fz-2-single-product-price">${item.price}</span>
                    </div>
                </div>
            </div> 
        ))}
       
    </div>
    )
}

export default NewTabContent