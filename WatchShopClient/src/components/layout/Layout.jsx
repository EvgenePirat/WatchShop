import React from 'react'
import FooterSection from '../footer/FooterSection'
import RightSideBar from '../sidebar/RightSideBar'
import HeaderSection2 from '../header/HeaderSection2'

const Layout = ({children}) => {
  return (
    <>
    <HeaderSection2 />
        {children}
        <RightSideBar/>
        <FooterSection/>
    </>
  )
}

export default Layout