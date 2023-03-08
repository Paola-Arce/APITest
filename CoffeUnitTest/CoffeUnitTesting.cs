using APITest.Controllers;
using APITest.Models;
using APITest.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CoffeUnitTest
{
    public class CoffeUnitTest
    {
        private readonly CoffeController _controller;
        private readonly ICoffeService _service;

        public CoffeUnitTest()
        {
            _service = new CoffeService();
            _controller = new CoffeController(_service);
        }


        [Fact]
        public void GetById_Ok()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_controller.Get();

            var coffes = Assert.IsType<List<Coffe>>(result.Value);

            Assert.True(coffes.Count > 0);

        }


        [Fact]
        public void GetByIdOk()
        {
            int id = 1;
            var result = _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetById_Exists()
        {
            //estos son los tres pasos para hacer la prueba unitaria
            
            //Arrange Preparación
            int id = 1;

            //Act la ejecución del test
            var result = (OkObjectResult)_controller.GetById(id); // cuando no sea del tipo sera nulo
            //también puede aparecer  de esta manera 
            // var result = _controller.GetById(id) as OkObjectResult;

            // Assert la evaluación del test, el que dice si pasa o no dicho test

            var coffe = Assert.IsType<Coffe>(result?.Value); //se evalua si el tipo es café
            Assert.True(coffe!= null); // se evaluar una instrucción booleana
            Assert.Equal(coffe?.Id, id); //se evalua si el id es igual al que se mandado o si la evaluación es sobre el id

        }

        [Fact]
        public void GetById_NotFound()
        {
            // Arrange
            int id = 11;

            // Act 
            var result = _controller.GetById(id);

            // Assert
            var coffe = Assert.IsType<NotFoundResult>(result);
        }

    }
}