using Moq;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NTec.Application.Tests.Services
{
    public class CargoServiceTests
    {
        private CargoApplicationService cargoApplicationService;

        public CargoServiceTests()
        {
            cargoApplicationService = new CargoApplicationService(new Mock<ICargoService>().Object, new Mock<ICargoMapper>().Object);
        }

        [Fact]
        public void Add_SendingValidId()
        {
            Assert.Throws<Exception>(() => cargoApplicationService.Add(new Dtos.CargoDto { Id = 10 }));
        }

        [Fact]
        public void GetById_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => cargoApplicationService.GetById(0));
        }

        [Fact]
        public void Update_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => cargoApplicationService.Update(new Dtos.CargoDto()));
        }

        [Fact]
        public void Remove_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => cargoApplicationService.Remove(0));
        }
    }
}
