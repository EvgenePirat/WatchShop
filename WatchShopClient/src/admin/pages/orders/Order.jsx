import React, { useState } from 'react'
import '../../styles/user/userEdit.css'
import { useLocation } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { Form } from 'react-bootstrap'
import toast, { Toaster } from 'react-hot-toast';
import { useUpdateOrderStatusMutation, useUpdateShipmentMutation } from '../../../apis/admin/orderApi';

function Order() {

    const location = useLocation();
    const userItems = useSelector(state => state.userItemsStore.userItems);

    const { order } = location.state || {};
    const [orderUpdate, setOrderUpdate] = useState(order);
    const [orderDetail, setOrderDetail] = useState(order);

    const [updateOrderStatusMutation] = useUpdateOrderStatusMutation();
    const [updateShipmentOrderMutation] = useUpdateShipmentMutation();

    const handleUpdate = async (e) => {
        e.preventDefault();

        if(orderDetail.orderStatus.name != orderUpdate.orderStatus.name){

            var result = await updateOrderStatusMutation({id:orderUpdate.id, status: orderUpdate.orderStatus.name});

            if(result.error){
                toast.error(result.error.data.description);
            }
            else{
                toast.success('Order Status is update');
                setOrderDetail(orderUpdate)
            }
        }

        console.log(orderDetail)

        if(orderDetail.shipment.address != orderUpdate.shipment.address || orderDetail.shipment.country != orderUpdate.shipment.country || orderDetail.shipment.city != orderUpdate.shipment.city){
            

            var result = await updateShipmentOrderMutation({id: orderUpdate.id, address: orderUpdate.shipment.address, country: orderUpdate.shipment.country, city: orderUpdate.shipment.city })

            console.log(result);
            
            if(result.error){
                toast.error(result.error.data.description);
            }
            else{
                toast.success('Order Shipment data is update');
                setOrderDetail(orderUpdate)
            }
        }
    }

  return (
    <div className='userEdit'> 
      <div className="userTitleContainerEdit">
        <h1 className="userTitle">Edit Order</h1>
      </div>
      <div className="userContainer">
        <div className="userShow">

            <span className="userUpdateTitle">Details</span>

          <div className="userShowBottom">
            <span className="userShowTitle">Order Id</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.id}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">UserName</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.userId}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Sum</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.sum}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Create Date</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.createDate ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Status</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.orderStatus.name ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Address</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.shipment.address ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">City</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.shipment.city ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Country</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.shipment.country ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Payment Method</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.payment.paymentMethod ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Payment Status</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.payment.status ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Payment Amount</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.payment.amount ?? '-'}</span>
            </div>
          </div>

          <div className="userShowBottom">
            <span className="userShowTitle">Payment Date</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{orderDetail.payment.paymentDate ?? '-'}</span>
            </div>
          </div>
        </div>
        <div className="userUpdate">
          <span className="userUpdateTitle">Edit</span>
          <form className="userUpdateForm" onSubmit={handleUpdate} >
            <div className="userUpdateLeft">
              <div className="userUpdateItem">
                <label>Address</label>
                <input
                  type="text"
                  placeholder={orderUpdate.shipment.address}
                  className="brendUpdateInput"
                  value={orderUpdate.shipment.address}
                  onChange={(e) => setOrderUpdate((prev) => ({...prev, shipment : {...prev.shipment, address : e.target.value}}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>City</label>
                <input
                  type="text"
                  placeholder={orderUpdate.shipment.city}
                  className="brendUpdateInput"
                  value={orderUpdate.shipment.city}
                  onChange={(e) => setOrderUpdate((prev) => ({...prev, shipment : {...prev.shipment, city : e.target.value}}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>Country</label>
                <Form.Select name="country" id="checkout-country" value={orderUpdate.shipment.country} onChange={(e) => setOrderUpdate((prev) => ({...prev, shipment : {...prev.shipment, country : e.target.value}}))} >
                                <option value="United States">United States (US)</option>
                                <option value="United Kingdom">United Kingdom (UK)</option>
                                <option value="France">France</option>
                                <option value="Ukraine">Ukraine</option>
                                <option value="Iran">Iran</option>
                                <option value="Bangladesh">Bangladesh</option>
                                <option value="Bhutan">Bhutan</option>
                                <option value="Nepal">Nepal</option>
                </Form.Select>
              </div>

              <div className="userUpdateItem">
                <label>Status</label>
                <Form.Select name="country" id="checkout-country" value={orderUpdate.orderStatus.name} onChange={(e) => setOrderUpdate((prev) => ({...prev, orderStatus : {...prev.orderStatus, name : e.target.value}}))} >
                    <option value="Create">Create</option>
                    <option value="Processing">Processing</option>
                    <option value="Sent">Sent</option>
                    <option value="Delivered">Delivered</option>
                    <option value="Cancelled">Cancelled</option>
                </Form.Select>
              </div>

              <button className="userUpdateButton">Update</button>
            </div>
          </form>
          <Toaster position="bottom-right" reverseOrder={false} />
        </div>
      </div>

    </div>
  )
}

export default Order
