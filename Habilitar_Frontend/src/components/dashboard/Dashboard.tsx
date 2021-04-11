import { Button } from "@material-ui/core";
import { useContext } from "react";
import { Context } from "../../context/AuthContext";

export default () => {
  const { handleLogout } = useContext(Context);

  return (
    <div>
      <h1>Dashboard</h1>

      <Button
        onClick={handleLogout}
        type="submit"        
        variant="contained"
        color="primary"
      >
        Sair
      </Button>
    </div>
  );
};
