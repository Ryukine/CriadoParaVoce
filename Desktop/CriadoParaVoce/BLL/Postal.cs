using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public class Postal
    {
        private int _CepId;

        public int CepId
        {
            get { return _CepId; }
            set { _CepId = value; }
        }
        private int _Cep;

        public int Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }
       private string _Cidade;

       public string Cidade
       {
           get { return _Cidade; }
           set { _Cidade = value; }
       }
       private string _Logradouro;

       public string Logradouro
       {
           get { return _Logradouro; }
           set { _Logradouro = value; }
       }
       private string _Bairro;

       public string Bairro
       {
           get { return _Bairro; }
           set { _Bairro = value; }
       }
       private string _UF;

       public string UF
       {
           get { return _UF; }
           set { _UF = value; }
       }

       public System.Data.SqlClient.SqlDataReader Consultar()
       {
           TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
           String SQL;
           try
           {
               SQL = "SELECT * FROM tblLogradouros$ WHERE CEP = " + _Cep + "";
               return c.RetornarDataReader(SQL);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       public System.Data.SqlClient.SqlDataReader ConsultarCep()
       {
            TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
            String SQL;
            try
            {
                SQL = "SELECT * FROM tblLogradouros$ WHERE Descricao = '" + _Logradouro + "' AND cidade = '"+ _Cidade +"'";
                return c.RetornarDataReader(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }




       }

        public DataSet ListarCep(string parteNome)
        {
            try
            {
                TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
                String SQL;
                SQL = "SELECT CEP, UF, Descricao, cidade, Bairro FROM tblLogradouros$";
                if (parteNome.Length != 0)
                {
                    SQL = SQL + " WHERE Descricao LIKE '%" + parteNome + "%'";
                }
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public DataSet Listar(string parteNome)
        {
            try
            {
                TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
                String SQL;
                SQL = "SELECT CEP, Descricao, Cidade, UF FROM tblLogradouros$";
                if (parteNome.Length != 0)
                {
                    SQL = SQL + " WHERE UF LIKE '%" + parteNome + "%'";
                }
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarUF()
        {
            try
            {
                TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
                String SQL;
                SQL = "SELECT Distinct UF FROM tblLogradouros$";
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarCidade(string parteNome)
        {
            try
            {
                TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
                String SQL;
                SQL = "SELECT Distinct Cidade FROM tblLogradouros$";
                if (parteNome.Length != 0)
                {
                    SQL = SQL + " WHERE UF LIKE '%" + parteNome + "%' ORDER BY Cidade";
                }
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
