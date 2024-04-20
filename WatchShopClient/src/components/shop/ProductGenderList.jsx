import React, { useContext, useEffect, useState } from 'react';
import { FarzaaContext } from '../../context/FarzaaContext';
import { useGetWatchCharacteristicsQuery } from '../../apis/admin/watchApi';
import { useLocation } from 'react-router-dom';

const ProductGenderList = () => {
    const { handleGenderFilter, jeweleryArray, active, setActive } = useContext(FarzaaContext);

    const {data, isLoading} = useGetWatchCharacteristicsQuery()
    const [genders, setGenders] = useState([])

    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const filter = searchParams.get('filter');

    useEffect(() => {
        if (!isLoading && data) {
            setGenders(data.result.genderEnums);
        }
      }, [isLoading, data]);
    
      useEffect(() => {
        console.log(filter)
        if (filter != null) {
            if(filter == 'Men' || filter == 'Women' || filter == 'Unisex'){
                handleGenderClick(filter);
            }
        }
      }, [filter]);

    const handleGenderClick = (gender) => {
        handleGenderFilter(gender);
        setActive(gender);
    };

    return (
        <section className="sidebar-single-area product-categories-area">
            <h3 className="sidebar-single-area__title">Watch Genders</h3>
            <ul className="product-categories">
                {genders.map((gender, index) => (
                    <li
                        key={index}
                        onClick={() => handleGenderClick(gender)}
                        className={active === gender ? 'active' : ''}
                    >
                        {gender} ({gender === null ? jeweleryArray.length : jeweleryArray.filter(watch => watch.gender === gender).length})
                    </li>
                ))}
            </ul>
        </section>
    );
}

export default ProductGenderList;
