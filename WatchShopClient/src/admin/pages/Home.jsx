import React, {useEffect, useState} from 'react'
import '../styles/home.css'
import FeaturedInfo from '../components/featuredInfo/FeaturedInfo'
import Chart from '../components/chart/Chart'
import {userData} from '../helpers/dummyData'
import WidgetSmall from '../components/widgetSmall/WidgetSmall'
import WidgetLarge from '../components/widgetLarge/WidgetLarge'
import { useGetSalesStatisticsQuery } from '../../apis/admin/analyticApi'


function Home() {

  const {data, isLoading} = useGetSalesStatisticsQuery();
  const [statistics, setStatistics] = useState();
  const [salesArray, setSalesArray] = useState([]);

  useEffect(() => {
    if (!isLoading && data) {
      setStatistics(data.result);
      setSalesArray();
      setSalesArray(Object.keys(data.result.salesByDay).map(date => ({
          date: date.slice(0, 10),
          sales: data.result.salesByDay[date]
        })))
    }
  }, [isLoading, data]);

  if(isLoading){
    return <div>Loading...</div>
  }
  else{
    console.log(statistics);
  }

  return (
    <div className='home'>
       <FeaturedInfo statistics={statistics} />
       <Chart salesArray={salesArray} title="Sales by Date" grid dataKey="Sales by Date"  />
       <div className="homeWidgets">
        <WidgetSmall />
        <WidgetLarge />
       </div>
    </div>
  )
}

export default Home