import React, {useEffect} from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';



const withAuth = (WrappedComponent) => {
  const WithAuth = (props) => {

    const navigate = useNavigate();
    const accessToken = localStorage.getItem("token");

    useEffect(() => {
      if (!accessToken) {
        navigate("/login");
      }
    }, [navigate, accessToken]);

    return <WrappedComponent {...props} />;
  };

  return WithAuth;
};

export default withAuth;