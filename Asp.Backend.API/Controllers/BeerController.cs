﻿using Asp.Backend.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_beerService.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var beer = _beerService.Get(id);
            if (beer == null)
                return NotFound();

            return Ok(beer);
        }
    }
}
