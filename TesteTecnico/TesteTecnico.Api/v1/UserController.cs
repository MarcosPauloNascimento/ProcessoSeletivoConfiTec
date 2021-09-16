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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UserController(INotifier notifier, IApplicationServiceUser applicationServiceUser) : base(notifier)
        {
            _applicationServiceUser = applicationServiceUser;

        }

        // GET: api/v1/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var userList = await _applicationServiceUser.GetAll();

            if (!userList?.Any() ?? false)
                return NotFound();

            return Ok(userList);
        }

        // GET api/v1/<UserController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Código Inválido");

            var user = await _applicationServiceUser.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/v1/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            if (!Enum.IsDefined(typeof(Schooling), userDto.Schooling))
                return BadRequest("Escolaridade Inválida");

            var userId = await _applicationServiceUser.Add(userDto);

            if(!ValidOperation())
                return CustomResponse();

            return CreatedAtAction("Post", userId);
        }

        // PUT api/v1/<UserController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
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

        // DELETE api/v1/<UserController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Código Inválido");

            var userDto = await _applicationServiceUser.GetById(id);

            if (userDto == null)
                return NotFound();

            await _applicationServiceUser.Delete(userDto);

            if (!ValidOperation())
                return CustomResponse();

            return NoContent();
        }
    }
}