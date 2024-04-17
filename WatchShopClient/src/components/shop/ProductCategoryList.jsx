import React, { useContext, useEffect, useState } from 'react';
import { FarzaaContext } from '../../context/FarzaaContext';
import { useGetBrendsQuery } from '../../apis/admin/brendApi';

const ProductCategoryList = () => {
    const { handleCategoryFilter, jeweleryArray } = useContext(FarzaaContext);
    const [activeBrend, setActiveBrend] = useState(null);

    const {data, isLoading} = useGetBrendsQuery();
    const [brends, setBrends] = useState([])

    useEffect(() => {
        if (!isLoading && data) {
          setBrends(data.result);
        }
      }, [isLoading, data]);

    const handleBrendClick = (brend) => {
        handleCategoryFilter(brend);
        setActiveBrend(brend);
    };

    return (
        <section className="sidebar-single-area product-categories-area">
            <h3 className="sidebar-single-area__title">Watch Brends</h3>
            <ul className="product-categories">
                {brends.map(brend => (
                    <li
                        key={brend.id}
                        onClick={() => handleBrendClick(brend.name)}
                        className={activeBrend === brend.name ? 'active' : ''}
                    >
                        {brend.name} ({brend.name === null ? jeweleryArray.length : jeweleryArray.filter(watch => watch.brend.name === brend.name).length})
                    </li>
                ))}
            </ul>
        </section>
    );
}

export default ProductCategoryList;
