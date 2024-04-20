import React, { useEffect } from 'react'
import BannerSection2 from '../banner/BannerSection2'
import LuxurySection from '../product/LuxurySection'
import SpecialOfferSection from '../offer/SpecialOfferSection'
import HotDealSection from '../offer/HotDealSection'
import TestimonialSlider from '../sliders/TestimonialSlider'
import GallerySection2 from '../gallery/GallerySection2'
import { useGetWatchesQuery } from '../../apis/admin/watchApi'
import { useDispatch } from 'react-redux'
import { setWatchItems } from '../../Storage/Redux/Slices/watchItemClise'
import GenderSection from '../styles/GenderSection'

const JewelleryShopMain = () => {

  const dispatch = useDispatch();
  const { data, error, isLoading } = useGetWatchesQuery()

  useEffect(() => {
    if (data) {
      dispatch(setWatchItems(data.result)); 
    }
  }, [data, dispatch]);

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>Error: {error.message}</div>;
  

  return (
    <main>
        <BannerSection2/>
        <GenderSection/>
        <LuxurySection/>
        <SpecialOfferSection/>
        <HotDealSection/>
        <TestimonialSlider/>
        <GallerySection2/>
    </main>
  )
}

export default JewelleryShopMain