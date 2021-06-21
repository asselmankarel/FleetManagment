import React, { useState }from 'react';

export default function LoginForm(props) {
    const [ username, setUsername ] = useState('Username');
    const [ password, setPassword ] = useState('Password');

    return (
        <div className="login-form mx-auto mt-3" >
            <h2>Sign on</h2>
            <input type="text" onChange={e => setUsername(e.target.value)}  value={ username } />
            <input type="password" onChange={e => setPassword(e.target.value)} value={ password } className="mt-2" />
            <button className="button mt-3" onClick={() => props.handleSuccessFullLogin(username)}>Login</button>
        </div>
    );
}