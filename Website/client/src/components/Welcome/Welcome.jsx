import { useNavigate } from "react-router-dom";

export const Welcome = () => {

const navigate = useNavigate();

    const handleLogin = () => {
        navigate(`/login`);
          };

          const handleRegister = () => {
            navigate(`/register`);
              };

    return (

        <div>
<h1>

    <span> Welcome to 

        <div>
            <span> The Obscura Den </span>
        </div>
    </span>

   

</h1>

<div> This is a Website Devoted to Some of My Hobbies and interests </div>




        </div>
    )
}