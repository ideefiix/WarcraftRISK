import './Report.css'
import '../Common.css'
import React, { useState, useEffect } from 'react'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import village1 from '../../Utilities/Images/villageLVL1.png'
import map from '../../Utilities/Images/mapIcon.png'
import Card from 'react-bootstrap/Card'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'
import {ExpiryTimeFormatter} from '../../Utilities/TimeFormatter'
import { getReportsForPlayer } from '../../AxiosRequest'
import { ValidateRequest } from '../../Utilities/RequestHandler'

const Report = (props) => {

    const [reports, setReports] = useState([])

    useEffect(() => {
        fetchReports();
        props.fetchPlayer();
    }, [])

    async function fetchReports() {
        let data = await getReportsForPlayer(props.player.id)
        let requestStatus = ValidateRequest(data);
        if (requestStatus) {
            let arr = data.data;
            setReports(arr)
        }else{
            //Bad request. Do nothing
        }



    }

    function GenerateReportItem(t) {
        if(t.territory == null){
            return (
                <Accordion className="mt-2" key={t.id} >
                    <Accordion.Item eventKey="0">
                        <Accordion.Header>
                            <Figure className="mb-0">
                                <Image src={map} height="31px" />
                                <FigureCaption className="text-center"></FigureCaption>
                                <FigureCaption className="text-center">NotFound</FigureCaption>
                            </Figure>
    
                            <p className="text-margin">Inget land hittades</p>
                            <p className="text-margin">Försvinner: {ExpiryTimeFormatter(t.expiryDate)}</p>
                        </Accordion.Header>
                    </Accordion.Item>
                </Accordion>
            )
        }else{
           return (
            <Accordion className="mt-2" key={t.id} >
                <Accordion.Item eventKey="0">
                    <Accordion.Header>
                        <Figure className="mb-0">
                            <Image src={village1} height="31px" />
                            <FigureCaption className="text-center">By #{t.territory.id}</FigureCaption>
                        </Figure>

                        <p className="text-margin">Ägare: {t.territory.ownedBy}</p>
                        <p className="text-margin">Soldater: {t.territory.defence}</p>
                        <p className="text-margin">Mur: nivå {t.territory.villageLvl}</p>
                        <p className="text-margin">By: nivå {t.territory.wallLvl}</p>
                        <p className="text-margin">Tid kvar: {ExpiryTimeFormatter(t.expiryDate)}</p>

                    </Accordion.Header>
                    <Accordion.Body>
                        <Row>
                            <Col xs={{ span: 3, offset: 1 }} lg={{ span: 2, offset: 1 }} className="">
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
        
    }
    return (
        <div className="bg-light mt-3 pb-5 report-container">
            <h3 className="headerTextMargin">Dina rapporter</h3>
            <hr></hr>

            {
                reports.length == 0 ?
                    <p className="ml-3">Du har inga tillgängliga rapporter</p>
                    :
                 reports.map(r =>
                    GenerateReportItem(r)
                ) 
            }
        </div>
    )
}

export default Report
