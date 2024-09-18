import React, { useEffect } from 'react';
import { Navigate, Outlet, useNavigate } from 'react-router-dom';
import { useUser } from '../../contexts/UserContext.jsx';

export default function ProtectedRoutes_user() {
    const { signOut } = useUser();
    const navigate = useNavigate();
    const signedIn = localStorage.getItem('signedIn');
    const signOutTime = localStorage.getItem('signOutTime');

    const checkUserStatus = () => {
        const currentTime = new Date().getTime();
        if (!signedIn || (signOutTime && currentTime > parseInt(signOutTime))) {
            signOut();
            navigate('/sign-in');
        }
    };

    useEffect(() => {
        checkUserStatus();
    }, [signedIn, signOutTime, signOut, navigate]);

    return signedIn ? <Outlet /> : <Navigate to="/sign-in"/>;
}