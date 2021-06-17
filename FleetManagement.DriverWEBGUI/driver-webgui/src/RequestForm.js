import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import useFetch from './useFetch';
import './css/RequestForm.css';

export default function RequestForm() {

    const [ type, setType ] = useState('');
    const [ date1, setDate1 ] = useState('');
    const [ date2, setDate2 ] = useState('');

    //const [ post, loading ] = useFetch('https://localhost:44318/');
 
    const handleSubmit = (e) => {
        e.preventDefault();
        alert(`submit triggerd ${type}, ${date1}, ${date2}`);
    }

    return(
        <div className="request-form">
            <form onSubmit={ handleSubmit } >
                <div className="form-group">                    
                    <label>Type of request</label>               
                    <div className="form-item">
                        <select onChange={e => setType(e.target.value)} value={type} required>
                            <option></option>
                            <option>Fuelcard</option>
                            <option>Maintenance</option>
                            <option>Repair</option>
                            <option>Other</option>                    
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
                    <button className="button">Send request</button>
                </div>
            </form>
        </div>
    );
}