import React from 'react';
import {useNavigate} from "react-router-dom";
import {useUser} from "../contexts/UserContext.jsx";

import SignInForm from "../components/SignIn/SignInForm.jsx"

const postSignIn = (user) => {
    return fetch('/api/auth/sign-in', {
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

export default function SignIn() {
    const navigate = useNavigate();
    const { signIn } = useUser();

    const handleSignIn = (user) => {
        postSignIn(user).then( resp => {
            signIn();
            resp.ok ? navigate("/") : navigate("/sign-in")
        })
    }

    const props = {
        handleSignIn
    }

    return (
        <>
            <SignInForm {...props}/>
        </>
    );
}
