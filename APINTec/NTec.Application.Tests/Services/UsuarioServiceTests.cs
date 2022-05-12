using Moq;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System;
using Xunit;

namespace NTec.Application.Tests.Services
{
    public class UsuarioServiceTests
    {
        private UsuarioApplicationService usuarioApplicationService;

        public UsuarioServiceTests()
        {
            usuarioApplicationService = new UsuarioApplicationService(new Mock<IUsuarioService>().Object, new Mock<IUsuarioMapper>().Object);
        }

        [Fact]
        public void Add_SendingValidId()
        {
            Assert.Throws<Exception>(() => usuarioApplicationService.Add(new Dtos.UsuarioDto { Id = 10 }));
        }

        [Fact]
        public void GetById_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => usuarioApplicationService.GetById(0));
        }

        [Fact]
        public void Update_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => usuarioApplicationService.Update(new Dtos.UsuarioDto()));
        }

        [Fact]
        public void Remove_SendingEmptyId()
        {
            Assert.Throws<Exception>(() => usuarioApplicationService.Remove(0));
        }

        [Fact]
        public void Authenticate_SendingEmptyValue()
        {
            Assert.Throws<Exception>(() => usuarioApplicationService.GetUsuarioByUserAndPassword(string.Empty, string.Empty));
        }
    }
}
