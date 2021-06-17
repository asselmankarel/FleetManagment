import React, { useState, useEffect } from 'react';
import Loader from './Loader';
import useFetch from './useFetch';

export default function VehicleInfo(props) {

    const { driverId } = props;
    const [ vehicle , setVehicle ] = useState([]);
    const { get, loading } = useFetch('https://localhost:44318/'); // base url

    useEffect(() => {
        get(`Driver/DriverVehicle/${driverId}`)
        .then((data) => { setVehicle(data); })
        .catch((error) => console.log("Could not load vehicle information!", error));
    })

    return(
        <div className="vehicle">
            <h2><i className="fas fa-car"></i> My vehicle</h2>
            {loading && <Loader />}            
            {loading === false &&
                <div className="vehicle-info">
                    <ul>
                        <li><div className="vehicle-info-row"><strong>Chassis number:</strong> {vehicle.vin}</div></li>
                        <li><div className="vehicle-info-row"><strong>License plate:</strong> {vehicle.licensePlate}</div></li>
                        <li><div className="vehicle-info-row"><strong>Vehicle type:</strong> {vehicle.vehicleType}</div></li>
                        <li><div className="vehicle-info-row"><strong>Last mileage:</strong> {vehicle.lastMileage}km</div></li>               
                    </ul>
                </div>
            }
        </div>
    );
}
