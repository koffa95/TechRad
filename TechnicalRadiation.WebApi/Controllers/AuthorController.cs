using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Services;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using TechnicalRadiation.WebApi.Attributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorController(IMapper mapper)
        {
            _authorService = new AuthorService(mapper);
        }
        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }
        [Route("authors/{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null) { return NotFound(); }
            return Ok(author);
        }
        [HttpGet]
        [Route("authors/{id:int}/newsItems")]
        public IActionResult GetNewsItemsByAuthor(int id)
        {
            var newsItems = _authorService.GetNewsItemsByAuthor(id);
            if (newsItems.Count == 0) { return NotFound(); }
            return Ok(newsItems);
        }
        [Route("authors")]
        [HttpPost]
        [AuthorizeBearer]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _authorService.CreateAuthor(author);
            return CreatedAtAction("GetAuthorById", new { id = entity.Id }, null);
        }
        [Route("authors/{id:int}")]
        [HttpPut]
        [AuthorizeBearer]
        public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _authorService.UpdateAuthorById(author, id);
            return NoContent();
        }
        [Route("authors/{id:int}")]
        [HttpDelete]
        [AuthorizeBearer]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorService.DeleteAuthorById(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("authors/{cid:int}/newsItems/{nid:int}")]
        [AuthorizeBearer]
        public ActionResult<string> LinkNewsItemToAuthorById(int aid, int nid)
        {
            _authorService.LinkNewsItemToAuthorById(aid, nid);
            return NoContent();
        }

    }
}
