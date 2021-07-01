import React, {useState, useEffect} from 'react';
import {NavLink} from 'react-router-dom';
import useFetch from './useFetch';
import Loader from './Loader';
import './css/RequestForm.css';

export default function RequestForm(props) {

    const {driverId, baseUrlWriteApi, baseUrlReadApi} = props

    const [postModel, setPostModel] = useState({
        driverId : driverId, 
        requestType : null,
        prefDate1 : null,
        prefDate2 : null,
    });

    const [types, setTypes] = useState([]);
    const [loading, setLoading] = useState(false);
    const [success , setSuccess] = useState(false);
    const [failure , setFailure] = useState(false);
    const [validationErrors, setValidationErrors] = useState([]);

    const {get} = useFetch(baseUrlReadApi);
    const {post} = useFetch(baseUrlWriteApi);

    function resetFlags() {  
        setLoading(true);       
        setSuccess(false);
        setFailure(false);
        setValidationErrors([]);
    }

    useEffect(() => {
        get('Request/Types')
        .then((data) => setTypes(data))
        .catch((error) => console.log(error));
    }, []);

    function validateFormData() {
        let errorCount = 0;

        if (postModel.requestType === null) {
            setValidationErrors(['Please select a type']);
            errorCount++;
        }
        
        if (new Date(postModel.prefDate1) <= new Date()) {
            setValidationErrors(validationErrors => [...validationErrors, 'Date 1 must be in the future']);
            errorCount++;
        }
        
        if (new Date(postModel.prefDate2) <= new Date()) {            
            setValidationErrors(validationErrors => [...validationErrors, 'Date 2 must be in the future']);
            errorCount++;            
        }

        return errorCount;
    }

    function handleSubmit(e) {
        e.preventDefault();               
        resetFlags();        

        if (validateFormData() === 0) {                    
            post('Request/New', postModel)
            .then((data) => {
                setLoading(false);
                console.log(data);
                // Check response for success and errorMessages
                setSuccess(true);                
            })
            .catch((error) => {
                if (error) {
                    setFailure(true);
                }
                setLoading(false);
                console.log('Post error: ', error);
            });

        } else {
            setLoading(false);
        }
    }

    return (
        <div className="request-form">
            {success === false &&
                <form >
                    <h2><i className="fas fa-plus-circle"></i> New request</h2>
                    <div className="form-group mt-2">                    
                        <label htmlFor="requestType">Type of request</label>               
                        <div htmlFor="requestType" className="form-item">
                            <select name="requestType" onChange={e => setPostModel({...postModel, requestType: e.target.value})}  required={true}>
                                <option></option>
                                { types.map(type => {
                                    return (<option value={types.indexOf(type)}>{type}</option>);
                                })}                
                            </select>
                        </div>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="prefDate1" >Preferred date 1:</label>
                        <div className="form-item">
                            <input name="prefDate1" type="date" value={postModel.prefDate1} onChange={e => setPostModel({...postModel, prefDate1: e.target.value })} required={ true } />
                        </div>
                    </div>

                    <div className="form-group">
                        <label htmlFor="prefDate2" >Preferred date 2:</label>
                        <div className="form-item">
                            <input name="prefDate2" type="date" value={postModel.prefDate2} onChange={e => setPostModel({...postModel, prefDate2: e.target.value})} />
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