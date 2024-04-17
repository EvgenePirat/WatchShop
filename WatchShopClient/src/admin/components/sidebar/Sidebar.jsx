import React from 'react'
import './sidebar.css'
import LineStyleIcon from '@mui/icons-material/LineStyle';
import TrendingUpIcon from '@mui/icons-material/TrendingUp';
import ShoppingBagIcon from '@mui/icons-material/ShoppingBag';
import PermIdentityIcon from '@mui/icons-material/PermIdentity';
import StorefrontIcon from '@mui/icons-material/Storefront';
import CategoryIcon from '@mui/icons-material/Category';
import CommentIcon from '@mui/icons-material/Comment';
import { Link } from 'react-router-dom';

function Sidebar() {
  return (
    <div className='sidebarAdmin'>
        <div className="sidebarWrapperAdmin">
            <div className="sidebarMenuAdmin">
                <h3 className="sidebarTitle">Main</h3>
                <ul className='sidebarListAdmin'>
                    <li className="sidebarListItemAdmin">
                        <LineStyleIcon className='sidebarIcon' />
                        <Link to="/admin" >Home</Link>
                    </li>
                    <li className="sidebarListItemAdmin">
                        <ShoppingBagIcon className='sidebarIcon' />
                        Orders
                    </li>
                    <li className="sidebarListItemAdmin">
                        <TrendingUpIcon className='sidebarIcon' />
                        Analytics
                    </li>
                </ul>
            </div>
            <div className="sidebarMenuAdmin">
                <h3 className="sidebarTitle">Quick Menu</h3>
                <ul className='sidebarListAdmin'>
                    <li className="sidebarListItemAdmin">
                        <Link to="/admin/users" > 
                            <PermIdentityIcon className='sidebarIcon' />
                            Users
                        </Link>
                    </li>
                    <li className="sidebarListItemAdmin">
                        <Link to="/admin/watches">
                            <StorefrontIcon className='sidebarIcon' />
                            Watches
                        </Link>
                    </li>
                    <Link to="/admin/brends" className="sidebarListItemAdmin">
                        <li>
                            <CategoryIcon className='sidebarIcon' />
                            Brends
                        </li>
                    </Link>

                    <li className="sidebarListItemAdmin">
                        <Link to="/admin/comments" className="sidebarListItemAdmin">
                            <CommentIcon className='sidebarIcon' />
                            Comments
                        </Link>
                    </li>
                </ul>
            </div>
        </div>
    </div>
  )
}

export default Sidebar