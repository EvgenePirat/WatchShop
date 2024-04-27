import React, { useContext, useEffect, useState } from 'react';
import { WatchContext } from '../../context/WatchContext';
import { useGetBrendsQuery } from '../../apis/admin/brendApi'

const ProductBrendList = ({filter}) => {
    const { handleCategoryFilter, jeweleryArray, active, setActive  } = useContext(WatchContext);

    const {data, isLoading} = useGetBrendsQuery();
    const [brends, setBrends] = useState([])

    useEffect(() => {
        if (!isLoading && data) {
          setBrends(data.result);
        }
      }, [isLoading, data]);

    const handleBrendClick = (brend) => {
        handleCategoryFilter(brend);
        setActive(brend);
    };

    useEffect(() => {
        if (filter != null && brends.some(brend => brend.name === filter)) {
          handleBrendClick(filter);
        }
      }, [filter, brends]);

    return (
        <section className="sidebar-single-area product-categories-area">
            <h3 className="sidebar-single-area__title">Watch Brends</h3>
            <ul className="product-categories">
                {brends.map(brend => (
                    <li
                        key={brend.id}
                        onClick={() => handleBrendClick(brend.name)}
                        className={active === brend.name ? 'active' : ''}
                    >
                        {brend.name} ({brend.name === null ? jeweleryArray.length : jeweleryArray.filter(watch => watch.brend.name === brend.name).length})
                    </li>
                ))}
            </ul>
        </section>
    );
}

export default ProductBrendList;
