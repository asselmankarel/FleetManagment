import React, { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import Loader from './Loader';
import useFetch from './useFetch';
import Request from './Request';


export default function Requests(props) {

    const { driverId } = props;
    const [ requests, setRequests ] = useState([]);
    const { get, loading } = useFetch('https://localhost:44318/');

    useEffect(() => {
        get(`Request/DriverRequests/${driverId}`)
        .then((data) => setRequests(data))
        .catch((error) => console.log('Requests could not be loaded!', error));
    })

    return(
        <div className="requests">
            <div className="requests-title">
                <h2><i className="far fa-list-alt"></i> My requests</h2>
                <NavLink className="button" to="/request/new"><i className="fas fa-plus"></i> New</NavLink> 
            </div>   
            { loading && <Loader /> }
            { loading === false &&
                <div className="requests-list">
                    <div className="request-row request-row-header">
                        <span>Created at</span>
                        <span>Type</span>
                        <span>Status</span>
                        <span>Chassis number</span>
                    </div>
                    { requests.map((request) => {
                        return (
                            <Request
                                createdAt={new Date(request.createdAt).toLocaleString()}
                                type={request.type}
                                vin={request.vin}
                                status={request.status}
                            />
                        );
                    })
                    }
                </div>
            }
        </div>
    );
}
