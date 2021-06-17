import React from 'react';

export default function Request(props) {

    const { createdAt, type, vin, status } = props;

    return (
        <div className="request">
            <div className="request-row">
                <span>{createdAt}</span>
                <span>{type}</span>
                <span>{status}</span>
                <span>{vin}</span>
            </div>
        </div>
    );
    
}

//     "createdAt": "2021-06-15T12:56:40.2603497",
//     "type": "Maintenance",
//     "vin": "qi7p6jp2nr49afblt",
//     "status": "Created"