import React from "react";
import Layout from "../components/layout/Layout";
import CheckoutMain from "../components/main/CheckoutMain";
import withAuth from '../HOC/withAuth'

const Checkout = () => {
  return (
    <Layout>
      <CheckoutMain />
    </Layout>
  );
};

export default withAuth(Checkout);
