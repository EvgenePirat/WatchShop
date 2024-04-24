import React, { useContext, useEffect, useState } from 'react';
import { FarzaaContext } from '../../context/FarzaaContext';
import { useGetWatchCharacteristicsQuery } from '../../apis/admin/watchApi';

const ProductStyleList = ({filter}) => {
    const { handleStyleFilter, jeweleryArray, active, setActive  } = useContext(FarzaaContext);

    const {data, isLoading} = useGetWatchCharacteristicsQuery()
    const [styles, setStyles] = useState([])

    useEffect(() => {
        if (!isLoading && data) {
            setStyles(data.result.styles);
        }
      }, [isLoading, data]);

    const handleStyleClick = (style) => {
        handleStyleFilter(style);
        setActive(style);
    };

    useEffect(() => {
        if (filter != null) {
            if(filter == 'Fashion' || filter == 'Children' || filter == 'Sport' || filter == 'Classic'){
                handleStyleClick(filter);
            }
        }
      }, [filter]);

    return (
        <section className="sidebar-single-area product-categories-area">
            <h3 className="sidebar-single-area__title">Watch Styles</h3>
            <ul className="product-categories">
                {styles.map(style => (
                    <li
                        key={style.id}
                        onClick={() => handleStyleClick(style.name)}
                        className={active === style.name ? 'active' : ''}
                    >
                        {style.name} ({style.name === null ? jeweleryArray.length : jeweleryArray.filter(watch => watch.style.name === style.name).length})
                    </li>
                ))}
            </ul>
        </section>
    );
}

export default ProductStyleList;
