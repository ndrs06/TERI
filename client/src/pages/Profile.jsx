import React from 'react';
import { useUser } from '../contexts/UserContext.jsx';

export default function Profile() {
    const { userProfile, setUserProfile } = useUser();
    
    return (
        <div>
            <button onClick={_ => console.log(userProfile)}>haló?</button>
            <h1></h1>
        </div>
    );
}
