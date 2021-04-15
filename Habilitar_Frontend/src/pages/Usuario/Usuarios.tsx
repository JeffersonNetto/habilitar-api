import { useEffect, useState } from "react";
import Usuario from "../../models/Usuario";
import { UsuarioService } from "../../services/UsuarioService";

export const Usuarios = () => {
  const { GetAll } = UsuarioService();
  const [usuarios, setUsuarios] = useState<Usuario[]>([]);

  useEffect(() => {
    GetAll()
      .then((response) => {
        console.log(response);
        setUsuarios(response);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <div>
      <ul>
        {usuarios.map((usuario) => (
          <li key={usuario.Id}>{`${usuario.Id} - ${usuario.Login}`}</li>
        ))}
      </ul>
    </div>
  );
};
