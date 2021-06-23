import React, { useState, useEffect } from 'react';
import useFetch from './useFetch';
import Loader from './Loader';
import { NavLink } from 'react-router-dom';
import './css/Profile.css';

export default function Profile(props) {

    const { driverId, apiUrl } = props;
    const { get, loading } = useFetch(apiUrl);
    const [ driverDetails, setDriverDetails ] = useState([]);
    const [ failed, setFailed ] = useState(false);

    useEffect(() => {
        get(`Driver/Show/${driverId}`)
        .then(data => {
            setDriverDetails(data);           
            setFailed(false);
        })
        .catch(error => {
            console.log(error);
            setFailed(true);
        });

    }, [driverId])

    return (
        <div className="driver-details">
            <h2><i className="fas fa-info-circle"></i> Profile info</h2>
            <ul>
                <li><div className="driver-details-row"><strong>First name:</strong> {driverDetails.firstName}</div></li>
                <li><div className="driver-details-row"><strong>Last name:</strong> {driverDetails.lastName}</div></li>
                <li><div className="driver-details-row"><strong>Driverslicense:</strong> {driverDetails.driversLicense}</div></li>
                <li><div className="driver-details-row"><strong>Street:</strong> {driverDetails.street}</div></li>
                <li><div className="driver-details-row"><strong>Number:</strong> {driverDetails.number}</div></li>
                <li><div className="driver-details-row"><strong>Box:</strong> {driverDetails.box === 0 ? "" : driverDetails.box }</div></li>
                <li><div className="driver-details-row"><strong>Postal code:</strong> {driverDetails.postalCode}</div></li>
                <li><div className="driver-details-row"><strong>City:</strong> {driverDetails.city}</div></li>
                <li><div className="driver-details-row"><strong>Country:</strong> {driverDetails.country}</div></li>
            </ul>
            <div><NavLink to="/"><button className="button mt-2 mx-auto" >Back</button></NavLink></div>
            { loading && <div className="mt-2 form-loader"><Loader /></div> }
            { failed && <div className="message error mt-2">😱 Unable to load profile...</div> }
        </div>
    );
}