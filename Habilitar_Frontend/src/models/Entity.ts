export default class Entity {
  Id: number = 0;
  Ip: string | undefined;
  Ativo: boolean = true;
  DataCriacao: Date = new Date();
  UsuarioCriacaoId: number | undefined;
  DataAtualizacao: Date | undefined;
  UsuarioAtualizacaoId: number | undefined;
}
