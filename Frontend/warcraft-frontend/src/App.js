import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import Col from "react-bootstrap/Col"
import { Container } from 'react-bootstrap';
import Login from './Pages/Login/Login.js'
import logo from './logo.svg';
import NavigationBar from './NavigationBar';
import PlayerBox from './PlayerBox';
import React, { useState, useEffect } from 'react'
import Row from "react-bootstrap/Row"
import Territory from './Pages/Territory/Territory';
import Image from 'react-bootstrap/Image'
import Report from './Pages/Report/Report';
import Store from './Pages/Store/Store';
import Profile from './Pages/Profile/Profile';

function App() {
  //CHANGE TO FALSE LATER
  const [loggedIn, setloggedIn] = useState(false)
  return (
    <div>
      <Container>
        {loggedIn ?
          <Row>
            <Col xs={3}>
              <PlayerBox playerName="Fille" gold="755" minions="45" points="12" />
            </Col>
            <Col xs={9}>
              <NavigationBar />
            </Col>
          </Row>
          : null
        }


        <Switch>
          {loggedIn ? <Redirect exact from="/" to="/territory" /> : <Redirect exact from="/" to="/login" />}

          <Route exact path="/login" render={() => <Login />} />

          <Route exact path="/territory" render={() => <Territory/>} />

          <Route exact path="/report" render={() => <Report/>} />
          
          <Route exact path="/store" render={() => <Store/>} />

          <Route exact path="/profile" render={() => <Profile/>} />
        </Switch>
      </Container>
      <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"
        crossOrigin="anonymous"
      />
    </div>


  );
}

export default App;
