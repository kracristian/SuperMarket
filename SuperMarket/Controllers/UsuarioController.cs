using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarcket.Data;
using SuperMarket.Data.Model;

namespace SuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private BaseContext _BaseDatos;

        public UsuarioController(BaseContext baseDatos)
        {
            _BaseDatos = baseDatos;
        }

        [HttpGet(Name = "GetAll")]
        public List<Usuario> GetAll()
        {
            return _BaseDatos.Usuarios.ToList();
        }
    }
}
