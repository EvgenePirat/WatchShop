import React from 'react'
import Layout from '../components/layout/Layout'
import AccountMain from '../components/main/AccountMain'
import withAuth from '../HOC/withAuth'

const Account = () => {
  return (
    <Layout>
        <AccountMain/>
    </Layout>
  )
}

export default withAuth(Account)