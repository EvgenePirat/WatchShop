import React from 'react'
import { Link } from 'react-router-dom'

const StoreSection = () => {
  return (
    <div className="fz-about-store-area">
        <div className="container">
            <div className="fz-about-single-store">
                <div className="row gy-3 gy-sm-4 align-items-center">
                    <div className="col-xl-6 col-lg-6">
                        <div className="fz-about-store-img">
                            <img src="assets/images/about_img_2.jpg" alt="House Door Image"/>
                        </div>
                    </div>

                    <div className="col-xl-6 col-lg-6">
                        <div className="fz-about-store-content">
                            <h4 className="fz-about-store-title">About</h4>
                            <p>WatchShop was created with the goal of offering the best brands of Watches at suitable prices for all budgets so you can find the watch or jewel you are looking for.
                                You will find the best known brands of watches and the latest trends at unbeatable prices.
                                We are official sellers of all the brands we have on our catalogue. All our products are 100% originals, authentic and new. We prepare each order taking care of the product and we ship all products in the original brand box, with brand certificate and international warranty of minimum for 2 years.
                                At WatchShop we are always doing special discounts and offers that you'll find on our website. We are continuously launching promotions, giveaways and campaigns for special events.
                                This way you will find the perfect thing for every moment such as Christmas, Black Friday, father's & mother's day, Back to school, Cyber Monday...
                                Throughout the year you can visit our Promotions & Offers page and be surprised by the best selection of products at incredible prices
                            </p>
                            <Link to="/shop" className="fz-1-banner-btn fz-about-store-btn">Visit Shop</Link>
                        </div>
                    </div>
                </div>
            </div>

            <div className="fz-about-single-store">
                <div className="row gy-3 gy-sm-4 align-items-center">
                    <div className="col-xl-6 col-lg-6 order-1 order-lg-0">
                        <div className="fz-about-store-content">
                            <h4 className="fz-about-store-title">Advantage</h4>

                            <div className="fz-about-right-list">
                                <ul>
                                    <li>We are official sellers of all brands we have on our catalogue and for this reason, we ship all products in the official packaging of the brand, completely new and with the official international warranty of the brand minimum of 2 years</li>
                                    <li>If you are not satisfied with the product when you receive the order, you have up to 30 days to return it or exchange it without any problem</li>
                                    <li>At WatchShop we know about the importance of being close to you. For this reason, our specialized team will help you at every moment solving doubts and concerns or simply helping you choosing a watch. You can contact us email (contact@clicktime.eu) or phone (Monday to Friday 9:00-18:00h)</li>
                                </ul>
                            </div>

                            <Link to="/shop" className="fz-1-banner-btn fz-about-store-btn">Visit Shop</Link>
                        </div>
                    </div>

                    <div className="col-xl-6 col-lg-6 order-0 order-lg-1">
                        <div className="fz-about-store-img">
                            <img src="assets/images/about_img_3.jpg" alt="House Door Image"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  )
}

export default StoreSection