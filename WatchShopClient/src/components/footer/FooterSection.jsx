import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { useGetWatchCharacteristicsQuery } from '../../apis/admin/watchApi';

const FooterSection = () => {

    const currentYear = new Date().getFullYear();

    const [styles, setStyles] = useState([]);

    const {data, isLoading} = useGetWatchCharacteristicsQuery();

    useEffect(() => {
        if (!isLoading && data) {
          setStyles(data.result.styles);
        }
      }, [isLoading, data]);    



  return (
    <footer className="fz-footer-section fz-1-footer-section">
        <div className="fz-footer-top">
            <div className="container">
                <div className="row gy-md-5 gy-4 justify-content-center justify-content-lg-between">
                    <div className="col-xxl-4 col-lg-12 col-md-8">
                        <div className="fz-footer-about fz-footer-widget">
                            <div className="fz-logo fz-footer-widget__title">
                                <Link to="/"><img src="assets/images/watch_shop_logo.jpg" alt="logo" className='footer_logo_img' /></Link>
                            </div>
                        </div>
                    </div>

                    <div className="col-xxl-2 col-lg-3 col-md-4 col-6 col-xxs-12">
                        <div className="fz-footer-widget">
                            <h5 className="fz-footer-widget__title">Styles</h5>
                            <ul>
                                {styles.map((style, index) => {
                                    return <li key={index}><Link to={{ pathname: '/shop', search: `?filter=${style.name}` }} >{style.name}</Link></li>
                                })}
                            </ul>
                        </div>
                    </div>

                    <div className="col-xxl-2 col-lg-3 col-md-4 col-6 col-xxs-12">
                        <div className="fz-footer-widget">
                            <h5 className="fz-footer-widget__title">Quick Links</h5>
                            <ul>
                                <li><Link to="/shop">Our Products</Link></li>
                                <li><Link to="/about">About</Link></li>
                                <li><Link to="/contact">Contact</Link></li>
                                <li><Link to="/account">Account</Link></li>
                            </ul>
                        </div>
                    </div>

                    <div className="col-xxl-2 col-lg-3 col-md-4 col-6 col-xxs-12">
                        <div className="fz-footer__contact-info">
                            <h5 className="fz-footer-widget__title">Store Address</h5>
                            <ul>
                                <li>
                                    <Link to="tel:9072254144"><i className="fa-light fa-phone"></i> (907) 225-4144</Link>
                                </li>
                                <li>
                                    <Link to="mailto:info@webmail.com"><i className="fa-light fa-envelope-open-text"></i>eugene.brexyn@gmail.com</Link>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div className="fz-footer-bottom">
            <div className="container">
                <div className="row gy-4 align-items-center">
                    <div className="col-md-6 col-12">
                        <p className="fz-copyright">
                            &copy;
                            {currentYear} Design & Developed by <b>CodeBasket</b>
                        </p>
                    </div>

                    <div className="col-md-6 col-12">
                        <div className="fz-footer-socials">
                            <ul>
                                <li><Link to="#"><i className="fa-brands fa-facebook-f"></i></Link></li>
                                <li><Link to="#"><i className="fa-brands fa-twitter"></i></Link></li>
                                <li><Link to="#"><i className="fa-brands fa-instagram"></i></Link></li>
                                <li><Link to="#"><i className="fa-brands fa-youtube"></i></Link></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>
  )
}

export default FooterSection