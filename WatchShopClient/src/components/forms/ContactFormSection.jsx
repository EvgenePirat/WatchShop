import React, { useState } from 'react';
import { toast } from 'react-toastify';
import { useSelector } from 'react-redux';
import { usePostMessageTelegramMutation } from '../../apis/admin/messageApi';

const ContactFormSection = () => {

  const userAuth = useSelector(state => state.userAuthStore);

  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState(userAuth.email ? userAuth.email : '');
  const [phoneNumber, setPhoneNumber] = useState(userAuth.username ? userAuth.username : '');
  const [comment, setComment] = useState('');

  const [postMessageMutation] = usePostMessageTelegramMutation();

  const handleFormSubmit = async (e) => {
    e.preventDefault();

    if (!firstName || !lastName || !email || !phoneNumber || !comment) {
      toast.error('Please fill out all fields.', { position: 'top-right' });
    } else if (!isValidEmail(email)) {
      toast.warning('Please provide a valid email address.', { position: 'top-right' });
    } else {

      var result = await postMessageMutation({firstName: firstName, lastName: lastName, email: email, phone: phoneNumber, message: comment })

      console.log(result)

      if(result.error){
        toast.error('Form not submitted. Try later!')
      }else{
        toast.success('Message submitted successfully! Check response on your email!', { position: 'top-right' });
        setFirstName('');
        setLastName('');
        setEmail('');
        setPhoneNumber('');
        setComment('');
      }
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
        <div className="col-12">
          <textarea
            name="commenter-comment"
            id="commenter-comment"
            placeholder="Your Message"
            value={comment}
            onChange={(e) => setComment(e.target.value)}
          ></textarea>
        </div>
      </div>

      <button type="submit" className="fz-1-banner-btn fz-comment-form__btn">
        Send Message
      </button>
    </form>
  );
};

export default ContactFormSection;
