import React from 'react'
import './FeaturedInfo.css'

function FeaturedInfo({statistics}) {

    if(!statistics){
        return <div>Loading...</div>
    }

  return (
    <div className='featured'>
        <div className="featuredItem">
            <span className="featuredTitle">Total Revanue</span>
            <div className="featuredMoneyContainer">
                <span className="featuredMoney">${statistics.totalRevenue}</span>
            </div>
            <span className="featuredSub">Statictic to last {Math.abs(statistics.daysAgo)} days </span>
        </div>
        <div className="featuredItem">
            <span className="featuredTitle">Total Sales</span>
            <div className="featuredMoneyContainer">
                <span className="featuredMoney">{statistics.totalSales}</span>
            </div>
            <span className="featuredSub">Statictic to last {Math.abs(statistics.daysAgo)} days </span>
        </div>
        <div className="featuredItem">
            <span className="featuredTitle">Average Order Price</span>
            <div className="featuredMoneyContainer">
                <span className="featuredMoney">${statistics.averageOrderValue}</span>     
            </div>
            <span className="featuredSub">Statictic to last {Math.abs(statistics.daysAgo)} days </span>
        </div>
    </div>
  )
}

export default FeaturedInfo