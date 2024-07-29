using CQRS_Library.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.CQRS.Queries
{
    public record GetAllQueries : IRequest<List<Items>>;
}
