import Usuario from '../models/Usuario';
import api from '../Interceptor/interceptor'

const url = 'usuario/login'

export default {

    EfetuarLogin: async function (usuario: Usuario) {

        try {
            const response = await api.post(url, JSON.stringify(usuario), {
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': '*'
                }
            })

            return response.data

        } catch (error) {                                    
            throw error
        }
    }

}
