import React, { useState, useEffect } from 'react'
import CommentFormSection from '../forms/CommentFormSection';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Rating } from '@mui/material';
import { useGetCommentByWatchNameModelQuery } from '../../apis/admin/commentApi';

const ProductReviewTabPane = ({watch}) => {

    const [isShowForm, setIsShowForm] = useState(false);
    const userAuth = useSelector(state => state.userAuthStore);
    const navigate = useNavigate();
    const userItems = useSelector(state => state.userItemsStore.userItems);
    const [comments, setComments] = useState([])

    const {data, isLoading} = useGetCommentByWatchNameModelQuery(watch.nameModel);

    useEffect(() => {
        if (!isLoading && data) {
            setComments(data.result);
        }
    }, [data, isLoading]);

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
        return comments.filter(review => review.grade === rating).length;
    };

    const averageRating = calculateAverageRating(comments);

    const [page, setPage] = useState(1);
    const pageSize = 6;

    const startIndex = (page - 1) * pageSize;
    const endIndex = page * pageSize;

    const paginatedComments = comments.slice(startIndex, endIndex);

    const goToPage = (pageNumber) => {
        setPage(pageNumber);
    };

    if(userItems.length == 0){
        return <div>Loading...</div>
    }
    
    const isUserAlreadyCommented = () => {
        const alreadyCommented = comments.find(comment => comment.userId === userAuth.id);
        return alreadyCommented;
    };

    const alreadyComment = isUserAlreadyCommented();

  return (
    <div className="fz-product-details__review">
        <div className="review-overview">
            <div className="average-rating-area">
                {!isShowForm && (
                    <button className="fz-1-banner-btn fz-comment-form__btn" onClick={handleToggleComment}>
                        {alreadyComment ? "Update Comment" : "Add Comment"}
                    </button>
                )}
                {isShowForm && <CommentFormSection watchId={watch.id} userId={userAuth.id} onCommentSubmit={handleCommentSubmit} alreadyComment={alreadyComment} />}
            </div>
            <div className="average-rating-area">
                <h3><span>{(Math.round(averageRating * 10) / 10).toFixed(1)}</span><span>/5</span></h3>
                <span className="rating-amount">{comments.length} ratings</span>
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
                            <div className="each-star-amount">({getAmountOfReviewsByRating(rating)})</div>
                        </li>
                    </ul>
                ))}
            </div>
        </div>

        {paginatedComments.length != 0 && <div className="user-reviews">
            <h4 className="reviews-title">Reviews of this product</h4>
            <div className="row g-4">
                {paginatedComments.map((comment, index) => (
                    <div className="col-xl-6" key={index}>
                        <div className="single-review">
                            <div className="user">
                                <div className="user-info">
                                    <h6 className="user-name">{userItems.filter((user) => user.id == comment.userId)[0].userName}</h6>
                                    <div className="user-rating">
                                        <Rating name="read-only" value={comment.grade} readOnly />
                                    </div>
                                </div>
                            </div>
                            <div className="review">
                                <p>{comment.comment}</p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
            <div className="pagination">
                {Array.from({ length: Math.ceil(comments.length / pageSize) }, (_, i) => i + 1).map((pageNumber) => (
                    <button key={pageNumber} onClick={() => goToPage(pageNumber)}>{pageNumber}</button>
                ))}
            </div>
        </div>}
    </div>
  )
}

export default ProductReviewTabPane