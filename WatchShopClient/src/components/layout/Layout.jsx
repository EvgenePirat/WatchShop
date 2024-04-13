import React from 'react'
import FooterSection from '../footer/FooterSection'
import RightSideBar from '../sidebar/RightSideBar'

const Layout = ({children}) => {
  return (
    <>
        {children}
        <RightSideBar/>
        <FooterSection/>
    </>
  )
}

export default Layout