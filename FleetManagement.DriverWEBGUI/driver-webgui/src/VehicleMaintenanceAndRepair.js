import React from 'react';
import { useParams, NavLink } from 'react-router-dom';

export default function VehicleMaintenanceAndRepair(props) {
    let { vehicleId } = useParams();

    return (
        <>
        <div className="maintenance-title mt-3">
            <h2><i className="fas fa-tools"></i> Maintenances and Repairs</h2>
            <NavLink className="button" to="/">Back</NavLink>                
        </div>

        <h3 className="mt-2 ml-2">Maintenances</h3>
        <div className="maintenances-list">
            <p className="p1">Maintenances for Vehicle id: {vehicleId}</p>
        </div>

        <h3 className="mt-2 ml-2">Repairs</h3>
        <div className="repairs-list">
            <p className=" p1">Repairs for Vehicle id: {vehicleId}</p>
        </div>
        </>
    );
}