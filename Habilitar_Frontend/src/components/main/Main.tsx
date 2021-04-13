import { Header } from "../header/Header";
import { Sidenav } from "../sidenav/Sidenav";
import { Content } from "../content/Content";
import { Footer } from '../footer/Footer';

export const Main = () => {
  return (
    <div>
      <Header></Header>
      <Sidenav></Sidenav>
      <Content></Content>
      <Footer></Footer>
    </div>
  );
}