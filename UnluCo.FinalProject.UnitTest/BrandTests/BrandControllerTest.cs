using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Controllers;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

using FluentAssertions;

namespace UnluCo.FinalProject.UnitTest.BrandTests
{
    public class BrandControllerTest
    {
        private readonly HttpClient _client;

        public BrandControllerTest()
        {
            _client = new HttpClient();
        }
        [Fact]
        public void Get_IActionResult()
        {

            //Arrange
            var brandService = new Mock<IBrandService>();

            //2
            brandService
                 .Setup(x => x.GetAll(b => b.Id > 0).Result)
                .Returns(new List<BrandViewModel>()
                {
            new BrandViewModel(){Id=1},
            new BrandViewModel(){Id=2},
            new BrandViewModel(){Id=3},
                });

            //3
            var controller = new BrandsController(brandService.Object);


            IActionResult actionResult = controller.Get();
            var response = actionResult as OkObjectResult;

            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }
    }
}
