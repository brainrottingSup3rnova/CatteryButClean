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
        private readonly string _filePathCat = "cat.json";
        private readonly string _filePathAdoption = "adoption.json";
        private readonly string _filePathAdopter = "adopter.json";
        private readonly Dictionary<string, Cat> _catCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, Adoption> _adoptionCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, Adopter> _adopterCache = new(StringComparer.OrdinalIgnoreCase);
        private bool _isLoaded = false;

        private void EnsureDataLoading()
        {
            if(_isLoaded) return;

            if(!File.Exists(_filePathCat) || !File.Exists(_filePathAdopter) || !File.Exists(_filePathAdoption))
            {
                _isLoaded = true;
                return;
            }

            var catJsonData = File.ReadAllText(_filePathCat);
            var adopterJsonData = File.ReadAllText(_filePathAdopter);
            var adoptionJsonData = File.ReadAllText(_filePathAdoption);
            var catDtos = JsonSerializer.Deserialize<List<CatPersistenceDto>>(catJsonData) ?? new List<CatPersistenceDto>();
            var adoptionDtos = JsonSerializer.Deserialize<List<AdoptionPersistenceDto>>(adoptionJsonData) ?? new List<AdoptionPersistenceDto>();
            var adopterDtos = JsonSerializer.Deserialize<List<AdopterPersistenceDto>>(adopterJsonData) ?? new List<AdopterPersistenceDto>();


            foreach (var dto in catDtos)
            {
                Cat cat = dto.ToCatPersistence();
                _catCache[cat.Name] = cat;
            }

            foreach (var dto in adopterDtos)
            {
                Adopter adopter = dto.ToAdopterPersistence();
                _adopterCache[adopter.Name] = adopter;
            }

            foreach (var dto in adoptionDtos)
            {
                Adopter? adopter = null;
                Cat? cat = null;
                _adopterCache.TryGetValue(dto.Adopter.Name, out adopter);
                _catCache.TryGetValue(dto.Cat.name, out cat);
                if (adopter != null && cat != null)
                {
                    Adoption adoption = dto.ToAdoptionPersistence();
                    _adoptionCache[cat.Name] = adoption;
                }
            }

            _isLoaded = true;
        }

        private void SaveData()
        {
            var catDtos = _catCache.Values.Select(a => a.ToCatPersistenceDto()).ToList();
            var adoptionDtos = _adoptionCache.Values.Select(a => a.ToAdoptionPersistenceDto()).ToList();
            var adopterDtos = _adopterCache.Values.Select(a => a.ToAdopterPersistenceDto()).ToList();
            var catJsonData = JsonSerializer.Serialize(catDtos, new JsonSerializerOptions { WriteIndented = true });
            var adoptionJsonData = JsonSerializer.Serialize(adoptionDtos, new JsonSerializerOptions { WriteIndented = true });
            var adopterJsonData = JsonSerializer.Serialize(adopterDtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePathCat, catJsonData);
            File.WriteAllText(_filePathAdoption, adoptionJsonData);
            File.WriteAllText(_filePathAdopter, adopterJsonData);
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
                    SaveData();
                }
            }
        }

        public void RemoveCat(Cat cat)
        {
            if(cat == null)
            {
                throw new ArgumentNullException("Cat cannot be null.");
            }
            else
            {
                EnsureDataLoading();
                if(!_catCache.ContainsKey(cat.Name))
                {
                    throw new InvalidOperationException($"The cat '{cat.Name}' does not exist.");
                }
                else
                {
                    _catCache.Remove(cat.Name);
                    SaveData();
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
                    SaveData();
                    RemoveCat(adoption.Cat);
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
                    SaveData();
                    AddCat(adoption.Cat);
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
                    SaveData();
                }
            }
        }

        public Cat? GetCatByName(string name)
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

        public Adoption? GetAdoption(string catName)
        {
            EnsureDataLoading();
            Adoption? adoption;
            _adoptionCache.TryGetValue(catName, out adoption);
            return adoption;
        }

        public Adoption[]? GetAllAdoptions()
        {
            EnsureDataLoading();
            Adoption[] adoptions = new Adoption[_adoptionCache.Count];
            for(int i=0; i< _adoptionCache.Count; i++)
            {
                adoptions[i] = _adoptionCache.Values.ElementAt(i);
            }
            return adoptions;
        }

        public Adopter[]? GetAllAdopters()
        {
            EnsureDataLoading();
            Adopter[] adopters = new Adopter[_adopterCache.Count];
            for(int i=0; i< _adopterCache.Count; i++)
            {
                adopters[i] = _adopterCache.Values.ElementAt(i);
            }
            return adopters;
        }

        public Adopter? GetAdopterByName(string name)
        {
            EnsureDataLoading();
            Adopter? adopter;
            _adopterCache.TryGetValue(name, out adopter);
            if(adopter != null)
            {
                return adopter;
            }
            else
            {
                return null;
            }
        }
    }
}