import { useEffect, useMemo, useState } from "react";
import Usuario from "../../models/Usuario";
import { UsuarioService } from "../../services/UsuarioService";
import MaterialTable from "material-table";
import Loader from "../../components/loader/Loader";
import EditIcon from "@material-ui/icons/Edit";
import IconButton from "@material-ui/core/IconButton";
import Tooltip from "@material-ui/core/Tooltip";
import { Link, useHistory } from "react-router-dom";
import { Retorno } from "../../helpers/Retorno";
import { localization } from "../../helpers/material-table-localization";

export const Usuarios = () => {
  const history = useHistory();
  const { GetAll } = UsuarioService();
  const [usuarios, setUsuarios] = useState<Usuario[] | undefined>([]);
  const columns = [
    {
      title: "Id",
      field: "Id",
    },
    {
      title: "Login",
      field: "Login",
    },
  ];

  useEffect(() => {
    GetAll()
      .then((response: Retorno<Usuario[]>) => {
        setUsuarios(response.Dados);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return usuarios && usuarios.length > 0 ? (
    <MaterialTable
      title="Usuários"
      data={usuarios}
      columns={columns}
      localization={localization}
      options={{
        search: true,
        sorting: true,
        paging: true,
        exportButton: true,
      }}
      actions={[
        {
          icon: "edit",
          tooltip: "Editar",
          onClick: (event, rowData) => {
            const usuario = rowData as Usuario;
            history.push(`/app/usuarios/editar/${usuario.Id}`, usuario);
          },
        },
      ]}
    />
  ) : (
    <div>
      <h2>Carregando usuários...</h2>
      <Loader loading={true} />
    </div>
  );
};
