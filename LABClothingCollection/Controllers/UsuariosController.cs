using AutoMapper;
using Azure;
using LABClothingCollection.Contexto;
using LABClothingCollection.DTO.Request_DTO;
using LABClothingCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LABClothingCollection.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly LabClothingCollectionContexto _contexto;

        public UsuariosController(LabClothingCollectionContexto contexto)
        {
            _contexto = contexto;
        }
        
        [HttpPost]
        public async Task<IActionResult> CadastroUsuario(
            [FromBody] Usuario usuario ) 
        { 
            if(!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");  
            }
            

            try
            {
                await _contexto.Usuarios.AddAsync(usuario);
                await _contexto.SaveChangesAsync();
                return Created($"api/usuarios/{usuario.Id}", usuario);
            }
            catch (Exception ex)
            {
                return Conflict("CPF ou CNPJ já existe no banco de dados: " + ex.ToString());
            }            

        }
        
        [HttpPut]
        [Route("/api/usuarios/{id}")]
        public async Task<IActionResult> AtualizacaoDadosUsuario(
            [FromBody] UsuarioPutDTO usuarioDTO,
            [FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<UsuarioPutDTO, Usuario>());
            var mapper = configuration.CreateMapper();
            Usuario usuario = mapper.Map<Usuario>(usuarioDTO);

            var usuarioAtualizar = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if(usuarioAtualizar == null) return NotFound("Usuario não encontrada");

            try
            {
                usuarioAtualizar.NomeCompleto = usuario.NomeCompleto;
                usuarioAtualizar.Genero = usuario.Genero;
                usuarioAtualizar.DataNascimento = usuario.DataNascimento;
                usuarioAtualizar.Telefone = usuario.Telefone;
                usuarioAtualizar.TipoUsuario = usuario.TipoUsuario;

                _contexto.Usuarios.Update(usuarioAtualizar);
                await _contexto.SaveChangesAsync();
                return Ok(usuarioAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("/api/usuarios/{id}/status")]
        public async Task<IActionResult> AtualizacaoStatusUsuario(
            [FromBody] UsuarioPutStatusDTO usuarioStatusDTO,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<UsuarioPutStatusDTO, Usuario>());
            var mapper = configuration.CreateMapper();
            Usuario usuario = mapper.Map<Usuario>(usuarioStatusDTO);

            var usuarioAtualizar = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuarioAtualizar == null) return NotFound("Usuario não encontrada");

            try
            {
                usuarioAtualizar.Status= usuario.Status;               

                _contexto.Usuarios.Update(usuarioAtualizar);
                await _contexto.SaveChangesAsync();
                return Ok(usuarioAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("/api/usuarios")]
        public async Task<IActionResult> ListagemUsuario(
            [FromQuery] StatusUsuario? status )
        {
            try
            {
                if (status == null)
                {
                    return Ok(await _contexto.Usuarios.AsNoTracking().ToListAsync());
                }
               
                return Ok(await _contexto.Usuarios.Where(x => x.Status == status).AsNoTracking().ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }

        }
               
        [HttpGet]
        [Route("/api/usuarios/{id}")]
        public async Task<IActionResult> ListarUsuarioPorId(
            [FromRoute] int id)
        {
            var usuario = await _contexto.Usuarios
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return usuario == null ? NotFound("Usuario não encontrado!") : Ok(usuario);
        }

    }
}
