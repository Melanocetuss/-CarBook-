using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandlers : IRequestHandler<GetBlogQuery,List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;
        public GetBlogQueryHandlers(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBlogQueryResult 
            {
                BlogID = x.BlogID,
                Title = x.Title,
                AuthorID = x.AuthorID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                CategoryID  = x.CategoryID
            }).ToList();
        }
    }
}