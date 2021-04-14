import { Header } from "../header/Header";
import { Sidenav } from "../sidenav/Sidenav";
import { Footer } from "../footer/Footer";
import Dashboard from "../dashboard/Dashboard";

export const Main = () => {
  return (
    <div>
      <Header></Header>
      <Sidenav></Sidenav>
      <Dashboard />
      <Footer></Footer>
    </div>
  );
};
