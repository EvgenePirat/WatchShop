import React, { useState, useEffect } from 'react'
import './widgetLarge.css'
import { useGetOrdersQuery } from '../../../apis/admin/orderApi'
import { useSelector } from 'react-redux';
import { formatDate } from '../../../utilities/TransformDate';

function WidgetLarge() {

    const {data, isLoading} = useGetOrdersQuery();
    const [latestOrders, setLatestOrders] = useState([]);
    const userItems = useSelector(state => state.userItemsStore.userItems);

    useEffect(() => {
        if (!isLoading && data) {
            const copiedOrders = [...data.result];
    
            const sortedOrders = copiedOrders.sort((a, b) => {
                return new Date(b.createDate) - new Date(a.createDate);
            });
    
            setLatestOrders(sortedOrders.slice(0, 7));
        }
    }, [data, isLoading]);

    const Button = ({type}) => {
        return <button className={'widgetLrButton'+type}>{type}</button>
    }

    if(isLoading){
        return <div>Loading...</div>
    }
    else{
        if(userItems.length == 0){
            return <div>Loading...</div>
        }

    }
    

  return (
    <div className='widgetLr'>
      <h3 className="widgetLrTitle">Latest transactions</h3>
      <table className='widgetLrTable'>
        <tr className='widgetLrTt'>
            <th className='widgetLrTh'>User</th>
            <th className='widgetLrTh'>Date</th>
            <th className='widgetLrTh'>Amount</th>
            <th className='widgetLrTh'>Status</th>
        </tr>
        {latestOrders.map((order, index) => (
                    <tr className='widgetLrTt' key={index}>
                        <td className="widgetlgUser">
                            <img className='widgetLrImg' src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' />
                            <span className="widgetLrName">{order.userId}</span>
                        </td>
                        <td className='widgetLrDate'>{formatDate(order.createDate)}</td>
                        <td className='widgetLrAmount'>{order.sum}</td>
                        <td className='widgetLgStatus'><Button type={order.orderStatus.name} /></td>
                    </tr>
        ))}
      </table>
    </div>
  )
}

export default WidgetLarge
