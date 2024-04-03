import React from 'react'
import Topbar from '../components/topbar/Topbar'
import Sidebar from '../components/sidebar/Sidebar'
import "../styles/app.css"
import Home from './Home'

function Admin() {
  return (
    <div>
        <Topbar />
        <div className="containerAdmin">
          <Sidebar/>
          <Home />
        </div>
    </div>
  )
}

export default Admin