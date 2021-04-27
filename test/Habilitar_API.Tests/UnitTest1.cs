using System;
using Xunit;

namespace Habilitar_API.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var t = new Habilitar_API.Application.ViewModels.UsuarioViewModel();

            Assert.NotNull(t);
        }
    }
}
