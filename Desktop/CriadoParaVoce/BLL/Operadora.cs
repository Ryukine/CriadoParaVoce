using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Operadora
    {
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        public string instrucaoSql;

        private int _CodigoOperadora;
        private string _NomeOperadora;
        private string _Cnpj;
        private byte _StatusOperadora;
        private string _NomeFantasia;
        private string _Site;
        private string _EmailOperadora;
        private string _Whatsapp;
        private string _TelefoneFixo;
        private string _NomeDoContato;
        private string _ObsOperadora;

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

        private string _Logradouro;
        private string _Cep;
        private string _UF;
        private string _Cidade;
        private string _Bairro;
        private string _Numero;
        private string _Complemento;

        public int CodigoOperadora
        {
            get
            {
                return _CodigoOperadora;
            }

            set
            {
                _CodigoOperadora = value;
            }
        }

        public string NomeOperadora
        {
            get
            {
                return _NomeOperadora;
            }

            set
            {
                _NomeOperadora = value.ToUpper().Trim();
            }
        }

        public byte StatusOperadora
        {
            get
            {
                return _StatusOperadora;
            }

            set
            {
                _StatusOperadora = value;
            }
        }

        public string NomeFantasia
        {
            get
            {
                return _NomeFantasia;
            }

            set
            {
                _NomeFantasia = value.ToUpper().Trim();
            }
        }

        public string Site
        {
            get
            {
                return _Site;
            }

            set
            {
                _Site = value;
            }
        }

        public string EmailOperadora
        {
            get
            {
                return _EmailOperadora;
            }

            set
            {
                _EmailOperadora = value;
            }
        }

        public string Whatsapp
        {
            get
            {
                return Whatsapp;
            }

            set
            {
                Whatsapp = value;
            }
        }

        public string TelefoneFixo
        {
            get
            {
                return _TelefoneFixo;
            }

            set
            {
                _TelefoneFixo = value;
            }
        }

        public string NomeDoContato
        {
            get
            {
                return _NomeDoContato;
            }

            set
            {
                _NomeDoContato = value;
            }
        }

        public string ObsOperadora
        {
            get
            {
                return _ObsOperadora;
            }

            set
            {
                _ObsOperadora = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return _Cnpj;
            }
            set
            {
                _Cnpj = value;
            }
        }

        /*public string Site { get => _Site; set => _Site = value.ToUpper().Trim(); }
        public string EmailOperadora { get => _EmailOperadora; set => _EmailOperadora = value.ToUpper().Trim(); }
        public string Whatsapp { get => Whatsapp; set => Whatsapp = value.ToUpper().Trim(); }
        public string TelefoneFixo { get => _TelefoneFixo; set => _TelefoneFixo = value.ToUpper().Trim(); }*/

        //metodos
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeOperadora",SqlDbType.VarChar) {Value = _NomeOperadora },
                   new SqlParameter("@Cnpj",SqlDbType.VarChar) {Value = Cnpj },
                   new SqlParameter("@NomeDoContato",SqlDbType.VarChar) {Value = _NomeDoContato },
                   new SqlParameter("@ObsOperadora",SqlDbType.VarChar) {Value = _ObsOperadora },
                   new SqlParameter("@StatusOperadora",SqlDbType.Bit) {Value = _StatusOperadora },
                   new SqlParameter("@NomeFantasia",SqlDbType.VarChar) {Value = _NomeFantasia },
                   new SqlParameter("@Site",SqlDbType.VarChar) {Value = Site },
                   new SqlParameter("@EmailOperadora",SqlDbType.VarChar) {Value = EmailOperadora },
                   new SqlParameter("@Whatsapp",SqlDbType.VarChar) {Value = _Whatsapp },
                   new SqlParameter("@TelefoneFixo",SqlDbType.VarChar) {Value = TelefoneFixo },
                   new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                   new SqlParameter("@CEP",SqlDbType.VarChar) {Value = _Cep },
                   new SqlParameter("@UF",SqlDbType.Char) {Value = _UF },
                   new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                   new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                   new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                   new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }

                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbOperadora (NomeOperadora, Cnpj, NomeDoContato, ObsOperadora, StatusOperadora, NomeFantasia, Site, EmailOperadora, Whatsapp, TelefoneFixo, Logradouro, CEP, UF, Cidade, Bairro, Numero, Complemento) VALUES (@NomeOperadora, @Cnpj, @NomeDoContato, @ObsOperadora, @StatusOperadora, @NomeFantasia, @Site, @EmailOperadora, @Whatsapp, @TelefoneFixo, @Logradouro, @CEP, @UF, @Cidade, @Bairro, @Numero, @Complemento)";
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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoOperadora",SqlDbType.Int) {Value = _CodigoOperadora },
                   new SqlParameter("@NomeOperadora",SqlDbType.VarChar) {Value = _NomeOperadora },
                   new SqlParameter("@Cnpj",SqlDbType.DateTime) {Value = Cnpj },
                   new SqlParameter("@NomeDoContato",SqlDbType.VarChar) {Value = _NomeDoContato },
                   new SqlParameter("@ObsOperadora",SqlDbType.VarChar) {Value = _ObsOperadora },
                   new SqlParameter("@StatusOperadora",SqlDbType.Bit) {Value = _StatusOperadora },
                   new SqlParameter("@NomeFantasia",SqlDbType.VarChar) {Value = _NomeFantasia },
                   new SqlParameter("@Site",SqlDbType.VarChar) {Value = Site },
                   new SqlParameter("@EmailOperadora",SqlDbType.VarChar) {Value = EmailOperadora },
                   new SqlParameter("@Whatsapp",SqlDbType.VarChar) {Value = _Whatsapp },
                   new SqlParameter("@TelefoneFixo",SqlDbType.VarChar) {Value = TelefoneFixo },
                   new SqlParameter("@Logradouro",SqlDbType.VarChar) {Value = _Logradouro },
                   new SqlParameter("@CEP",SqlDbType.VarChar) {Value = _Cep },
                   new SqlParameter("@UF",SqlDbType.Char) {Value = _UF },
                   new SqlParameter("@Cidade",SqlDbType.VarChar) {Value = _Cidade },
                   new SqlParameter("@Bairro",SqlDbType.VarChar) {Value = _Bairro },
                   new SqlParameter("@Numero",SqlDbType.VarChar) {Value = _Numero },
                   new SqlParameter("@Complemento",SqlDbType.VarChar) {Value = _Complemento }

                };

                instrucaoSql = "UPDATE tbOperadora SET NomeOperadora=@NomeOperadora, Cnpj=@Cnpj, NomeDoContato=@NomeDoContato, ObsOperadora=@ObsOperadora, StatusOperadora=@StatusOperadora, NomeFantasia=@NomeFantasia, Site=@Site, EmailOperadora=@EmailOperadora, Whatsapp=@Whatsapp, TelefoneFixo=@TelefoneFixo Logradouro=@Logradouro, CEP=@CEP, UF=@UF, Cidade=@Cidade, Bairro=@Bairro, Numero=@Numero, Complemento=@Complemento WHERE CodigoOperadora=@CodigoOperadora ";
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
                instrucaoSql = "UPDATE tbOperadora SET StatusOperadora=1   WHERE CodigoOperadora=" + _CodigoOperadora;
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
                instrucaoSql = "UPDATE tbOperadora SET StatusOperadora=0   WHERE CodigoOperadora=" + _CodigoOperadora;
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
                instrucaoSql = "DELETE FROM tbOperadora  WHERE CodigoOperadora=" + _CodigoOperadora;
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
                instrucaoSql = "SELECT * FROM tbOperadora  WHERE CodigoOperadora=" + _CodigoOperadora;
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
                instrucaoSql = "SELECT CodigoOperadora, NomeOperadora, StatusOperadora FROM tbOperadora";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeOperadora LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
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
                instrucaoSql = "SELECT CodigoOperadora, NomeOperadora, StatusOperadora FROM tbOperadora WHERE StatusOperadora=1";
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
                instrucaoSql = "SELECT CodigoOperadora, NomeOperadora, StatusOperadora FROM tbOperadora WHERE StatusOperadora=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
