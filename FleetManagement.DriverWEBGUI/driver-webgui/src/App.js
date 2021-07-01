import { BrowserRouter, Switch, Route, useParams } from 'react-router-dom';
import { useState } from 'react';
import Banner from './Banner';
import Profile from './Profile';
import LoginForm from './LoginForm';
import VehicleInfo from "./VehicleInfo";
import VehicleMaintenanceAndRepair from './VehicleMaintenanceAndRepair';

import Fuelcard from './Fuelcard';
import Requests from './Requests';
import RequestForm from './RequestForm';
import Footer from './Footer';
import './css/App.css';


function App() {
  const [driverId , setDriverId] = useState(0);
  const baseUrlReadApi = 'https://localhost:44318/';
  const baseUrlWriteApi = 'https://localhost:44340/';


  function handleSuccessFullLogin(username, password, rememberMe) {
    //do some authentication

    // store username in LocalStoreage
    const id = username;
    setDriverId(id);
  }

  return (
    <BrowserRouter>
      <header>
        <Banner driverId={driverId}/>
      </header>
      <div className="container">
        <Switch>
          <Route exact path="/">
            { driverId === 0 && <LoginForm handleSuccessFullLogin={handleSuccessFullLogin}/> }
            { driverId > 0 && <div>
              <VehicleInfo driverId={driverId} apiUrl={baseUrlReadApi} />
              <Fuelcard driverId={driverId} apiUrl={baseUrlReadApi} />
              <Requests driverId={driverId} apiUrl={baseUrlReadApi} />
            </div> }
          </Route>

          <Route path="/vehicle/:vehicleId/maintenances">
              <VehicleMaintenanceAndRepair apiUrl={baseUrlReadApi} />
          </Route>

          <Route exact path="/request/new">
            <RequestForm driverId={driverId} baseUrlWriteApi={baseUrlWriteApi} baseUrlReadApi={baseUrlReadApi}/>
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
