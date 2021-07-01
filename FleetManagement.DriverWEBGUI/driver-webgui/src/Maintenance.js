import React from 'react';

export default function Maintenance(props) {
    const { date, price, garage, invoiceId } = props;

    return (        
        <div className="maintenance-row">
            <span>{date}</span>
            <span>{price}</span>
            <span>{garage}</span>
            <span>{invoiceId}</span>
        </div>
    );
}