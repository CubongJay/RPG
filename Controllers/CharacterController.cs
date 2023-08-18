global using RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;


        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {

            var characters = await _characterService.GetAllCharacters();
            return Ok(characters);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            var character = await _characterService.GetCharacterById(id);
            return Ok(character);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var characters = await _characterService.AddCharacter(newCharacter);

            return Ok(characters);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var character = await _characterService.UpdateCharacter(updateCharacter);
            if (character.Data == null)
            {
                return NotFound(character);
            }


            return Ok(character);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var characters = await _characterService.DeleteCharacter(id);
            if (characters.Data == null)
            {
                return NotFound(characters);
            }

            return Ok(characters);
        }


    }
}