using Moq;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System;
using Xunit;

namespace NTec.Application.Tests.Services
{
    public class ColaboradorServiceTests
    {
        private ColaboradorApplicationService colaboradorApplicationService;

        public ColaboradorServiceTests()
        {
            colaboradorApplicationService = new ColaboradorApplicationService(new Mock<IColaboradorService>().Object, new Mock<ICargoApplicationService>().Object, new Mock<ISetorApplicationService>().Object, new Mock<IColaboradorMapper>().Object);
        }

        [Fact]
        public void Add_SendingValidId()
        {
            Assert.Throws<Exception>(() => colaboradorApplicationService.Add(new Dtos.ColaboradorDto { Id = 10 }));
        }

        [Fact]
        public void GetById_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => colaboradorApplicationService.GetById(0));
        }

        [Fact]
        public void Update_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => colaboradorApplicationService.Update(new Dtos.ColaboradorDto()));
        }

        [Fact]
        public void Remove_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => colaboradorApplicationService.Remove(0));
        }
    }
}
