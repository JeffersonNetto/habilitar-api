import Usuario from "../models/Usuario";
import ServiceBase from "./ServiceBase";

const url = "usuario";

export const UsuarioService = () => {
  const { GetAll, Insert } = ServiceBase<Usuario>(url);

  return { GetAll, Insert };
};
