﻿using LivePlanetmans.App.Services.Planetside;
using LivePlanetmans.Data.Models.Census;
using LivePlanetmans.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivePlanetmans.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ILoadoutRepository _loadoutRepository;
        private readonly ICharacterService _characterService;

        public WeatherForecastController(ILoadoutRepository loadoutRepository, ICharacterService characterService, ILogger<WeatherForecastController> logger)
        {
            _loadoutRepository = loadoutRepository;
            _characterService = characterService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/loadouts")]
        public async Task<IEnumerable<Loadout>> GetLoadouts()
        {
            return await _loadoutRepository.GetAllLoadoutsAsync();
        }

        [HttpGet("/characters/{characterName}")]
        public async Task<Character> GetCharacterByName(string characterName)
        {
            return await _characterService.GetCharacterByName(characterName);
        }
    }
}
