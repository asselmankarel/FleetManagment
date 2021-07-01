import React from 'react';

export default function Maintenance(props) {
    const { date, price, garage, invoiceId } = props;

    return (        
        <div className="maintenance-row">
            <span>{new Date(date).toLocaleString('nl-BE', {day: '2-digit', month: '2-digit', year:'numeric'})}</span>
            <span>€ {price}</span>
            <span>{garage}</span>
            <span>{invoiceId > 0 ? <a href={`/invoice/${invoiceId}`}><i className="fas fa-file-invoice" title="Download invoice"></i></a> : ''}</span>
        </div>
    );
}