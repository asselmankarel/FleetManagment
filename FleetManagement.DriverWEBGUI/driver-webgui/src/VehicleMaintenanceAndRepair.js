import React, { useState, useEffect } from 'react';
import { useParams, NavLink } from 'react-router-dom';
import useFetch from './useFetch';
import Maintenance from './components/Maintenance';
import Loader from './components/Loader';

export default function VehicleMaintenanceAndRepair(props) {

    let { vehicleId } = useParams();
    const { apiUrl } = props;
    const { get, loading } = useFetch(apiUrl);

    const [ maintenances, setMaintenances ] = useState([]);
    const [ repairs, setRepairs ] = useState([]);
    const [ maintenanceLoadError, setMaintenanceLoadError ] = useState(false);
    const [repairLoadError, setRepairLoadError ] = useState(false);

    useEffect(() => {
        setRepairLoadError(false);
        setMaintenanceLoadError(false);
        get(`vehicle/${vehicleId}/maintenances`)
        .then((data) => {
            setMaintenances(data);
        })
        .catch((error) => {
            console.log(error);
            setMaintenanceLoadError(true);
        });

        get(`vehicle/${vehicleId}/repairs`)
        .then((data) => {
            setRepairs(data);
        })
        .catch((error) => {
            console.log(error);
            setRepairLoadError(true);
        });
    }, [])

    return (
        <>
            <div className="maintenance-title mt-3">
                <h2><i className="fas fa-tools"></i> Maintenances and Repairs</h2>
                <NavLink className="button" to="/">Back</NavLink>                
            </div>

            <h3 className="mt-2 ml-2">Maintenances</h3>
            
            <div className="form-loader">
                { loading && <Loader /> }
            </div>
            
            { (loading === false && maintenanceLoadError === false) &&            
                <div className="mt-2">
                    <div className="maintenance-list">
                        <div className="maintenance-row-header">
                            <span>Date</span><span>Price</span><span>Garage</span><span>Invoice</span>
                        </div>
                        { maintenances.map(maintenance => {
                            return (
                                <Maintenance 
                                    key={maintenance.date}
                                    date={maintenance.date}
                                    price={maintenance.price}
                                    garage={maintenance.garage}
                                    invoiceId={maintenance.invoiceId}
                                /> 
                            )
                        })}
                    </div>
                </div>
            }
            
            { maintenanceLoadError && <div className="message error">😱 Unable to load maintenances...</div>}

            <h3 className="mt-2 ml-2">Repairs</h3>
            <div className="repairs-list">
                <p className=" p1">TODO: Repairs for Vehicle id: {vehicleId}</p>
            </div>
        </>
    );
}