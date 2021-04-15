import api from "../interceptor/http-interceptor";

const url = "usuario";

export const UsuarioService = () => {
  const GetAll = async () => {
    try {
      const { data } = await api.get(url);
      return data;
    } catch (error) {
      throw error;
    }
  };

  return { GetAll };
};
