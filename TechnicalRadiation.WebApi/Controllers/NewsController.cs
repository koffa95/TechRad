using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Services;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TechnicalRadiation.WebApi.Attributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsService _newsService;

        public NewsController(IMapper mapper)
        {
            _newsService = new NewsService(mapper);
        }

        // GET /api
        [HttpGet]
        [Route("")]
        public IActionResult GetAllNews([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            if (pageSize == 0) { pageSize = 25; }
            var news = new Envelope<NewsItemDto>(pageNumber, pageSize, _newsService.GetAllNews());
            return Ok(news);
        }

        // GET /api/5
        [HttpGet]
        [Route("{id:int}", Name = "GetNewsById")]
        public IActionResult GetNewsById(int id)
        {
            var news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // POST /api
        [Route("")]
        [AuthorizeBearer]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsItemInputModel news)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _newsService.CreateNews(news);
            return CreatedAtAction("GetNewsById", new { id = entity.Id }, null);
        }

        // PUT api/news/5
        [Route("{id:int}")]
        [HttpPut]
        [AuthorizeBearer]
        public IActionResult UpdateNewsById([FromBody] NewsItemInputModel news, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _newsService.UpdateNewsById(news, id);
            return NoContent();
        }

        // DELETE api/news/5
        [Route("{id:int}")]
        [HttpDelete]
        [AuthorizeBearer]
        public IActionResult DeleteNewsById(int id)
        {
            _newsService.DeleteNewsById(id);
            return NoContent();
        }
    }
}

