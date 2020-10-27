using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class Cliente
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoCliente;
        private string _NomeCliente;
        private DateTime _DataNascimento;
        private byte _StatusCliente;
        private string _PastaFotoCliente;
        private string _RG;
        private string _NomePai;
        private string _NomeMae;
        private string _Naturalidade;
        private string _CpfCliente;
        private string _EmailCliente;
        
        public string Logradouro
        {
            get
            {
                return _Logradouro;
            }

            set
            {
                _Logradouro = value.Trim();
            }
        }
        public string Cep
        {
            get
            {
                return _Cep;
            }
            set
            {
                _Cep = value.Trim();
            }
        }
        public string UF
        {
            get
            {
                return _UF;
            }
            set
            {
                _UF = value.Trim();
            }
        }
        public string Cidade
        {
            get
            {
                return _Cidade;
            }

            set
            {
                _Cidade = value.Trim();
            }
        }
        public string Bairro
        {
            get
            {
                return _Bairro;
            }

            set
            {
                _Bairro = value.Trim();
            }
        }
        public string Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                _Numero = value.Trim();
            }
        }
        public string Complemento
        {
            get
            {
                return _Complemento;
            }
            set
            {
                _Complemento = value.Trim();
            }
        }
        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }

        private string _Logradouro;
        private string _Cep;
        private string _UF;
        private string _Cidade;
        private string _Bairro;
        private string _Numero;
        private string _Complemento;
        private string _Sexo;
        private string _Telefone;

        public int CodigoCliente
        {
            get
            {
                return _CodigoCliente;
            }

            set
            {
                _CodigoCliente = value;
            }
        }

        public string NomeCliente
        {
            get
            {
                return _NomeCliente;
            }

            set
            {
                _NomeCliente = value.ToUpper().Trim() ;
            }
        }

        public DateTime DataNascimento
        {
            get
            {
                return _DataNascimento;
            }

            set
            {
                _DataNascimento = value;
            }
        }

        public byte StatusCliente
        {
            get
            {
                return _StatusCliente;
            }

            set
            {
                _StatusCliente = value;
            }
        }

        public string PastaFotoCliente
        {
            get
            {
                return _PastaFotoCliente;
            }

            set
            {
                _PastaFotoCliente = value.ToUpper().Trim();
            }
        }

        public string RG
        {
            get
            {
                return _RG;
            }

            set
            {
                _RG = value;
            }
        }

        public string NomePai
        {
            get
            {
                return _NomePai;
            }

            set
            {
                _NomePai = value;
            }
        }

        public string NomeMae
        {
            get
            {
                return _NomeMae;
            }

            set
            {
                _NomeMae = value;
            }
        }

        public string Naturalidade
        {
            get
            {
                return _Naturalidade;
            }

            set
            {
                _Naturalidade = value;
            }
        }

        public string CpfCliente
        {
            get
            {
                return _CpfCliente;
            }

            set
            {
                _CpfCliente = value;
            }
        }

        public string EmailCliente
        {
            get
            {
                return _EmailCliente;
            }

            set
            {
                _EmailCliente = value;
            }
        }

        public string Telefone
        {
            get
            {
                return _Telefone;
            }

            set
            {
                _Telefone = value;
            }
        }

        /*public string RG { get => _RG; set => _RG = value.ToUpper().Trim(); }
        public string NomePai { get => _NomePai; set => _NomePai = value.ToUpper().Trim(); }
        public string NomeMae { get => _NomeMae; set => _NomeMae = value.ToUpper().Trim(); }
        public string Naturalidade { get => _Naturalidade; set => _Naturalidade = value.ToUpper().Trim(); }*/

        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeCliente",SqlDbType.VarChar) {Value = _NomeCliente },
                   new SqlParameter("@DataNascimento",SqlDbType.DateTime) {Value = _DataNascimento },
                   new SqlParameter("@CpfCliente",SqlDbType.VarChar) {Value = _CpfCliente },
                   new SqlParameter("@EmailCliente",SqlDbType.VarChar) {Value = _EmailCliente },
                   new SqlParameter("@StatusCliente",SqlDbType.Bit) {Value = _StatusCliente },
                   new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                   new SqlParameter("@Telefone",SqlDbType.VarChar) {Value = _Telefone },
                   new SqlParameter("@CEP",SqlDbType.VarChar) {Value = _Cep },
                   new SqlParameter("@UF",SqlDbType.Char) {Value = _UF },
                   new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                   new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                   new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                   new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }

                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbCliente (nomecliente, datanascimento, CpfCliente, EmailCliente, statuscliente, Logradouro, Telefone, CEP, UF, Cidade, Bairro, Numero, Complemento) VALUES (@NomeCliente, @DataNascimento, @CpfCliente, @EmailCliente, @StatusCliente, @Logradouro, @Telefone, @CEP, @UF, @Cidade, @Bairro, @Numero, @Complemento)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoCliente",SqlDbType.Int) {Value = _CodigoCliente },
                   new SqlParameter("@NomeCliente",SqlDbType.VarChar) {Value = _NomeCliente },
                   new SqlParameter("@DataNascimento",SqlDbType.DateTime) {Value = _DataNascimento },
                   new SqlParameter("@CpfCliente",SqlDbType.VarChar) {Value = _CpfCliente },
                   new SqlParameter("@EmailCliente",SqlDbType.VarChar) {Value = _EmailCliente },
                   new SqlParameter("@StatusCliente",SqlDbType.Bit) {Value = _StatusCliente },
                   new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                   new SqlParameter("@Telefone",SqlDbType.VarChar) {Value = _Telefone },
                   new SqlParameter("@CEP",SqlDbType.VarChar) {Value = _Cep },
                   new SqlParameter("@UF",SqlDbType.Char) {Value = _UF },
                   new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                   new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                   new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                   new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }

                };

                instrucaoSql = "UPDATE tbCliente SET nomecliente=@NomeCliente, datanascimento=@DataNascimento, CpfCliente=@CpfCliente, EmailCliente=@EmailCliente, statuscliente=@StatusCliente, Logradouro=@Logradouro, Telefone=@Telefone, CEP=@CEP, UF=@UF, Cidade=@Cidade, Bairro=@Bairro, Numero=@Numero, Complemento=@Complemento WHERE codigocliente=@CodigoCliente ";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

               
        public void Ativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbCliente SET statuscliente=1   WHERE CodigoCliente=" + _CodigoCliente;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Desativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbCliente SET statuscliente=0   WHERE CodigoCliente=" + _CodigoCliente;
                c.ExecutarComando(instrucaoSql);
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
                instrucaoSql = "DELETE FROM tbCliente  WHERE CodigoCliente=" + _CodigoCliente;
                c.ExecutarComando(instrucaoSql);
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
                instrucaoSql = "SELECT * FROM tbCliente  WHERE codigocliente=" + _CodigoCliente;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNome, byte tipostatus)
        {
            try
            {
                instrucaoSql = "SELECT codigocliente, nomecliente, CpfCliente, statuscliente FROM tbCliente";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE nomecliente LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }
                return c.RetornarDataSet(instrucaoSql);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarAtivos()
        {
            try
            {
                instrucaoSql = "SELECT codigocliente, nomecliente, statuscliente FROM tbCliente WHERE statuscliente=1";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarInativos()
        {
            try
            {
                instrucaoSql = "SELECT codigocliente, nomecliente, statuscliente FROM tbCliente WHERE statuscliente=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }






    }
}
