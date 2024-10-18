
const baseUrl = 'https://localhost:7143/api/User'; 

// https://localhost:7143/api/User/GetByEmail?email=

export const getUserById = (id) => {
    return fetch (`${baseUrl}/GetUserById/${id}`).then((res) => res.json()); 
}; 

export const login = (userObject) => {
    return fetch(`${baseUrl}/getbyemail?email=${userObject.email}`)
    .then((r) => r.json())
      .then((userProfile) => {
        if(userProfile.id){
          localStorage.setItem("userProfile", JSON.stringify(userProfile));
          return userProfile
        }
        else{
          return undefined
        }
      });
  };
  
  export const logout = () => {
        localStorage.clear()
  };
  
  export const register = (userObject, password) => {
    return  fetch(`${baseUrl}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userObject),
    })
    .then((response) => response.json())
      .then((savedUserProfile) => {
        localStorage.setItem("userProfile", JSON.stringify(savedUserProfile))
      });
  };
  
  