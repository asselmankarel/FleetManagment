import React, { useState, useEffect } from 'react';
import Loader from './Loader';
import useFetch from './useFetch';


export default function Requests(props) {

    const { driverId } = props;
    const [ requests, setRequests ] = useState([]);
    const { get, loading } = useFetch('https://localhost:44318/');

    useEffect(() => {
        get(`Request/DriverRequests/${driverId}`)
        .then((data) => setRequests(data))
        .catch((error) => console.log('Requests could not be loaded!', error));
    }, [])

    return(
        <div className="requests">
            <h2><i class="far fa-list-alt"></i> My requests</h2>
            {loading && <Loader />}
            {loading === false &&
                <div className="requests-list">

                </div>
            }
        </div>
    );
}