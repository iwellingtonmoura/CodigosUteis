using System;
using System.Text.RegularExpressions;

namespace ExpressaoRegularTelefoneCelular
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            string numeroTelefone = "971028885";
            string numeroTelefoneFixo = "72223455";


            string retornoCelular = ValidaTelefoneCelular(numeroTelefone);
            string retornoTelefoneFixo = ValidaTelefonefixo(numeroTelefoneFixo);

            Console.WriteLine(retornoCelular);
            Console.WriteLine(retornoTelefoneFixo);
        }


        static string ValidaTelefoneCelular(string telefone)
        {
            //Regex regex = new Regex(@"^\d{5}\d{4}$"); //formato (XX)XXXXX-XXXX
            //Regex regex = new Regex(@"^\d{5}-\d{4}$"); //formato XXXXX-XXXX
            //Regex regex = new Regex(@"^\d{9}$"); //formato (XX)XXXXX-XXXX
            Regex regex = new Regex(@"^(?:|9[1-9])[0-9]{3}?[0-9]{4}$");
            //Regex rgxCelular = new Regex(@"^\(?[1-9]{2}\)??(?:|9[1-9])[0-9]{3}\-?[0-9]{4}$");

            if (!regex.IsMatch(telefone))

                return "9" + telefone;
            //return false;
            else
                return telefone;
        }

        static string ValidaTelefonefixo(string telefone)
        {
            //Regex rgxFixo = new Regex(@"^\(?[1-9]{2}\)??(?:[2-5])[0-9]{3}\-?[0-9]{4}$");
            Regex rgxFixo = new Regex(@"^(?:[2-5])[0-9]{3}?[0-9]{4}$");

            if (!rgxFixo.IsMatch(telefone))
            {
                return "Numero Fixo Invalido";
            }

            return telefone;
        }


    }


}


//Validar data: 

//public bool validaData(string data) //recebe data como parâmetro
//{
//    DateTime resultado = DateTime.MinValue;

//    if (DateTime.TryParse(data, out resultado))
//        return true; //retorna true se data for válida
//    return false; //retorna false se data for inválida
//}

//Validar email: 
       
//   bool ValidEmail = false;
//int indexArr = Email.IndexOf("@");

//if (indexArr > 0)
//{
//    int indexDot = Email.IndexOf(".", indexArr);
//    if (indexDot - 1 > indexArr)
//    {
//        if (indexDot + 1 < Email.Length)
//        {
//            string indexDot2 = Email.Substring(indexDot + 1, 1);
//            if (indexDot2 != ".")
//            {
//                ValidEmail = true;
//            }
//        }
//    }
//}
//return ValidEmail;
//    }               

//   //Validar telefone: 

//   using System.Text.RegularExpressions; // biblioteca para usar o Regex
   
//   ...
   
//   public bool ValidaTelefone(string telefone)
//{
//    Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"); //formato (XX)XXXXX-XXXX

//    if (!Rgx.IsMatch(telefone))
//        return false;
//    else
//        return true;
//}

////Validar CEP: 

//public bool ValidaCEP(string cep)
//{
//    Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

//    if (!Rgx.IsMatch(cep))
//        return false;
//    else
//        return true;
//}