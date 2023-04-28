import './ProductCategory.css';

function ProductCategory(props) {
    const { categoryName } = props;

    return (
      <div className='productCategoryAsGrid'>
        <span></span>
        <p className='boldCategory'>{categoryName}</p>
      </div>
    );
  }
  
  export default ProductCategory;
  
  