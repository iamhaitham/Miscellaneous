import './SearchBar.css';

function SearchBar() {
  return (
    <>
      <form className='searchForm'>
        <input type='search' placeholder='Search...' className='searchInput'/>
        <div>
          <input type='checkbox'/> 
          <span>Only show products in stock</span>
        </div>
      </form>
    </>
  );
}

export default SearchBar;