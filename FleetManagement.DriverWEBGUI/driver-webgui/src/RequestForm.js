import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import useFetch from './useFetch';
import Loader from './Loader';
import './css/RequestForm.css';

export default function RequestForm(props) {

    const { driverId } = props
    const [ type, setType ] = useState('');
    const [ date1, setDate1 ] = useState('');
    const [ date2, setDate2 ] = useState('');
    const [ loading, setLoading ] = useState(false);

    const { post } = useFetch('https://localhost:44318/');
 
    const handleSubmit = (e) => {
        e.preventDefault();  
        setLoading(true);      
        //alert(`submit triggerd ${type}, ${date1}, ${date2}`);
        var  body = {                
                    type : type,
                    prefDate1: date1,
                    prefDate2: date2,
                    driverId: driverId                              
        };

        post('Request/new', body)
        .then(data => {
            console.log(data);
            setLoading(false);
        })
        .catch(error => {
            console.log(error);
            setLoading(false);
        }); 
    }

    return(
        <div className="request-form">
            <form >
                <div className="form-group">                    
                    <label>Type of request</label>               
                    <div className="form-item">
                        <select onChange={e => setType(e.target.value)} value={type} required>
                            <option></option>
                            <option value="0" >Fuelcard</option>
                            <option value="1" >Maintenance</option>
                            <option value="2" >Repair</option>
                            <option value="3" >Other</option>                    
                        </select>
                    </div>
                </div>
                
                <div className="form-group">
                    <label>Preferred date 1:</label>
                    <div className="form-item">
                        <input type="date" value={date1} onChange={e => setDate1(e.target.value)} required />
                    </div>
                </div>

                <div className="form-group">
                    <label>Preferred date 2:</label>
                    <div className="form-item">
                        <input type="date" value={date2} onChange={e => setDate2(e.target.value)} />
                    </div>
                </div>                
                
                <div className="button-group">
                    <NavLink to="/" ><button className="button button-cancel">Cancel</button></NavLink>
                    <button className="button" onClick={ handleSubmit }>Send request</button>
                </div>
                <div className="form-loader">
                    { loading && <Loader />}
                </div>         
            </form>
        </div>
    );
}