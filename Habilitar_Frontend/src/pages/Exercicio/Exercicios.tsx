import MaterialTable from "material-table";
import { useEffect, useState } from "react";
import { Retorno } from "../../helpers/Retorno";
import Exercicio from "../../models/Exercicio";
import { ExercicioService } from "../../services/ExercicioService";
import Loader from "../../components/loader/Loader";
import { localization } from "../../helpers/material-table-localization";
import { useHistory } from "react-router";

export const Exercicios = () => {
  const history = useHistory();
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

  return exercicios && exercicios.length > 0 ? (
    <div>
      <MaterialTable
        title="Exercícios"
        data={exercicios}
        columns={columns}
        localization={localization}
        options={{
          search: true,
          sorting: true,
          paging: true,
          exportButton: true,
          //actionsColumnIndex: -1,
        }}
        actions={[
          {
            icon: "edit",
            tooltip: "Editar",
            onClick: (event, rowData) => {
              const exercicio = rowData as Exercicio;
              history.push(`/app/exercicios/editar/${exercicio.Id}`, exercicio);
            },
          },
        ]}
      />
    </div>
  ) : (
    <div>
      <h2>Carregando exercícios...</h2>
      <Loader loading={true} />
    </div>
  );
};
