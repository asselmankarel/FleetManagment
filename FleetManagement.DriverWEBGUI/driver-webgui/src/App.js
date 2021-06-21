import { BrowserRouter, Switch, Route } from "react-router-dom";
import { useState } from "react";
import Banner from './Banner';
import Profile from "./Profile";
import LoginForm from "./LoginForm";
import VehicleInfo from "./VehicleInfo";
import Requests from "./Requests";
import RequestForm from "./RequestForm";
import Footer from './Footer';
import './css/App.css';


function App() {
  const [driverId , setDriverId] = useState(0);
  const baseUrlReadApi = 'https://localhost:44318/';
  const baseUrlWriteApi = 'https://localhost:44340/';

  function handleSuccessFullLogin(id) {
    setDriverId(id);
  }

  return (
    <BrowserRouter>
      <header>
        <Banner />
      </header>
      <div className="container">
        <Switch>
          <Route exact path="/">
            { driverId === 0 && <LoginForm handleSuccessFullLogin={ handleSuccessFullLogin }/> }
            { driverId > 0 && <div>
              <VehicleInfo driverId={driverId} apiUrl={baseUrlReadApi} />
              <Requests driverId={driverId} apiUrl={baseUrlReadApi} />
            </div> }
          </Route>

          <Route exact path="/request/new">
            <RequestForm driverId={driverId} apiUrl={baseUrlWriteApi}/>
          </Route>

          <Route exact path="/profile" >
            <Profile driverId={driverId} apiUrl={baseUrlReadApi} />
          </Route>
        </Switch>
      </div>
     <Footer />
    </BrowserRouter>
  );
}

export default App;
