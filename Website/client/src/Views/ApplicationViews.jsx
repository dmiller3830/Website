import { Route, Routes } from "react-router-dom";
import { Welcome } from "../components/Welcome/Welcome.jsx";
import { ProductList } from "../components/Products/ProductsLIst.jsx";
import { ProductsForm } from "../components/Products/ProductsForm.jsx";
import { ProductsDetails } from "../components/Products/ProductsDetails.jsx";
import { EditProductForm } from "../components/Products/EditProductForm.jsx";
import { FrontDoor } from "../components/Welcome/FrontDoor.jsx";

const ApplicationViews =() => {

    return(
        <Routes>
            
            <Route path="/" element={<Welcome/>}/>

            <Route path="/frontdoor" element={<FrontDoor/>}/>

          
            
            <Route path="/products" element= {<ProductList/>}/>

            <Route path="/products/add" element={<ProductsForm/>}/>

            <Route path="/products/:id" element={<ProductsDetails/>}/>

        <Route path="/products/edit/:id" element={<EditProductForm/>}/>

        
            

        </Routes>
    )


}; 

export default ApplicationViews