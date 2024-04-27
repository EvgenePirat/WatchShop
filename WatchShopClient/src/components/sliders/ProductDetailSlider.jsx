import React, { useRef, useEffect, useState } from 'react';
import Slider from 'react-slick';
import 'react-slideshow-image/dist/styles.css'
import { Fade } from 'react-slideshow-image';

const ProductDetailSlider = ({watch}) => {

  if(!watch){
    return <div>Loading...</div>
  }


  return (
    <>
       <Fade>
        {watch.images.map((image, index) => (
          <div key={index}>
            <img style={{ width: '100%', height: '600px' }} src={image.path} />
          </div>
        ))}
      </Fade>
    </>
  );
};

export default ProductDetailSlider;
