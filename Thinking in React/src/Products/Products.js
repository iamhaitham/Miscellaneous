import React from "react";

function Products(props) {
    const { categoryName, products } = props;
    
    let productsRows = products.filter(p => p.category === categoryName);
    
    let rows = [];

    productsRows.forEach(p => rows.push(
        <React.Fragment key={p.id}>
            <span style={p.isInStock ? {color: 'black'} : {color: 'red'}}> {p.name} </span>
            <span> {p.price} </span>
        </React.Fragment>
    ));

    return ( 
        <>
            {rows}
        </>
    );
}

export default Products;