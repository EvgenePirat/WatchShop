import React from 'react'
import BreadcrumbSection from '../breadcrumb/BreadcrumbSection'
import PaymentSection from '../payment/PaymentSection'

const PaymentMain = () => {
  return (
    <>
        <BreadcrumbSection title={"Payment Cart"} current={"Payment"}/>
        <PaymentSection/>
    </>
  )
}

export default PaymentMain