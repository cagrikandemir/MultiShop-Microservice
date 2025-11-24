using AutoMapper;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCompanyResults;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoDetailResults;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Mapping;

public class GeneralMapping: Profile
{
    public GeneralMapping()
    {
        CreateMap<CargoCompany,CreateCargoCompanyCommand>().ReverseMap();
        CreateMap<CargoCompany,RemoveCargoCompanyCommand>().ReverseMap();
        CreateMap<CargoCompany,UpdateCargoCompanyCommand>().ReverseMap();
        CreateMap<CargoCompany,GetCargoCompanyByIdQueryResult>().ReverseMap();
        CreateMap<CargoCompany,GetCargoCompanyQueryResult>().ReverseMap();


        CreateMap<CargoCustomer,CreateCargoCustomerCommand>().ReverseMap();
        CreateMap<CargoCustomer,RemoveCargoCustomerCommand>().ReverseMap();
        CreateMap<CargoCustomer,UpdateCargoCustomerCommand>().ReverseMap();
        CreateMap<CargoCustomer,GetCargoCustomerByIdQueryResult>().ReverseMap();
        CreateMap<CargoCustomer,GetCargoCustomerQueryResult>().ReverseMap();


        CreateMap<CargoDetail,CreateCargoDetailCommand>().ReverseMap();
        CreateMap<CargoDetail,RemoveCargoDetailCommand>().ReverseMap();
        CreateMap<CargoDetail,UpdateCargoDetailCommand>().ReverseMap();
        CreateMap<CargoDetail, GetCargoDetailByIdQueryResult>().ReverseMap();
        CreateMap<CargoDetail, GetCargoDetailQueryResult>().ReverseMap();


        CreateMap<CargoOperation,CreateCargoOperationCommand>().ReverseMap();
        CreateMap<CargoOperation,RemoveCargoOperationCommand>().ReverseMap();
        CreateMap<CargoOperation,UpdateCargoOperationCommand>().ReverseMap();
        CreateMap<CargoOperation, GetCargoOperationByIdQueryResult>().ReverseMap();
        CreateMap<CargoOperation, GetCargoOperationQueryResult>().ReverseMap();
    }
}
