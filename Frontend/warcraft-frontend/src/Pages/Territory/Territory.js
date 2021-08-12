import './Territory.css'
import '../Common.css'
import React, { useState, useEffect } from 'react'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import village1 from '../../Utilities/Images/villageLVL1.png'
import Card from 'react-bootstrap/Card'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'

const Territory = () => {
    const [territories, setTerritories] = useState([])

    useEffect(() => {
        fetchTerritories();
    }, [])

    function fetchTerritories() {
        let arr = []
        arr.push({
            id: 96,
            troops: 133,
            income: 37,
            lvl: 3,
            wall: 5
        })
        arr.push({
            id: 95,
            troops: 13,
            income: 42,
            lvl: 1,
            wall: 4
        })
        setTerritories(arr)
    }

    function GenerateVillageItem(t) {
        return (
            <Accordion className="mt-2" key={t.id} >
                <Accordion.Item eventKey="0">
                    <Accordion.Header>
                        <Figure className="mb-0">
                            <Image src={village1} width="60px" />
                            <FigureCaption>By #122</FigureCaption>
                        </Figure>

                        <p className="text-margin">Soldater: 300</p>
                        <p className="text-margin">Mur: nivå 2</p>
                        <p className="text-margin">By: nivå 2</p>
                        <p className="text-margin">Inkomst: 25</p>
                        <p className="text-margin">Erövrad: 3 dagar 7 timmar</p>

                    </Accordion.Header>
                    <Accordion.Body>
                        <Row>
                            <Col xs={3} className="">
                                <Row >
                                    <input type="text" name="reinforceInput" placeholder="Antal soldater"></input>
                                </Row>
                                <Row >
                                    <Button variant="outline-dark">Skicka förstärkning</Button>
                                </Row>
                            </Col>
                            <Col xs={{span: 3, offset: 1}}>
                                <Row>
                                <p className="borderMargin text-center">Uppgradera mur</p>
                                </Row>
                                <Row>
                                    <Button variant="outline-dark">Betala 150 g</Button>
                                </Row>
                            </Col>
                            <Col xs={{span: 3, offset: 1}}>
                                <Row>
                                <p className="borderMargin text-center">Uppgradera byn</p>
                                </Row>
                                <Row>
                                    <Button variant="outline-dark">Betala 200 g</Button>
                                </Row>
                            </Col>
                        </Row>


                    </Accordion.Body>
                </Accordion.Item>
            </Accordion>
        )
    }



    return (
        <div className="bg-light mt-3 pb-5 territory-container">
            <h3 className="headerTextMargin">Dina områden</h3>
            <hr></hr>
            {territories.map(t =>
                GenerateVillageItem(t)
            )}
        </div>
    )
}

export default Territory
