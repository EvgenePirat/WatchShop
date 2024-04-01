import React from 'react'
import './topbar.css'
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import SettingsIcon from '@mui/icons-material/Settings';

function Topbar() {
  return (
    <div className='topbar'>
        <div className='topbarWrapper'>
            <div className="topLeft">
                <span className='logo'>AdminPage</span>
            </div>
            <div className="topRight">
                <div className="topbarIconContainer">
                    <NotificationsNoneIcon />
                </div>
                <div className="topbarIconContainer">
                    <SettingsIcon />
                </div>
                <img src='https://i.kinja-img.com/image/upload/c_fill,h_675,pg_1,q_80,w_1200/ijsi5fzb1nbkbhxa2gc1.png' alt='' className='topAvatar' />
            </div>
        </div>
    </div>
  )
}

export default Topbar