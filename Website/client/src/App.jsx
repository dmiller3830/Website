import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import ApplicationViews from './Views/ApplicationViews.jsx';
import Authorize from './components/Auth/Authorize.jsx';
import Header from './components/Header.jsx';
import { BrowserRouter } from 'react-router-dom';


function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(true);

    useEffect(() => {
        if (!localStorage.getItem("userProfile")) {
            setIsLoggedIn(false);
        }
    }, [isLoggedIn]);

    return (
        <BrowserRouter>
            <Header isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn} />
            {isLoggedIn ? (
                <ApplicationViews />
            ) : (
                <Authorize setIsLoggedIn={setIsLoggedIn} />
            )}
        </BrowserRouter>
    );
}

export default App;
