import Usuario from '../models/Usuario';
import axios from 'axios'

const url = 'https://localhost:5001/api/usuario/login'

export const EfetuarLogin = async (usuario: Usuario) => {

    await axios.post(url, JSON.stringify(usuario), {
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        }
    })
    .then(res =>  console.log(res.data))
    .catch(err => console.log(err))
    
}

