import Usuario from '../models/Usuario';
import axios from '../../src/services/interceptor'

const url = 'usuario/login'

export const EfetuarLogin = async (usuario: Usuario) => {

    try {
        const response = await axios.post(url, JSON.stringify(usuario), {
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            }
        })        
    } catch (error) {
        console.log(error)
    }
    
}

