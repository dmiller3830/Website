import { useEffect, useState } from "react";
import { GetAllProducts } from "../../Services/ProductsServices.jsx";
import { Products } from "./Products.jsx";
import { Link, useNavigate } from "react-router-dom";

export const ProductList = () => {

    const [admin, setAdmin] = useState(); 
    const [products, setProducts] = useState([]); 
    const navigate = useNavigate();

    const user = JSON.parse(localStorage.getItem("userProfile"));


    const getProducts = () => {
        GetAllProducts().then(allProducts => setProducts(allProducts)); 
    }; 

    useEffect(() => {
        getProducts(); 
    }, []); 

    const handleCreateProduct = () => {
      navigate("/products/add");  // Navigate to the product form
  
     
    };

    return (
        <>
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {products.map((product) => (
              <Products key={product.id} product={product} />
            ))}
        </div>
        <div className="text-center mt-4">
        {/* Use onClick to trigger navigation */}

       
        
      {user.admin ? <>
      <li>
        
        <button onClick={handleCreateProduct} className="btn btn-primary">
          Create Product
          </button>
          </li>
    </> : ""}
    
      </div>

      </div>
    </div>
    </>
  );
};



