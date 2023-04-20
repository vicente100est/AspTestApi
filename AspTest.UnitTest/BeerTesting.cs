using Asp.Backend.API.Controllers;
using Asp.Backend.API.Models;
using Asp.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspTest.UnitTest
{
    public class BeerTesting
    {
        private readonly BeerController _controller;
        private readonly IBeerService _servicio;

        public BeerTesting()
        {
            _servicio = new BeerService();
            _controller = new BeerController(_servicio);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_controller.Get();

            var beers = Assert.IsType<List<Beer>>(result.Value);

            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            int id = 1;

            var result = _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            // Arrange
            int id = 1;

            // Act
            var result = (OkObjectResult)_controller.GetById(id);

            // Assert
            var beer = Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(beer?.Id, id);
        }

        [Fact]
        public void GetById_NotFound()
        {
            int id = 11;

            var result = _controller.GetById(id);

            var beer = Assert.IsType<NotFoundResult>(result);
        }
    }
}