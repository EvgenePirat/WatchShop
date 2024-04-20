import React from 'react'
import Topbar from '../components/topbar/Topbar'
import Sidebar from '../components/sidebar/Sidebar'
import "../styles/app.css"
import { Outlet } from 'react-router-dom'
import withAuthAdmin from '../../HOC/withAuthAdmin'

function Admin() {
  return (
    <div>
     <Topbar />
        <div className="containerAdmin">
          <Sidebar/>
          <Outlet />
        </div>
    </div>
  )
}

export default withAuthAdmin(Admin);