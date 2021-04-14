import { Redirect, Route, Switch } from "react-router-dom";
import Login from "./components/login/Login";
import { Main } from "./components/main/Main";
import CustomRoute from "./helpers/CustomRoute";

export default function Routes() {
  return (    
      <Switch>
        <Route exact path="/" render={() => <Redirect to="/app" />} />
        <CustomRoute isPrivate={true} path="/app" component={Main} />
        <CustomRoute path="/login" component={Login} />                      
      </Switch>    
  );
}
