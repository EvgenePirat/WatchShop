import React from 'react'
import Topbar from '../components/topbar/Topbar'
import Sidebar from '../components/sidebar/Sidebar'
import "../styles/app.css"

function HomeAdmin() {
  return (
    <div>
        <Topbar />
        <div className="containerAdmin">
          <Sidebar/>
          <div className='othersAdmin'>
              other pages
          </div>
        </div>
    </div>
  )
}

export default HomeAdmin