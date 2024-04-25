import React, { useState } from 'react';
import { toast } from 'react-toastify';

const AccountFormSection = ({user}) => {

  const [firstName, setFirstName] = useState(user.firstName);
  const [lastName, setLastName] = useState(user.lastName);
  const [email, setEmail] = useState(user.email ? user.email : '');
  const [phoneNumber, setPhoneNumber] = useState(user.userName ? user.userName : '');

  const handleFormSubmit = async (e) => {
    e.preventDefault();

    if (!firstName || !lastName || !email || !phoneNumber) {
      toast.error('Please fill out all fields.', { position: 'top-right' });
    } else if (!isValidEmail(email)) {
      toast.warning('Please provide a valid email address.', { position: 'top-right' });
    } else {


    }
  };

  const isValidEmail = (email) => {
    // Basic email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  };

  return (
    <form action="#" onSubmit={handleFormSubmit}>
      <div className="row g-xl-4 g-3">
        <div className="col-6 col-xxs-12">
          <input
            type="text"
            name="commenter-first-name"
            id="commenter-first-name"
            placeholder="First Name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
        </div>
        <div className="col-6 col-xxs-12">
          <input
            type="text"
            name="commenter-last-name"
            id="commenter-last-name"
            placeholder="Last Name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
        </div>
        <div className="col-6 col-xxs-12">
          <input
            type="email"
            name="commenter-email"
            id="commenter-email"
            placeholder="Email Address"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div className="col-6 col-xxs-12">
          <input
            type="text"
            name="commenter-number"
            id="commenter-number"
            placeholder="Phone Number"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </div>
      </div>

      <button type="submit" className="fz-1-banner-btn fz-comment-form__btn">
        Update Account
      </button>
    </form>
  );
};

export default AccountFormSection;
