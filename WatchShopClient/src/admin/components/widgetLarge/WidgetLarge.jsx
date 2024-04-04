import React from 'react'
import './widgetLarge.css'

function WidgetLarge() {

    const Button = ({type}) => {
        return <button className={'widgetLrButton'+type}>{type}</button>
    }

  return (
    <div className='widgetLr'>
      <h3 className="widgetLrTitle">Latest transactions</h3>
      <table className='widgetLrTable'>
        <tr className='widgetLrTt'>
            <th className='widgetLrTh'>Customer</th>
            <th className='widgetLrTh'>Date</th>
            <th className='widgetLrTh'>Amount</th>
            <th className='widgetLrTh'>Status</th>
        </tr>
        <tr className='widgetLrTt'>
            <td className="widgetlgUser">
                <img className='widgetLrImg' src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' />
                <span className="widgetLrName">Susan Carol</span>
            </td>
            <td className='widgetLrDate'>2 Jun 2021</td>
            <td className='widgetLrAmount'>$122.20</td>
            <td className='widgetLgStatus'><Button type="Declined" /></td>
        </tr>
        <tr className='widgetLrTt'>
            <td className="widgetlgUser">
                <img className='widgetLrImg' src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' />
                <span className="widgetLrName">Susan Carol</span>
            </td>
            <td className='widgetLrDate'>2 Jun 2021</td>
            <td className='widgetLrAmount'>$122.20</td>
            <td className='widgetLgStatus'><Button type="Pending" /></td>
        </tr>
        <tr className='widgetLrTt'>
            <td className="widgetlgUser">
                <img className='widgetLrImg' src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' />
                <span className="widgetLrName">Susan Carol</span>
            </td>
            <td className='widgetLrDate'>2 Jun 2021</td>
            <td className='widgetLrAmount'>$122.20</td>
            <td className='widgetLgStatus'><Button type="Approved" /></td>
        </tr>
        <tr className='widgetLrTt'>
            <td className="widgetlgUser">
                <img className='widgetLrImg' src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' />
                <span className="widgetLrName">Susan Carol</span>
            </td>
            <td className='widgetLrDate'>2 Jun 2021</td>
            <td className='widgetLrAmount'>$122.20</td>
            <td className='widgetLgStatus'><Button type="Approved" /></td>
        </tr>
      </table>
    </div>
  )
}

export default WidgetLarge
