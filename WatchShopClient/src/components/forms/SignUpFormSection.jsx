import React, { useState } from 'react'
import { toast } from 'react-toastify';
import { Link } from 'react-router-dom';
import { useRegisterNewUserMutation } from '../../apis/admin/authApi';

const SignUpFormSection = () => {
    const [userName,setUserName] = useState('')
    const [password,setPassword] = useState('')
    const [email,setEmail] = useState('')

    const [registrationNewUser] = useRegisterNewUserMutation()

    const isValidEmail = (email) => {

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
    };

    const handleFormSubmit = async (e) => {
        e.preventDefault();
    
        if (!userName && !password && !email) {
            toast.error('Please fill out all fields.', { position: 'top-right' });
        } else if (!password) {
            toast.warning('Please provide password.', { position: 'top-right' });
        } else if(!userName){
            toast.warning('Please provide user name.', { position: 'top-right' });
        } else if (!isValidEmail(email) || !email) {
            toast.warning('Please provide a valid email address.', { position: 'top-right' });
        } else {
    
            try{
                const response = await registrationNewUser({
                    username: userName,
                    password: password,
                    email: email,
                    role: 'Client'
                });
                
                if(response.data){
                    toast.success('Registered successfully!', { position: 'top-right' });
                    setUserName('');
                    setPassword('');
                    setEmail('');
                } else if(response.error){
                    toast.error(response.error.data.description, { position: 'top-right' });
                }
            }catch (error){
                toast.error('Error registration', { position: 'top-right' });
            }

        }
      };

    
  return (
    <form action="#" onSubmit={handleFormSubmit}>
        <input 
        type="text" 
        name="register-username" 
        id="register-username" 
        placeholder="Phone number"
        required
        value={userName}
        onChange={(e) => setUserName(e.target.value)}
        />
        <input 
        type="email" 
        name="register-email" 
        id="register-email" 
        placeholder="Email Address"
        required
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        />
        <input 
        type="password" 
        name="register-password" 
        id="register-password" 
        placeholder="Password"
        required
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        />

        <div className="sign-in-checkbox-container d-flex justify-content-between">
            <Link to="/login" className="password-recovery-btn">Login</Link>
        </div>

        <button type="submit" className="fz-1-banner-btn single-form-btn">Register</button>
    </form>
  )
}

export default SignUpFormSection