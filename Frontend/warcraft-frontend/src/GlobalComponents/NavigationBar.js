import React from 'react'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import { NavDropdown } from 'react-bootstrap'
import { Link } from 'react-router-dom';

// Used in ALL pages
const NavigationBar = (props) => {

    return (
        <>
            <Navbar collapseOnSelect expand="sm" bg="light" variant="light">
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">

                    <Nav className="mx-auto ">
                        <Link className="nav-link" to="/territory" >Områden</Link>
                        <Link className="nav-link" to="/scout" >Spejare</Link>
                        <Link className="nav-link" to="/report" >Rapporter</Link>
                        <Link className="nav-link" to="/store" >Affären</Link>
                        <Link className="nav-link pl-3" to="/profile" >Profil</Link>
                        <Link className="nav-link" to="" >Rank</Link>

                        <Link className="nav-link" to="/login" >Logga ut</Link>
                    </Nav>
                </Navbar.Collapse>



            </Navbar>
        </>
    )
}

export default NavigationBar