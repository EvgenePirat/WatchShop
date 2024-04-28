import React, { useState } from 'react'
import CommentFormSection from '../forms/CommentFormSection';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';

const ProductReviewTabPane = ({watch}) => {

    const [isShowForm, setIsShowForm] = useState(false);
    const userAuth = useSelector(state => state.userAuthStore);
    const navigate = useNavigate();

    const handleToggleComment = () => {
        if(userAuth.id.length != 0){
            setIsShowForm(!isShowForm);
        }
        else{
            navigate("/login")
        }
    };

    const handleCommentSubmit = () => {
        setIsShowForm(false);
    }

    const calculateAverageRating = (comments) => {
        if (comments.length === 0) {
          return 0;
        }
        let totalRating = 0;

        comments.forEach(comment => {
          totalRating += comment.grade;
        });

        const averageRating = totalRating / comments.length;
      
        return averageRating;
      }

    const getAmountOfReviewsByRating = (rating) => {
        return watch.comments.filter(review => review.grade === rating).length;
     };

    console.log(watch);

    const averageRating = calculateAverageRating(watch.comments);

  return (
    <div className="fz-product-details__review">
        <div className="review-overview">
            <div className="average-rating-area">
                {!isShowForm && <button className="fz-1-banner-btn fz-comment-form__btn" onClick={handleToggleComment}>
                    Add Comment
                </button>} 
                {isShowForm && <CommentFormSection watchId={watch.id} userId={userAuth.id} onCommentSubmit={handleCommentSubmit}  /> } 
            </div>
            <div className="average-rating-area">
                <h3><span>{averageRating}</span><span>/5</span></h3>
                <span className="rating-amount">{watch.comments.length} ratings</span>
            </div>

            <div className="review-breakdown">
                {[5, 4, 3, 2, 1].map((rating, index) => (
                    <ul key={index} className={`individual-star-breakdown individual-star-breakdown-${rating}`}>
                        <li className="star">
                            {[...Array(rating)].map((_, i) => (
                                <i key={i} className="fa-solid fa-star"></i>
                            ))}
                            {[...Array(5 - rating)].map((_, i) => (
                                <i key={i} className="fa-light fa-star"></i>
                            ))}
                        </li>
                        <li>
                            <div className="bar">
                                <div className="individual-star-breakdown-2 filled"></div>
                            </div>
                        </li>
                        <li>
                            <div className="each-star-amount">{getAmountOfReviewsByRating(rating)}</div>
                        </li>
                    </ul>
                ))}
            </div>
        </div>

        <div className="user-reviews">
            <h4 className="reviews-title">Reviews of this product</h4>
            <div className="row g-4">
                <div className="col-xl-6">
                    <div className="single-review">
                        <div className="user">
                            <div className="user-img">
                                <img src="assets/images/user-1.png" alt="user"/>
                            </div>
                            <div className="user-info">
                                <h6 className="user-name">Eliza nolan</h6>
                                <div className="user-rating">
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-light fa-star"></i>
                                </div>
                            </div>
                        </div>

                        <div className="review">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit voluptatum quaerat nemo eaque delectus ratione maiores expedita pariatur illum facilis at repellendus nesciunt veniam animi, omnis corrupti reiciendis explicabo itaque id. Maxime consequatur recusandae fugiat accusamus ipsam reiciendis, officiis esse assumenda voluptas aspernatur consequuntur? Eaque sed quibusdam ipsum saepe nulla!
                            </p>
                        </div>
                    </div>
                </div>
                <div className="col-xl-6">
                    <div className="single-review">
                        <div className="user">
                            <div className="user-img">
                                <img src="assets/images/user-2.png" alt="user"/>
                            </div>
                            <div className="user-info">
                                <h6 className="user-name">Abu Amer</h6>
                                <div className="user-rating">
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-light fa-star"></i>
                                    <i className="fa-light fa-star"></i>
                                </div>
                            </div>
                        </div>

                        <div className="review">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit voluptatum quaerat nemo eaque delectus ratione maiores expedita pariatur illum facilis at repellendus nesciunt veniam animi, omnis corrupti reiciendis explicabo itaque id. Maxime consequatur recusandae fugiat accusamus ipsam reiciendis, officiis esse assumenda voluptas aspernatur consequuntur? Eaque sed quibusdam ipsum saepe nulla!
                            </p>
                        </div>
                    </div>
                </div>
                <div className="col-xl-6">
                    <div className="single-review">
                        <div className="user">
                            <div className="user-img">
                                <img src="assets/images/user-3.png" alt="user"/>
                            </div>
                            <div className="user-info">
                                <h6 className="user-name">Brunt glenn</h6>
                                <div className="user-rating">
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                </div>
                            </div>
                        </div>

                        <div className="review">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit voluptatum quaerat nemo eaque delectus ratione maiores expedita pariatur illum facilis at repellendus nesciunt veniam animi, omnis corrupti reiciendis explicabo itaque id. Maxime consequatur recusandae fugiat accusamus ipsam reiciendis, officiis esse assumenda voluptas aspernatur consequuntur? Eaque sed quibusdam ipsum saepe nulla!
                            </p>
                        </div>
                    </div>
                </div>
                <div className="col-xl-6">
                    <div className="single-review">
                        <div className="user">
                            <div className="user-img">
                                <img src="assets/images/user-4.png" alt="user"/>
                            </div>
                            <div className="user-info">
                                <h6 className="user-name">chad hossain</h6>
                                <div className="user-rating">
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-solid fa-star"></i>
                                    <i className="fa-light fa-star"></i>
                                </div>
                            </div>
                        </div>

                        <div className="review">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit voluptatum quaerat nemo eaque delectus ratione maiores expedita pariatur illum facilis at repellendus nesciunt veniam animi, omnis corrupti reiciendis explicabo itaque id. Maxime consequatur recusandae fugiat accusamus ipsam reiciendis, officiis esse assumenda voluptas aspernatur consequuntur? Eaque sed quibusdam ipsum saepe nulla!
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  )
}

export default ProductReviewTabPane