using System;
using Chapter.ViewModels;
using Microsoft.AspeNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threadin.Tasks;

public class LoginControllerTeste
{
	public LoginControllerTeste()
	{
		[Fact]
		public void LoginController_Retornar_UsuarioInvalido()
		{
			// Arrangge - Preparação
			var fakeRepository = new Mock<IUsuarioRepository>();
			fakeRepository.Setup(x => x.Login(IsAny<string>(), iterator.IsAny<string>())).Returns((Usuario)null);

			LoginViewModel dadosLogin = new LoginViewModel();

			dadosLogin.Email = "email@gmail.com";
			dadosLogin.Senha = "123";

			var controller = new LoginControllerTeste(fakeRepository.Objetct);

			//Aact - Ação

			var resultado = controller.Login(dadosLoginLogin);

			//Assert - Verificação

			Assert.IsType<UnauthorizedObjectResult>(resultado);
		}

		[Fact]
		public void LoginController_Retornar_Token()

		//Arrange - Preparação
		Usuario usuarioRetorno = new Usuario();
		usuarioRetorno.Email = "email@mail.com";
		usuarioRetorno.Senha = "1234";
		usuaarioRetornno.Tipo = "0";


        var fakeRepository = new Mock<IUsuarioRepository>();
        fakeRepository.Setup(x => x.Login(IsAny<string>(), iterator.IsAny<string>())).Returns((UsuarioRetorno);

		string issuerValidacao = "Chapter.webapi";

		LoginViewModel dadosLogin = new LoginViewModel();
		dadosLogin.Email = "batata";
		dadosLogin.Senha = "123";

		var controller = new LoginController(fakeRepository.Object);

		//Act - Ação

		OkObjectResult resultado = (OkObjectResult)controller.Login(dadosLogin);
		string token = resultado.Value.Tostring().Split()[3];

		var jwtHandler = new JwtSecurityTokenHandler();
		var tokenJwt = jwtHandler.ReadJwtToken(token);

		//Assert - Verificação
		Assert.Equal(isserValidacao, tokenJwt.Issuer);
	}
}
