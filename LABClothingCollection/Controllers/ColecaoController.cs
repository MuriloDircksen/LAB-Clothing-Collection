using AutoMapper;
using LABClothingCollection.Contexto;
using LABClothingCollection.DTO.Request_DTO;
using LABClothingCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace LABClothingCollection.Controllers
{
    [ApiController]
    [Route("api/coleções")]
    public class ColecaoController : ControllerBase
    {
        private readonly LabClothingCollectionContexto _contexto;

        public ColecaoController(LabClothingCollectionContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        [Route("/api/colecoes")]
        public async Task<IActionResult> CadastroColecao(
            [FromBody] Colecao colecao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }

            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Id == colecao.IdUsuario);

            if (usuario == null) return BadRequest("Usuário inválido!");

            try
            {
                await _contexto.Colecoes.AddAsync(colecao);
                await _contexto.SaveChangesAsync();
                return Created($"api/usuarios/{colecao.Id}", colecao);
            }
            catch (Exception ex)
            {
                return Conflict("Nome da coleção já existe no banco de dados: " + ex.ToString());
            }
        }

        [HttpPut]
        [Route("/api/colecoes/{id}")]
        public async Task<IActionResult> AtualizacaoDadosColecao(
            [FromBody] ColecaoPutDTO colecaoDTO,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ColecaoPutDTO, Colecao>());
            var mapper = configuration.CreateMapper();
            Colecao colecao = mapper.Map<Colecao>(colecaoDTO);
            var colecaoDB = await _contexto.Colecoes.FirstOrDefaultAsync(x => x.Id == id);
           
            if(colecaoDB == null) return NotFound("Coleção não encontrada");

            try
            {
                colecaoDB.NomeColecao = colecao.NomeColecao;
                colecaoDB.IdUsuario = colecao.IdUsuario;
                colecaoDB.Marca = colecao.Marca;
                colecaoDB.Orcamento = colecao.Orcamento;
                colecaoDB.DataLancamento = colecao.DataLancamento;
                colecaoDB.Estacao = colecao.Estacao;
                
                _contexto.Colecoes.Update(colecaoDB);
                await _contexto.SaveChangesAsync();

                return Ok(colecaoDB);
            }
            catch (Exception ex)
            {
                return BadRequest("Dado duplicado no banco de dados: "+ex.ToString());
            }
        }
        //HTTP PUT no path /api/colecoes/{identificador}/status
        [HttpPut]
        [Route("/api/colecoes/{id}/status")]
        public async Task<IActionResult> AtualizacaoStatusColeção(
            [FromBody] ColecaoPutStatusDTO colecaoStatusDTO,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ColecaoPutStatusDTO, Colecao>());
            var mapper = configuration.CreateMapper();
            Colecao colecao = mapper.Map<Colecao>(colecaoStatusDTO);

            var colecaoAtualizar = await _contexto.Colecoes.FirstOrDefaultAsync(x => x.Id == id);

            if (colecaoAtualizar == null) return NotFound("Coleção não encontrada");

            try
            {
                colecaoAtualizar.Status = colecao.Status;

                _contexto.Colecoes.Update(colecaoAtualizar);
                await _contexto.SaveChangesAsync();
                return Ok(colecaoAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //HTTP GET no path /api/colecoes
        [HttpGet]
        [Route("/api/colecoes")]
        public async Task<IActionResult> ListagemColecoes(
            [FromQuery] StatusColecao? status)
        {
            try
            {
                if (status == null)
                {
                    return Ok(await _contexto.Colecoes.AsNoTracking().ToListAsync());
                }

                return Ok(await _contexto.Colecoes.Where(x => x.Status == status).AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");
            }

        }
        //HTTP GET no path /api/colecoes/{identificador}
        [HttpGet]
        [Route("/api/colecoes/{id}")]
        public async Task<IActionResult> ListarColecaoPorId(
            [FromRoute] int id)
        {
            var colecao = await _contexto.Colecoes
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return colecao == null ? NotFound("Coleção não encontrado!") : Ok(colecao);
        }

        //HTTP DELETE no path /api/colecoes/{identificador}
        [HttpDelete]
        [Route("/api/colecoes/{id}")]
        public async Task<IActionResult> ExclusaoColecao(
            [FromRoute] int id)
        {
            var colecao = await _contexto.Colecoes
                .AsNoTracking()
                .Include(x => x.Modelo)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(colecao == null) return NotFound("Coleção não encontrada");

            if (colecao.Status == StatusColecao.ATIVO) return BadRequest("Não pode deletar coleção ativa");

            if( colecao.Modelo.FirstOrDefault() != null) return BadRequest("Não pode deletar coleção com modelos associados");

            try
            {
                _contexto.Colecoes.Remove(colecao);
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
