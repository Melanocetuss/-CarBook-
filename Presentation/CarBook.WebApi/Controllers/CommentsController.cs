using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        { 
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum Başarıyla Guncellendi");
        }

        [HttpGet("GetCommentsByBlogId")]
        public IActionResult GetCommentsByBlogId(int id)
        {
            var values = _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }

        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)
        {
            var values = _commentRepository.GetCountCommentByBlog(id);
            return Ok(values);
        }
    }
}