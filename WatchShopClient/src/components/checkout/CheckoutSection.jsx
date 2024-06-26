import React, { useContext, useEffect, useState } from 'react'
import { Form } from 'react-bootstrap'
import { WatchContext } from '../../context/WatchContext'
import { Link, useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux';
import { useGetUserByIdQuery, useUpdateUserMutation } from '../../apis/admin/userApi';
import { useAddNewOrderMutation } from '../../apis/admin/orderApi';
import { toast } from 'react-toastify';

const CheckoutSection = () => {

    const {subTotal, finalPrice, cartItems, setCartItems } = useContext(WatchContext)
    const userAuth = useSelector(state => state.userAuthStore);
    const {data, isLoading} = useGetUserByIdQuery(userAuth.id);
    const [updateUserMutation] = useUpdateUserMutation();
    const [createOrderMutation] = useAddNewOrderMutation();
    const navigate = useNavigate();

    const orderTemplate = {
        sum: finalPrice,
        userId:"",
        shipment : {
            address : "",
            city: "",
            country: "Ukraine",
            applicationUserId: ""
        },
        payment: {
            stripeIntend : "",
            paymentMethod: "",
            amount: finalPrice,
            applicationUserId: ""
        },
        carts : [],
        comment : ""
    }

    const userTemplate = {
        id: "",
        firstName: "",
        lastName: ""
    }

    const [user, setUser] = useState(userTemplate);
    const [order, setOrder] = useState(orderTemplate);
    const [isUpdate, setIsUpdate] = useState();

    useEffect(() => {
        if (!isLoading && data) {
          setUser(data.result);
          setOrder((prev) => ({...prev, userId: data.result.id, 
            shipment: {...prev.shipment, applicationUserId: data.result.id},
             payment: {...prev.payment, applicationUserId: data.result.id} }));
        }
    }, [isLoading, data]);

    useEffect(() => {
        const carts  = cartItems.map(item => ({
            watchId: item.id, 
            count: item.quantity
        }));
        setOrder((prev) => ({...prev, carts: carts}))
    }, [])

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(isUpdate == true){
            var result = await updateUserMutation(user);

            console.log(result);

            if(result.data.isSuccess){
                toast.success('User is update');
            }
            else
                toast.error('User is not update');
        }

        if(order.payment.paymentMethod == 'Cash'){

            var result = await createOrderMutation(order);

            if(result.data.isSuccess){
                
                toast.success('You made order, check his status in your account');
                setCartItems([])
                setOrder(orderTemplate)
                localStorage.removeItem('cartItems');
                navigate("/")
            }
            else
                toast.error('Order is not make');
        }
        else{
            navigate('/payment', { state: order });
        }
    } 

  return (
    <div className="container">
        <div className="fz-checkout">
            <form className="checkout-form"  onSubmit={handleSubmit}>
                <div className="fz-billing-details">
                    <div className="row gy-0 gx-3 gx-md-4">
                        <h3 className="fz-checkout-title">Billing Details</h3>
                        <div className="col-6 col-xxs-12">
                            <input type="text" required name="firstName" id="checkout-first-name" placeholder="First Name" value={user.firstName}  onChange={(e) => setUser((prev) => ({...prev,firstName: e.target.value}))} />
                        </div>
                        <div className="col-6 col-xxs-12">
                            <input type="text" required name="lastName" id="checkout-last-name" placeholder="Last Name" value={user.lastName}  onChange={(e) => setUser((prev) => ({...prev,lastName: e.target.value}))} />
                        </div>

                        <div className="col-12">
                            <Form.Select className='country-select' required name="country" id="checkout-country" value={order.shipment.country} onChange={(e) => setOrder((prev) => ({...prev, shipment: {...prev.shipment, country: e.target.value} }))} >
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

                        <div className="col-12">
                            <input type="text" required name="address" id="checkout-house-street-number" placeholder="House Number & Street Name" value={order.shipment.address} onChange={(e) => setOrder((prev) => ({...prev, shipment: {...prev.shipment, address: e.target.value} }))}  />
                        </div>

                        <div className="col-12">
                            <input type="text" required name="city" id="checkout-city-name" placeholder="Town / City" value={order.shipment.city} onChange={(e) => setOrder((prev) => ({...prev, shipment: {...prev.shipment, city: e.target.value} }))} />
                        </div>

                        <div className="col-6 col-xxs-12">
                            <input disabled type="text" required name="username" id="checkout-phone-number" placeholder="Phone Number" value={user.userName} onChange={(e) => setUser((prev) => ({...prev,username: e.target.value}))}  />
                        </div>

                        <div className="col-6 col-xxs-12">
                            <input type="email" required name="email-address" id="checkout-email-address" placeholder="Email Address" value={user.email} onChange={(e) => setUser((prev) => ({...prev,email: e.target.value}))} />
                        </div>

                        <div className="col">
                            <input type="checkbox" name="create-account" id="checkout-create-account" value={isUpdate} onChange={(e) => setIsUpdate(e.target.checked)} />
                            <label className='create-acc-lebel' htmlFor="checkout-create-account">Update data in Account</label>
                        </div>

                        <div className="col-12 additional-info">
                            <label htmlFor="checkout-additional-info" className="fz-checkout-title">Additional Information</label>
                            <textarea name="additional-info" id="checkout-additional-info" placeholder="Notes about your order, e.g. special notes for delivery" value={order.comment} onChange={(e) => setOrder((prev) => ({...prev, comment:  e.target.value }))}></textarea>
                        </div>
                    </div>
                </div>

                <div className="fz-checkout-sidebar">
                    <div className="billing-summery">
                        <h4 className="fz-checkout-title">Billing Summary</h4>
                        <div className="cart-checkout-area">
                            <ul className="checkout-summary">
                                <li>
                                    <span className="checkout-summary__key">Subtotal</span>
                                    <span className="checkout-summary__value"><span>$</span>{subTotal}</span>
                                </li>

                                <li className="cart-checkout-total">
                                    <span className="checkout-summary__key">Total</span>
                                    <span className="checkout-summary__value"><span>$</span>{finalPrice}</span>
                                </li>
                            </ul>


                            <Link to="/cart" className="fz-1-banner-btn cart-checkout-btn">Edit Order</Link>
                        </div>
                    </div>

                    <div className="payment-info">
                        <h4 className="fz-checkout-title">Payment Information</h4>
                        <div className="d-flex payment-area align-items-center">
                            <Form.Select required name="methodType" value={order.payment.paymentMethod} onChange={(e) => setOrder((prev) => ({...prev, payment: {...prev.payment, paymentMethod : e.target.value} }))} >
                                <option value="Cart">Cart</option>
                                <option value="Cash">Cash</option>
                            </Form.Select>
                        </div>
                        <button type="submit" className="fz-1-banner-btn cart-checkout-btn checkout-form-btn">Place Order</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
  )
}

export default CheckoutSection