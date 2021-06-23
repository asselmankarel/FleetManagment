import React from 'react';

export default function Request(props) {

    const { createdAt, type, vin, status, licensePlate } = props;

    return (
        <div className="request">
            <div className="request-row">
                <span>{createdAt}</span>
                <span>{type}</span>
                <span>{status}</span>
                <span>{vin}</span>
                <span>{licensePlate}</span>
            </div>
        </div>
    );
    
}
