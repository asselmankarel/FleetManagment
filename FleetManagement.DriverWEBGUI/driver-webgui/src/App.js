import { BrowserRouter, Switch, Route } from "react-router-dom";
import { useState } from "react";
import './css/App.css';
import Banner from './Banner';
import Footer from './Footer';
import VehicleInfo from "./VehicleInfo";
import Requests from "./Requests";
import RequestForm from "./RequestForm";
import Profile from "./Profile";


function App() {
  const [driverId , setDriverId] = useState(4);

  return (
    <BrowserRouter>
      <header>
        <Banner />
      </header>
      <div className="container">
        <Switch>
          <Route exact path="/">
            <VehicleInfo driverId={driverId} />
            <Requests driverId={driverId} />
          </Route>

          <Route exact path="/request/new">
            <RequestForm driverId={driverId}/>
          </Route>

          <Route exact path="/profile" >
            <Profile driverId={driverId}/>
          </Route>
        </Switch>
      </div>
     <Footer />
    </BrowserRouter>
  );
}

export default App;
