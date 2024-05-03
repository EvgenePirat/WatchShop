import React from 'react'
import './topbar.css'
import HomeIcon from '@mui/icons-material/Home';
import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux';

function Topbar() {

    const userAuth = useSelector(state => state.userAuthStore);

  return (
    <div className='topbar'>
        <div className='topbarWrapper'>
            <div className="topLeft">
                <span className='logo'>Admin Panel</span>
            </div>
            <div className="topRight">
                <div className="topbarIconContainer">
                    <Link to="/"><HomeIcon /></Link>
                </div>
                <div >
                    {userAuth.username}
                </div>
                <img src='https://i.kinja-img.com/image/upload/c_fill,h_675,pg_1,q_80,w_1200/ijsi5fzb1nbkbhxa2gc1.png' alt='' className='topAvatar' />
            </div>
        </div>
    </div>
  )
}

export default Topbar