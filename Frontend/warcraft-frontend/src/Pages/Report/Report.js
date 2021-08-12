import './Report.css'
import '../Common.css'
import React, { useState, useEffect } from 'react'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import village1 from '../../Utilities/Images/villageLVL1.png'
import Card from 'react-bootstrap/Card'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'

const Report = () => {

    const [reports, setReports] = useState([])

    useEffect(() => {
        fetchReports();
    }, [])

    function fetchReports() {
        let arr = []
        arr.push({
            villageId: 27,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        arr.push({
            villageId: 32,
            owner: "Ogge",
            income: 35,
            troops: 170,
            village: 3,
            wall: 5,
            expiresIn: "5 h"
        })
        setReports(arr)
    }

    function GenerateReportItem(t) {
        return (
            <Accordion className="mt-2" key={t.id} >
                <Accordion.Item eventKey="0">
                    <Accordion.Header>
                        <Figure className="mb-0">
                            <Image src={village1} width="60px" />
                            <FigureCaption>By #122</FigureCaption>
                        </Figure>

                        <p className="text-margin">Ägare: Ogge</p>
                        <p className="text-margin">Soldater: 300</p>
                        <p className="text-margin">Mur: nivå 2</p>
                        <p className="text-margin">By: nivå 2</p>
                        <p className="text-margin">Upphör: 23 timmar</p>

                    </Accordion.Header>
                    <Accordion.Body>
                        <Row>
                            <Col xs={{span: 3, offset: 1}} lg={{span: 2, offset: 1}} className="">
                                <Row >
                                    <input type="text" name="reinforceInput" placeholder="Antal soldater"></input>
                                </Row>
                                <Row >
                                    <Button variant="outline-dark">Anfall</Button>
                                </Row>
                            </Col>
                        </Row>


                    </Accordion.Body>
                </Accordion.Item>
            </Accordion>
        )
    }
    return (
        <div className="bg-light mt-3 pb-5 report-container">
            <h3 className="headerTextMargin">Dina rapporter</h3>
            <hr></hr>
            {reports.map(r =>
                GenerateReportItem(r)
            )}
        </div>
    )
}

export default Report
