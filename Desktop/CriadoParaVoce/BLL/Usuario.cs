using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL //Camada Lógica de Negócio
{
    public class Usuario
    {
        //Essa classe representa a 'tabela' do meu banco de dados. Também representa o levantamento de requisitos para o meu sistema funcionar.
        //1º Declarar os membros da classe
        private int _CodigoUsuario;
        public int CodigoUsuario
        {
            get
            {
                return _CodigoUsuario;
            }

            set
            {
                _CodigoUsuario = value;
            }
        }

        private string _NomeUsuario;
        public string NomeUsuario
        {
            get
            {
                return _NomeUsuario;
            }

            set
            {
                _NomeUsuario = value.ToUpper().Trim().Replace("  ",string.Empty);
                //Trim() Remover espaços em branco no inicio e fim do NomeUsuario. ToUpper() transformar para caixa alta(texto em maiúsculo)
            }
        }

        private string _SenhaSistema;
        public string SenhaSistema
        {
            get
            {
                return BLL.FuncoesGerais.Descriptografar(_SenhaSistema);
            }

            set
            {
                _SenhaSistema = BLL.FuncoesGerais.Criptografar(value);
            }
        }

        /*private DateTime _DataAcessoUsuario;
        public DateTime DataAcessoUsuario
        {
            get
            {
                return _DataAcessoUsuario;
            }

            set
            {
                _DataAcessoUsuario = value;
            }
        }*/

        private byte _StatusUsuario;
        public byte StatusUsuario
        {
            get
            {
                return _StatusUsuario;
            }

            set
            {
                _StatusUsuario = value;
            }
        }

        /*private string _EmailUsuario;
        public string EmailUsuario
        {
            get
            {
                return _EmailUsuario;
            }

            set
            {
                _EmailUsuario = value.Trim().ToUpper();
            }

        }*/

        private string _NomeSistema;
        public string NomeSistema
        {
            get { 
                  return _NomeSistema;
                }

            set {
                  _NomeSistema = value.Trim();
                }
        }

        private int _CodigoNivelAcesso;
        public int CodigoNivelAcesso
        {
            get { 
                   return _CodigoNivelAcesso;
                }

            set {
                   _CodigoNivelAcesso = value;
                }
        }

        /*private string _CpfUsuario;
        public string CpfUsuario
        {
            get {
                    return _CpfUsuario;
                }

            set {
                     _CpfUsuario = value;
                }
        }

        private DateTime _NascimentoUsuario;
        public DateTime NascimentoUsuario
        {
            get { 
                    return _NascimentoUsuario;
                }

            set { 
                     _NascimentoUsuario = value;
                }
        }*/

        private string _PerguntaUsuario;
        public string PerguntaUsuario
        {
            get {
                    return _PerguntaUsuario;
                }

            set {
                     _PerguntaUsuario = value.ToUpper().Trim();
                }
        }

        private string _RespostaUsuario;
        public string RespostaUsuario
        {
            get {
                    return BLL.FuncoesGerais.Descriptografar(_RespostaUsuario);
                }
            set {
                     _RespostaUsuario = BLL.FuncoesGerais.Criptografar(value.Trim().ToUpper());
                }
        }

        /*public string Logradouro
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
            get {
                    return _Sexo;
                }

            set {
                     _Sexo = value;
                }
        }*/

        public string PinUsuario
        {
            get
            {
                return _PinUsuario;
            }
            set
            {
                _PinUsuario = value;
            }
        }

        public int CodigoFunc
        {
            get
            {
                return _CodigoFunc;
            }
            set
            {
                _CodigoFunc = value;
            }
        }

        private string _PinUsuario;
        private int _CodigoFunc;
        /*private string _Logradouro;
        private string _Cep;
        private string _UF;
        private string _Cidade;
        private string _Bairro;
        private string _Numero;
        private string _Complemento;
        private string _Sexo;*/

        //2º criar as propriedades/atributos da classe
        //Lembra do atalho Ctrl + R + E
        TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
        // Criar o objeto 'c' e instanciar
        private static string instrucaoSql;
        //variável que irá conter o comando de texto da instrução em SQL para ser usada no banco de dados

        public int CodigoLogado()
        {
            try
            {
                SqlDataReader dr;
                dr = c.RetornarDataReader("Select codigousuario, codigonivelacesso, nomesistema, senhasistema, nomeusuario, pinusuario FROM tbUsuario WHERE nomesistema='" + _NomeSistema + "' AND senhasistema = '" + _SenhaSistema + "'");
                dr.Read();
                if (dr.HasRows)
                {
                    _NomeUsuario = Convert.ToString(dr["nomeusuario"]);
                    _CodigoNivelAcesso = Convert.ToInt32(dr["codigonivelacesso"]);
                    _PinUsuario = Convert.ToString(dr["pinusuario"]);
                    return Convert.ToInt32(dr["CodigoUsuario"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Incluir()
        {
            try
            {
                instrucaoSql = "INSERT INTO TbUsuario (NomeUsuario, SenhaSistema, StatusUsuario, NomeSistema, CodigoNivelAcesso,PerguntaUsuario, RespostaUsuario) Values('" + _NomeUsuario +"', '"+_SenhaSistema+"', "+_StatusUsuario+", '"+ _NomeSistema +"', "+ _CodigoNivelAcesso +", '"+ _PerguntaUsuario +"', '" + _RespostaUsuario + "')";
                c.ExecutarComando(instrucaoSql);
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
                    new SqlParameter("@NomeUsuario",SqlDbType.VarChar) {Value = _NomeUsuario },
                    new SqlParameter("@SenhaSistema",SqlDbType.VarChar) {Value = _SenhaSistema },
                    new SqlParameter("@StatusUsuario",SqlDbType.Bit) {Value = _StatusUsuario },
                    new SqlParameter("@NomeSistema",SqlDbType.VarChar) {Value = _NomeSistema },
                    new SqlParameter("@CodigoNivelAcesso",SqlDbType.Int) {Value = _CodigoNivelAcesso },
                    new SqlParameter("@PerguntaUsuario",SqlDbType.VarChar) {Value = _PerguntaUsuario },
                    new SqlParameter("@RespostaUsuario",SqlDbType.VarChar) {Value = _RespostaUsuario },
                    new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc }
                };
                //Criar o Objeto 'listarComParametro' a partir da classe 'SqlParameter' definida como uma lista'[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros. Cada parametro foi definido com a identificação '@.....' + um tipo de dado' SqlDbType' + um valor '{Value = _....}'
                instrucaoSql = "INSERT INTO tbusuario (NomeUsuario, SenhaSistema, StatusUsuario,  NomeSistema, CodigoNivelAcesso, PerguntaUsuario, RespostaUsuario, CodigoFunc) Values (@NomeUsuario, @SenhaSistema, @StatusUsuario, @NomeSistema, @CodigoNivelAcesso, @PerguntaUsuario, @RespostaUsuario, @CodigoFunc)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametro);


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
                SqlParameter[] listaComParametros = { new SqlParameter("@CodigoUsuario",SqlDbType.Int) {Value = _CodigoUsuario },
                    new SqlParameter("@NomeUsuario",SqlDbType.VarChar) {Value = _NomeUsuario },
                    new SqlParameter("@SenhaSistema",SqlDbType.VarChar) {Value = _SenhaSistema },
                    new SqlParameter("@StatusUsuario",SqlDbType.Bit) {Value = _StatusUsuario },
                    new SqlParameter("@NomeSistema",SqlDbType.VarChar) {Value = _NomeSistema },
                    new SqlParameter("@CodigoNivelAcesso",SqlDbType.Int) {Value = _CodigoNivelAcesso },
                    new SqlParameter("@PerguntaUsuario",SqlDbType.VarChar) {Value = _PerguntaUsuario },
                    new SqlParameter("@RespostaUsuario",SqlDbType.VarChar) {Value = _RespostaUsuario },
                    new SqlParameter("@CodigoFunc",SqlDbType.Int) {Value = _CodigoFunc}
                };
                instrucaoSql = "UPDATE tbusuario SET NomeUsuario =@NomeUsuario, SenhaSistema=@SenhaSistema, StatusUsuario=@StatusUsuario, NomeSistema=@NomeSistema, CodigoNivelAcesso=@CodigoNivelAcesso, PerguntaUsuario=@PerguntaUsuario, RespostaUsuario=@RespostaUsuario, CodigoFunc=@CodigoFunc WHERE CodigoUsuario=@CodigoUsuario";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void TrocarSenhaComParametro()
        {
            try
            {
                SqlParameter[] listaComParametro =
                {
                    new SqlParameter("@CodigoUsuario",SqlDbType.Int) {Value = _CodigoUsuario },
                    new SqlParameter("@SenhaSistema",SqlDbType.VarChar) {Value = _SenhaSistema }
                };
                instrucaoSql = "UPDATE tbusuario SET SenhaSistema=@SenhaSistema WHERE CodigoUsuario=@CodigoUsuario";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int IncluirRetornarNumeroAutomatico()
        {
            try
            {
                instrucaoSql = "INSERT INTO TbUsuario(NomeUsuario, SenhaSistema, StatusUsuario) Values ('"+_NomeUsuario+
                    "', '"+_SenhaSistema+"', "+_StatusUsuario+")";
                return c.RecuperarUltimoCodigoNumeracaoAutomatica(instrucaoSql);
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
                instrucaoSql = "UPDATE TbUsuario Set NomeUsuario= '"+_NomeUsuario+"', SenhaSistema = '"+_SenhaSistema+"', StatusUsuario = "+_StatusUsuario+" WHERE CodigoUsuario = _CodigoUsuario";
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void TrocarSenhaSistema()
        {
            try
            {
                instrucaoSql = "UPDATE TbUsuario SET SenhaSistema= '"+_SenhaSistema+"' WHERE CodigoUsuario = "+_CodigoUsuario+"";
                c.ExecutarComando(instrucaoSql);
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
                instrucaoSql = "UPDATE TbUsuario SET StatusUsuario = 1 WHERE CodigoUsuario = "+_CodigoUsuario+"";
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
                instrucaoSql = "UPDATE TbUsuario SET StatusUsuario = 0 WHERE CodigoUsuario = "+_CodigoUsuario+"";
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader RetornarNivelAcesso()
        {
            try
            {
                instrucaoSql = "SELECT tbNivelAcesso.NomeNivel FROM tbNivelAcesso INNER JOIN tbUsuario ON  tbNivelAcesso.CodigoNivel = tbUsuario.CodigoNivelAcesso WHERE tbUsuario.CodigoUsuario =" + _CodigoUsuario +"";
                return c.RetornarDataReader(instrucaoSql);
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
                instrucaoSql = "DELETE FROM TbUsuario WHERE CodigoUsuario = "+_CodigoUsuario+"";
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
                instrucaoSql = "SELECT * FROM TbUsuario WHERE CodigoUsuario= "+_CodigoUsuario+"";
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Listar(string parteNomeUsuario, byte TipoStatusUsuario)
        {
            try
            {
                instrucaoSql = "SELECT CodigoUsuario, NomeUsuario, NomeSistema, StatusUsuario, CodigoFunc FROM TbUsuario";
                if (parteNomeUsuario.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeUsuario LIKE '%" + parteNomeUsuario + "%'";
                }
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListaVendedorAtivo()
        {
            try
            {
                instrucaoSql = "SELECT CodigoUsuario, NomeUsuario, CodigoNivelAcesso, StatusUsuario FROM TbUsuario WHERE CodigoNivelAcesso=2 AND StatusUsuario = 1";
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
                instrucaoSql = "SELECT CodigoUsuario, NomeUsuario, StatusUsuario FROM TbUsuario WHERE StatusUsuario=1";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ExistenciaAdministrador()
        {
            try
            {
                SqlDataReader dr;
                _NomeSistema = "ADMIN";
                dr = c.RetornarDataReader("Select codigousuario, nomesistema, senhasistema FROM tbUsuario WHERE nomesistema='" + _NomeSistema + "'");
                dr.Read();
                return dr.HasRows;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void CriarUsuarioAdministrador()
        {
            try
            {
                SenhaSistema = "123456";//padrão inicial
                _CodigoNivelAcesso = 1;
                _StatusUsuario = (byte)BLL.FuncoesGerais.TipoStatus.Ativo;
                _NomeUsuario = "";
                _PinUsuario = BLL.FuncoesGerais.GerarPin();
                _PerguntaUsuario = "QUAL O NOME DO COMPUTADOR ONDE FOI DESENVOLVIDA ESTA APLICAÇÃO?";
                RespostaUsuario = "IBM-5100";
                SqlParameter[] listaComParametros = {
                  new SqlParameter("@NomeSistema",SqlDbType.VarChar) {Value = _NomeSistema },
                  new SqlParameter("@NomeUsuario",SqlDbType.VarChar) {Value = _NomeUsuario },
                  new SqlParameter("@SenhaSistema",SqlDbType.VarChar) {Value = _SenhaSistema },
                  new SqlParameter("@CodigoNivelAcesso",SqlDbType.Bit) {Value = _CodigoNivelAcesso },
                  new SqlParameter("@StatusUsuario",SqlDbType.Bit) {Value = _StatusUsuario },
                  new SqlParameter("@PerguntaUsuario",SqlDbType.VarChar) {Value = _PerguntaUsuario },
                  new SqlParameter("@RespostaUsuario",SqlDbType.VarChar) {Value = _RespostaUsuario },
                  new SqlParameter("@PinUsuario",SqlDbType.VarChar) {Value = _PinUsuario }
                };
                instrucaoSql = @"INSERT INTO tbusuario (nomesistema, nomeusuario,senhasistema, codigonivelacesso, statususuario, perguntausuario, respostausuario, pinusuario) VALUES (@NomeSistema, @NomeUsuario, @SenhaSistema, @CodigoNivelAcesso, @StatusUsuario, @PerguntaUsuario, @RespostaUsuario, @pinusuario)";

                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);

                Nivel nivelAcesso = new Nivel();
                nivelAcesso.CriarNivel();
                Funcionario fuc = new Funcionario();
                fuc.CriarFuncionarioAdministrador();

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
                instrucaoSql = "SELECT CodigoUsuario, NomeUsuario, StatusUsuario FROM TbUsuario WHERE StatusUsuario=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Logar()
        {
            try
            {
                //instrucaoSql = "SELECT NomeUsuario,SenhaSistema,CodigoUsuario FROM tbusuario WHERE NomeUsuario ='" + _NomeUsuario + "'AND SenhaSistema='" + _SenhaSistema + "' AND StatusUsuario =1";
                instrucaoSql = "SELECT NomeSistema,SenhaSistema,CodigoUsuario FROM tbusuario WHERE NomeSistema ='" + _NomeSistema + "'AND SenhaSistema='" + _SenhaSistema + "' AND StatusUsuario = 1";
                SqlDataReader dr;
                dr = c.RetornarDataReader(instrucaoSql);
                dr.Read();
                if (dr.HasRows)
                {
                    _CodigoUsuario = Convert.ToInt32(dr["CodigoUsuario"]);
                    //_DataAcessoUsuario = DateTime.Today;
                    //AlterarComParametro();
                    return Convert.ToInt32(dr["CodigoUsuario"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
