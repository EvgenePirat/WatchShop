import React from 'react'
import AccountFormSection from './AccountFormSection';

function AccountDescTabPane({user}) {

  return (
    <div className="container">
        <div className="fz-inner-contact-details">
            <div className="fz-inner-contact-details__left">
                <div className="fz-blog-details__comment-form">
                    <h4 className="fz-comment-form__title fz-inner-contact-details__title">Details</h4>
                    <AccountFormSection user={user} />
                </div>
            </div>
        </div>
    </div>
  )
}

export default AccountDescTabPane