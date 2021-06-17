import './App.css';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Banner from './Banner';
import logo from './Logo50px.png';

function App() {
  return (
    <BrowserRouter>
      <header>
        <Banner />
      </header>
      <div ClassName="container">
        <Switch>
          <Route exact path="/">

          </Route>
          <Route exact path="/request">

          </Route>
        </Switch>
      </div>
      <footer>   
        <img src={logo} alt="logo"/>
      </footer>      
    </BrowserRouter>
  );
}

export default App;
