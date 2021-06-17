import { BrowserRouter, Switch, Route } from "react-router-dom";
import './App.css';
import Banner from './Banner';
import Footer from './Footer';
import VehicleInfo from "./VehicleInfo";


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
            
          </Route>

          <Route exact path="/request">

          </Route>
        </Switch>
      </div>
     <Footer />
    </BrowserRouter>
  );
}

export default App;
