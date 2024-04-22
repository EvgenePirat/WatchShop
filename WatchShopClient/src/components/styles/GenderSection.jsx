import React from 'react'
import { Link } from 'react-router-dom'

const GenderSection = () => {

  return (
    <section className="fz-2-category-section">
            <div className="container">
                <div className="fz-2-section-heading">
                    <div className="row gy-4 justify-content-between align-items-center">
                        <div className="col-lg-5 col-md-6">
                            <h2 className="fz-section-title">Shop by <br/> <span>Genders</span></h2>
                        </div>
                    </div>
                </div>

                <div className="row gy-4 g-2 g-sm-4 justify-content-center">
                    <div className="col-4">
                        <div className="fz-single-category">
                            <div className="fz-single-category__img">
                                <img src="assets/images/men_watch.jpeg" alt="category image"/>
                                <div className="fz-overlay"></div>
                                <Link to={{ pathname: '/shop', search: '?filter=Men' }} className="fz-def-btn">
                                    <span></span>
                                    Shop Now
                                    <i className="fa-light fa-arrow-up-right"></i>
                                </Link>
                            </div>

                            <div className="fz-single-category__txt">
                                <h5><Link to={{ pathname: '/shop', search: '?filter=Men' }}>Men <span className="fz-category-amount">(24)</span></Link></h5>
                            </div>
                        </div>
                    </div>

                    <div className="col-4">
                        <div className="fz-single-category second-category d-flex flex-column-reverse justify-content-between">
                            <div className="fz-single-category__img">
                                <img src="assets/images/women_watch.jpg" alt="category image"/>
                                <div className="fz-overlay"></div>
                                <Link to={{ pathname: '/shop', search: '?filter=Women' }} className="fz-def-btn">
                                    <span></span>
                                    Shop Now
                                    <i className="fa-light fa-arrow-up-right"></i>
                                </Link>
                            </div>

                            <div className="fz-single-category__txt">
                                <h5><Link to={{ pathname: '/shop', search: '?filter=Women' }}>Women <span className="fz-category-amount">(20)</span></Link></h5>
                            </div>
                        </div>
                    </div>

                    <div className="col-4">
                        <div className="fz-single-category">
                            <div className="fz-single-category__img">
                                <img src="assets/images/unisex_watch.webp" alt="category image"/>
                                <div className="fz-overlay"></div>
                                <Link to={{ pathname: '/shop', search: '?filter=Unisex' }} className="fz-def-btn">
                                    <span></span>
                                    Shop Now
                                    <i className="fa-light fa-arrow-up-right"></i>
                                </Link>
                            </div>

                            <div className="fz-single-category__txt">
                                <h5>
                                    <Link to={{ pathname: '/shop', search: '?filter=Unisex' }}>Unisex <span className="fz-category-amount">(30)</span></Link>
                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
  )
}

export default GenderSection