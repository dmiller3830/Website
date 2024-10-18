import { Link, useNavigate } from "react-router-dom";
import { logout } from "../Services/UserServices.jsx";

const Header = () => {

  const navigate = useNavigate()
    return (
        <nav className="navbar navbar-expand navbar-dark bg-info">
        
          <Link to="/Products" className="navbar-brand">   Store   </Link>
       
          <Link>      
          
          
           Webtoons      
           
           
            </Link>

       

          <Link>      Gallery      </Link>

          <Link to="/Products">      Products      </Link>


          <Link>     Orders    </Link>

          <Link>     Blog       </Link>

          
          <Link onClick={() =>{ logout().then(navigate("/")) }}> Log Out </Link>



          
        </nav>
      );
    };
    
    export default Header;
