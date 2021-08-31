import axios from 'axios'

axios.defaults.baseURL = process.env.REACT_APP_SERVER_BASE_URL ? process.env.REACT_APP_SERVER_BASE_URL : "https://localhost:5001";

axios.interceptors.request.use(function (config) {
    const token = `Bearer ${sessionStorage.getItem('Token')}`;
    config.headers.Authorization = token;

    return config;
});
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

// TOKEN
export async function login(playerName, playerPassword) {
    try {
        const body = {
            playerName,
            playerPassword
        }
        let response = await axios.post('/login', body)
            .then(res => {
                return res
            })
        return response
    }
    catch (e) {
        return e
    }
}
// PLAYER
export async function getPlayer(playerID) {
    try {
        let response = await axios.get(`/player/${playerID}`)
        return response
    }
    catch (e) {
        return e
    }
}
// TERRITORY
export async function getTerritoriesForPlayer(playerID) {
    try {
        let res = await axios.get(`/tile/owner/${playerID}`)

        return res
    }
    catch (e) {
        return e
    }
}
// SCOUT
export async function getScouts(playerID){
    try {
        let res = await axios.get(`/scout/get/${playerID}`);
        return res;
    }
    catch (e){
        return e
    }
}

export async function sendScout(playerID) {
    try {
        let res = await axios.put(`/scout/send/${playerID}`);
        return res;
    }
    catch (e){
        return e
    }
}

// REPORT
export async function getReportsForPlayer(playerID) {
    try {
        let res = await axios.get(`/report/${playerID}`)
        return res;
    }
    catch (e) {
        return e
    }
}