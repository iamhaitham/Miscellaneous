import { useState } from 'react';
import './App.css';
import ProductsTable from './ProductsTable/ProductsTable';
import SearchBar from './SearchBar/SearchBar';

function App() {
  const [searchTerm, setSearchTerm] = useState('');
  const [isInStockOnly, setIsInStockOnly] = useState(false);

  return (
    <>
      <SearchBar searchTerm={searchTerm} setSearchTerm={setSearchTerm} isInStockOnly={isInStockOnly} setIsInStockOnly={setIsInStockOnly}/>
      <ProductsTable searchTerm={searchTerm} isInStockOnly={isInStockOnly}/>
    </>
  );
}

export default App;
