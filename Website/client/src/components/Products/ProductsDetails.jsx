import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { DeleteProduct, GetProductById } from "../../Services/ProductsServices.jsx"; // Assuming GetProductById is the correct service function
import { Products } from "./Products.jsx";

export const ProductsDetails = () => {
  const [product, setProduct] = useState(null); // Use singular 'product' for clarity
  const { id } = useParams();
  const navigate = useNavigate();

  const user = JSON.parse(localStorage.getItem("userProfile"));


  useEffect(() => {
    if (id) {
      GetProductById(id).then(setProduct); // Corrected the function call to GetProductById
    }
  }, [id]); // Add 'id' as a dependency to rerun the effect if the id changes

  if (!product) {
    return <p>Loading...</p>; // Provide some fallback content while loading
  }


  const handleEditProduct = () => {
navigate(`/products/edit/${id}`);
  };


        // {/* ternary operation that displays the create button only if the user type is an admin */
        
        //   {user?.description} - {user?.admin ? "yes" : "no"} - {currentUser?.adminUser ? `Current user is an admin ${adminUser?.user?.name}` : "Current user is not an admin"}
        //   {currentUser?.admin ? "" 
          
        //   }


  const handleDelete = async () => {
    try{
      await DeleteProduct(id);
      navigate("/products");  
    } catch (error){
      console.error("error deleting the product:", error); 
    }
  }; 

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-sm-12 col-lg-6">
          <Products product={product} /> {/* Pass 'product' as prop instead of 'post' */}
       
         
       {user.admin ? <>
       <li>
          <button onClick={handleEditProduct}>Edit Product</button>

          </li>

          <li>
          <button onClick={handleDelete}>Delete Product</button>
          </li>
          </> : ""}
          
       
       
        </div>

        
      </div>
    </div>
  );
};
