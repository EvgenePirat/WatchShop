import { WatchContext } from '../../context/WatchContext';
import React, { useContext } from 'react'

const SearchFilter = () => {
  const {searchTerm,handleSearchChange} = useContext(WatchContext)
  return (
    <section className="sidebar-single-area product-search-area">
    <h3 className="sidebar-single-area__title">Search Watches</h3>
    <form role="search" className="fz-product-search-form">
        <input
            type="search"
            id="woocommerce-product-search-field-0"
            className="search-field"
            placeholder="Search products…"
            value={searchTerm}
            onChange={handleSearchChange}
        />
        <button type="submit" value="Search"><i className="fa-light fa-magnifying-glass"></i></button>
    </form>
</section>
  )
}

export default SearchFilter