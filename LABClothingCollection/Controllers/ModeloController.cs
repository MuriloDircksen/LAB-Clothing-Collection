using AutoMapper;
using LABClothingCollection.Contexto;
using LABClothingCollection.DTO.Request_DTO;
using LABClothingCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABClothingCollection.Controllers
{
    public class ModeloController : Controller
    {
        private readonly LabClothingCollectionContexto _contexto;

        public ModeloController(LabClothingCollectionContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        [Route("/api/modelos")]
        public async Task<IActionResult> CadastroModelo(
            [FromBody] Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }

            var colecao = await _contexto.Colecoes.FirstOrDefaultAsync(x => x.Id == modelo.IdColecao);

            if (colecao == null) return BadRequest("Coleção inválida!");

            try
            {
                
                await _contexto.Modelos.AddAsync(modelo);
                await _contexto.SaveChangesAsync();
                return Created($"api/modelos/{modelo.Id}", modelo);
            }
            catch (Exception ex)
            {
                return Conflict("Nome do modelo já existe no banco de dados: " + ex.ToString());
            }
        }

        //HTTP PUT no path /api/modelos/{identificador}
        [HttpPut]
        [Route("/api/modelos/{id}")]
        public async Task<IActionResult> AtualizacaoDadosModelo(
            [FromBody] ModeloDTO modeloDTO,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ModeloDTO, Modelo>());
            var mapper = configuration.CreateMapper();
            Modelo modelo = mapper.Map<Modelo>(modeloDTO);

            var modeloDB = await _contexto.Modelos.FirstOrDefaultAsync(x => x.Id == id);

            if (modeloDB == null) return NotFound("Modelo não encontrado!");

            try
            {
                modeloDB.NomeModelo = modelo.NomeModelo;
                modeloDB.IdColecao = modelo.IdColecao;
                modeloDB.Tipo = modelo.Tipo;
                modeloDB.Layout = modelo.Layout;
                _contexto.Modelos.Update(modeloDB);
                await _contexto.SaveChangesAsync();
                return Ok(modeloDB);
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos: " + ex.ToString());
            }
        }

        [HttpGet]
        [Route("/api/modelos")]
        public async Task<IActionResult> ListagemModelos(
            [FromQuery] Layout? layout)
        {
            try
            {
                if (layout == null)
                {
                    return Ok(await _contexto.Modelos.AsNoTracking().ToListAsync());
                }

                return Ok(await _contexto.Modelos.Where(x => x.Layout == layout).AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }
        }

        [HttpGet]
        [Route("/api/modelos/{id}")]
        public async Task<IActionResult> ListarModeloPorId(
            [FromRoute] int id)
        {
            var modelo = await _contexto.Modelos
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return modelo == null ? NotFound("Modelo não encontrado!") : Ok(modelo);
        }

        [HttpDelete]
        [Route("/api/modelos/{id}")]
        public async Task<IActionResult> ExclusaoModelo(
            [FromRoute] int id)
        {
            var modelo = await _contexto.Modelos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (modelo == null) return NotFound("Modelo não encontrada");
            
            try
            {
                _contexto.Modelos.Remove(modelo);
                await _contexto.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
