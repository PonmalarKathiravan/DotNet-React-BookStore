import React, { useContext } from 'react';
import { Redirect, Route } from 'react-router-dom';
import AuthContext from '../Authentication/AuthContext';

const PrivateRoute = ({ component: Component, ...rest }) => {
  
    const authContent = useContext(AuthContext);
    console.log(authContent);

    return <Route {...rest} render={(props) => (
              authContent.state.auth.authenticated
                ? <Component {...rest} />
                : <Redirect to={{
                    pathname : "/login",
                    state : { from : props.location, }
                }} />
            )} />
  }
  
export default PrivateRoute;