import React, { useState } from 'react'
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useLoginMutation } from '../../apis/admin/authApi';

const SignInFormSection = () => {
    const [userName,setUserName] = useState('')
    const [password,setPassword] = useState('')
    const [error, setError] = useState('')

    const [loginInSystem] = useLoginMutation();

    const handleFormSubmit = async (e) => {
        e.preventDefault();
    
        if (!userName && !password) {
            toast.error('Please fill out all fields.', { position: 'top-right' });
        } else if (!password) {
            toast.warning('Please provide password.', { position: 'top-right' });
        } else if(!userName){
            toast.warning('Please provide user name.', { position: 'top-right' });
        }
         else {
    
            const response = await loginInSystem({
                username: userName,
                password: password
            });

            if(response.data){
                toast.success('Signed In successfully!', { position: 'top-right' });
                setUserName('');
                setPassword('');
                console.log(response.data)
            } else if(response.error){
                toast.error(response.error.data.description, { position: 'top-right' });
                setError(response.error.data.description);
            }
        }
      };
    
  return (
    <form action="#" onSubmit={handleFormSubmit}>
        <input 
        type="text" 
        name="login-username" 
        id="login-username" 
        placeholder="Phone number"
        required
        value={userName}
        onChange={(e) => setUserName(e.target.value)}
        />
        <input 
        type="password" 
        name="login-password" 
        id="login-password" 
        required
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        />
        <div className="sign-in-checkbox-container d-flex justify-content-between">
            <Link to="/registration" className="password-recovery-btn">Registration</Link>
        </div>

        {error && <p className='text-danger'>{error}</p>}

        <button type="submit" className="fz-1-banner-btn single-form-btn">Log in</button>
    </form>
  )
}

export default SignInFormSection