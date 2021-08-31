import React, { useState, useEffect } from 'react'
import { Row } from 'react-bootstrap'
import {goldIcon, scoreIcon, minionIcon, territoryIcon, spyIcon} from '../Utilities/Icons'
const PlayerBox = (props) => {

    return (
        <div className="bg-light">
            <Row className="mb-0">
                <h3 className="text-center mt-2 mb-0">{props.player.name}</h3>
            </Row>
            <hr className="m-0"/>
            <Row className="mt-2">
            <p className="mb-0 ml-3">{goldIcon} {props.player.cash} <span className="text-muted">guld +{props.player.income} </span> </p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0 ">{minionIcon} {props.player.soldiers} <span className="text-muted">soldater +{props.player.soldierIncome}</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{spyIcon} {`${props.player.spiesAvailable}/${props.player.spiesTotal}`}  <span className="text-muted">spioner</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{territoryIcon} {props.player.ownedTerritories} <span className="text-muted">territorium</span></p>
            </Row>
            <Row className="mt-0">
            <p className="">{scoreIcon} {props.player.score} <span className="text-muted">poäng</span></p>
            </Row>
        </div>
    )
}

export default PlayerBox
