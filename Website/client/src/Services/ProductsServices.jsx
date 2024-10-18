const baseUrl = 'https://localhost:7143/api/Products'; 

// Get all products
export const GetAllProducts = () => {
    return fetch(baseUrl).then((res) => res.json());
      
};

// Get a product by ID
export const GetProductById = (id) => {
    return fetch(`${baseUrl}/${id}`)
        .then((res) => res.json())
};

export const addProduct = (singleProduct) => {
  return fetch(baseUrl, {
    method: "POST", 
    headers: {
      "Content-Type": "application/json", 
    },
    body: JSON.stringify(singleProduct),
    })  
}



export const EditProduct = (product) => {  
    return fetch(`${baseUrl}/${product.id}`, {
      method: "PUT", 
      headers: {
        "Content-Type": "application/json", 
      }, 
      body: JSON.stringify(product)
    })


}
  
  export const DeleteProduct = (productId) => {
      return fetch(`${baseUrl}/${productId}`, {
        method: "DELETE"
      })
  }
  