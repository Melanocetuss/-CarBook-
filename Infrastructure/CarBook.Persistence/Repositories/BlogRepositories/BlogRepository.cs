using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }
   
        public List<Blog> GetLast3BlogWithAuthorsAndCategories()
        {
            var values = _context.Blogs.Include(x=> x.Author).Include(x=> x.Category).OrderByDescending(x=> x.BlogID).Take(3).ToList();
            return values;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs.Include(x=> x.Author).Where(x=> x.BlogID == id).ToList();
            return values;
        }
    }
}
