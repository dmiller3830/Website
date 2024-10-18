// import { useState } from "react"
// import { useNavigate, useParams } from "react-router-dom"

// export const CreateProductForm = () => {
//     const [name, setName] = useState

//     const navigate = useNavigate(); 
//     const {id: productId} = useParams(); 

//     const handleProductSubmit = async (e) => {
//         <e.preventDefault(); 
//         if(productId) {
//             await updateProduct ({ id: productId, name: productName}); 
//             navigate("/products"); 

//         }else {
//             const newProduct = await CreateProductForm({name: productName});
//             if(newProduct) navigate("/products"); 
//         }
//     }; 

//     const callGetProduct = async () => {
//         const product = await getByDisplayValue(productId);
//         setProductName(product.name); 
//     }; 

//     useEffect(() => {
//         if(productId) callGetProduct(productId); 
//     }, [productId]); 

//     return (

//         <>
//         <ProductPageHeader title={productId ? "Edit " : "Name Your Product"} />
//         <div className="container pt-5">
//           <div className="container d-flex align-items-center justify-content-center flex-column">
//             <form onSubmit={handleProductSubmit}>
//               {productId ? (
//                 <h1 className="p-4">
//                    Enter a new Product name.
//                 </h1>
//               ) : (
//                 <h1 className="p-4">Enter a price</h1>
//               )}
//               <Input
//                 placeholder={productName}
//                 onChange={(e) => setProductName(e.target.value)}
//               />
  
//               <button
                
//                 type="submit"
//                 className="btn mt-4 btn-primary mx-1 text-white w-100"
//               >
//                 Save
//               </button>
             
             
             
             
             
//               <button
//                 onClick={() => navigate("/tags")}
//                 type="button"
//                 className="btn mt-4 btn-outline-primary mx-1 text-primary w-100"
//               >
//                 Cancel
//               </button>

//             </form>
//           </div>
//         </div>
//       </>



//     )
// }