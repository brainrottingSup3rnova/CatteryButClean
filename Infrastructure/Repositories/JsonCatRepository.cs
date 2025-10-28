using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using System.Text.Json;
using Infrastructure.Dto;

namespace Infrastructure.Repositories
{
    public class JsonCatRepository : ICatteryRepository
    {
        private readonly string _filePath = "cat.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _isLoaded = false;

        private void EnsureDataLoading()
        {
            if(_isLoaded) return;

            if(!File.Exists(_filePath))
            {
                _isLoaded = true;
                return;
            }

            var jsonData = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<CatPersistenceDto>>(jsonData) ?? new List<CatPersistenceDto>();
        }
        public void AddCat(Cat cat)
        {
            throw new NotImplementedException();
        }
        public void RegisterAdoption(Adoption adoption)
        {
            throw new NotImplementedException();
        }
        public void CancelAdoption(Adoption adoption)
        {
            throw new NotImplementedException();
        }
        public void RegisterAdopter(Adopter adopter)
        {
            throw new NotImplementedException();
        }
        public Cat? GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}