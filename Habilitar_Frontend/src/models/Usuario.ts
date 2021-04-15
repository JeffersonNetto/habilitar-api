export default class Usuario {
    Id!: number
    Login!: string
    Senha!: string
    PessoaId?: number
    UnidadeId?: number
    Profissional!: boolean
    Fisioterapeuta!: boolean
    Conselho?: string
    Ip!: string    
    Ativo: boolean = true    
    DataCriacao: Date = new Date()
    UsuarioCriacaoId!: number
    DataAtualizacao?: Date
    UsuarioAtualizacaoId?: number    
}