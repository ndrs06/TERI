import React from 'react';
import {useNavigate} from "react-router-dom";

import SignUpForm from "../components/SignUp/SignUpForm.jsx"

const postSignUp = (user) => {
    return fetch('/api/auth/sign-up', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(user)
    }).then(resp => {
        if (!resp.ok) {
            throw new Error(`HTTP error! status: ${resp.status}`);
        }
        return resp
    }).catch(err => {
        console.error('Error:', err);
    });
}

export default function SignUp() {
    const navigate = useNavigate();

    const handleSignUp = (user) => {
        postSignUp(user).then( resp => resp.ok ? navigate("/") : navigate("/sign-up"))
    }

    const props = {
        handleSignUp
    }
    
    return (
        <>
            <SignUpForm {...props}/>
        </>
    );
}
