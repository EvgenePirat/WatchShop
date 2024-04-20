import React, {useEffect} from 'react';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";



const withAuthAdmin = (WrappedComponent) => {
  const withAuthAdmin = (props) => {

    const navigate = useNavigate();
    const accessToken = localStorage.getItem("token") ?? "";

    useEffect(() => {
      if (accessToken) {
        const {role} = jwtDecode(accessToken);

        if(role !== 'Admin'){
            navigate("/error")
        }
      }
      else{
        navigate("/login");
      }
    }, [navigate, accessToken]);

    return <WrappedComponent {...props} />;
  };

  return withAuthAdmin;
};

export default withAuthAdmin;