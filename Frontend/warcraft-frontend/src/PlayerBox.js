import React from 'react'
import { Row } from 'react-bootstrap'
import {goldIcon, scoreIcon, minionIcon, territoryIcon, spyIcon} from './Utilities/Icons'

const PlayerBox = (props) => {
    return (
        <div className="bg-light">
            <Row className="mb-0">
                <h3 className="text-center mt-2 mb-0">{props.playerName}</h3>
            </Row>
            <hr className="m-0"/>
            <Row className="mt-2">
            <p className="mb-0 ml-3">{goldIcon} 500 <span className="text-muted">guld +50 </span> </p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0 ">{minionIcon} 500 <span className="text-muted">soldater +27</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{spyIcon} 2 <span className="text-muted">spioner</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{territoryIcon} 5 <span className="text-muted">territorium</span></p>
            </Row>
            <Row className="mt-0">
            <p className="">{scoreIcon} 500 <span className="text-muted">poäng</span></p>
            </Row>
        </div>
    )
}

export default PlayerBox
