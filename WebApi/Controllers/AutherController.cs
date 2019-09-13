using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.Attributes;
using Models;

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

        // GET /api/authors
        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        // GET /api/authors/5
        [HttpGet]
        [Route("authors/{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null) { return NotFound(); }
            return Ok(author);
        }

        // GET /api/authors/5/newsItems
        [HttpGet]
        [Route("authors/{id:int}/newsItems")]
        public IActionResult GetNewsItemsByAuthor(int id)
        {
            var newsItems = _authorService.GetNewsItemsByAuthor(id);
            if (newsItems.Count == 0) { return NotFound(); }
            return Ok(newsItems);
        }

        // POST /api/authors
        [Route("authors")]
        [HttpPost]
        [AuthorizeBearer]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _authorService.CreateAuthor(author);
            return CreatedAtAction("GetAuthorById", new { id = entity.Id }, null);
        }

        // PUT api/authors/5
        [Route("authors/{id:int}")]
        [HttpPut]
        [AuthorizeBearer]
        public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _authorService.UpdateAuthorById(author, id);
            return NoContent();
        }

        // DELETE api/authors/5
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
