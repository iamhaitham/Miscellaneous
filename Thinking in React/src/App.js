import { useState } from 'react';
import './App.css';
import ProductsTable from './ProductsTable/ProductsTable';
import SearchBar from './SearchBar/SearchBar';

function App() {
  const [searchTerm, setSearchTerm] = useState('');

  return (
    <>
      <SearchBar searchTerm={searchTerm} setSearchTerm={setSearchTerm}/>
      <ProductsTable/>
    </>
  );
}

export default App;
