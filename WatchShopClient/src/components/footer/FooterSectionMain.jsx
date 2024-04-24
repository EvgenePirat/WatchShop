import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { useSubscriptionLettersMutation } from '../../apis/admin/userApi';
import { toast } from 'react-toastify';
import { useGetWatchCharacteristicsQuery } from '../../apis/admin/watchApi';

const FooterSectionMain = () => {

    const [email, setEmail] = useState();
    const currentYear = new Date().getFullYear();
    const [styles, setStyles] = useState([]);

    const {data, isLoading} = useGetWatchCharacteristicsQuery();

    useEffect(() => {
        if (!isLoading && data) {
          setStyles(data.result.styles);
        }
      }, [isLoading, data]);    


    const [subscribeLetterMutation] = useSubscriptionLettersMutation()

    const handleOnClick = async () =>{
        var result = await subscribeLetterMutation({email: email, isActive: true});
        
        console.log(result)

        if(result.error){
            toast.error('Email not found');
        }
        else{
            toast.success('You have subscribed to the news');
            setEmail("")
        }
    }

  return (
    <footer className="fz-2-footer-section">
        <div className="fz-footer-top">
            <div className="container">
                <div className="row gy-5 justify-content-center justify-content-xl-between">
                    <div className="col-xl-3 col-lg-6 col-md-8">
                        <div className="fz-footer-about">
                            <div className="fz-logo">
                                <img src="assets/images/watch_shop_logo.jpg" alt="logo" className='footer_logo_img' />
                            </div>

                            <div className="fz-footer-socials">
                                <div className="fz-footer-socials-title">Follow Us</div>
                                <ul className="d-flex">
                                    <li><Link to="#"><i className="fa-brands fa-facebook-f"></i></Link></li>
                                    <li><Link to="#"><i className="fa-brands fa-twitter"></i></Link></li>
                                    <li><Link to="#"><i className="fa-brands fa-instagram"></i></Link></li>
                                    <li><Link to="#"><i className="fa-brands fa-youtube"></i></Link></li>
                                    <li><Link to="#"><i className="fa-brands fa-tiktok"></i></Link></li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div className="col-lg-3 col-md-4 col-6 col-xxs-12">
                        <div className="fz-footer-widget">
                            <h5 className="fz-footer-widget__title">Styles</h5>
                            <ul>
                                {styles.map((style, index) => {
                                    return <li key={index}><Link to={{ pathname: '/shop', search: `?filter=${style.name}` }} >{style.name}</Link></li>
                                })}
                            </ul>
                        </div>
                    </div>

                    <div className="col-lg-3 col-md-4 col-6 col-xxs-12">
                        <div className="fz-footer-widget">
                            <h5 className="fz-footer-widget__title">Quick Link</h5>
                            <ul>
                                <li><Link to="/shop">Our Products</Link></li>
                                <li><Link to="/about">About</Link></li>
                                <li><Link to="/contact">Contact</Link></li>
                                <li><Link to="/account">Account</Link></li>
                            </ul>
                        </div>
                    </div>

                    <div className="col-xl-3 col-lg-5 col-md-8">
                        <div className="fz-footer-widget">
                            <h5 className="fz-footer-widget__title">News Letter</h5>
                            <div className="fz-footer-subscribe">
                                <p className="fz-footer-subscribe-txt">Sign up to get the latest on sales, new releases, store events and more.</p>

                                <div className="fz-footer-subscribe-form">
                                    <div className="fz-footer-subscribe-form-input">
                                        <input type="email" name="footer-subs-email" id="fz-footer-subs-email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
                                        <span className="fz-footer-subs-icon"><i className="fa-light fa-envelope-open"></i></span>
                                    </div>
                                    <button className="fz-footer-subs-btn" onClick={handleOnClick}>subscribe <i className="fa-light fa-paper-plane"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div className="fz-footer-bottom">
            <div className="container">
                <div className="row gy-4 align-items-center">
                    <div className="col-lg-6">
                        <p className="fz-copyright">&copy;
                            {currentYear} Design & Developed by <b>CodeBasket</b>
                        </p>
                    </div>

                    <div className="col-lg-6 text-lg-end text-center">
                        <img src="assets/images/card.png" alt="Pyament Methods" className="fz-payment-methods"/>
                    </div>
                </div>
            </div>
        </div>
    </footer>
  )
}

export default FooterSectionMain