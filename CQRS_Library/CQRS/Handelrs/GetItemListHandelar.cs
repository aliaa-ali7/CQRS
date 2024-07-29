using CQRS_Library.CQRS.Commands;
using CQRS_Library.CQRS.Queries;
using CQRS_Library.Data;
using CQRS_Library.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.CQRS.Handelrs
{
    public class GetItemListHandelar : IRequestHandler<GetAllQueries, List<Items>>
    {
        private readonly AppDbContext appDbContext;

        public GetItemListHandelar(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<Items>> Handle(GetAllQueries request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(appDbContext.Item.ToList());
        }
    }
}
