import React, { useContext } from 'react'
import { Swiper, SwiperSlide } from 'swiper/react'
import { Autoplay } from 'swiper/modules';
import { WatchContext } from '../../context/WatchContext';
import { brandList } from '../../data/Data';
import { Link } from 'react-router-dom';

const BrandSection = () => {
    const {slidesBrand} = useContext(WatchContext)
  
  return (
    <div className="clients-section fz-1-brands-section">
        <div className="container">
            <div className="fz-1-section-heading">
                <h2 className="fz-section-title">Browse by Brand</h2>
            </div>
            <Swiper 
            slidesPerView={slidesBrand} 
            className="clients fz-1-brands"
            autoplay={true}
            loop={true}
            modules={[Autoplay]}
            >
                {brandList.map((item)=>(
                    <SwiperSlide key={item.id}>
                        <Link to="/shop">
                            <img src={item.imgSrc} alt="Client logo"/>
                        </Link> 
                    </SwiperSlide>  
                ))}
                
            </Swiper>
        </div>
    </div>
  )
}

export default BrandSection