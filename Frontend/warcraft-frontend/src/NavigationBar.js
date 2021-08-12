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
                        <Link className="nav-link" to="/territory" >Område</Link>
                        <Link className="nav-link" to="/report" >Rapport</Link>
                        <Link className="nav-link" to="/store" >Affär</Link>
                        <Link className="nav-link pl-3" to="" >Profil</Link>
                        <Link className="nav-link" to="" >Rank</Link>

                        <Link className="nav-link" to="/login" >Logga ut</Link>
                    </Nav>
                </Navbar.Collapse>



            </Navbar>
        </>
    )
}

export default NavigationBar