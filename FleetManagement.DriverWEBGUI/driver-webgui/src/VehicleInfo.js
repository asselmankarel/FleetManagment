import React, { useState, useEffect } from 'react';
import Loader from './Loader';
import useFetch from './useFetch';
import car from './images/car.png';

export default function VehicleInfo(props) {

    const { driverId, apiUrl } = props;
    const { get, loading } = useFetch(apiUrl); // base url
    const [ vehicle , setVehicle ] = useState([]);
    const [ loadError, setLoadError ] = useState(false);

    useEffect(() => {
        get(`Driver/Vehicle/${driverId}`)
        .then((data) => {
            setVehicle(data); 
            setLoadError(false);
        })
        .catch((error) => {
            console.log("Could not load vehicle information!", error);
            setLoadError(true);
        });        
    }, [driverId])

    return(
        <div className="vehicle mt-2">
            <h2><i className="fas fa-car"></i> My vehicle</h2>
            <div className="form-loader">
                { loading && <Loader /> }            
            </div>
            {(loading === false && loadError === false) &&
                <div className="vehicle-info">
                    <ul>
                        <li><div className="vehicle-info-row"><strong>Chassis number:</strong> {vehicle.vin}</div></li>
                        <li><div className="vehicle-info-row"><strong>License plate:</strong> {vehicle.licensePlate}</div></li>
                        <li><div className="vehicle-info-row"><strong>Vehicle type:</strong> {vehicle.vehicleType}</div></li>
                        <li><div className="vehicle-info-row"><strong>Last mileage:</strong> {vehicle.lastMileage}km</div></li>               
                    </ul>
                    <div className="vehicle-image">
                        <img src={car} alt="car" width="200px"/>
                    </div>
                </div>
            }
            { loadError && <div className="message error">😱 Unable to load vehicle data...</div> }
        </div>
    );
}
