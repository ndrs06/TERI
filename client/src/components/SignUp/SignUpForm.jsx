import React, {useState} from "react";
import bcrypt from 'bcryptjs';

export default function SignUpForm(props) {
    const { handleSignUp } = props;
    const [user, setUser] = useState({
        email: "",
        username: "",
        password: ""
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const onSubmit = async e => {
        e.preventDefault();
        handleSignUp(user)
/*        bcrypt.genSalt(10)
            .then(salt => bcrypt.hash(user.password, salt))
            .then(hashedPassword => {
                const newUser = { ...user, password: hashedPassword };
                return handleSignUp(newUser);
            })
            .then(() => setUser({ email: '', username: '', password: '' }))
            .catch(error => console.error('Error hashing password:', error))*/
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <input
                    value={user.email}
                    onChange={handleChange}
                    placeholder="Email"
                    type="email"
                    name="email"
                    id="email-sign-up"
                />
            </div>
            <div>
                <input
                    value={user.username}
                    onChange={handleChange}
                    placeholder="Username"
                    type="text"
                    name="username"
                    id="username-sign-up"
                />
            </div>
            <div>
                <input
                    value={user.password}
                    onChange={handleChange}
                    placeholder="Password"
                    type="password"
                    name="password"
                    id="password-sign-up"
                />
            </div>

            <button type="submit">Sign Up</button>

        </form>
    );
}