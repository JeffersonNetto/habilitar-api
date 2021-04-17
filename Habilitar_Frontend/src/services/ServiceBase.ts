import api from "../interceptor/http-interceptor";

const ServiceBase = <T>(url: string) => {
  const GetAll = async () => {
    try {
      const { data } = await api.get<T[]>(url);
      return data;
    } catch (error) {
      throw error;
    }
  };

  const Insert = async (usuario: T) => {
    try {
      const { data } = await api.post<T>(url, usuario);
      return data;
    } catch (error) {
      throw error;
    }
  };

  return { GetAll, Insert };
};

export default ServiceBase;
