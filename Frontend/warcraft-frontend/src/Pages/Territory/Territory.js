import './Territory.css'
import '../Common.css'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import Card from 'react-bootstrap/Card'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'
import { getTerritoriesForPlayer } from '../../AxiosRequest.js'
import React, { useState, useEffect } from 'react'
import village1 from '../../Utilities/Images/villageLVL1.png'
const Territory = (props) => {
    const [territories, setTerritories] = useState([])

    useEffect(() => {
        fetchTerritories();
        props.fetchPlayer()
    }, [])

    async function fetchTerritories() {
        let res = await getTerritoriesForPlayer(props.player.id);
        let arr = res.data
        console.log(arr);

        setTerritories(arr)
    }

    function GenerateVillageItem(t) {
        return (
            <Accordion className="mt-2" key={t.id} >
                <Accordion.Item eventKey="0">
                    <Accordion.Header>
                        <Figure className="mb-0">
                            <Image src={village1} width="60px" />
                            <FigureCaption className="text-center">By #{t.id}</FigureCaption>
                        </Figure>

                        <p className="text-margin">Garnison: {t.defence}</p>
                        <p className="text-margin">Mur: nivå {t.wallLvl}</p>
                        <p className="text-margin">By: nivå {t.villageLvl}</p>
                        <p className="text-margin">Inkomst: NOT IMPLEMENTED</p>

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
                            <Col xs={{ span: 3, offset: 1 }}>
                                <Row>
                                    <p className="borderMargin text-center">Uppgradera mur</p>
                                </Row>
                                <Row>
                                    <Button variant="outline-dark">Betala 150 g</Button>
                                </Row>
                            </Col>
                            <Col xs={{ span: 3, offset: 1 }}>
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
