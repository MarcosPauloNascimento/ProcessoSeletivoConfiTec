using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.Api.Controllers;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Entities.Entities.Enums;

namespace TesteTecnico.Api.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IApplicationServiceUser _applicationServiceUser;
        private readonly INotifier _notifier;

        public UserController(INotifier notifier, IApplicationServiceUser applicationServiceUser) : base(notifier)
        {
            _applicationServiceUser = applicationServiceUser;
            _notifier = notifier;

        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var userList = await _applicationServiceUser.GetAll();

            if (!userList?.Any() ?? false)
                return NotFound();

            return Ok(userList);
        }

        // GET api/<UserController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var user = await _applicationServiceUser.GetById(id);

            if (user == null)
                return NotFound("Não foi encontrado usuário com o código informado");

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto userDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!Enum.IsDefined(typeof(Schooling), userDto.Escolaridade))
            {
                Notify("Escolaridade Inválida");
                return CustomResponse();
            }

            var userId = await _applicationServiceUser.Add(userDto);

            if (!ValidOperation())
                return CustomResponse();

            return CreatedAtAction("Post", userId);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDto userDto)
        {
            if (id != userDto.Id)
            {
                Notify("Os códigos informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _applicationServiceUser.Update(userDto);

            if (!ValidOperation())
                return CustomResponse();

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var userDto = await _applicationServiceUser.GetById(id);

            if (userDto == null)
                return NotFound("Não foi encontrado usuário com o código informado");

            await _applicationServiceUser.Delete(userDto);

            if (!ValidOperation())
                return CustomResponse();

            return NoContent();
        }
    }
}