import {useStripe, useElements, PaymentElement} from '@stripe/react-stripe-js';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useAddNewOrderMutation } from '../../apis/admin/orderApi';
import React, { useContext} from 'react'
import { WatchContext } from '../../context/WatchContext'


const PaymentForm = ({order}) => {

  const { setCartItems } = useContext(WatchContext)
  const stripe = useStripe();
  const elements = useElements();
  const navigate = useNavigate();
  const [createOrderMutation] = useAddNewOrderMutation();

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!stripe || !elements) {
      return;
    }

    const result = await stripe.confirmPayment({
      elements,
      confirmParams: {
        return_url: "https://example.com/order/123/complete",
      },
      redirect: "if_required"
    });

    if (result.error) {
      toast.error("Error with pay!")
      console.log(result.error.message);
    } else {
      console.log(result);

      if(result.paymentIntent.status == 'succeeded'){
        var resultCreateOrder = await createOrderMutation(order);

        console.log(resultCreateOrder);

        if(resultCreateOrder.error){
          toast.error('Order is not make');
        }
        else{
          toast.success('You made order, check his status in your account');
          setCartItems([])
          localStorage.removeItem('cartItems');
          navigate("/")
        }
      }
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <PaymentElement />
      <button>Submit</button>
    </form>
  );
};

export default PaymentForm;