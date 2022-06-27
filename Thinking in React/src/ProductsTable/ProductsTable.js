import React from 'react';
import Products from '../Products/Products';
import ProductCategory from '../ProductCategory/ProductCategory';
import ProductsTableHeaders from "../ProductsTableHeaders/ProductsTableHeaders";

function ProductsTable(props) {
  const { searchTerm } = props;

  const products = [
    {'id': 1, 'name': 'Apple', 'price': '$1', 'isInStock': true, 'category': 'Fruits'},
    {'id': 2, 'name': 'Dragonfruit', 'price': '$1', 'isInStock': true, 'category': 'Fruits'},
    {'id': 3, 'name': 'Passionfruit', 'price': '$2', 'isInStock': false, 'category': 'Fruits'},
    {'id': 4, 'name': 'Spinach', 'price': '$2', 'isInStock': true, 'category': 'Vegetables'},
    {'id': 5, 'name': 'Pumpkin', 'price': '$4', 'isInStock': false, 'category': 'Vegetables'},
    {'id': 6, 'name': 'Peas', 'price': '$1', 'isInStock': true, 'category': 'Vegetables'}
  ];

  const uniqueCategories = Array.from(new Set(products.map(p => p.category)));

  const categories = uniqueCategories.map((uc, idx) => {
    return {'id': idx, 'name': uc}
  });

  let allProducts = [];

  for(let i = 0; i < categories.length; i++) {
    allProducts.push(
      <React.Fragment key={categories[i].id}>
        <ProductCategory categoryName={categories[i].name}/>
        <Products categoryName={categories[i].name} products={products} searchTerm={searchTerm}/>
      </React.Fragment>
    );
  }

  return (
    <>
        <ProductsTableHeaders/>
        {allProducts}
    </>
  );
}

export default ProductsTable;
