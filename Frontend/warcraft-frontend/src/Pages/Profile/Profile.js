import React, { useState, useEffect } from 'react'

const Profile = (props) => {

    useEffect(() => {
        props.fetchPlayer();
    }, [])

    return (
        <div className="bg-light mt-3">
            <p>Profilsidan är inte klar</p>
        </div>
    )
}

export default Profile
