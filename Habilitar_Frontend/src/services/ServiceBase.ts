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

  const Get = async (id: number) => {
    try {
      const { data } = await api.get<Retorno<T>>(`${url}${id}`);
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

  const Update = async (id: number, body: T) => {
    try {
      const { data } = await api.put<Retorno<T>>(`${url}${id}`, body);
      return data;
    } catch (error) {
      throw error;
    }
  };

  const Delete = async (id: number) => {
    try {
      const { data } = await api.delete<Retorno<T>>(`${url}${id}`);
      return data;
    } catch (error) {
      throw error;
    }
  };

  return { GetAll, Get, Insert, Update, Delete };
};

export default ServiceBase;
