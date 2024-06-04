using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Dtos.Dependent;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contracts;

namespace MyVaccineWebApi.Services.Implementations
{
    public class DependentService : IDependentService
    {
        private readonly IBaseRepository<Dependent> _dependentRepository;
        private readonly IMapper _mapper;
        public DependentService(IBaseRepository<Dependent> dependentRepository, IMapper mapper)
        {
            _dependentRepository = dependentRepository;
            _mapper = mapper;
        }
        public async Task<DependentResponseDto> Add(DependentRequestDto request)
        {
            var dependents = new Dependent();
            dependents.Name = request.Name;
            dependents.DateOfBirth = request.DateOfBirth;
            dependents.UserId = request.UserId;

            await _dependentRepository.Add(dependents);
            var response = _mapper.Map<DependentResponseDto>(dependents);
            return response;
        }

        public async Task<DependentResponseDto> Delete(int id)
        {
            var dependents = await _dependentRepository.FindBy(x => x.DependentId == id).FirstOrDefaultAsync();

            await _dependentRepository.Delete(dependents);
            var response = _mapper.Map<DependentResponseDto>(dependents);
            return response;
        }

        public async Task<IEnumerable<DependentResponseDto>> GetAll()
        {
            var dependents = await _dependentRepository.GetAll().AsNoTracking().ToListAsync();
            var response = _mapper.Map<IEnumerable<DependentResponseDto>>(dependents);
            return response;
        }

        public async Task<DependentResponseDto> GetById(int id)
        {
            var dependents = await _dependentRepository.FindByAsNoTracking(x => x.DependentId == id).FirstOrDefaultAsync();
            var response = _mapper.Map<DependentResponseDto>(dependents);
            return response;
        }
        public async Task<IEnumerable<DependentResponseDto>> GetDependentsByUserId(int userId)
        {
            var dependents = await _dependentRepository.FindByAsNoTracking(x => x.UserId == userId).ToListAsync();
            var response = _mapper.Map<IEnumerable<DependentResponseDto>>(dependents);
            return response;
        }

        public async Task<DependentResponseDto> Update(DependentRequestDto request, int id)
        {
            var dependents = await _dependentRepository.FindBy(x => x.DependentId == id).FirstOrDefaultAsync();
            dependents.Name = request.Name;
            dependents.DateOfBirth = request.DateOfBirth;
            dependents.UserId = request.UserId;

            await _dependentRepository.Update(dependents);
            var response = _mapper.Map<DependentResponseDto>(dependents);
            return response;
        }
    }
}
