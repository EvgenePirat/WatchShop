import React from 'react'
import HeaderSection2 from '../header/HeaderSection2'
import FooterSection from '../footer/FooterSection'
import RightSideBar from '../sidebar/RightSideBar'

const Layout = ({children}) => {
  return (
    <>
        <HeaderSection2/>
        {children}
        <RightSideBar/>
        <FooterSection/>
    </>
  )
}

export default Layout