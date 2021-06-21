import React, { useState }from 'react';

export default function LoginForm(props) {
    const [ username, setUsername ] = useState('');
    const [ password, setPassword ] = useState('');

    return (
        <div className="login-form mx-auto mt-3" >
            <h2>Sign on</h2>
            <input type="text" onChange={e => setUsername(e.target.value)}  value={ username } placeholder="Username" />
            <input type="password" onChange={e => setPassword(e.target.value)} value={ password } placeholder="Password" className="mt-2" />

            <div className="mt-3 login-button-wrapper">
                <button className="button" onClick={() => props.handleSuccessFullLogin(username)}>Login</button>
            </div>
        </div>
    );
}