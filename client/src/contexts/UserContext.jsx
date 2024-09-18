import React, {createContext, useContext} from "react";

const UserContext = createContext(null);

export const useUser = () => {
    return useContext(UserContext);
};

export const UserContextProvider = ({ children }) => {
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

    return (
        <UserContext.Provider value={{ signIn, signOut }}>
            { children }
        </UserContext.Provider>
    );
};