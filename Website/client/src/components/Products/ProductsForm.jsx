import { useState } from "react";
import { useNavigate } from "react-router-dom"; // Remove `Form` from this import
import { Card, CardBody, Form, FormGroup, Input, Label, Button } from "reactstrap"; // Add Button to this import
import { addProduct } from "../../Services/ProductsServices.jsx";

export const ProductsForm = () => {
  const [productId, setProductId] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [type, setType] = useState("");

  // Hook to navigate after form submission
  const navigate = useNavigate();

  // Handle form submission
  const submit = (e) => {
    e.preventDefault(); // Prevent page reload on form submission

    const product = {
      name: name,
      price: parseFloat(price), // Convert price to a number
      typeId: type,
    };

    // Here you would typically send the product data to your server or API
    
    
    console.log("Product submitted:", product);
    addProduct(product).then(() =>
      navigate("/products"))
    // Redirect to the products list or another page
    
  };

  return (
    <div className="container pt-4">
      <div className="row justify-content-center">
        <Card className="col-sm-12 col-lg-6">
          <CardBody>
            <Form onSubmit={submit}> {/* Add onSubmit handler */}
              <FormGroup>
                <Label for="name">Product Name</Label>
                <Input
                  id="name"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  required
                />
              </FormGroup>
              <FormGroup>
                <Label for="price">Price</Label>
                <Input
                  id="price"
                  type="number"
                  value={price}
                  onChange={(e) => setPrice(e.target.value)}
                  required
                />
              </FormGroup>
              <FormGroup>
                <Label for="type">Type</Label>
                <Input
                  id="type"
                  value={type}
                  onChange={(e) => setType(e.target.value)}
                  required
                />
              </FormGroup>
              <Button type="submit" color="primary">Submit</Button> {/* Submit button */}
            </Form>
          </CardBody>
        </Card>
      </div>
    </div>
  );
};
