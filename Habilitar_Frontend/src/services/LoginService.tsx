import Usuario from "../models/Usuario";
import api from "../interceptor/http-interceptor";
import { useState, useEffect } from "react";
import history from "../history";

const url = "usuario/login";

export default function LoginService() {

  const [authenticated, setAuthenticated] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    
    const token = localStorage.getItem("token");

    if (token) {
      api.defaults.headers.Authorization = `Bearer ${JSON.parse(token)}`;
      setAuthenticated(true);
    }

    setLoading(false);
  }, []);

  async function handleLogin(usuario: Usuario) {
      
    try {
      const { data, data: { Dados: { Token } } } = await api.post(url, JSON.stringify(usuario), {
        headers: {
          "Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*",
        },
      });      

      localStorage.setItem("token", JSON.stringify(Token));
      api.defaults.headers.Authorization = `Bearer ${Token}`;
      setAuthenticated(true);
      history.push("/");

      return data;
    } catch (error) {
      throw error;
    }
  }

  async function handleLogout() {
    setAuthenticated(false);
    localStorage.removeItem("token");
    api.defaults.headers.Authorization = undefined;
    history.push("/login");
  }

  return { authenticated, loading, handleLogin, handleLogout };
}
