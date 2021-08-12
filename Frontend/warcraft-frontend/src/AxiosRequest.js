import axios from 'axios'

axios.defaults.baseURL = process.env.REACT_APP_SERVER_BASE_URL ? process.env.REACT_APP_SERVER_BASE_URL : "https://localhost:5001";

/* axios.interceptors.request.use(function (config) {
    const token = `Bearer ${sessionStorage.getItem('AUTH_TOKEN')}`;
    config.headers.Authorization = token;

    return config;
}); */


function login() {
    
}