import { Retorno } from "../helpers/Retorno";
import api from "../interceptor/http-interceptor";

const ServiceBase = <T>(url: string) => {
  const GetAll = async () => {
    try {
      const { data } = await api.get<Retorno<T[]>>(url);
      return data;
    } catch (error) {
      throw error;
    }
  };

  const Insert = async (body: T) => {
    try {
      const { data } = await api.post<Retorno<T>>(url, body);
      return data;
    } catch (error) {
      throw error;
    }
  };

  return { GetAll, Insert };
};

export default ServiceBase;
