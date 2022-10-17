using System.IdentityModel.Tokens.Jwt;
using ChapterBET6.Controllers;
using ChapterBET6.Interfaces;
using ChapterBET6.Models;
using ChapterBET6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TesteIntegracao
{
    public class LoginControllerTeste
    {
    [Fact]
    public void LoginController_Retornar_Usuario_Invalido()
        {
            //Arrange

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();

            dadosUsuario.email = "batata@gmail.com";

            dadosUsuario.senha = "batata";

            //Act

            var resultado = controller.Login(dadosUsuario);

            //Assert

            Assert.IsType<UnauthorizedObjectResult>(resultado);
            
        }

        [Fact]

        public void LoginController_Retornar_Token()
        {
            //Arrange

            Usuario usuarioRetornado = new Usuario();

            usuarioRetornado.Email = "email@email.com";

            usuarioRetornado.Senha = "1234";

            usuarioRetornado.Tipo = "0";

            usuarioRetornado.Id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();

            dadosUsuario.email = "batata@gmail.com";

            dadosUsuario.senha = "batata";

            var controller = new LoginController(repositoryEspelhado.Object);

            string issuerValido = "chapter.webapi";

            //Act
            //var resultado = controller.Login(dadosUsuario);

            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);

            //Assert

            Assert.Equal(issuerValido, tokenJwt.Issuer);
        }
    }
}
