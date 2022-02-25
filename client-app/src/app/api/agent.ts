import axios, { AxiosResponse } from 'axios';
import { OwnersInfo } from '../models/ownersinfo';
import { toast } from 'react-toastify';
import { StationOwnersInfo } from '../models/stationOwnerInfo';



  axios.defaults.baseURL = 'http://localhost:5000/api';
//axios.defaults.baseURL  = 'https://localhost:44391/api';
axios.defaults.withCredentials = true;


axios.interceptors.response.use(undefined, error => {
    if(error.message === 'Network Error' && !error.response){
        toast.error('Network error - make sure API is running!');
    }
    const {status} = error.response;
  
    if(status === 500){
        toast.error('Server error - check the terminal for more info!');
    }

    throw error.response;
})

const responseBody = (response: AxiosResponse) => response.data;

const sleep = (ms: number) => (response: AxiosResponse) =>
    new Promise<AxiosResponse>(resolve => setTimeout(() => resolve(response), ms));

const requests = {
    get: (url: string) => axios.get(url).then(sleep(1000)).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(sleep(1000)).then(responseBody),
    postForm: (url: string, data: FormData) => axios.post(url, data, {
        headers: {'Content-type': 'multipart/form-data'}
    })
}

function createFormData(item: any) {
    let formData = new FormData();
    for (const key in item) {
        formData.append(key, item[key])
    }
    return formData;
}
const VehicleOwnersInfo = {
    list: (): Promise<OwnersInfo[]> => requests.get('/VehicleOwnerInfos'),
    create: (ownersinfo: any) => requests.post('/VehicleOwnerInfos', createFormData(ownersinfo)),
    
}

const StationOwnerInfo = {
    list: (): Promise<StationOwnersInfo[]> => requests.get('/FuellingStationOwner'),
    create: (stationownersinfo: any) => requests.post('/FuellingStationOwner', createFormData(stationownersinfo)),
    
}



export default {
    VehicleOwnersInfo,
    StationOwnerInfo
}