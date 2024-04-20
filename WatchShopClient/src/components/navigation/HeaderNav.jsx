import React from 'react'
import { Link } from 'react-router-dom'
import { useSelector } from 'react-redux';

const HeaderNav = ({position}) => {
  const userAuth = useSelector(state => state.userAuthStore);

  return (
    <nav className="fz-header-nav">
        <ul className={`align-items-center ${position}`}>
            <li className="fz-nav-item"><Link to="/" className="fz-nav-link">Home</Link></li>
            <li className="fz-nav-item"><Link to="/shop" className="fz-nav-link">Shop</Link></li>
            <li className="fz-nav-item"><Link to="/about" className="fz-nav-link">About</Link></li>
            <li className="fz-nav-item"><Link to="/contact" className="fz-nav-link">Contact</Link></li>

            {userAuth.role == 'Admin' && (
              <div className="col-md-4 col-6 col-xxs-12">
                  <div className="top-header-right-actions">
                     <li className="fz-nav-item"><Link to="/admin/" className="fz-nav-link">Admin</Link></li>
                  </div>
              </div>
            )}
        </ul>
    </nav>
  )
}

export default HeaderNav