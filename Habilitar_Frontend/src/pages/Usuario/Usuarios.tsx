import { useEffect, useMemo, useState } from "react";
import Usuario from "../../models/Usuario";
import { UsuarioService } from "../../services/UsuarioService";
import DataTable, { IDataTableColumn } from "react-data-table-component";
import Loader from "../../components/loader/Loader";
import EditIcon from "@material-ui/icons/Edit";
import IconButton from "@material-ui/core/IconButton";
import Tooltip from "@material-ui/core/Tooltip";
import { Link } from "react-router-dom";

export const Usuarios = () => {
  const { GetAll } = UsuarioService();
  const [usuarios, setUsuarios] = useState<Usuario[]>([]);
  const columns = useMemo<IDataTableColumn<Usuario>[]>(
    () => [
      {
        name: "Id",
        selector: "Id",
        sortable: true,
      },
      {
        name: "Login",
        selector: "Login",
        sortable: true,
      },
      {
        name: "",
        right: true,
        selector: (usuario) => (
          <Link to={`/app/usuarios/${usuario.Id}`}>
            <Tooltip title="Editar">
              <IconButton color="primary">
                <EditIcon />
              </IconButton>
            </Tooltip>
          </Link>
        ),
      },
    ],
    []
  );

  useEffect(() => {
    GetAll()
      .then((response) => {
        console.log(response);
        setTimeout(() => {
          setUsuarios(response);
        }, 1000);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return usuarios && usuarios.length > 0 ? (
    <DataTable
      title="Usuários"
      columns={columns}
      data={usuarios}
      defaultSortField="title"
      pagination
      selectableRows
    />
  ) : (
    <div>
      <h2>Carregando usuários...</h2>
      <Loader loading={true} />
    </div>
  );
};
