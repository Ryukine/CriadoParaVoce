using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Text.RegularExpressions;


namespace BLL
{
    //  QR Code
    //http://fabriciolondero.com.br/2016/11/19/gerar-e-ler-qrcode-com-c/
    //http://www.macoratti.net/15/06/c_qrcd1.htm
    //http://www.c-sharpcorner.com/UploadFile/38268a/generating-qr-code-in-C-Sharp/


    public class FuncoesGerais
    {
        //http://csharp.net-informations.com/communications/csharp-email-attachment.htm
        //enviar email

        public enum TipoUso : byte
        {
            Inclusao,       //0
            Alteracao,      //1
            ExclusaoFisica, //2
            ExclusaoLogica, //3
            Consulta,       //4
            TrocaSenha      //5
        }
        public enum NivelDeAcesso : byte
        {
            Administrador, //0
            Supervisor,    //1
            Usuario        //2
        }
        public enum LocalBanco : byte
        {
            MicroPessoal,  //0
            EstacaoLab,    //1
            ServidorLab    //2
        }
        public enum TipoBancoDados : byte
        {
            SqlServer,      //0
            SqlLite,        //1        
            Access2013,     //2
            SqlServer2008,  //3
            Oracle11g,      //4
            MySql,          //5
            Access97        //6
        }

        public enum TipoStatus : byte
        {
            Inativo,    //0
            Ativo,      //1
            Todos       //2
        }

        ///https://www.dotnetperls.com/first-words
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Texto"></param>
        /// <param name="NumeroPalavras"></param>
        /// <returns></returns>
        public static string PrimeirasPalavras(string Texto, int NumeroPalavras)
        {
            try
            {
                // Number of words we still want to display.
                int Palavras = NumeroPalavras;
                // Loop through entire summary.
                for (int i = 0; i < Texto.Length; i++)
                {
                    // Increment words on a space.
                    if (Texto[i] == ' ')
                    {
                        Palavras--;
                    }
                    // If we have no more words to display, return the substring.
                    if (Palavras == 0)
                    {
                        return Texto.Substring(0, i);
                    }
                }
            }
            catch (Exception)
            {
                // Log the error.
            }
            return string.Empty;
        }

        public static bool IsNumeric(Object Expression)
        {
            if (Expression == null || Expression is DateTime)
            {
                return false;
            }

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
            {
                return true;
            }

            try
            {
                if (Expression is string)
                {
                    Double.Parse(Expression as string);
                }
                else
                {
                    Double.Parse(Expression.ToString());
                }
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }



        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }


        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }



        public static bool IsPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }


        /// <summary>
        /// Validar o formato de entrada para e-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public static bool ValidarEmailRegEx(string email)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");
            System.Text.RegularExpressions.Match m = r.Match(email);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        /// <summary>
        /// http://fabiocabral.gabx.com.br/2013/03/criptografando-strings-em-uma-aplicacao.html
        /// </summary>
        const string senha = "196812";

        public static string Criptografar(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));

            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;

            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            try
            {
                System.Security.Cryptography.ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();

                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        public static string Descriptografar(string Message)
        {
            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));

            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;

            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            try
            {
                System.Security.Cryptography.ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();

                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }




        ///https://alexandrejmuniz.wordpress.com/2012/07/05/funcao-para-validar-senha-forte-com-expressao-regular-com-c/
        /// <summary>
        /// Função que verifica se a string informada “Tes123@#$” will be accepted.
        /// UMA LETRA MINUSCULA
        /// UMA LETRA MAIUSCULA
        /// UM NUMERO
        /// UM ESPECIAL
        /// NO MINIMO 6 CARACTERES
        /// </summary>
        /// <param name=”password”></param>
        /// <returns></returns>
        public static bool IsPasswordStrong(string password)
        {
            int tamanhoMinimo = 6;
            int tamanhoMinusculo = 1;
            int tamanhoMaiusculo = 1;
            int tamanhoNumeros = 1;
            int tamanhoCaracteresEspeciais = 1;
            // Definição de letras minusculas
            Regex regTamanhoMinusculo = new Regex("[a-z]");
            // Definição de letras maiusculas
            Regex regTamanhoMaiusculo = new Regex("[A-Z]");
            // Definição de números
            Regex regTamanhoNumeros = new Regex("[0-9]");
            // Definição de caracteres especiais
            Regex regCaracteresEspeciais = new Regex("[^a-zA-Z0-9]");
            // Verificando tamanho minimo
            if (password.Length < tamanhoMinimo) return false;
            // Verificando caracteres minusculos
            if (regTamanhoMinusculo.Matches(password).Count < tamanhoMinusculo) return false;
            // Verificando caracteres maiusculos
            if (regTamanhoMaiusculo.Matches(password).Count < tamanhoMaiusculo) return false;
            // Verificando numeros
            if (regTamanhoNumeros.Matches(password).Count < tamanhoNumeros) return false;
            // Verificando os diferentes
            if (regCaracteresEspeciais.Matches(password).Count < tamanhoCaracteresEspeciais) return false;
            return true;
        }




        public static string GerarPin()
        {
            //solução básica - mais rápida 
            //int _min = 1000;
            //int _max = 9999;
            //Random _rdm = new Random();
            //return _rdm.Next(_min, _max).ToString();

            //esta solução é 300x mais lenta que anterior, porém, mais segura
            //https://www.dotnetperls.com/rngcryptoserviceprovider
            System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] data = new byte[4];
            crypto.GetBytes(data);
            return Convert.ToString(Math.Abs(BitConverter.ToInt32(data, 0))).Substring(0,4);
        }

        public static bool IsDataValida(string QualData)
        {
            DateTime d = default(DateTime);
            if (DateTime.TryParse(QualData, out d))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
