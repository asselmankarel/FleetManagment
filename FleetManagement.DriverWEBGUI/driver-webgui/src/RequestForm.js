import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import useFetch from './useFetch';
import Loader from './Loader';
import './css/RequestForm.css';

export default function RequestForm(props) {

    const { driverId, apiUrl } = props
    const [ type, setType ] = useState('');
    const [ prefDate1, setPrefDate1 ] = useState('');
    const [ prefDate2, setPrefDate2 ] = useState('');
    const [ validationErrors, setValidationErrors] = useState([]);
    const [ loading, setLoading ] = useState(false);
    const [ success , setSuccess] = useState(false);
    const [ failure , setFailure] = useState(false);
    const { post } = useFetch(apiUrl);

    const resetFlags = () => {  
        setLoading(true);       
        setSuccess(false);
        setFailure(false);
        setValidationErrors([]);
    }

    function validateFormData() {
        let errorCount = 0;

        if (type === '') {
            setValidationErrors(['Please select a type']);
            errorCount++;
        }

        if (prefDate1 === '') {
            setValidationErrors(validationErrors => [...validationErrors, 'Please select date 1']);
            errorCount++;       
        }  
        
        if (new Date(prefDate1) <= new Date()) {
            setValidationErrors(validationErrors => [...validationErrors, 'Date 1 must be in the future']);
            errorCount++;
        }
        
        if ((prefDate2 !== '') && (new Date(prefDate2) <= new Date())) {            

            setValidationErrors(validationErrors => [...validationErrors, 'Date 2 must be in the future']);
            errorCount++;            
        }

        return errorCount;
    }

    function handleSubmit(e) {
        e.preventDefault();               
        resetFlags();        

        if (validateFormData() === 0) {                    
            var  body = {                
                        "type" : Number.parseInt(type),
                        "prefDate1": prefDate1,                    
                        "driverId": driverId
            };
    
            if (prefDate2 !== '') { body.prefDate2 = prefDate2 }
    
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

        } else {
            setLoading(false);
        }
    }

    return(
        <div className="request-form">
            {success === false &&
                <form >
                    <div className="form-group">                    
                        <label>Type of request</label>               
                        <div className="form-item">
                            <select onChange={ e => setType(e.target.value) }  required={true}>
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
                            <input type="date" value={ prefDate1 } onChange={ e => setPrefDate1(e.target.value) } required={ true } />
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Preferred date 2:</label>
                        <div className="form-item">
                            <input type="date" value={ prefDate2} onChange={e => setPrefDate2(e.target.value)} />
                        </div>
                    </div>                
                    
                    <div className="button-group">
                        <NavLink to="/" ><button className="button button-cancel">Cancel</button></NavLink>
                        <button className="button" onClick={handleSubmit} >Send request</button>
                    </div>
                    <div className="form-loader">
                        { loading && <Loader /> }
                    </div>
                        
                </form>
            }
                        
            { validationErrors.map(error => <div className="message error" >😱 {error}...</div>) }            
            { failure && <div className="message error">😱 Request failed!</div> }
            { success && 
                <div>
                    <div className="message">🎉 Request sent succesfully... </div>
                    <div className="mx-auto mt-4">
                        <NavLink to="/" className="button">Back</NavLink>
                    </div>
                </div>
            }
        </div>
    );
}