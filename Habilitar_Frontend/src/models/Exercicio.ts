export default class Exercicio {
  Id!: number;
  Nome!: string;
  NomePopular!: string;
  Descricao!: string;
  Url!: string;
  Ip!: string;
  Ativo!: boolean;
  DataCriacao!: Date;
  UsuarioCriacaoId!: number;
  DataAtualizacao?: Date;
  UsuarioAtualizacaoId?: number;
}
