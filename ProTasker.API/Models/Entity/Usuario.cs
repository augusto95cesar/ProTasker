using ProTasker.API.Models.Enum;

namespace ProTasker.API.Models.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
