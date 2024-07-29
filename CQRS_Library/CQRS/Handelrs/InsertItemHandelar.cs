using CQRS_Library.CQRS.Commands;
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
    public class InsertItemHandelar : IRequestHandler<InsertCommand, Items>
    {
        private readonly AppDbContext appDbContext;

        public InsertItemHandelar(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Items> Handle(InsertCommand request, CancellationToken cancellationToken)
        {
            await appDbContext.Item.AddAsync(request.Items);
            appDbContext.SaveChanges();
            return await Task.FromResult(request.Items);
        }
    }
}
