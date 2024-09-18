import React from "react";
import {Outlet} from "react-router-dom";
import Navbar from "../../components/Navbar/Navbar.jsx";
import "./Layout.scss"

export default function Layout() {

    return (
        <div className="layout">
            <header className="layout-header">
                <h1>Welcome to TERI's page</h1>
                    
            </header>
                    <Navbar/>
            <div className="layout-content">
                <aside className="layout-sidebar layout-sidebar-left">
                    <nav>
                        <ul>
                            <li><a href="#">Left Link 1</a></li>
                            <li><a href="#">Left Link 2</a></li>
                            <li><a href="#">Left Link 3</a></li>
                        </ul>
                    </nav>
                </aside>
                <main className="layout-main">
                    <Outlet/>
                </main>
                <aside className="layout-sidebar layout-sidebar-right">
                    <nav>
                        <ul>
                            <li><a href="#">Right Link 1</a></li>
                            <li><a href="#">Right Link 2</a></li>
                            <li><a href="#">Right Link 3</a></li>
                        </ul>
                    </nav>
                </aside>
            </div>
            <footer className="layout-footer">
                <p>Footer Content</p>
            </footer>
        </div>
    );
}
