import Exercicio from "../models/Exercicio";
import ServiceBase from "./ServiceBase";

const url = "exercicio/";

export const ExercicioService = () => {
  const { GetAll, Insert, Update, Delete } = ServiceBase<Exercicio>(url);

  return { GetAll, Insert, Update, Delete };
};
