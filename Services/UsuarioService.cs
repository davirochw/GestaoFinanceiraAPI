using Microsoft.EntityFrameworkCore;

public class UsuarioService : IUsuarioService
{
    private readonly ApplicationDbContext _context;

    public UsuarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ObterTodosUsuariosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> AdicionarUsuarioAsync(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> AtualizarUsuarioAsync(Usuario usuario)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);
        if (usuarioExistente == null)
            throw new InvalidOperationException("Usuário não encontrado.");

        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Senha = usuario.Senha;

        _context.Usuarios.Update(usuarioExistente);
        await _context.SaveChangesAsync();
        return usuarioExistente;
    }

    public async Task<bool> ExcluirUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}