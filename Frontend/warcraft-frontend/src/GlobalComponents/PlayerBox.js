import React, { useState, useEffect } from 'react'
import { Row } from 'react-bootstrap'
import {goldIcon, scoreIcon, minionIcon, territoryIcon, spyIcon} from '../Utilities/Icons'
import {getPlayer} from '../AxiosRequest.js'
const PlayerBox = (props) => {

    const [playerInfo, setplayerInfo] = useState({})

    useEffect(() => {
        fetchPlayer();
    }, [])

    async function fetchPlayer(){
        let res = await getPlayer(props.player.id);
        setplayerInfo(res.data)
    }
    return (
        <div className="bg-light">
            <Row className="mb-0">
                <h3 className="text-center mt-2 mb-0">{playerInfo.name}</h3>
            </Row>
            <hr className="m-0"/>
            <Row className="mt-2">
            <p className="mb-0 ml-3">{goldIcon} {playerInfo.cash} <span className="text-muted">guld +{playerInfo.income} </span> </p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0 ">{minionIcon} {playerInfo.soldiers} <span className="text-muted">soldater +{playerInfo.soldierIncome}</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{spyIcon} {`${playerInfo.spiesAvailable}/${playerInfo.spiesTotal}`}  <span className="text-muted">spioner</span></p>
            </Row>
            <Row className="mt-0">
            <p className="mb-0">{territoryIcon} {playerInfo.ownedTerritories} <span className="text-muted">territorium</span></p>
            </Row>
            <Row className="mt-0">
            <p className="">{scoreIcon} {playerInfo.score} <span className="text-muted">poäng</span></p>
            </Row>
        </div>
    )
}

export default PlayerBox
