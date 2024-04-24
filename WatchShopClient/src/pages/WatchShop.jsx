import React from 'react'
import HeaderSectionMain from '../components/header/HeaderSectionMain'
import FooterSectionMain from '../components/footer/FooterSectionMain'
import WatchShopMain from '../components/main/WatchShopMain'
import RightSideBar from '../components/sidebar/RightSideBar'

const WatchShop = () => {
  return (
    <>
        <HeaderSectionMain/>
        <WatchShopMain/>
        <RightSideBar/>
        <FooterSectionMain/>
    </>
  )
}

export default WatchShop