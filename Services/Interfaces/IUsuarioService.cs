public interface IUsuarioService
{
    Task<List<Usuario>> ObterTodosUsuariosAsync();
    Task<Usuario> ObterUsuarioPorIdAsync(int id);
    Task<Usuario> AdicionarUsuarioAsync(Usuario usuario);
    Task<Usuario> AtualizarUsuarioAsync(Usuario usuario);
    Task<bool> ExcluirUsuarioAsync(int id);
}