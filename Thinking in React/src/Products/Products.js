import './Products.css';

function Products(props) {
    const { categoryName, products, searchTerm, isInStockOnly } = props;
    
    let productsRows = [];

    productsRows = searchTerm === '' ? 
        products.filter(p => p.category === categoryName) : 
        products.filter(p => p.category === categoryName && p.name.toLowerCase().includes(searchTerm.toLowerCase()));

    productsRows = isInStockOnly === false ?
        productsRows : 
        productsRows.filter(p => p.isInStock === true);
    
    let rows = [];

    productsRows.forEach(p => rows.push(
        <div key={p.id} className='productsAsGrid'>
            <span style={p.isInStock ? {color: 'black'} : {color: 'red'}}> {p.name} </span>
            <span> {p.price} </span>
        </div>
    ));

    return ( 
        <>
            {rows}
        </>
    );
}

export default Products;