import React, {useState} from "react";
import bcrypt from "bcryptjs";

export default function SignInForm(props) {
    const { handleSignIn } = props;
    const [user, setUser] = useState({
        email: "",
        password: ""
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const onSubmit = e => {
        e.preventDefault();
        handleSignIn(user);
/*        bcrypt.genSalt(10)
            .then(salt => bcrypt.hash(user.password, salt))
            .then(hashedPassword => {
                const newUser = { ...user, password: hashedPassword };
                return handleSignIn(newUser);
            })
            .then(() => setUser({ email: '', password: '' }))
            .catch(error => console.error('Error hashing password:', error))*/
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <input
                    value={user.username}
                    onChange={handleChange}
                    placeholder="Email"
                    type="email"
                    name="email"
                    id="username-sign-in"
                />
            </div>
            <div>
                <input
                    value={user.password}
                    onChange={handleChange}
                    placeholder="Password"
                    type="password"
                    name="password"
                    id="password-sign-in"
                />
            </div>

            <button type="submit">Sign In</button>

        </form>
    );
}