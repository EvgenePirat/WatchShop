import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { useSelector } from 'react-redux';
import { useGetWatchCharacteristicsQuery } from '../../apis/admin/watchApi';

const HeaderNav = ({position}) => {

  const userAuth = useSelector(state => state.userAuthStore);
  const {data, isLoading} = useGetWatchCharacteristicsQuery();

  const [styles, setStyles] = useState([]);

  useEffect(() => {
    if (!isLoading && data) {
      setStyles(data.result.styles);
    }
  }, [isLoading, data]);

  return (
    <nav className="fz-header-nav">
        <ul className={`align-items-center ${position}`}>
            <li className="fz-nav-item"><Link to="/" className="fz-nav-link">Home</Link></li>
            <li className="fz-dropdown fz-nav-item">
                <a role="button" className="fz-nav-link"><span>Style</span> <i className="fa-regular fa-plus"></i></a>

                <ul className="fz-submenu">
                   {styles.map((style, index) => {
                      return <li key={index}><Link  to={{ pathname: '/shop', search: `?filter=${style.name}` }} className="fz-nav-link fz-submenu-nav-link">{style.name}</Link></li>
                   })}
                </ul>
            </li>
            <li className="fz-nav-item"><Link to="/shop" className="fz-nav-link">Shop</Link></li>
            <li className="fz-nav-item"><Link to="/about" className="fz-nav-link">About</Link></li>
            <li className="fz-nav-item"><Link to="/contact" className="fz-nav-link">Contact</Link></li>

            {userAuth.role == 'Admin' && (
              <li className="fz-nav-item"><Link to="/admin/" className="fz-nav-link">Admin</Link></li>
            )}
        </ul>
    </nav>
  )
}

export default HeaderNav