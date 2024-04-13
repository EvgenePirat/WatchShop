import React, { useEffect } from 'react'
import BannerSection2 from '../banner/BannerSection2'
import CategorySection2 from '../category/CategorySection2'
import LuxurySection from '../product/LuxurySection'
import SpecialOfferSection from '../offer/SpecialOfferSection'
import HotDealSection from '../offer/HotDealSection'
import TestimonialSlider from '../sliders/TestimonialSlider'
import BlogSection2 from '../blog/BlogSection2'
import GallerySection2 from '../gallery/GallerySection2'
import { useGetWatchesQuery } from '../../apis/admin/watchApi'
import { useDispatch } from 'react-redux'
import { setWatchItems } from '../../Storage/Redux/Slices/watchItemClise'

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
        <CategorySection2/>
        <LuxurySection/>
        <SpecialOfferSection/>
        <HotDealSection/>
        <TestimonialSlider/>
        <GallerySection2/>
    </main>
  )
}

export default JewelleryShopMain