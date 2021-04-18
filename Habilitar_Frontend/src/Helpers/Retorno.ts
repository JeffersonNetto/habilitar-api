export class Retorno<T> {
  Mensagem?: string;
  Dados?: T;
  Erros: string[] = [];
}
