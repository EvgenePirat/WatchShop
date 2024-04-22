import React, {useEffect} from 'react'
import '../styles/home.css'
import FeaturedInfo from '../components/featuredInfo/FeaturedInfo'
import Chart from '../components/chart/Chart'
import {userData} from '../helpers/dummyData'
import WidgetSmall from '../components/widgetSmall/WidgetSmall'
import WidgetLarge from '../components/widgetLarge/WidgetLarge'
import { useGetUsersQuery } from '../../apis/admin/userApi'
import { useDispatch } from 'react-redux';
import { setUserItems } from '../../Storage/Redux/Slices/userItemSlice'


function Home() {

  const { data, isLoading } = useGetUsersQuery();
  const dispatch = useDispatch();

  useEffect(() => {
    if (!isLoading && data) {
      dispatch(setUserItems(data.result));
    }
  }, [isLoading, data]);

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