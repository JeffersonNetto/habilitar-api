import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Box from "@material-ui/core/Box";
import * as yup from "yup";
import { useFormik } from "formik";
import { Retorno } from "../../helpers/Retorno";
import Loader from "../../components/loader/Loader";
import { useState } from "react";
import Usuario from "../../models/Usuario";
import { UsuarioService } from "../../services/UsuarioService";
import CssBaseline from "@material-ui/core/CssBaseline";
import Link from "@material-ui/core/Link";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import InputLabel from "@material-ui/core/InputLabel";
import MenuItem from "@material-ui/core/MenuItem";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import Autocomplete from "@material-ui/lab/Autocomplete";

const validationSchema = yup.object({
  login: yup.string().required("Informe seu login"),
  senha: yup.string().required("Informe sua senha"),
});

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(5),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

export const UsuarioForm = () => {
  const classes = useStyles();
  const { Insert } = UsuarioService();
  const [loading, setLoading] = useState(false);
  const [open, setOpen] = useState(false);
  const [pessoaId, setPessoaId] = useState(0);
  const [alertMessage, setAlertMessage] = useState<any>({
    severity: "",
    mensagem: "",
  });

  const pessoas = [
    {
      Id: 1,
      Nome: "Jefferson",
      Sobrenome: "Neto",
    },
    {
      Id: 2,
      Nome: "Luiz",
      Sobrenome: "Reis",
    },
  ];

  const handleClose = (event?: React.SyntheticEvent, reason?: string) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };

  const handleChange = (event: any) => {
    let value: number = parseInt(event.target.value);
    console.log(value);
    setPessoaId(value);
  };

  const formik = useFormik({
    initialValues: {
      login: "",
      senha: "",
      conselho: "",
      pessoaId: 0,
    },
    onSubmit: (values) => {
      console.log(values);
      //setLoading(true);
      const usuario: Usuario = {
        Login: values.login,
        Senha: values.senha,
        Ativo: true,
        DataCriacao: new Date(),
        Ip: "",
        Profissional: false,
        Fisioterapeuta: false,
        UsuarioCriacaoId: 1,
        Id: 1,
        PessoaId: values.pessoaId,
        Conselho: values.conselho,
      };

      console.log("form", usuario);

      Insert(usuario)
        .then((response: any) => {
          setAlertMessage({ severity: "success", mensagem: response.Mensagem });
          setOpen(true);
        })
        .catch((error: any) => {
          let err: Retorno<Usuario> = error?.response?.data;
          setAlertMessage({
            severity: "error",
            mensagem: err
              ? err.Mensagem
              : "Sistema temporariamente indisponível",
          });
          setOpen(true);
        })
        .finally(() => {
          setLoading(false);
        });
    },
    validationSchema: validationSchema,
  });

  return (
    <Container component="main" maxWidth="xl">
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          Usuário
        </Typography>
        <form className={classes.form} onSubmit={formik.handleSubmit}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                autoComplete="login"
                name="login"
                variant="outlined"
                fullWidth
                id="login"
                label="Login"
                autoFocus
                value={formik.values.login}
                onChange={formik.handleChange}
                error={formik.touched.login && Boolean(formik.errors.login)}
                helperText={formik.touched.login && formik.errors.login}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                fullWidth
                id="senha"
                label="Senha"
                name="senha"
                autoComplete="senha"
                value={formik.values.senha}
                onChange={formik.handleChange}
                error={formik.touched.senha && Boolean(formik.errors.senha)}
                helperText={formik.touched.senha && formik.errors.senha}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                fullWidth
                id="conselho"
                label="Conselho"
                name="conselho"
                autoComplete="conselho"
                value={formik.values.conselho}
                onChange={formik.handleChange}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              {/* <Autocomplete
                fullWidth
                id="pessoa"
                options={pessoas}
                getOptionLabel={(option) => {
                  setPessoaId(option.Id);
                  return option.Nome;
                }}
                renderInput={(params) => (
                  <TextField {...params} label="Pessoa" variant="outlined" />
                )}
              /> */}
            </Grid>
            <Grid item xs={12} sm={6}>
              <FormControlLabel
                control={<Checkbox value="profissional" color="primary" />}
                label="Profissional"
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <FormControlLabel
                control={<Checkbox value="fisioterapeuta" color="primary" />}
                label="Fisioterapeuta"
              />
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
          >
            Salvar
          </Button>
        </form>
      </div>
      <Box display="flex" justifyContent="center">
        <Loader loading={loading}></Loader>
      </Box>
    </Container>
  );
};
