using Clinica.Models;
using Clinica.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Clinica.Controllers
{
     
[Route("api/[controller]")]
[ApiController]
    
    public class DonosController : ControllerBase
    {
        private DonoRepository repositorio = new DonoRepository();
        
        // Cadastrar
        /// <summary>
        /// Cadastra Donos na Aplicação
        /// </summary>
        /// <param name="dono">Dados do Dono</param>
        /// <returns>Dados do Dono cadastrado</returns>

        //POST - CADASTRAR
        [HttpPost]

        //usando o using para abrir uma conexão com o banco de dados
        public IActionResult Cadastrar(Dono dono)
        {
            try
            {
                repositorio.Insert(dono);

                return Ok(dono);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new { msg = "falha na conexão",
                    erro = ex.Message, });
            }

        }
        //GET - Listar
        /// <summary>
        /// Lista todos os Donos da aplicação
        /// </summary>
        /// <returns>Lista de Donos</returns>
        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                var _donos = repositorio.GetAll();

                
                return Ok(_donos);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "falha na conexão",
                    erro = ex.Message,
                });
            }

        }

        // PUT - Alterar
        /// <summary>
        /// Alterar Nome dos donos
        /// </summary>
        /// <param name="dono"></param>
        /// <returns>Alterado nome do Dono</returns>
        [HttpPut("/{id}")]
        public IActionResult Alterar(int id, Dono dono) 
        {
            try
            {
               var buscarDono = repositorio.GetById(id);
                if(buscarDono == null)
                {
                    return NotFound();
                }

                var donoAlterado = repositorio.Update(id, dono);
                return Ok(dono);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "falha na conexão",
                    erro = ex.Message,
                });

            }
        }

        // DELETE
        /// <summary>
        /// Exclui o cadastro do Dono
        /// </summary>
        /// <param name="id">Id do Dono</param>
        /// <returns>Deletar</returns>
        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var buscarDono = repositorio.GetById(id);
                if (buscarDono == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);


                return Ok(new
                {
                    msg = "Usuário excluido com sucesso!"
                });
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "falha na conexão",
                    erro = ex.Message,
                });
            }
        }



    }
            
            
}

    















           



        
   



    

