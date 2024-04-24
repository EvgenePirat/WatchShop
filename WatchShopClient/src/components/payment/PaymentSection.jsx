import React, { useEffect, useState } from 'react'
import { useLocation } from 'react-router-dom';
import { useMakePaymentMutation } from '../../apis/admin/paymentApi';
import { toast } from 'react-toastify';
import { Link, useNavigate } from 'react-router-dom'
import {Elements} from '@stripe/react-stripe-js';
import {loadStripe} from '@stripe/stripe-js';
import PaymentForm from '../payment/PaymentForm.jsx';


const PaymentSection = () => {

  const location = useLocation();
  const order = location.state;
  const [createPaymentMutation] = useMakePaymentMutation();
  const navigate = useNavigate();
  const [paymentCreated, setPaymentCreated] = useState(false);

  const [createOrder, setCreateOrder] = useState(order);

  const createPayment = async (e) => {

      const result = await createPaymentMutation(order.sum);

      if(result.error){
        toast.error('Error with cart payment, try later!');
        navigate("/")
      }
      else{
         setCreateOrder((prev) => ({...prev, payment : {...prev.payment, clientSecret: result.data.result.clientSecret, stripeIntend: result.data.result.stripePaymentIntentId, paymentMethod: "Card"  }}))
      }
  }

  console.log(createOrder);


  useEffect(() => {
    createPayment();
    setPaymentCreated(true);
  }, [paymentCreated]);

  if (!createOrder || !createOrder.payment || !createOrder.payment.clientSecret) {
    return <div>Loading...</div>;
  }

  const stripePromise = loadStripe('pk_test_51P8294Jqil8qlI9LgPUF0wzquRkvlIwLBbkobLxf0GbvzT3BaCE9TDKeoQjlrCDKPYY63fBydQRagrqrKgglnPuS00TWuMSIVz');

  const options = {
    clientSecret: createOrder.payment.clientSecret,
  };

  return (
    <Elements stripe={stripePromise} options={options}>
      <div className='container-fluid d-flex justify-content-center align-items-center vh-100'>
        <div className="row">
          <div className='col-md-8'> 
            <PaymentForm order = {createOrder} />
          </div>
        </div>
      </div>
    </Elements>
  )
}

export default PaymentSection