using ApiUsuarios.Application.Models;
using ApiUsuarios.Tests.Helpers;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiUsuarios.Tests.Tests
{
    public class AutenticarTest
    {
        [Fact]
        public async Task Test_Post_Autenticar_Returns_Ok()
        {
            #region Criar um usuário

            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            //criando os dados para cadastrar um usuário
            var modelCriarConta = new CriarContaPostModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = "21999990000",
                Senha = "@Teste1234"
            };

            //serializando os dados em JSON
            var contentCriarConta = testHelper.CreateContent(modelCriarConta);

            //enviando a requisição para a API
            var result = await testHelper.CreateClient().PostAsync("/api/CriarConta", contentCriarConta);

            #endregion

            #region Autenticando o usuário

            var modelAutenticar = new AutenticarPostModel
            {
                Email = modelCriarConta.Email,
                Senha = modelCriarConta.Senha
            };

            var contentAutenticar = testHelper.CreateContent(modelAutenticar);
            var response = await testHelper.CreateClient().PostAsync("/api/Autenticar", contentAutenticar);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_Post_Autenticar_Returns_Unauthorized()
        {
            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            var model = new AutenticarPostModel
            {
                Email = faker.Internet.Email(),
                Senha = "@Teste123456"
            };

            var content = testHelper.CreateContent(model);
            var response = await testHelper.CreateClient().PostAsync("/api/Autenticar", content);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Unauthorized);
        }
    }
}



