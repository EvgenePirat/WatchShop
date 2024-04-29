import React, { useState } from 'react'
import { toast } from 'react-toastify';
import { Rating } from '@mui/material';
import { useAddNewCommentMutation, useUpdateCommentMutation } from '../../apis/admin/commentApi';

const CommentFormSection = ({watchId, userId, onCommentSubmit, alreadyComment}) => {

  if(!watchId && !userId && !alreadyComment){
    return <div>Loading...</div>
  }

  const [grade, setGrade] = useState(alreadyComment != null ? alreadyComment.grade : 0);
  const [comment, setComment] = useState(alreadyComment != null ? alreadyComment.comment : '');

  const [postCommentToWatchMutation] = useAddNewCommentMutation();
  const [updateCommentMutation] = useUpdateCommentMutation();

  const handleFormSubmit = async (e) => {
    e.preventDefault();

    if (!comment) {
      toast.error('Please fill out all fields.', { position: 'top-right' });
    } 
    else if(grade == 0){
      toast.error('Please fill out all fields.', { position: 'top-right' });
    }else {

      var result = null;

      if(alreadyComment != null){
        result = await updateCommentMutation({id: alreadyComment.id, watchId:watchId, userId: userId, comment: comment, grade: grade});
        updateCommentMutation.invalidateQueries('Comments');
      }
      else{
        result = await postCommentToWatchMutation({watchId:watchId, userId: userId, comment: comment, grade: grade});
        postCommentToWatchMutation.invalidateQueries('Comments');
      }

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

        <button type="submit" className="fz-1-banner-btn fz-comment-form__btn">{alreadyComment ? "Update Comment" : "Post Comment"}</button>
    </form>
  )
}

export default CommentFormSection