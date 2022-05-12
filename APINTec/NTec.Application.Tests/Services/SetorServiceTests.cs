using Moq;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System;
using Xunit;

namespace NTec.Application.Tests.Services
{
    public class SetorServiceTests
    {
        private SetorApplicationService setorApplicationService;

        public SetorServiceTests()
        {
            setorApplicationService = new SetorApplicationService(new Mock<ISetorService>().Object, new Mock<ISetorMapper>().Object);
        }

        [Fact]
        public void Add_SendingValidId()
        {
            Assert.Throws<Exception>(() => setorApplicationService.Add(new Dtos.SetorDto { Id = 10 }));
        }

        [Fact]
        public void GetById_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => setorApplicationService.GetById(0));
        }

        [Fact]
        public void Update_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => setorApplicationService.Update(new Dtos.SetorDto()));
        }

        [Fact]
        public void Remove_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => setorApplicationService.Remove(0));
        }
    }
}
