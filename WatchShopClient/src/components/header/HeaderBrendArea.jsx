import React, { useContext } from 'react'
import { WatchContext } from '../../context/WatchContext'
import { useGetBrendsQuery } from '../../apis/admin/brendApi'
import { Link } from 'react-router-dom'

const HeaderBrendArea = ({header}) => {

    const {data, isLoading} = useGetBrendsQuery(null)

    const {
        isCategoryOpen,
        handleCategoryBtn,
        categoryBtnRef,
    } = useContext(WatchContext)
    
  return (
    <div className={`fz-category-area ${header}`} ref={categoryBtnRef}>
        <button className="fz-category-btn" onClick={handleCategoryBtn}>
            <i className="fa-solid fa-grid"></i>
            <span>Brends</span>
        </button>

        <div className={`fz-category-menu ${isCategoryOpen? 'open':''}`}>
            <div className="row gx-3 gx-md-5 gy-5">
            {isLoading ? (
            <div>Loading...</div>
        ) : data ? (
            <React.Fragment>
                <div className="col-md-4 col-6">
                    <ul className="fz-category-list">
                        {data.result.length > 0 && 
                            data.result.slice(0, Math.ceil(data.result.length / 3)).map((brend, index) => (
                                <li key={index}><Link to={{ pathname: '/shop', search: `?filter=${brend.name}` }}>{brend.name}({brend.countWatches})</Link></li>
                            ))
                        }
                    </ul>
                </div>
                <div className="col-md-4 col-6">
                    <ul className="fz-category-list">
                        {data.result.length > 0 && 
                            data.result.slice(Math.ceil(data.result.length / 3), Math.ceil(2 * data.result.length / 3)).map((brend, index) => (
                                <li key={index}><Link to={{ pathname: '/shop', search: `?filter=${brend.name}` }}>{brend.name}({brend.countWatches})</Link></li>
                            ))
                        }
                    </ul>
                </div>
                <div className="col-md-4 col-6">
                    <ul className="fz-category-list">
                        {data.result.length > 0 && 
                            data.result.slice(Math.ceil(2 * data.result.length / 3)).map((brend, index) => (
                                <li key={index}><Link to={{ pathname: '/shop', search: `?filter=${brend.name}` }}>{brend.name}({brend.countWatches})</Link></li>
                            ))
                        }
                    </ul>
                </div>
            </React.Fragment>
        ) : (
            <div>No data available.</div>
        )}
            </div>
        </div>
    </div>
  )
}

export default HeaderBrendArea