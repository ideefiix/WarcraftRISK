import './login.css'
import 'react-toastify/dist/ReactToastify.css';
import React, { useState, useEffect } from 'react'
import { Card, Container } from 'react-bootstrap'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'
import Row from 'react-bootstrap/Row'
import { login as loginCall } from '../../AxiosRequest'
import { ToastContainer, toast } from 'react-toastify';
const Login = (props) => {
    const [password, setpassword] = useState("")
    const [name, setname] = useState("")

    async function handleLogin() {
        if (password === "" || name === "") {
            toast.info('Fyll i dina uppgifter!', {
                position: "top-center",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: false,
                draggable: true,
                progress: undefined,
                });

        } else {
            let res = await loginCall(name, password);

            if ((200 <= res.status) && (res.status < 300)) {
                console.log(res.data);
                sessionStorage.setItem("Token", res.data.token)
                props.setplayer({id: res.data.playerID, name: res.data.playerName })
                props.setloggedIn(true)
            } else {
                toast.info('Det finns inget konto med dom uppgifterna', {
                    position: "top-center",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: false,
                    draggable: true,
                    progress: undefined,
                    });
                
            }
        }

    }

    function isEnterPressed(event) {
        if(event.key === 'Enter'){
            handleLogin();
        }
    }
    return (
        <div className="d-flex justify-content-center containerLogin">

            <Card className="loginBox" onKeyDown={isEnterPressed}>
                <Card.Body>
                    <Card.Title>Logga in</Card.Title>
                    <Row>
                        <label htmlFor="usernameInput">användarnamn</label>
                    </Row>
                    <Row>
                        <input className="w-50" type="text" id="usernameInput" onChange={e => setname(e.target.value)} />
                    </Row>
                    <Row>
                        <label htmlFor="passwordInput">lösenord</label>
                    </Row>
                    <Row>
                        <input className="w-50" type="password" id="passwordInput" onChange={e => setpassword(e.target.value)} />
                    </Row>
                    <Row className="mt-3">
                        <Col >
                            <p className=""><u>Skapa konto</u></p>
                        </Col>
                        <Col>
                            <Button className="w-100" variant="primary" onClick={handleLogin}>Logga in</Button>
                        </Col>
                    </Row>
                </Card.Body>
            </Card>
            
        </div>


    )
}

export default Login
