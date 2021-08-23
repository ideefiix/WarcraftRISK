import './Report.css'
import '../Common.css'
import React, { useState, useEffect } from 'react'
import { Accordion, Button, Image, Row, Col } from 'react-bootstrap';
import village1 from '../../Utilities/Images/villageLVL1.png'
import Card from 'react-bootstrap/Card'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'
import { getReportsForPlayer } from '../../AxiosRequest'
import { ValidateRequest } from '../../Utilities/RequestHandler'

const Report = (props) => {

    const [reports, setReports] = useState([])

    useEffect(() => {
        fetchReports();
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

    function ExpiryTimeFormatter(timeStamp) {
        let timeDiff = new Date(timeStamp).getTime() - new Date().getTime()//In ms
        let MinutesTotal = Math.floor(timeDiff / (1000 * 60));

        let hours = Math.floor(MinutesTotal / 60);
        let minutes = (MinutesTotal % 60)
        if (hours >= 1) {

            return (`${hours} timmar ${minutes} minuter`)

        } else {
            return (`${minutes} minuter`)
        }

    }

    function GenerateReportItem(t) {
        return (
            <Accordion className="mt-2" key={t.id} >
                <Accordion.Item eventKey="0">
                    <Accordion.Header>
                        <Figure className="mb-0">
                            <Image src={village1} width="60px" />
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
