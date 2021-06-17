import { BrowserRouter, Switch, Route } from "react-router-dom";
import './css/App.css';
import Banner from './Banner';
import Footer from './Footer';
import VehicleInfo from "./VehicleInfo";
import Requests from "./Requests";
import RequestForm from "./RequestForm";


function App() {
  return (
    <BrowserRouter>
      <header>
        <Banner />
      </header>
      <div className="container">
        <Switch>
          <Route exact path="/">
            <VehicleInfo driverId={4} />
            <Requests driverId={4} />
          </Route>

          <Route exact path="/request/new">
            <RequestForm />
          </Route>
        </Switch>
      </div>
     <Footer />
    </BrowserRouter>
  );
}

export default App;
