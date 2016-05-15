using System;


namespace TutorialEcommerce.Helpers
{
    public class Guard
    {

        public static void ForValidId(string proName, Guid id)
        {
            ForValidId(id, proName + " id inválido!");
        }

        public static void ForValidId(Guid id, string errorMessage)
        {
            if (id == Guid.Empty)
                throw new Exception(errorMessage);
        }

        public static void ForValidId(string propName, int id)
        {
            ForValidId(id, propName + " id Inválido!");
        }

        public static void ForValidId(int id, string errorMessage)
        {
            if (!(id > 0))
                throw new Exception(errorMessage);
        }

        public static void ForNegative(int number, string proName)
        {
            if (number < 0)
                throw new Exception(proName + " não pode ser negativo!");
        }

        public static void ForNullOrEmptyDefaultMessage(string value, string propName)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(propName + " é obrigatório!");
        }


        public static void ForNullOrEmpty(string value, string msgError)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception(msgError);
        }

        public static void StringLength(string propName, string stringValue, int maximum)
        {
            StringLength(stringValue, maximum, propName + "não pode ter mais de que " + maximum + " caracteres");
        }

        public static void StringLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Length;
            if(length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void StringLength(string propName, string stringValue, int minimum, int maximum)
        {
            StringLength(stringValue, minimum, maximum, propName + "deve ter de " + minimum + " à " + maximum + " caracteres!");
        }

        public static void StringLength(string stringValue, int mininum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Length;
            if(length < mininum || length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void AreEqual(string a, string b, string errorMessage)
        {
            if (a != b)
                throw new Exception(errorMessage);
        }
    }
}
