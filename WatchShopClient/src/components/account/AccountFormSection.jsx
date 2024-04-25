import React, { useState } from 'react';
import { toast } from 'react-toastify';
import { useDeleteUserMutation, useUpdateUserMutation } from '../../apis/admin/userApi';
import { useNavigate } from 'react-router-dom';

const AccountFormSection = ({user}) => {

    if (!user) {
        return <div>...Loading</div>;
    }

    const [firstName, setFirstName] = useState(user.firstName);
    const [lastName, setLastName] = useState(user.lastName);
    const [email, setEmail] = useState(user.email ? user.email : '');
    const [city, setCity] = useState(user.city ? user.city : '');

    const [userUpdateMutation] = useUpdateUserMutation();
    const [deleteUserMutation] = useDeleteUserMutation();
    const navigate = useNavigate();

    const handleDeleteAccount = () => {
        const result = deleteUserMutation(user.id)

        result.then(response => {
            console.log(response);
            if (response.data) {
                toast.success("Your account is deleted")
            } else {
                toast.error('Your account is not deleted. Try later!')
            }
        })

        localStorage.removeItem("token");
        navigate("/");
    }

    const handleFormSubmit = async (e) => {
        e.preventDefault();

        if (!isValidEmail(email)) {
            toast.warning('Please provide a valid email address.', { position: 'top-right' });
        } else {

            var result = await userUpdateMutation({id: user.id, firstName: firstName, lastName: lastName, userName: user.userName, email: email, city: city, role: user.role});

            console.log(result)

            if(result.error){
                toast.error('User is not update');
            }
            else
                toast.success('User is update');
            }
    };

    const isValidEmail = (email) => {
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
                placeholder="City"
                value={city}
                onChange={(e) => setCity(e.target.value)}
            />
            </div>
        </div>

        <button type="submit" className="fz-1-banner-btn fz-comment-form__btn">
            Update
        </button>

        <button className="fz-1-banner-btn-delete fz-comment-form__btn_delete" onClick={handleDeleteAccount}>
            Delete
        </button>
        </form>
    );
};

export default AccountFormSection;
