import React, { useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import { Link, useNavigate } from 'react-router-dom'
import CountdownSection from '../timer/CountdownSection'

const HotDealSection = () => {

    const navigate = useNavigate();
    const {addToWishlist,addToCart,jeweleryArray} = useContext(WatchContext)

    const handleClick = (item) => {
        navigate('/shopDetails', { state: { item } });
    }

  return (
    <section className="fz-2-hot-deal-section">
        <div className="container">
            <div className="fz-2-section-heading">
                <div className="row gy-4 align-items-center">
                    <div className="col-md-6">
                        <h2 className="fz-section-title">Hot Deals For Watches</h2>
                    </div>
                    <div className="col-md-6">
                        <CountdownSection/>
                    </div>
                </div>
            </div>

            <div className="fz-hot-deal-products">
                <div className="row gy-md-4 gy-1 gx-3 justify-content-center">
                    {jeweleryArray.filter((item) => item.isDiscounted == true).sort(() => Math.random() - 0.5).slice(0,4).map((item) => (
                        <div className="col-xl-3 col-md-4 col-6 col-xxs-12" key={item.id}>
                            <div className="fz-2-single-product">
                                <div className="fz-2-single-product-img">
                                    <img src={item.images.length > 0 && item.images[0].path} alt="Product Image"  className='img-cart-most-popular-watch'/>

                                    <div className="fz-2-single-product-actions">
                                        <button 
                                        className="fz-add-to-cart-btn"
                                        onClick={() => addToCart(item.id)}
                                        >Add to cart</button>
                                        <button 
                                        className="fz-add-to-wishlist"
                                        onClick={() => addToWishlist(item.id)}
                                        >{item.isInWishlist? (<i className="fa-solid fa-heart"></i>):(<i className="fa-regular fa-heart"></i>)}</button>
                                    </div>
                                </div>
                                <div className="fz-2-single-product-txt">
                                    <span className="fz-2-single-product-category"><Link to={{ pathname: '/shop', search: `?filter=${item.brend.name}` }}>{item.brend.name}</Link></span>
                                    <h5 className="fz-2-single-product-title"><p onClick={() => handleClick(item)}>{item.nameModel}</p></h5>
                                    <span className="fz-2-single-product-price">${item.discountPrice}<span className="prev-price">${item.price}</span></span>
                                </div>
                            </div>
                        </div>  
                    ))}
                    
                </div>
            </div>
        </div>
    </section>
  )
}

export default HotDealSection