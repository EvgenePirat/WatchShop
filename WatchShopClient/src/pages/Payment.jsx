import React from "react";
import Layout from "../components/layout/Layout";
import withAuth from '../HOC/withAuth'
import PaymentMain from "../components/main/PaymentMain";

const Checkout = () => {
  return (
    <Layout>
      <PaymentMain />
    </Layout>
  );
};

export default withAuth(Checkout);