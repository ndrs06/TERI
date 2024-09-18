import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.scss'
import {BrowserRouter, Route, Routes} from "react-router-dom";

import Layout from './pages/Layout/Layout.jsx';
import Home from "./pages/Home.jsx";
import SignUp from "./pages/SignUp.jsx";
import SignIn from "./pages/SignIn.jsx";

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        
        <Route path="/" element={<Layout />}>
            <Route path="/" element={<Home />}/>
            <Route path="/sign-up" element={<SignUp />}/>
            <Route path="/sign-in" element={<SignIn />}/>
        </Route>
        
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
)
