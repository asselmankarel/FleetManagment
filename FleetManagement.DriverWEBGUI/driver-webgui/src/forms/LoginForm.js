import React, { useState }from 'react';

export default function LoginForm(props) {
    const [ username, setUsername ] = useState('');
    const [ password, setPassword ] = useState('');
    const [ rememberMe, setRememberMe ] = useState(false)

    return (
        <div className="login-form mx-auto mt-3" >
            <h2><i className="fas fa-sign-in-alt"></i> Sign on</h2>
            <input type="text" className="width-85 mt-2" onChange={e => setUsername(e.target.value)}  value={ username } placeholder="Username" />
            <input type="password" className="width-85 mt-2" onChange={e => setPassword(e.target.value)} value={ password } placeholder="Password" />
            <div className="mt-2 row">
                <div className="ml-1"><input type="checkbox"  checked={rememberMe} onChange={e => setRememberMe(!rememberMe) }/></div>
                <div className="ml-1"><p>Remember me</p></div>
            </div>
            <div className="mt-3 login-button-wrapper">
                <button className="button" onClick={() => props.handleSuccessFullLogin(username, password, rememberMe)}>Login</button>
            </div>
        </div>
    );
}