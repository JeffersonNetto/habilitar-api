import { useContext } from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';

import { Context } from './context/AuthContext'

import Login from './components/login/Login';
import Dashboard from './components/dashboard/Dashboard';

function CustomRoute({ isPrivate, ...rest }) {
  
  const { loading, authenticated } = useContext(Context);  

  if (loading) {
    return <h1>Loading...</h1>;
  }

  if (isPrivate && !authenticated) {
    return <Redirect to="/login" />
  }  

  return <Route {...rest} />;
}

export default function Routes() {  

  return (
    <Switch>
      <CustomRoute exact path="/login" component={Login} />
      <CustomRoute isPrivate exact path="/" component={Dashboard} />      
    </Switch>
  );
}