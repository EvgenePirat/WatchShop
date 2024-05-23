import React, { useState } from 'react'
import toast, { Toaster } from 'react-hot-toast';
import { useNavigate } from 'react-router-dom';
import "../../styles/user/createUser.css"
import { useRegisterNewUserMutation } from '../../../apis/admin/authApi';

function CreateUser() {

    const navigate = useNavigate();
    const [username, setUserName] = useState("")
    const [password, setPassword] = useState("")
    const [email, setEmail] = useState("")
    const [role, setRole] = useState("")

    const [addnewUserMutation] = useRegisterNewUserMutation();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const resultOperation = await addnewUserMutation({username,password,email, role});

        console.log(resultOperation)

        if(resultOperation.error)
            toast.error('User is not added');
        else
            toast.success('User is added');
    
        setUserName("");
        setPassword("");
        setEmail("");
    };


  return (
    <div className='createUser'>
    <div className="newUser">
        <h1 className="addUserTitle">New User</h1>
        <form className="addUserForm" onSubmit={handleSubmit}>
            <div className="addUserItem">
                <p>Phone number</p>
                <input type="number" placeholder="45678312" className='inputBrendStyle' value={username} onChange={(e) => setUserName(e.target.value)} />
            </div>
            <div className="addUserItem">
                <p>UserName</p>
                <input type="text" placeholder="gogle@gmail.com" className='inputBrendStyle' value={email} onChange={(e) => setEmail(e.target.value)} />
            </div>
            <div className="addUserItem">
                <p>Password</p>
                <input type="password" placeholder="*****" className='inputBrendStyle' value={password} onChange={(e) => setPassword(e.target.value)} />
            </div>
            <div className="addUserItem">
                <p>Role</p>
                <input type="text" placeholder="Client" className='inputBrendStyle' value={role} onChange={(e) => setRole(e.target.value)} />
            </div>
            <div className='userContainerButtons'>
                <button className="addUserButton">Create</button>
                <button className="backUserButton" onClick={() => navigate("/admin/users")}> Back</button>
            </div>
        </form>
    </div>
    <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default CreateUser