import React, { useState } from 'react'
import { toast } from 'react-toastify';
import { Rating } from '@mui/material';
import { useAddNewCommentMutation } from '../../apis/admin/commentApi';

const CommentFormSection = ({watchId, userId, onCommentSubmit}) => {

  if(!watchId && !userId){
    return <div>Loading...</div>
  }

  const [grade, setGrade] = useState(0);
  const [comment, setComment] = useState('');

  const [postCommentToWatchMutation] = useAddNewCommentMutation();

  const handleFormSubmit = async (e) => {
    e.preventDefault();

    if (!comment) {
      toast.error('Please fill out all fields.', { position: 'top-right' });
    } 
    else if(grade == 0){
      toast.error('Please fill out all fields.', { position: 'top-right' });
    }else {

      var result = await postCommentToWatchMutation({watchId:watchId, userId: userId, comment: comment, grade: grade});

      if(result.error){
        toast.error('Comment is not added. Try later!', { position: 'top-right' });
      }
      else{
        toast.success('Comment is added!', { position: 'top-right' });
      }     
      setGrade(0);
      setComment('');
      onCommentSubmit();
    }
  };

  return (
    <form onSubmit={handleFormSubmit} className='form-container'>
        <div>
          <div>
                <label htmlFor="commenter-comment">Grade<span></span></label>
                <Rating
                  name="simple-controlled"
                  value={grade}
                  onChange={(event, newValue) => {
                    setGrade(newValue);
                  }}
                />
            </div>
            <div>
                <label htmlFor="commenter-comment">Comment<span></span></label>
                <textarea 
                name="commenter-comment" 
                id="commenter-comment" 
                placeholder="Type Your Comment Here"
                value={comment}
                onChange={(e) => setComment(e.target.value)}
                ></textarea>
            </div>
        </div>

        <button type="submit" className="fz-1-banner-btn fz-comment-form__btn">Post Comment</button>
    </form>
  )
}

export default CommentFormSection