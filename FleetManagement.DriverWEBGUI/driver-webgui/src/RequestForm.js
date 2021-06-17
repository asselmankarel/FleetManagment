import React from 'react';
import './css/RequestForm.css';

export default function RequestForm() {

    return(
        <div className="request-form">
            <form>
                <div className="form-group">                    
                    <label>Type of request</label>               
                    <div className="form-item">
                        <select>
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
                        <input type="date" />
                    </div>
                </div>

                <div className="form-group">
                    <label>Preferred date 2:</label>
                    <div className="form-item">
                        <input type="date" />
                    </div>
                </div>
                
                <div className="button-group">
                    <button className="button">Cancel</button>
                    <button className="button">Save</button>
                </div>
            </form>
        </div>
    );
}