import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Card } from "reactstrap";


export const Products = ({ product }) => {
  const navigate = useNavigate();
  

 


 
  return (
    <>
    <Card className="m-4">
        <div></div>
        <Link to={`/Products/${product.id}`} className="navbar-brand">
          Product {product.name}
        </Link>

        <div>{product.price}</div>

        <button>Add to Order</button>

       
          </Card>
       
      <div className="text-center mt-4">
        {/* Use onClick to trigger navigation */}
       
      </div>
    </>
  );
};
