import React, { useEffect, useState, useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import { useGetOrdersByUsernameQuery, useUpdateOrderStatusMutation } from '../../apis/admin/orderApi';
import { toast } from 'react-toastify';

function AccountOrderTable({user}) {

    const {
        jeweleryArray
    } = useContext(WatchContext)

    if (!user) {
        return <div>...Loading</div>;
    }
    
    const { data, isLoading } = useGetOrdersByUsernameQuery(user.userName);
    const [orders, setOrders] = useState([]);
    const [canceledOrderMutation] = useUpdateOrderStatusMutation();
    
    useEffect(() => {
        if (!isLoading && data) {
            setOrders(data.result);
        }
    }, [isLoading, data]);
    
    console.log(orders);

    const handleCanceledOrder = async (order) => {

        var result = await canceledOrderMutation({id:order.id, status: "Cancelled"});

        console.log(result);

        if(result.error){
            toast.error(result.error.data.description);
        }
        else{
            toast.success("Order is canceled");
        }
    }

  return (
        <table className='cart-page-table'>
            <tbody>
                <tr>
                    <th>Product</th>
                    <th>Product Price</th>
                    <th>Sum</th>
                    <th>Quantity</th>
                    <th>Status</th>
                    <th>Country</th>
                    <th>City</th>
                    <th>Address</th>
                    <th>Action</th>
                </tr>
                {orders.length === 0 ? (
                    <tr className='no-item-msg'>
                        <td className='no-item-msg-text'>You don`t make order</td>
                    </tr>
                ) : (
                    orders.map((order) => (
                        <tr key={order.id}>
                            <td>
                                {order.carts.map((cart, index) => {
                                    const watch = jeweleryArray.find((item) => item.id === cart.watchId);
                                    if (watch) {
                                        return (
                                            <div key={index}>
                                                <span>- {watch.brend.name} {watch.nameModel}</span>
                                            </div>
                                        );
                                    }
                                    return null;
                                })}
                            </td>
                            <td>
                                {order.carts.map((cart, index) => {
                                    const watch = jeweleryArray.find((item) => item.id === cart.watchId);
                                    if (watch) {
                                        return (
                                            <div key={index}>
                                                <span>${watch.price}</span>
                                            </div>
                                        );
                                    }
                                    return null;
                                })}
                            </td>
                            <td>${order.sum}</td>
                            <td>{order.carts.length}</td>
                            <td>{order.orderStatus.name}</td>
                            <td>{order.shipment.country}</td>
                            <td>{order.shipment.city}</td>
                            <td>{order.shipment.address}</td>
                            {(order.orderStatus.name !== 'Sent' && order.orderStatus.name !== 'Cancelled' && order.orderStatus.name !== 'Delivered') && 
                                <td>
                                    <button 
                                        className="item-remove-btn"
                                        onClick={() => handleCanceledOrder(order)}
                                    >
                                        <i className="fa-light fa-xmark"></i>
                                    </button>
                                </td>
                            }
                        </tr>
                    ))
                )}

            </tbody>
        </table>
  )
}

export default AccountOrderTable
