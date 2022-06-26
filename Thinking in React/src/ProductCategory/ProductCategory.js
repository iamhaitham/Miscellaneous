import './ProductCategory.css';

function ProductCategory(props) {
    const { categoryName } = props;

    return (
      <>
        <p className='boldCategory'>{categoryName}</p>
      </>
    );
  }
  
  export default ProductCategory;
  
  