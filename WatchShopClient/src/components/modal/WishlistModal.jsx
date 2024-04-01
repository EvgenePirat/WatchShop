import { Modal } from 'react-bootstrap';
import { useContext } from 'react';
import WishlistItemTable from '../wishlist/WishlistItemTable';
import { FarzaaContext } from '../../context/FarzaaContext';
import { useNavigate } from 'react-router-dom';

const WishlistModal = ({ wishlistArray, removeItem }) => {
  const { showWishlist, handleWishlistClose, addWishlistToCart } = useContext(FarzaaContext);
    const navigate = useNavigate(); // Initialize the useNavigate hook

    // Function to close the modal and navigate
    const closeAndNavigate = (path) => {
      handleWishlistClose();
      navigate(path);
    };
  return (
    <Modal show={showWishlist} onHide={handleWishlistClose} className="cart-area cart-area-modal fz-wishlist-modal" id="wishlist-modal-area" size="xl" centered>
      <Modal.Header className="cart__header">
      <h3 className="cart__title">Your Wishlist</h3>
      <button className="cart-area-modal-close-btn" onClick={handleWishlistClose}><i className="fa-regular fa-xmark"></i></button>
      </Modal.Header>
  
      <Modal.Body className="cart__body">
          <WishlistItemTable wishlistArray={wishlistArray} removeItem={removeItem}/>

          {wishlistArray.length === 0 ? (
            <div className="cart-left-actions d-flex justify-content-end">
              <button onClick={() => closeAndNavigate('/shop')} className="fz-1-banner-btn update-cart-btn">Go to Shop</button>
            </div>
          ):(
            <div className="cart-left-actions d-flex justify-content-between">
              <button onClick={() => closeAndNavigate("/wishlist")} className="fz-1-banner-btn update-cart-btn">Go to Wishlist</button>
              <button className="fz-1-banner-btn update-cart-btn" onClick={addWishlistToCart}>Add to Cart</button>
            </div>
          )}
      </Modal.Body>
    </Modal>
  );
};

export default WishlistModal;
