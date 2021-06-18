import React, { useState, useEffect } from 'react';
import useFetch from './useFetch';
import Loader from './Loader';
import { NavLink } from 'react-router-dom';
import './css/Profile.css';

export default function Profile(props) {

    const { driverId } = props;
    const { get, loading } = useFetch('https://localhost:44318/');
    const [ driverDetails, setDriverDetails ] = useState([]);
    const [ failed, setFailed ] = useState(false);

    useEffect(() => {
        get(`Driver/Show/${driverId}`)
        .then(data => {
            setDriverDetails(data);
            console.log(data);
            setFailed(false);
        })
        .catch(error => {
            console.log(error);
            setFailed(true);
        });

    }, [driverId])

    return (
        <div className="driver-details">
            { loading && <Loader />}
            <h2><i className="fas fa-info-circle"></i> Profile info</h2>
            <ul>
                <li><div className="driver-details-row"><strong>First name:</strong> {driverDetails.firstName}</div></li>
                <li><div className="driver-details-row"><strong>Last name:</strong> {driverDetails.lastName}</div></li>
                <li><div className="driver-details-row"><strong>Driverslicense:</strong> {driverDetails.driversLicense}</div></li>          
            </ul>
            <NavLink to="/"><button className="button mt-2 ml-2" >Back</button></NavLink>
        </div>
    );


}