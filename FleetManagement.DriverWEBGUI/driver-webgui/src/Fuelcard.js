import React, { useState, useEffect } from 'react';
import Loader from './Loader';
import useFetch from './useFetch';
import './css/Fuelcard.css';

export default function Fuelcard(props) {

    const { driverId, apiUrl } = props;
    const { get, loading } = useFetch(apiUrl);
    const [ fuelcard, setFuelcard ] = useState({ services: [] });
    const [ loadError, setLoadError] = useState(false); 

    useEffect(() => {
        get(`Driver/Fuelcard/${driverId}`)
        .then((data) => {
            setFuelcard(data); 
            setLoadError(false);
        })
        .catch((error) => {
            console.log("Could not load fuelcard information!", error);
            setLoadError(true);
        });   

    }, [driverId])

    return (
        <div className="mt-3">
            <h2> <i className="far fa-credit-card"></i> Fuelcard</h2>
            { loading && <Loader /> }
            { (loading === false && loadError === false) && 
                <div className="fuelcard">
                    <div className="fuelcard-col">
                        <div><strong>Number: </strong></div>
                        <div>{fuelcard.number}</div>
                    </div>
                    <div className="fuelcard-col">
                        <div><strong>Fuel type: </strong></div>
                        <div>{fuelcard.fuelType}</div>
                    </div>

                    <div className="fuelcard-col">
                        <p><strong>Services: </strong></p>
                        { fuelcard.services.map(service => {
                            return <p>{service}</p>;
                        })}
                    </div>
                </div>
            }
            { loadError && <div className="message error">😱 Unable to load fuelcard data...</div> }
        </div>
    );
}