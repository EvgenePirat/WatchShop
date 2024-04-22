import React, { useState } from 'react'
import '../../styles/user/userEdit.css'
import { useLocation } from 'react-router-dom';
import { useUpdateUserMutation } from '../../../apis/admin/userApi';
import toast, { Toaster } from 'react-hot-toast';

function User() {

  const location = useLocation();

  const { user } = location.state || {};

  const [userUpdate, setUserUpdate] = useState(user);
  const [userDetail, setUserDetail] = useState(user);

  const [updateUserMutation] = useUpdateUserMutation();

  
  const handleUpdateUser= async (e) => {
    e.preventDefault();

    console.log(userUpdate)

    var result = await updateUserMutation(userUpdate);

    if(result.data.isSuccess){
        toast.success('User is update');
        setUserDetail(userUpdate)
    }
    else
        toast.error('User is not update');
}

  return (
    <div className='userEdit'> 
      <div className="userTitleContainerEdit">
        <h1 className="userTitle">Edit User</h1>
      </div>
      <div className="userContainer">
        <div className="userShow">
            <span className="userUpdateTitle">Details</span>
          <div className="userShowBottom">
            <span className="userShowTitle">UserName</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.userName}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="userShowTitle">Role</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.role}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="userShowTitle">FirstName</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.firstName ?? '-'}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="userShowTitle">LastName</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.lastName ?? '-'}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="userShowTitle">Email</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.email ?? '-'}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="userShowTitle">City</span>
            <div className="userShowInfo">
              <span className="userShowInfoTitle">{userDetail.city ?? '-'}</span>
            </div>
          </div>
        </div>
        <div className="userUpdate">
          <span className="userUpdateTitle">Edit</span>
          <form className="userUpdateForm" onSubmit={handleUpdateUser}>
            <div className="userUpdateLeft">
              <div className="userUpdateItem">
                <label>UserName</label>
                <input
                  type="text"
                  placeholder={userUpdate.userName}
                  className="brendUpdateInput"
                  value={userUpdate.userName}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, userName : e.target.value}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>Role</label>
                <input
                  type="text"
                  placeholder={userUpdate.role}
                  className="brendUpdateInput"
                  value={userUpdate.role}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, role : e.target.value}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>FirstName</label>
                <input
                  type="text"
                  placeholder={userUpdate.firstName}
                  className="brendUpdateInput"
                  value={userUpdate.firstName}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, firstName : e.target.value}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>LastName</label>
                <input
                  type="text"
                  placeholder={userUpdate.lastName}
                  className="brendUpdateInput"
                  value={userUpdate.lastName}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, lastName : e.target.value}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>Email</label>
                <input
                  type="text"
                  placeholder={userUpdate.email}
                  className="brendUpdateInput"
                  value={userUpdate.email}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, email : e.target.value}))}
                />
              </div>

              <div className="userUpdateItem">
                <label>City</label>
                <input
                  type="text"
                  placeholder={userUpdate.city}
                  className="brendUpdateInput"
                  value={userUpdate.city}
                  onChange={(e) => setUserUpdate((prev) => ({...prev, city : e.target.value}))}
                />
              </div>

              <button className="userUpdateButton">Update</button>
            </div>
          </form>
          <Toaster position="bottom-right" reverseOrder={false} />
        </div>
      </div>

    </div>
  )
}

export default User