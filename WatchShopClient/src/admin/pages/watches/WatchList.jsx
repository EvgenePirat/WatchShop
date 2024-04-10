import React from 'react'
import '../../styles/watch/WatchList.css'
import { Link } from 'react-router-dom';

function WatchList() {
  return (
    <div className='watchList'>
        <div className='brendTitleContainer'>
            <h3 className="brendTitle">Watches</h3>
            <button className='brendAddButton'><Link to="/admin/watch/create">Add Watch</Link></button>
        </div>
    </div>
  )
}

export default WatchList