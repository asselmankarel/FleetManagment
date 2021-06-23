import React, { useState, useEffect } from 'react';
import Loader from './Loader';
import useFetch from './useFetch';
import './css/Fuelcard.css';
import carwash from './images/carwash.png';
import tires from './images/tires.png';
import shop from './images/shop.png';

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
            <h2> <i className="far fa-credit-card"></i> My Fuelcard</h2>
            <div className="form-loader">
                { loading && <Loader /> }
            </div>
            { (loading === false && loadError === false) && 
                <div className="fuelcard">
                    <div className="fuelcard-col">
                        <div><strong>Card number:</strong></div>
                        <div>{fuelcard.cardNumber}</div>
                    </div>
                    <div className="fuelcard-col">
                        <div><strong>Fuel type: </strong></div>
                        <div>{fuelcard.fuelType}</div>
                    </div>

                    <div className="fuelcard-col">
                        <p><strong>Services: </strong></p>
                        { fuelcard.services.map(service => {
                            switch (service) {
                                case 'carwash':
                                    return (<img key={service} className="service-image" src={carwash} alt="carwash" title="Carwash" />);
                                    break;
                                case 'tires':
                                    return (<img key={service} className="service-image" src={tires} alt="tires" title="Tires" />);
                                    break;
                                case 'shop':
                                    return (<img key={service} className="service-image" src={shop} alt="shop" title="Shop" />);
                                    break;
                                default:
                                    return (<img key={service} className="service-image" src="" alt={service} tite={service}> </img>);
                                    break;
                            }
                        
                        })}
                    </div>
                </div>
            }
            { loadError && <div className="message error">😱 Unable to load fuelcard data...</div> }
        </div>
    );
}