import { BrowserRouter, Switch, Route } from "react-router-dom";
import './App.css';
import Banner from './Banner';
import Footer from './Footer';


function App() {
  return (
    <BrowserRouter>
      <header>
        <Banner />
      </header>
      <div ClassName="container">
        <Switch>
          <Route exact path="/">
            <VehicleInfo />
            <Requests />
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
