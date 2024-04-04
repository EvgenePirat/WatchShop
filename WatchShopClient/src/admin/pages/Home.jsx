import React from 'react'
import '../styles/home.css'
import FeaturedInfo from '../components/featuredInfo/FeaturedInfo'
import Chart from '../components/chart/Chart'
import {userData} from '../helpers/dummyData'
import WidgetSmall from '../components/widgetSmall/WidgetSmall'
import WidgetLarge from '../components/widgetLarge/WidgetLarge'

function Home() {
  return (
    <div className='home'>
       <FeaturedInfo />
       <Chart data={userData} title="User Analytics" grid dataKey="Active User"  />
       <div className="homeWidgets">
        <WidgetSmall />
        <WidgetLarge />
       </div>
    </div>
  )
}

export default Home