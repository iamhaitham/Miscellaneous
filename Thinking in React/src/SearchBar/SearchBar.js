import './SearchBar.css';

function SearchBar(props) {
  const { searchTerm, setSearchTerm, isInStockOnly, setIsInStockOnly } = props;

  return (
    <>
      <form className='searchForm'>
        <input type='search' placeholder='Search...' className='searchInput' value={searchTerm} onChange={e => setSearchTerm(e.target.value)}/>
        <div>
          <input type='checkbox' checked={isInStockOnly} onChange={e => setIsInStockOnly(e.target.checked)}/> 
          <span>Only show products in stock</span>
        </div>
      </form>
    </>
  );
}

export default SearchBar;
