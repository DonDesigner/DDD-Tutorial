﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialEcommerce.Domain.ValueObject;
using TutorialEcommerce.Domain.Entities;

namespace TutorialEcommerce.Domain.Tests.Entities
{
    [TestClass]
    public class UsuarioTest
    {

        private Cpf Cpf { get; set; }
        private Email Email { get; set; }
        private string Login { get; set; }
        private string Senha { get; set; }
        private string SenhaConfirmacao { get; set; }
        private Usuario usuario { get; set; }
        

        public UsuarioTest()
        {
            Cpf = new Cpf("40914294830");
            Email = new Email("diego@diego.com.br");
            Login = "adminTeste";
            Senha = "123456";
            SenhaConfirmacao = "123456";

            usuario = new Usuario(Login, Cpf, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Cpf_Obrigatório()
        {
            new Usuario(Login, null, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Login_Obrigatório()
        {
            new Usuario("", Cpf, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Email_Obrigatório()
        {
            new Usuario(Login, Cpf, null, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Senha_Obrigatório()
        {
            new Usuario(Login, Cpf, Email, "", SenhaConfirmacao);
        }

        [TestMethod]
        public void Usuario_New_Cpf()
        {
             Assert.AreEqual(Cpf, usuario.Cpf);
        }

        [TestMethod]
        public void Usuario_New_Login()
        {
             Assert.AreEqual(Login, usuario.Login);
        }

        [TestMethod]
        public void Usuario_New_Email()
        {
            Assert.AreEqual(Email, usuario.Email);
        }

        [TestMethod]
        public void Usuario_New_Senha()
        {
            Assert.IsNotNull(usuario.Senha);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetLogin_Min_Value()
        {
            var login = "12345";
            new Usuario(login, Cpf, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetLogin_Max_Value()
        {
            usuario.SetLogin("1234567890123456789012345678901");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetSenha_Min_Value()
        {
            var senha1 = "12345";
            new Usuario(Login, Cpf, Email, senha1, senha1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_SetSenha_Max_Value()
        {
            var senha = "1234567890123456789012345678901";
            new Usuario(Login, Cpf, Email, senha, SenhaConfirmacao);
        }

        [TestMethod]
        public void AlterarSenha_Valida()
        {
            usuario.AlterarSenha("123456", "654321", "654321");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AlterarSenha_Invalido()
        {
            usuario.AlterarSenha("123456", "654321", "654322");
        }

        [TestMethod]
        public void AlterarSenha_Token_valido()
        {
            var t = usuario.GerarNovoTokenAlterarSenha();
            usuario.AlterarSenha(t, "654321", "654321");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AlterarSenha_Token_Invalido()
        {
            var t = Guid.NewGuid();
            usuario.AlterarSenha(t, "654321", "654321");

        }

        [TestMethod]
        public void ValidarSenha_Valido()
        {
            usuario.ValidarSenha("123456");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidarSenha_Invalida()
        {
            usuario.ValidarSenha("");
        }
    }
}
