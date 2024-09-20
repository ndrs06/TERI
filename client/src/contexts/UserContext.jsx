import React, {createContext, useContext, useState} from "react";

const UserContext = createContext(null);

export const useUser = () => {
    return useContext(UserContext);
};

export const UserContextProvider = ({ children }) => {
    const [userProfile, setUserProfile] = useState(null);
    const signIn = () => {
        localStorage.setItem('signedIn', true);
        const signOutTime = new Date();
        signOutTime.setMinutes(signOutTime.getMinutes() + 30);
        localStorage.setItem('signOutTime', signOutTime.getTime());
    }

    const signOut = () => {
        localStorage.removeItem('signedIn');
        localStorage.removeItem('signOutTime' );
    }
    
    const props = {
        userProfile,
        setUserProfile,
        signIn,
        signOut,
    }

    return (
        <UserContext.Provider value={{...props}}>
            { children }
        </UserContext.Provider>
    )
};