import React from 'react';
import { NavLink } from 'react-router-dom';


export default function Banner() {

    return (
    <div className="banner">
        <NavLink to="/"><i className="fas fa-2x fa-home"></i></NavLink>
        <h1>Fleet Management</h1>
        <NavLink to="/profile"><i className="fas fa-2x fa-user-circle"></i></NavLink>        

    </div>
    );
}