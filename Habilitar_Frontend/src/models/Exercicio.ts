export default class Exercicio {
  Id!: number;
  Nome!: string;
  NomePopular: string | undefined;
  Descricao!: string;
  Url!: string;
  Ip!: string;
  Ativo!: boolean;
  DataCriacao!: Date;
  UsuarioCriacaoId!: number;
  DataAtualizacao?: Date;
  UsuarioAtualizacaoId?: number;
}
