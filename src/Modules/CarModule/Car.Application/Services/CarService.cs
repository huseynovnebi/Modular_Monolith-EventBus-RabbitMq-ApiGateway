using Car.Application.Models.DTO;
using Car.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Car.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _CarRepository;
        private readonly IMapper mapper;

        public CarService(ICarRepository CarRepository,IMapper mapper)
        {
            _CarRepository = CarRepository;
            this.mapper = mapper;
        }


        public async Task Add(CreateCarDTO entity)
        {
            var car = mapper.Map<Domain.Car>(entity);
            await _CarRepository.Add(car);
        }


        public async Task<List<Domain.Car>> GetAll()
        {
           var cars = await _CarRepository.GetAll();

            return cars;
        }

        public async Task<Domain.Car?> GetByIdStrictAsync(int entityId)
        {
            var car = await _CarRepository.GetByIdStrictAsync(entityId);
            return car; 
        }

        public void Remove(Domain.Car entity) { 
            
            _CarRepository.Remove(entity);
        
        }

        public void Update(UpdateCarDTO entity) {
            var car = mapper.Map<Domain.Car>(entity);
            _CarRepository.Update(car); 
        }

    }
}
