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
    const [ validationErrors, setValidationErrors] = useState([]);
    const [ loading, setLoading ] = useState(false);
    const [ success , setSuccess] = useState(false);
    const [ failure , setFailure] = useState(false);

    const { post } = useFetch('https://localhost:44340/');

    const resetFlags = () => {
        setLoading(false);
        setSuccess(false);
        setFailure(false);
    }

 
    const handleSubmit = (e) => {
        e.preventDefault();
        let errorCount = 0;

        if (type === '') {
            setValidationErrors(validationErrors => [...validationErrors, 'Please select a type']);
            errorCount++;
        }

        if (date1 === '') {
            setValidationErrors(validationErrors => [...validationErrors, 'Please select date 1']);
            errorCount++;       
        }        

        if (errorCount === 0) {
            resetFlags();
        
            var  body = {                
                        "type" : Number.parseInt(type),
                        "prefDate1": date1,                    
                        "driverId": driverId
            };
    
            if (date2 !== '') {
                body.prefDate2 = date2
            }
    
            post('Request/New', body)
            .then((data) => {
                setLoading(false);
                setSuccess(true);
                
            })
            .catch((error) => {
                if (error) {
                    setFailure(true);
                }
                setLoading(false);
                console.log('Error: ', error);
            }); 
        }

    }

    return(
        <div className="request-form">
            {success === false &&
                <form >
                    <div className="form-group">                    
                        <label>Type of request</label>               
                        <div className="form-item">
                            <select onChange={e =>  setType(e.target.value) }  required="true">
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
                            <input type="date" value={date1} onChange={e =>  setDate1(e.target.value) } required />
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Preferred date 2:</label>
                        <div className="form-item">
                            <input type="date" value={date2} onChange={e =>  setDate2(e.target.value) } />
                        </div>
                    </div>                
                    
                    <div className="button-group">
                        <NavLink to="/" ><button className="button button-cancel">Cancel</button></NavLink>
                        <button className="button" onClick={ handleSubmit } >Send request</button> 
                    </div>
                    <div className="form-loader mt-2">
                        { loading && <Loader />}
                    </div>
                        
                </form>
            }
                        
            {validationErrors.map(error => <div className="message error" >😱 {error}...</div>)}            
            { failure && <div className="message error">Oops! 😱 Request failed!</div>}
            { success && 
                <div>
                    <div className="message">Yay! 🎉 Request sent succesfully... </div>
                    <NavLink to="/" className="button">Back</NavLink>
                </div>
            }
        </div>
    );
}