using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialEcommerce.Domain.ValueObject;



namespace TutorialEcommerce.Domain.Tests.ValueObject
{
    [TestClass]
    public class EmailTest
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_em_Branco()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_em_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_New_Email_valido()
        {
            var endereco = "diego@diego.com.br";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido()
        {
            var email = new Email("fasdfaasasfdsfd");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_ErroMaxLength()
        {
            var endereco = "diego@diego.com.br";
            while (endereco.Length < Email.EnderecoMaxLengtn + 1)
            {
                endereco = endereco + "diego@diego.com.br";
            }
            new Email("fasdfaasasfdsfd");
        }
    }
}
