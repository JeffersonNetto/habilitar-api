using Bogus;
using FluentAssertions;
using Habilitar.Api.Controllers;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Habilitar.Api.Tests
{
    public class EmpresaTests
    {
        private readonly AutoMocker mocker;
        private readonly EmpresaController controller;

        public EmpresaTests()
        {
            mocker = new AutoMocker();
            controller = mocker.CreateInstance<EmpresaController>();
        }

        [Fact]
        public async void GetEmpresasShouldNotBeNull()
        {
            //Arrange            
            var expected = new Faker<Empresa>("pt_BR")
                .RuleFor(m => m.Id, f => f.Random.Short(1, 100))
                .RuleFor(m => m.NomeFantasia, f => f.Company.CompanyName())
                .RuleFor(m => m.RazaoSocial, f => f.Company.CompanyName())
                .RuleFor(m => m.Ativo, f => f.Random.Bool())
                .RuleFor(m => m.DataCriacao, f => f.Date.Recent())
                .RuleFor(m => m.UsuarioCriacaoId, Guid.NewGuid())
                .Generate(5);

            mocker.GetMock<IRepositoryBase<Empresa>>().Setup(_ => _.GetAll()).ReturnsAsync(expected);            

            //Act
            var actual = await controller.Get();

            var result = actual.Result.As<OkObjectResult>();

            //Assert            
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<SuccessResponse<IEnumerable<Empresa>>>();
            var obj = result.Value as SuccessResponse<IEnumerable<Empresa>>;
            obj.Dados.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void GetEmpresaShouldNotBeNull()
        {
            //Arrange            
            var expected = new Faker<Empresa>("pt_BR")
                .RuleFor(m => m.Id, f => f.Random.Short(1, 100))
                .RuleFor(m => m.NomeFantasia, f => f.Company.CompanyName())
                .RuleFor(m => m.RazaoSocial, f => f.Company.CompanyName())
                .RuleFor(m => m.Ativo, f => f.Random.Bool())
                .RuleFor(m => m.DataCriacao, f => f.Date.Recent())
                .RuleFor(m => m.UsuarioCriacaoId, Guid.NewGuid())
                .Generate();

            mocker.GetMock<IRepositoryBase<Empresa>>().Setup(_ => _.GetById(It.Is<int>(id => id > 0))).ReturnsAsync(expected);            

            //Act
            var actual = await controller.Get(1);

            var result = actual.Result.As<OkObjectResult>();

            //Assert            
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<SuccessResponse<Empresa>>();
            var obj = result.Value as SuccessResponse<Empresa>;
            obj.Dados.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void AddEmpresa()
        {
            //Arrange
            var empresa = new Faker<Empresa>("pt_BR")
                .RuleFor(m => m.Id, f => f.Random.Short(1, 100))
                .RuleFor(m => m.NomeFantasia, f => f.Company.CompanyName())
                .RuleFor(m => m.RazaoSocial, f => f.Company.CompanyName())
                .RuleFor(m => m.Ativo, f => f.Random.Bool())
                .RuleFor(m => m.DataCriacao, f => f.Date.Recent())
                .RuleFor(m => m.UsuarioCriacaoId, Guid.NewGuid())
                .Generate();
            
            mocker.GetMock<IRepositoryBase<Empresa>>().Setup(_ => _.GetById(It.Is<int>(id => id > 0))).ReturnsAsync(empresa);            

            //Act
            var actual = await controller.Post(empresa);

            var result = actual.Result.As<CreatedResult>();

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Value.Should().BeOfType<SuccessResponse<Empresa>>();
            var obj = result.Value as SuccessResponse<Empresa>;
            obj.Dados.Should().BeEquivalentTo(empresa);            
            mocker.GetMock<IRepositoryBase<Empresa>>().Verify(m => m.Add(empresa), Times.Once);
            mocker.GetMock<IUnitOfWork>().Verify(u => u.Commit(), Times.Once);            
        }
    }
}
