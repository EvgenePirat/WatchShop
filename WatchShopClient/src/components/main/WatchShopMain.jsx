import React, { useEffect } from 'react'
import BannerSection from '../banner/BannerSection'
import LuxurySection from '../product/LuxurySection'
import SpecialOfferSection from '../offer/SpecialOfferSection'
import HotDealSection from '../offer/HotDealSection'
import TestimonialSlider from '../sliders/TestimonialSlider'
import GallerySection from '../gallery/GallerySection'
import { useGetWatchesQuery } from '../../apis/admin/watchApi'
import { useDispatch } from 'react-redux'
import { setWatchItems } from '../../Storage/Redux/Slices/watchItemClise'
import GenderSection from '../styles/GenderSection'

const WatchShopMain = () => {

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
        <BannerSection/>
        <GenderSection/>
        <LuxurySection/>
        <SpecialOfferSection/>
        <HotDealSection/>
        <TestimonialSlider/>
        <GallerySection/>
    </main>
  )
}

export default WatchShopMain