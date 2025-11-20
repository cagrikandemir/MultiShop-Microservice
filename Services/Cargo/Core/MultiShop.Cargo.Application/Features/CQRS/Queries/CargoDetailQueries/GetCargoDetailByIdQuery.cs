using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoDetailQueries;

public class GetCargoDetailByIdQuery : IRequest<GetCargoDetailByIdQueryResult>
{
    public int Id { get; set; }

    public GetCargoDetailByIdQuery(int ıd)
    {
        Id = ıd;
    }
}
