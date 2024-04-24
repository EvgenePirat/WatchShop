import React, {useContext, useEffect} from 'react'
import SearchFilter from './SearchFilter'
import ProductPriceFilter from './ProductPriceFilter'
import ProductViewFilter from './ProductViewFilter'
import ProductContainer from './ProductContainer'
import ProductPagination from './ProductPagination'
import ProductStyleList from './ProductStyleList'
import ProductBrendList from './ProductBrendList'
import ProductGenderList from './ProductGenderList'
import { useLocation } from 'react-router-dom';
import { FarzaaContext } from '../../context/FarzaaContext';

const ShopAreaSection = () => {

    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const filter = searchParams.get('filter');

    const { setFilteredProducts, jeweleryArray, setActive } = useContext(FarzaaContext);

    useEffect(() => {
        if(filter == null){
            setFilteredProducts(jeweleryArray);
            setActive('');
        }
        if (filter === 'discount') {
            const discountedProducts = jeweleryArray.filter(product => product.isDiscounted);
            setFilteredProducts(discountedProducts);
            setActive('');
        }
    }, [filter]);

  return (
    <div className="shop-area">
        <div className="container">
            <div className="row gy-5 justify-content-center">
                <div className="col-xl-3 col-lg-4 col-md-6 col-sm-8 col-9 col-xxs-12 order-1 order-lg-0">
                    <div className="fz-sidebar">
                        <SearchFilter/>

                        <ProductBrendList filter={filter} />

                        <ProductStyleList filter={filter} />

                        <ProductGenderList filter={filter} />

                        <ProductPriceFilter/>
                    </div>
                </div>

                <div className="col-xl-9 col-lg-8 order-0 order-lg-1">
                    <ProductViewFilter/>

                    <ProductContainer/>

                    <ProductPagination/>
                </div>
            </div>
        </div>
    </div>
  )
}

export default ShopAreaSection