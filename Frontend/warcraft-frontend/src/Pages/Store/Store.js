import './Store.css'
import '../Common.css'
import React, { useState, useEffect } from 'react'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import village1 from '../../Utilities/Images/villageLVL1.png'
import tradingPost from '../../Utilities/Images/tradingPost.png'
import inn from '../../Utilities/Images/inn.png'
import spy from '../../Utilities/Images/Spy.png'
import Card from 'react-bootstrap/Card'
import CardGroup from 'react-bootstrap/CardGroup'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'

const Store = () => {

    return (
        <div className="bg-light mt-3 mb-2 pb-5">
            <h3 className="headerTextMargin">Affären</h3>
            <hr></hr>
            <Row >
                <Col xs={{span: 5, offset: 1}} md={{span: 3, offset: 1}} xl={{span: 2, offset: 1}}>
                    <Card className="ml-5 mb-1" style={{ width: '11rem' }}>
                        <Card.Img variant="top" src={tradingPost} />
                        <Card.Body>
                            <Card.Title>Marknad</Card.Title>
                            <Card.Text>
                                +1 guld/timmen
                            </Card.Text>
                            <Button variant="primary">Go somewhere</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col xs={5} md={3} xl={2}>
                    <Card className="mb-1" style={{ width: '11rem' }}>
                        <Card.Img variant="top" src={inn} />
                        <Card.Body>
                            <Card.Title>Värdshus</Card.Title>
                            <Card.Text>
                                +1 soldat/timmen
                            </Card.Text>
                            <Button variant="primary">Go somewhere</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col xs={{span: 5, offset: 1}} md={{span: 3, offset: 0}} xl={2}>
                    <Card className="mb-1" style={{ width: '11rem' }}>
                        <Card.Img variant="top" src={spy} />
                        <Card.Body>
                            <Card.Title>Spion</Card.Title>
                            <Card.Text>
                                +1 spion
                            </Card.Text>
                            <Button variant="primary">Go somewhere</Button>
                        </Card.Body>
                    </Card>
                </Col>
                    
            </Row>

        </div>
    )
}

export default Store
