using AutoMapper;
using CalculationService.Core.Models;
using CalculationService.Core.Services.DTOs;
using CalculationService.Services;
using ResultService.Core.Repositories.Interfaces;

namespace CalculationService.Core.Services;

public class CalculationService : ICalculationService
{
    private readonly ICalculationRepository _calculationRepository;
    private readonly IMapper _mapper;

    public CalculationService(ICalculationRepository calculationRepository, IMapper mapper)
    {
        _calculationRepository = calculationRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Calculation>> GetAllCalculations()
    {
        return await _calculationRepository.GetAllCalculations();
    }

    public async Task<Calculation> GetCalculationById(int calculationId)
    {
        return await _calculationRepository.GetCalculationById(calculationId);
    }

    public async Task<Calculation> AddCalculation(AddCalculationDTO addCalculationDto)
    {
        return await _calculationRepository.AddCalculation(_mapper.Map<Calculation>(addCalculationDto));
    }

    public async Task RebuildDatabase()
    {
        await _calculationRepository.RebuildDatabase();
    }
}