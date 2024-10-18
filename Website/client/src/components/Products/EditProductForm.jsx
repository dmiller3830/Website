import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { EditProduct, GetAllProducts } from "../../Services/ProductsServices.jsx";

export const EditProductForm = () => {
  const [productId, setProductId] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
const [typeId, setType] = useState("");
  const { id } = useParams();
  const userTypeId = localStorage.getItem("userTypeId");
  const navigate = useNavigate();

  // Fetch the product to edit
  useEffect(() => {
    GetAllProducts().then((products) => {
      const productToEdit = products.find(
        (product) => product.id === parseInt(id)
      );
      if (productToEdit) {
        
        setProductId(productToEdit.id);
        setName(productToEdit.name);
        setPrice(productToEdit.price);
        setType(productToEdit.typeId);
      }
    });
  }, [id]);
  
  // Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    const updatedProduct = {
      id: parseInt(id),
      name: name,
      price: price,
      typeId: typeId
    };
    console.log(updatedProduct)
    EditProduct(updatedProduct).then(() => {
      navigate("/products"); // Redirect to products page
    });
  };



  return (
    <div className="container pt-4">
      <div className="row justify-content-center">
        <div className="col-sm-12 col-lg-6">
          <h2>Edit Product</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label htmlFor="name">Product Name</label>
              <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                className="form-control"
                required
              />
            </div>

            <div className="form-group">
              <label htmlFor="price">Price</label>
              <input
                type="number"
                id="price"
                value={price}
                onChange={(e) => setPrice(e.target.value)}
                className="form-control"
                required
              />
            </div>
{/*mAp type to get dropdown */}
            {/* <div className="form-group">
              <label htmlFor="type">Type</label>
              <input
                type="text"
                id="type"
                value={type}
                onChange={(e) => setType(e.target.value)}
                className="form-control"
                required
              />
            </div> */}

            <button type="submit" className="btn btn-primary">
              Save Changes
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};
