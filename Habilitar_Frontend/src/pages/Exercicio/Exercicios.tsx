import MaterialTable from "material-table";
import { useEffect, useState } from "react";
import { Retorno } from "../../helpers/Retorno";
import Exercicio from "../../models/Exercicio";
import { ExercicioService } from "../../services/ExercicioService";

export const Exercicios = () => {
  const [exercicios, setExercicios] = useState<Exercicio[]>([]);
  const { GetAll } = ExercicioService();

  useEffect(() => {
    GetAll()
      .then((response: Retorno<Exercicio[]>) => {
        if (response.Dados) {
          setExercicios(response.Dados);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const columns = [
    {
      title: "Id",
      field: "Id",
    },
    {
      title: "Nome",
      field: "Nome",
    },
    {
      title: "Descrição",
      field: "Descricao",
    },
  ];

  return (
    <div>
      <MaterialTable
        title="Exercícios"
        data={exercicios}
        columns={columns}
        options={{
          search: true,
          sorting: true,
          paging: true,
          exportButton: true,
        }}
      />
    </div>
  );
};
