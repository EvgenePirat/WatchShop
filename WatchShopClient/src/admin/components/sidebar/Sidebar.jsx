import React from 'react'
import './sidebar.css'
import LineStyleIcon from '@mui/icons-material/LineStyle';
import TrendingUpIcon from '@mui/icons-material/TrendingUp';
import ShoppingBagIcon from '@mui/icons-material/ShoppingBag';
import PermIdentityIcon from '@mui/icons-material/PermIdentity';
import StorefrontIcon from '@mui/icons-material/Storefront';
import CategoryIcon from '@mui/icons-material/Category';
import CommentIcon from '@mui/icons-material/Comment';

function Sidebar() {
  return (
    <div className='sidebarAdmin'>
        <div className="sidebarWrapperAdmin">
            <div className="sidebarMenuAdmin">
                <h3 className="sidebarTitle">Main</h3>
                <ul className='sidebarListAdmin'>
                    <li className="sidebarListItemAdmin">
                        <LineStyleIcon className='sidebarIcon' />
                        Home
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
                        <PermIdentityIcon className='sidebarIcon' />
                        Users
                    </li>
                    <li className="sidebarListItemAdmin">
                        <StorefrontIcon className='sidebarIcon' />
                        Products
                    </li>
                    <li className="sidebarListItemAdmin">
                        <CategoryIcon className='sidebarIcon' />
                        Categories
                    </li>
                    <li className="sidebarListItemAdmin">
                        <CommentIcon className='sidebarIcon' />
                        Comments
                    </li>
                </ul>
            </div>
        </div>
    </div>
  )
}

export default Sidebar