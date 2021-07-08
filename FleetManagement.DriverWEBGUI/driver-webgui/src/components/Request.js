import React from 'react';

export default function Request(props) {

    const { createdAt, type, chassisNumber, status, licensePlate } = props;

    return (
        <section className="request">
            <div className="request-row">
                <div className="request-row-item">{createdAt}</div>
                <div className="request-row-item">{type}</div>
                <div className="request-row-item">{status}</div>
                <div className="request-row-item"><small>{chassisNumber}</small></div>
                <div className="request-row-item">{licensePlate}</div>
            </div>
        </section>
    );
    
}
