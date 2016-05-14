using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Helpers;

namespace TutorialEcommerce.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLengtn = 254;
        public string Endereco { get; private set; }

        //Construtor do EntityFramework
        protected Email()
        {

        }


        public Email(string endereco)
        {
            Guard.ForNullOrEmptyDefaultMessage(endereco, "E-mail");
            Guard.StringLength("E-mail". en)

                
        }

    }

    
}
