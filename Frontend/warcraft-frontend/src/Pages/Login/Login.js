import './login.css'
import React from 'react'
import { Card, Container } from 'react-bootstrap'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'
import Row from 'react-bootstrap/Row'

const Login = () => {

    function login(){
        
        /* try {
            const response = await federatedLogin();
            if (response) {
                window.open(response.redirectUrl, "_self")
            }
        } catch (e) {
            console.log("logerr",e);
        } */
    }
    return (
        <Row className="containerLogin" >
            <Col xs={8} md={5} lg={4} className="mx-auto my-auto">
            <Card className=" ">
                <Card.Body>
                    <Card.Title>Logga in</Card.Title>
                    <Row>
                    <label htmlFor="usernameInput">användarnamn</label>
                    </Row>
                    <Row>
                    <input className="w-50" type="text" id="usernameInput" />
                    </Row>
                    <Row>
                    <label htmlFor="passwordInput">lösenord</label>
                    </Row>
                    <Row>
                    <input className="w-50" type="text" id="passwordInput" />
                    </Row>
                    <Row className="mt-3">
                        <Col >
                        <p className=""><u>Skapa konto</u></p>
                        </Col>
                        <Col>
                    <Button className="w-100" variant="primary">Logga in</Button>
                        </Col>
                    </Row>
                </Card.Body>
            </Card>
            </Col>
            
        </Row>
    )
}

export default Login
