using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BLL
{
    public class Fornecedor
    {

        private static string SQL;
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();

        private int _FornecedorId;

        public int FornecedorId
        {
            get { return _FornecedorId; }
            set { _FornecedorId = value; }
        }

        private string _Descricao;

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        private int _StatusFornecedor;

        public int StatusFornecedor
        {
            get { return _StatusFornecedor; }
            set { _StatusFornecedor = value; }
        }


        private string _Logradouro;

        public string Logradouro
        {
            get { return _Logradouro; }
            set { _Logradouro = value; }
        }

        private string _Numero;

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        private string _Bairro;

        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private string _Cep;

        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }

        private string _Contato;

        public string Contato
        {
            get { return _Contato; }
            set { _Contato = value; }
        }

        private string _Cnpj;

        public string Cnpj
        {
            get { return _Cnpj; }
            set { _Cnpj = value; }
        }

        private string _Inscricao;

        public string Inscricao
        {
            get { return _Inscricao; }
            set
            {
                _Inscricao = value;
                if (value == null)
                {
                    _Inscricao = "ISENTA";
                }
            }
        }

        private string _Cidade;

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _TelefoneCelular;

        public string TelefoneCelular
        {
            get { return _TelefoneCelular; }
            set { _TelefoneCelular = value; }
        }

        private string _Site;

        public string Site
        {
            get { return _Site; }
            set { _Site = value; }
        }
        private string _Complemento;

        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        private string _Uf;

        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }


        public void Incluir()
        {
            try
            {
                SQL = "INSERT INTO TBFORNECEDOR ( Descricao, Logradouro, Numero, Complemento, Bairro, Cidade, Cep, Contato, Cnpj, Inscricao, Email, TelefoneCelular, Site, StatusFornecedor, Uf ) VALUES ( '" + _Descricao + "', '" + _Logradouro + "', '" + _Numero + "', '" + _Complemento + "', '" + _Bairro + "', '" + _Cidade + "', '" + _Cep + "', '" + _Contato + "', '" + _Cnpj + "', '" + _Inscricao + "', '" + _Email + "', '" + _TelefoneCelular + "', '" + _Site + "', " + _StatusFornecedor + ", '"+ _Uf + "')";
                c.ExecutarComando(SQL);
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
                SQL = "INSERT INTO TBFORNECEDOR ( Descricao, Logradouro, Numero, Complemento, Bairro, Cidade, Cep, Contato, Cnpj, Inscricao, Email, Whatsapp, TelefoneFixo, TelefoneCelular, Site, StatusFornecedor, Uf ) VALUES ( '" + _Descricao + "', '" + _Logradouro + "', '" + _Numero + "', '" + _Complemento + "', '" + _Bairro + "', '" + _Cidade + "', '" + _Cep + "', '" + _Contato + "', '" + _Cnpj + "', '" + _Inscricao + "', '" + _Email + "', '" + _Whatsapp + "', '" + _TelefoneFixo + "', '" + _TelefoneCelular + "', '" + _Site + "', " + _StatusFornecedor + ", '" + _Uf + "')";
                return c.executarComandoRetorno(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@Descricao",SqlDbType.VarChar) {Value = _Descricao },
                    new SqlParameter("@StatusFornecedor",SqlDbType.Int) {Value = _StatusFornecedor },
                    new SqlParameter("@Inscricao",SqlDbType.VarChar) {Value = _Inscricao },
                    new SqlParameter("@Email",SqlDbType.VarChar) {Value = _Email },
                    new SqlParameter("@TelefoneCelular",SqlDbType.VarChar) {Value = _TelefoneCelular },
                    new SqlParameter("@Site",SqlDbType.VarChar) {Value = _Site },
                    new SqlParameter("@Contato",SqlDbType.VarChar) {Value = _Contato },
                    new SqlParameter("@Cnpj",SqlDbType.VarChar) {Value = _Cnpj },
                    new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                    new SqlParameter("@Cep",SqlDbType.VarChar) {Value = _Cep },
                    new SqlParameter("@UF",SqlDbType.Char) {Value = _Uf },
                    new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                    new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                    new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                    new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                SQL = "INSERT INTO TBFORNECEDOR (Descricao, StatusFornecedor, Inscricao, Email, TelefoneCelular, Site, Contato, Cnpj, Logradouro, Cep, UF, Cidade, Bairro, Numero, Complemento) Values (@Descricao, @StatusFornecedor, @Inscricao, @Email, @TelefoneCelular, @Site, @Contato, @Cnpj, @Logradouro, @Cep, @UF, @Cidade, @Bairro, @Numero, @Complemento)";
                c.ExecutarComandoParametro(SQL, listaComParametro);


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
                SqlParameter[] listaComParametros = { new SqlParameter("@FornecedorId",SqlDbType.Int) {Value = _FornecedorId },
                    new SqlParameter("@Descricao",SqlDbType.VarChar) {Value = _Descricao },
                    new SqlParameter("@StatusFornecedor",SqlDbType.Int) {Value = _StatusFornecedor },
                    new SqlParameter("@Inscricao",SqlDbType.VarChar) {Value = _Inscricao },
                    new SqlParameter("@Email",SqlDbType.VarChar) {Value = _Email },
                    new SqlParameter("@TelefoneCelular",SqlDbType.VarChar) {Value = _TelefoneCelular },
                    new SqlParameter("@Site",SqlDbType.VarChar) {Value = _Site },
                    new SqlParameter("@Contato",SqlDbType.VarChar) {Value = _Contato },
                    new SqlParameter("@Cnpj",SqlDbType.VarChar) {Value = _Cnpj },
                    new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                    new SqlParameter("@Cep",SqlDbType.VarChar) {Value = _Cep },
                    new SqlParameter("@UF",SqlDbType.Char) {Value = _Uf },
                    new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                    new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                    new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                    new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }
                };
                SQL = "UPDATE TBFORNECEDOR SET Descricao =@Descricao, StatusFornecedor=@StatusFornecedor, Inscricao=@Inscricao, Email=@Email, TelefoneCelular=@TelefoneCelular, Site=@Site, Contato=@Contato, Cnpj=@Cnpj, Logradouro=@Logradouro, Cep=@Cep, UF=@UF, Cidade=@Cidade, Bairro=@Bairro, Numero=@Numero, Complemento=@Complemento WHERE FornecedorId=@FornecedorId";
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
                
                SQL = "UPDATE TBFORNECEDOR SET Descricao = '"+_Descricao+"', Logradouro = '"+_Logradouro+"', Numero = '"+_Numero+"', Complemento = '"+_Complemento+"', Bairro = '"+_Bairro+"', Cidade = '"+_Cidade+"', Cep = '"+_Cep+"', Contato = '"+_Contato+"', Cnpj = '"+_Cnpj+"', Inscricao = '"+_Inscricao+"', Email = '"+_Email+"', TelefoneCelular = '"+_TelefoneCelular+"', Site = '"+_Site+"', StatusFornecedor = "+_StatusFornecedor+ ", Uf = '"+ _Uf+"' WHERE FORNECEDORID = " + _FornecedorId + " ";
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
                SQL = "UPDATE TBFORNECEDOR SET StatusFornecedor = '" + Valor + "'  WHERE FORNECEDORID = " + _FornecedorId + " ";
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
                SQL = "DELETE FROM TBFORNECEDOR  WHERE FORNECEDORID = " + _FornecedorId + " ";
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
                SQL = "SELECT * FROM TBFORNECEDOR  WHERE FORNECEDORID = " + _FornecedorId + " ";
                return c.RetornarDataReader(SQL);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Listar(string texto)
        {
            SQL = "SELECT FORNECEDORID, DESCRICAO FROM TBFORNECEDOR ORDER BY DESCRICAO";
            if (texto.Length != 0) // texto == null || texto == ""
            {
                SQL = "SELECT FORNECEDORID, DESCRICAO FROM TBFORNECEDOR WHERE DESCRICAO LIKE '%" + texto + "%' ORDER BY DESCRICAO";
            }
            return c.RetornarDataSet(SQL);
        }










    }
}
