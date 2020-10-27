using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BLL
{ 
    public class Categoria
    {
        private static string SQL;
        //private static OleDbDataReader dr;
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _CategoriaId;

        public int CategoriaId
        {
            get { return _CategoriaId; }
            set { _CategoriaId = value; }
        }

        private string _DescricaoCategoria;

        public string DescricaoCategoria
        {
            get { return _DescricaoCategoria; }
            set { _DescricaoCategoria = value.ToUpper(); }
        }

        private int _StatusCategoria;

        public int StatusCategoria
        {
            get { return _StatusCategoria; }
            set { _StatusCategoria = value; }
        }


        public void Incluir()
        {
            try
            {
                SQL = "INSERT INTO TBCATEGORIA (DescricaoCategoria, StatusCategoria) VALUES ('" + _DescricaoCategoria + "', '" + _StatusCategoria + "')";
                c.ExecutarComando(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@DescricaoCategoria",SqlDbType.VarChar) {Value = _DescricaoCategoria },
                    new SqlParameter("@StatusCategoria",SqlDbType.VarChar) {Value = _StatusCategoria }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                SQL = "INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) Values (@DescricaoCategoria, @StatusCategoria)";
                c.ExecutarComandoParametro(SQL, listaComParametro);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*public int IncluirRetornoCodigo()
        {
            try
            {
                SQL = "INSERT INTO TBCATEGORIA (DescricaoCategoria, StatusCategoria) VALUES ('" + _DescricaoCategoria + "', '" + _StatusCategoria + "')";
                return c.executarComandoRetorno(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public DataSet ListarAtivos()
        {
            try
            {
                SQL = "SELECT CategoriaID, DescricaoCategoria, StatusCategoria FROM tbCategoria WHERE StatusCategoria= 1 ORDER BY DescricaoCategoria";
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AlterarComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = { new SqlParameter("@CategoriaID",SqlDbType.Int) {Value = _CategoriaId },
                    new SqlParameter("@DescricaoCategoria",SqlDbType.VarChar) {Value = _DescricaoCategoria },
                    new SqlParameter("@StatusCategoria",SqlDbType.VarChar) {Value = _StatusCategoria }
                };
                SQL = "UPDATE tbCategoria SET DescricaoCategoria =@DescricaoCategoria, StatusCategoria=@StatusCategoria WHERE CategoriaID=@CategoriaID";
                c.ExecutarComandoParametro(SQL, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Alterar()
        {
            try
            {
                SQL = "UPDATE TBCATEGORIA SET DescricaoCategoria = '" + _DescricaoCategoria + "', StatusCategoria = '" + _StatusCategoria + "' WHERE CATEGORIAID = " + _CategoriaId + " ";
                c.ExecutarComando(SQL);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Ativar(Byte Valor)
        { //Valor 1 = Reativar    Valor 0 = Desativar
            try
            {
                SQL = "UPDATE TBCATEGORIA SET StatusCategoria = '" + Valor + "' WHERE CATEGORIAID = " + _CategoriaId + " ";
                c.ExecutarComando(SQL);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Excluir()
        {
            try
            {
                SQL = "DELETE FROM TBCATEGORIA WHERE CATEGORIAID = " + _CategoriaId + " ";
                c.ExecutarComando(SQL);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader Consultar()
        {
            try
            {
                SQL = "SELECT * FROM TBCATEGORIA WHERE CATEGORIAID = " + _CategoriaId + " ";
                return c.RetornarDataReader(SQL);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Listar(string texto)
        {
            SQL = "SELECT CATEGORIAID, DescricaoCategoria FROM TBCATEGORIA ORDER BY DescricaoCategoria";
            if (texto.Length != 0) // texto == null || texto == ""
            {
                SQL = "SELECT CATEGORIAID, DescricaoCategoria FROM TBCATEGORIA WHERE DescricaoCategoria LIKE '%" + texto + "%' ORDER BY DescricaoCategoria";
            }
            return c.RetornarDataSet(SQL);
        }




    }
}
