import React from 'react'
import ProductDetailAction from './ProductDetailAction';
import { Rating } from '@mui/material';

const ProductDetailTextSection = ({watch}) => {
  return (
    <div className="fz-product-details__txt">
        <h2 className="fz-product-details__title">{watch.brend.name} {watch.nameModel}</h2>
        <div className="fz-product-details__price-rating">
            <span className="price">${watch.isDiscounted == true ? watch.discountPrice : watch.price}</span>
            <Rating name="read-only" value={3} readOnly />
            <div className="rating">
                <i className="fa-solid fa-star"></i>
                <i className="fa-solid fa-star"></i>
                <i className="fa-solid fa-star"></i>
                <i className="fa-solid fa-star"></i>
                <i className="fa-light fa-star"></i>
            </div>
        </div>

        <div className="fz-product-details__infos">
            <ul>
                <li><span className="info-property"> Brend </span> : <span className="info-value">{watch.brend.name}</span></li>
                <li><span className="info-property"> Country </span> : <span className="info-value">{watch.country.name}</span></li>
                <li><span className="info-property"> Glass Type </span> : <span className="info-value">{watch.glassType.name}</span></li>
                <li><span className="info-property"> Strap </span> : <span className="info-value">{watch.strap.name}</span></li>
                <li><span className="info-property"> Style </span> : <span className="info-value">{watch.style.name}</span></li>
                <li><span className="info-property"> Gender </span> : <span className="info-value">{watch.gender}</span></li>
                <li><span className="info-property"> Mechanism Type </span> : <span className="info-value">{watch.mechanismType.name}</span></li>
            </ul>
        </div>

        {
            watch.description == null || watch.description.length > 0 ? <p>{watch.description}</p> : <br/>
        }
        <p className="fz-product-details__short-descr">
        </p>

        <ProductDetailAction watch={watch} />

        <div className="fz-product-details__payment-methods">
            <img src="assets/images/card.png" alt="Pyament Methods"/>
            <span className="dialog">Guaranteed safe & secure checkout</span>
        </div>
    </div>
  )
}

export default ProductDetailTextSection