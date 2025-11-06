using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using System.Text.Json;
using Infrastructure.Dto;
using Infrastructure.Mapper;

namespace Infrastructure.Repositories
{
    public class JsonCatRepository : ICatteryRepository
    {
        private readonly string _filePath = "cat.json";
        private readonly Dictionary<string, Cat> _catCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, Adoption> _adoptionCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, Adopter> _adopterCache = new(StringComparer.OrdinalIgnoreCase);
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
            
            foreach(var dto in dtos)
            {
                Cat cat = dto.ToCatPersistence();
                _catCache[cat.Name] = cat;
            }

            _isLoaded = true;
        }

        private void SaveData()
        {
            var dtos = _catCache.Values.Select(a => a.ToCatPersistenceDto()).ToList();
            var jsonData = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);

        }

        public void AddCat(Cat cat)
        {
            if(cat== null)
            {
                throw new ArgumentNullException("Cat cannot be null.");
            }
            else
            {
                EnsureDataLoading();
                if(_catCache.ContainsKey(cat.Name))
                {
                    throw new InvalidOperationException($"A cat with the name '{cat.Name}' already exists.");
                }
                else
                {   
                    _catCache.Add(cat.Name, cat);
                }
            }
        }

        public void RegisterAdoption(Adoption adoption)
        {
            if(adoption == null)
            {
                throw new ArgumentNullException("Adoption cannot be null.");
            }
            else
            {
                EnsureDataLoading();
                if(_adoptionCache.ContainsKey(adoption.Cat.Name))
                {
                    throw new InvalidOperationException($"The cat '{adoption.Cat.Name}' is already adopted.");
                }
                else
                {
                    _adoptionCache.Add(adoption.Cat.Name, adoption);
                }
            }
        }

        public void CancelAdoption(Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException("Adoption cannot be null.");
            }
            else
            {
                EnsureDataLoading();
                if(!_adoptionCache.ContainsKey(adoption.Cat.Name))
                {
                    throw new InvalidOperationException($"The cat '{adoption.Cat.Name}' is not adopted.");
                }
                else
                {
                    _adoptionCache.Remove(adoption.Cat.Name);
                }
            }
        }

        public void RegisterAdopter(Adopter adopter)
        {
            if(adopter == null)
            {
                throw new ArgumentNullException("Adopter cannot be null.");
            }
            else
            {
                EnsureDataLoading();
                if(!_adopterCache.ContainsKey(adopter.Name))
                {
                    _adopterCache.Add(adopter.Name, adopter);
                }
            }
        }

        public Cat? GetByName(string name)
        {
            EnsureDataLoading();

            Cat? cat;
            _catCache.TryGetValue(name, out cat);
            return cat;
        }

        public Cat[]? GetAllCats()
        {
            EnsureDataLoading();

            Cat[] cats= new Cat[_catCache.Count];
            for(int i=0; i< _catCache.Count; i++)
            {
                cats[i] = _catCache.Values.ElementAt(i);
            }
            return cats;
        }
    }
}