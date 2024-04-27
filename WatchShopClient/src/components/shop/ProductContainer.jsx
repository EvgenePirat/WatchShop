import React, { useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import cartImage from '../../../public/assets/images/card-img-1.png'
import { useNavigate } from 'react-router-dom';

const ProductContainer = () => {

    const navigate = useNavigate();

    const {
        isListView,
        paginatedProducts,
        addToCart,
        addToWishlist,
    } = useContext(WatchContext)

    const handleClick = (item) => {
        navigate('/shopDetails', { state: { item } });
    }
    
  return (
    <div className={`fz-inner-products-container ${isListView? 'list-view-on':''}`}>
        <div className="row justify-content-center">
            {paginatedProducts.length === 0 ? (
                <div className='no-product-area'>
                    <h3 className='no-product-text'>No Products Available</h3>
                    <p className='no-product-desc'>We're sorry. We cannot find any matches for your search term.</p>
                </div>
            ):(
              paginatedProducts.map((item) => (
             <div className="col-xl-4 col-md-4 col-6 col-xxs-12" key={item.id}>
                <div className="fz-1-single-product">
                    <div className="fz-single-product__img">
                        <img src={item.images.length > 0 ? item.images[0].path : cartImage} alt={item.nameModel}/>
                        <div className="fz-single-product__actions">
                            <button 
                            className="fz-add-to-wishlist-btn"
                            onClick={() => addToWishlist(item.id)}
                            >
                                <span className="btn-txt">add To wishlist</span>
                                <span className="btn-icon">{item.isInWishlist? (<i className="fa-solid fa-heart"></i>):(<i className="fa-light fa-heart"></i>)}</span>
                            </button>

                            <button 
                            className="fz-add-to-cart-btn"
                            onClick={() => addToCart(item.id)}
                            >
                                <span className="btn-txt">add To cart</span>
                                <span className="btn-icon"><i className="fa-light fa-cart-shopping"></i></span>
                            </button>
                        </div>
                    </div>

                    <div className="fz-single-product__txt">
                        <span className="fz-single-product__category list-view-text">{item.brend.name}</span>
                        <p onClick={() => handleClick(item)}  className="fz-single-product__title">{item.brend.name} {item.nameModel}</p>
                        <div className="fz-single-product__price-rating">
                            <p className="fz-single-product__price">
                            <span className="fz-2-single-product-price">
                                {item.isDiscounted ? (
                                    <>
                                        <span className="current-price">${item.discountPrice}</span>
                                        <span className="prev-price">${item.price}</span>
                                    </>
                                ) : (
                                    <span className="current-price">${item.price}</span>
                                )}
                            </span>
                            </p>

                            <div className="rating list-view-text">
                                <i className="fa-solid fa-star"></i>
                                <i className="fa-solid fa-star"></i>
                                <i className="fa-solid fa-star"></i>
                                <i className="fa-solid fa-star"></i>
                                <i className="fa-light fa-star"></i>
                            </div>
                        </div>

                        <p className="fz-single-product__desc list-view-text">
                            {item.description}
                        </p>

                        <div className="fz-single-product__actions list-view-text">
                            <button 
                            className="fz-add-to-wishlist-btn"
                            onClick={() => addToWishlist(item.id)}
                            >                                
                                <span className="btn-txt">add To wishlist</span>
                                <span className="btn-icon">{item.isInWishlist? (<i className="fa-solid fa-heart"></i>):(<i className="fa-light fa-heart"></i>)}</span>
                            </button>

                            <button 
                            className="fz-add-to-cart-btn"
                            onClick={() => addToCart(item.id)}
                            >
                                <span className="btn-txt">add To cart</span>
                                <span className="btn-icon"><i className="fa-light fa-cart-shopping"></i></span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>   
            ))  
            )}
            
        </div>
    </div>
  )
}

export default ProductContainer