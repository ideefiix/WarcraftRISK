import './Scout.css'
import { Card, Button, Image, Row, Col } from 'react-bootstrap';
import {ExpiryTimeFormatter} from '../../Utilities/TimeFormatter'
import Figure from 'react-bootstrap/Figure'
import FigureCaption from 'react-bootstrap/FigureCaption'
import React, { useState, useEffect } from 'react'
import spyImage from '../../Utilities/Images/Spy.png'
import {getScouts, sendScout} from '../../AxiosRequest'
import {ValidateRequest} from '../../Utilities/RequestHandler'
import { ToastContainer, toast } from 'react-toastify';
const Scout = (props) => {
    const [scouts, setscouts] = useState([])

    useEffect(() => {
        fetchScouts();
    }, [])

    async function fetchScouts(){
        let res = await getScouts(props.player.id);
        let scouts = res.data;
        console.log(scouts);

        setscouts(res.data);
    }

    async function onSendScout(){
        let res = await sendScout(props.player.id);
        if(ValidateRequest(res)){
            fetchScouts();
        }else{
            toast.error('Något gick fel!', {
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

    function generateScoutItem(scout) {
        if (scout.scoutTime === null) {
            return (
                <Col xs="auto" className="">
                <Card className="scoutCard align-items-center mt-4">
                    <Card.Body className="">
                    <Figure className="mb-0 d-block">
                            <Image className="cardItem" src={spyImage} width="60px" />
                            <FigureCaption className="text-center">Spion #{scout.id}</FigureCaption>
                        </Figure>
                        <p className="text-center mt-2">Redo</p>
                        <Button variant="primary" onClick={onSendScout}>Spionera</Button>
                    </Card.Body>
                </Card>
                </Col>
                
            )
        }
        else{
            return (
                <Col xs="auto" className="">
                <Card className="scoutCard align-items-center mt-4">
                    <Card.Body className="">
                    <Figure className="mb-0 d-block">
                            <Image className="cardItem" src={spyImage} width="60px" />
                            <FigureCaption className="text-center">Spion #{scout.id}</FigureCaption>
                        </Figure>
                        <p className="text-center mt-2">Tid kvar:</p>
                        <p className="small ">{ExpiryTimeFormatter(scout.scoutTime)}</p>
                    </Card.Body>
                </Card>
                </Col>
                
            )
        }
    }

    return (
        <div className="bg-light mt-3 pb-5 report-container">
            <h3 className="headerTextMargin">Dina spioner</h3>
            <hr className="mb-0"></hr>
            <Row className="m-auto">
               {
                scouts.map(scout => generateScoutItem(scout)
                )} 
            </Row>
            
        </div>
    )
}

export default Scout
