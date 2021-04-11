import { Switch, Route, BrowserRouter } from "react-router-dom";
import Dashboard from "./components/dashboard/Dashboard";

export const Router = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Dashboard}></Route>

        <Route path="*"></Route>
      </Switch>
    </BrowserRouter>
  );
};
