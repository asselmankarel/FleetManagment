import React, { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import Loader from './Loader';
import useFetch from './useFetch';
import Request from './Request';


export default function Requests(props) {

    const { driverId, apiUrl } = props;
    const [ requests, setRequests ] = useState([]);
    const [ loadError, setLoadError] = useState(false);
    const { get, loading } = useFetch(apiUrl);

    useEffect(() => {
        get(`Request/DriverRequests/${driverId}`)
        .then((data) => {
            setRequests(data);
            setLoadError(false);
        })
        .catch((error) => {
            console.log('Requests could not be loaded!', error);
            setLoadError(true);
        });
    }, [driverId])

    return(
        <div className="requests mt-3">
            <div className="requests-title">
                <h2><i className="far fa-list-alt"></i> My requests</h2>
                { (loadError === false && loading === false) && <NavLink className="button" to="/request/new"><i className="fas fa-plus-circle"></i> New</NavLink> }
            </div>
             
            <div className="form-loader">
                { loading && <Loader /> }
            </div>

            { (loading === false && loadError === false) &&
                <div className="requests-list">
                    <div className="request-row request-row-header">
                        <span>Created at</span>
                        <span>Type</span>
                        <span>Status</span>
                        <span>Chassis number</span>
                        <span>LicensePlate</span>
                    </div>
                    { requests.map((request) => {
                        return (
                            <Request
                                key={Date.parse(request.createdAt)}
                                createdAt={new Date(request.createdAt).toLocaleString('nl-BE', {dateStyle: 'short', timeStyle : 'short'})}
                                type={request.type}
                                vin={request.vin}
                                status={request.status}
                                licensePlate={request.licensePlate}
                            />
                        );
                    })
                    }
                </div>
            }
            { loadError && <div className="message error">😱 Unable to load requests...</div>}
        </div>
    );
}
