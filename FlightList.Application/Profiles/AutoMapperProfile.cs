using AutoMapper;
using FlightList.Application.Features.Airports.Queries.GetAirportList;
using FlightList.Application.Features.Flights.Commands.CreateFlight;
using FlightList.Application.Features.Flights.Commands.DeleteFlight;
using FlightList.Application.Features.Flights.Commands.UpdateFlight;
using FlightList.Application.Features.Flights.Dtos;
using FlightList.Application.Features.Flights.Queries.GetFlightDetail;
using FlightList.Application.Features.Flights.Queries.GetFlightList;
using FlightList.Domain;

namespace FlightList.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        this.CreateMap<Flight, GetFlightsListViewModel>().ReverseMap();
        this.CreateMap<Flight, GetFlightDetailViewModel>().ReverseMap();
        this.CreateMap<Airport, ArrivalAirportDto>().ReverseMap();
        this.CreateMap<Airport, DepartureAirportDto>().ReverseMap();
        this.CreateMap<Coordinates, CoordinatesDto>().ReverseMap();
        this.CreateMap<Flight, CreateFlightCommad>().ReverseMap();
        this.CreateMap<Flight, UpdateFlightCommand>().ReverseMap();
        this.CreateMap<Flight, DeleteFlightCommand>().ReverseMap();
        this.CreateMap<Airport, GetAirportListViewModel>().ReverseMap();
    }
}