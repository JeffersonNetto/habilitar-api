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

  return { GetAll };
};

export default ServiceBase;
