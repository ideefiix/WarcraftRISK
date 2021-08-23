import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import Col from "react-bootstrap/Col"
import { Button, Container } from 'react-bootstrap';
import Login from './Pages/Login/Login.js'
import logo from './logo.svg';
import NavigationBar from './GlobalComponents/NavigationBar';
import PlayerBox from './GlobalComponents/PlayerBox';
import React, { useState, useEffect } from 'react'
import Row from "react-bootstrap/Row"
import Territory from './Pages/Territory/Territory';
import Image from 'react-bootstrap/Image'
import Report from './Pages/Report/Report';
import Store from './Pages/Store/Store';
import Profile from './Pages/Profile/Profile';
import { ToastContainer, toast } from 'react-toastify';

function App() {
 
  const [loggedIn, setloggedIn] = useState(false)
  const [player, setplayer] = useState({id: null, name: null})
  return (
    <div>
      <Container>
        <Button onClick={() => console.log(player)}></Button>
        {loggedIn ?
          <Row>
            <Col xs={3}>
              <PlayerBox player={player} />
            </Col>
            <Col xs={9}>
              <NavigationBar />
            </Col>
          </Row>
          : null
        }


        <Switch>
          {loggedIn ? <Redirect exact from="/" to="/territory" /> : <Redirect exact from="/" to="/login" />}
          {loggedIn ? <Redirect exact from="/login" to="/territory" /> : null}
          <Route exact path="/login" render={() => <Login setloggedIn={setloggedIn} setplayer={setplayer}/>} />

          <Route exact path="/territory" render={() => <Territory player={player} />} />

          <Route exact path="/report" render={() => <Report player={player} />} />
          
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
      <ToastContainer
          position="top-center"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
        />
    </div>


  );
}

export default App;
