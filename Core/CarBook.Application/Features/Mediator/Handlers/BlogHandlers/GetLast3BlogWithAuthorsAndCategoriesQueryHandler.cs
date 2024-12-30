using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogWithAuthorsAndCategoriesQueryHandler : IRequestHandler<GetLast3BlogWithAuthorsAndCategoriesQuery, List<GetLast3BlogWithAuthorsAndCategoriesQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetLast3BlogWithAuthorsAndCategoriesQueryHandler(IBlogRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<GetLast3BlogWithAuthorsAndCategoriesQueryResult>> Handle(GetLast3BlogWithAuthorsAndCategoriesQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogWithAuthorsAndCategories();
            return values.Select(x => new GetLast3BlogWithAuthorsAndCategoriesQueryResult
            {
                BlogID = x.BlogID,
                Title = x.Title,
                Description  = x.Description,
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name
            }).ToList();
        }
    }
}