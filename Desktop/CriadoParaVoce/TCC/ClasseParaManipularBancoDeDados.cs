using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TCC
{
    public class ClasseParaManipularBancoDeDados
    {
        //Declarar os Objetos para uso
        private static SqlConnection cn;
        //Criar um objeto 'cn' que representa a classe de conexão ao banco de dados sql server; Esse objeto irá precisar uma string de conexão ao banco de dados - caminho/pasta/endereço do banco de dados;
        private static SqlCommand cmd;
        //Criar objeto 'cmd' que irá executar as instruções (Insert, Update, Delete) no banco de Dados; Essas instruções podem ser strings (Texto) ou procedimentos armazenados no banco de dados (stored procedures -> se fizermos esse uso será necessário criar parâmetros). Store procedure é uma "programação" dentro do banco de dados.
        private static SqlDataAdapter da;
        //Criar objeto 'da' que representa a ligação (ponto) mundo conectado (Banco de dados) com o desconectado(RAM).
        private static SqlDataReader dr;
        //Criar objeto 'dr' que representa um leitor de dados. Usado para 1. ler rapidamente uma tabela no banco de dados para transferir o conteudo para um COMBOBOX ou LISTBOX   2. Ler UMA linha de dados de uma tabela. Ideal para fazer uma consulta (cenário: Consultar [saber] o endereço do aluno LUCIO rm 27056 e exibir em um TEXTBOXs)
        private static DataSet ds;
        //Criar objeto 'ds' que representa as tabelas de um banco de dados na memória RAM. Pode conter todas as tabelas, uma ou nenhuma tabela. Para existir um DATASET é necessário um DATAADAPTER e para existir um DATAADAPTER é necessário um COMMAND e para existir um COMMAND é necessário existir uma CONNECTION.
        private static DataTable dt;
        //Criar objeto 'dr' que representa uma tabela de dados. Para existir um DATATABLE -> DataAdapter + Command + Connection.
        private static string instrucaoSQL;
        //A variavel INSTUCAOSQL representa o texto do comando em linguagem Sql para Inserir, Alterar, Excluir, etc. Os dados em uma tabela.
        private static string stringConexao = @"server=P3L3M04\SQLEXPRESS;database=CriadoParaVoce;user id=sa;password=123456;";
        //a variável STRINGCONEXAO é um texto onde informo o nome do servidor de banco de dados, o nome do banco de dados, o usuario que gerencia o banco de dados e a senha deste usuario; no site connectionstrings.com você pode saber mais sobre as diferentes variações de string. De modo bem simples a string de conexao com o banco representa o caminho até o banco de dados.

        public static SqlConnection ConectarBanco()
        {
            try
            {
                cn = new SqlConnection(stringConexao);
                //Faço a instância do objeto usando a variável string de conexão como um parâmetro da classe SQLConnection
                //Pergunta do Aluno - Profº como eu sei que é instância ?
                //quando na linha de código você tem = new
                //Instanciar algo é 'fazer uma cópia'
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                //teste para saber o estado da conexão. Se o estado é fechado a conexão é aberta.
                return cn;
                //Retornar a conexão ... que nesse momento está aberta.
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string Conexao()
        {
            string info = "";
            try
            {

                string SqlConection = stringConexao;
                cn = new SqlConnection(SqlConection);

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    //cn.BeginTransaction();
                    info = "Conectando com a Versão SQL " + cn.ServerVersion + " Utilizando a fonte " + cn.DataSource;
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return info + " Estado da Conexao " + cn.State.ToString() + " OK";
        }

        public void FecharBanco(SqlConnection minhaConexao)
        {
            try
            {
                if (minhaConexao.State == ConnectionState.Open)
                {
                    minhaConexao.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void FecharBanco2()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExecutarComando(string meuComando)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(meuComando, cn);
                //= new  INSTANCIAR COPIA
                cmd.ExecuteReader();
                //Execute o comando. Para executar o comando é necessário o meuComando e uma conexao cn.
                //o objeto 'cmd' tem outros três metodos que serão utilizados (1) ExecuteScalar para totalizar/sumarizar dados em uma tabela o 'meucomando' conterá as funções de agrupamento Min() Max() Count() Sum(). Convém Lembrar que o resultado da execução deste método é uma única COLUNA com UMA ÚNICA LINHA DE DADOS    (2) ExecuteNonQuery é utilizado para executar comandos de INSERT, UPDATE e DELETE na tabela.  (3) ExecuteReader para selecionar (SELECT) os dados da tabela que podem ser 0 linha ou várias linhas de dados.
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader RetornarDataReader(string meuComandoSQL)
        {
            try
            {
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                dr = cmd.ExecuteReader();
                return dr;
                //Esse método terá como retorno uma listagem dos dados da tabela
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable RetornarDataTable(string meuComandoSQL)
        {
            try
            {
                dt = new DataTable();
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt); //o objeto 'da' preenche (FILL) objeto 'dt' com as linhas de dados de uma tabela. O número de linhas podem ser 0 ou várias.
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet RetornarDataSet(string meuComandoSQL)
        {
            try
            {
                ds = new DataSet();
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int RetornarContagem(string meuComandoSQL)
        {
            try
            {
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                //Objeto 'cmd' instanciado ' = new' com o comando em sql que contém a função  COUNT para contar o número de linhas em uma tabela de dados (AULA LIEC)
                return Convert.ToInt32(cmd.ExecuteScalar());
                //Converte.ToInt32 - converte o resultado do método 'executescalar' para um número inteiro de 32 bits
                //Lembre-se esse método é para responder sobre quantidade. Quantos alunos temos na turma INF2DM? Resp.33 Quantos alunos da turma INF2DM tem o nome iniciado pela letra Z? Resp. 0
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public double RetornarTotal(string meuComandoSQL)
        {
            try
            {
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                return Convert.ToDouble(cmd.ExecuteScalar());
                //Esse método usa um comando em Sql que faz a soma dos valores em uma coluna da tabela. Qual a soma total de salários dos professores do ITB? Resp. 115453,22
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double RetornarMenorValor(string meuComandoSQL)
        {
            try
            {
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                //'meuComandoSQL' contém uma instruçãocom a função MIN ... aula de LIEC
                return Convert.ToDouble(cmd.ExecuteScalar());
                //Esse método serve para saber o menor valor em uma coluna. Por exemplo: Qual a menor nota do aluno Breno no 1º trimestre? Resp. 3,6
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public double RetornarMaiorValor(string meuComandoSQL)
        {
            try
            {
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                return Convert.ToDouble(cmd.ExecuteScalar());
                //'meuComandoSQL' tem uma instrução MAX.. aula de LIEC    Esse método funciona para saber o maior valor em uma coluna de dados. Exemplo: Qual é a maior nota do aluno Breno no 2º Trimestre? Resp. 8,2
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int RecuperarUltimoCodigoNumeracaoAutomatica(string meuComandoSQL)
        {
            try
            {
                //Nesse método a entrada 'meuComandoSQL' contém uma instrução para inserir dados na tabela 'INSERT' aula de LIEC. A ideia aqui é recuperar o código da númeração automática quando inserimos uma linha na tabela
                cmd = new SqlCommand(meuComandoSQL, ConectarBanco());
                //Objeto 'cmd' Instanciado '= new' com a variavel 'meuComandoSQL'
                cmd.ExecuteNonQuery();
                //Objeto 'cmd' Executa o comando para Inserir a linha de dados
                cmd.CommandText = "SELECT @@Identity";
                //A propriedade texto do comando recebe a instrução para selecionar a autonumeração (aula LIEC)
                dr = cmd.ExecuteReader();
                //Objeto 'dr' recebe do comando o resultado da leitura da execução do comando 'Select @@Indentity'
                dr.Read();
                //Objeto 'dr' faz a leitura
                return Convert.ToInt32(dr[0]);
                //retorna o código que está na coluna '0' que representa a numeração automatica

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ExecutarComandoParametroRetornarCodigo(string meuComandoSQL, SqlParameter[] listaParametros)
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandText = meuComandoSQL;
                cmd.CommandType = CommandType.Text;
                //testar a 'listaparametro' para ver se não é nula, ou seja, foi informado algo para a lista
                if (listaParametros != null)
                {
                    foreach (SqlParameter item in listaParametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.Connection = ConectarBanco();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@Identity";
                //A propriedade texto do comando recebe a instrução para selecionar a autonumeração (aula LIEC)
                dr = cmd.ExecuteReader();
                //Objeto 'dr' recebe do comando o resultado da leitura da execução do comando 'Select @@Indentity'
                dr.Read();
                //Objeto 'dr' faz a leitura
                return Convert.ToInt32(dr[0]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlParameter criarParametro(string nomeParametro, SqlDbType tipoParametro, object valorParametro)
        {
            try
            {
                //esse método possui 3 assinaturas:'nomeParametro' ... variável + 'tipoParametro'... tipo de dado da variavel + 'valorParametro'... valor da variável.
                SqlParameter p = new SqlParameter();
                //criar objeto 'p'
                p.ParameterName = nomeParametro;
                p.SqlDbType = tipoParametro;
                //testar para valor nulo do parametro
                if ((valorParametro == null) || (tipoParametro == SqlDbType.Char && valorParametro.ToString().Length == 0))
                {
                    p.Value = DBNull.Value;
                    //propriedade 'value' do objeto 'p' receber o valor nulo da classe 'dbnull'
                }
                else
                {
                    p.Value = valorParametro;
                }
                return p;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExecutarComandoStoredProcedure(string nomeProcedure, SqlParameter[]listaParametros)
        {
            try
            {
                //esse método tem 2 assinaturas 'nomeprocedure' que representa o nome do programa feito dentro do banco de dados e a 'listaparametros' que são as variáveis usadas nesse programa feito no banco de dados
                cmd = new SqlCommand();
                cmd.CommandText = nomeProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                //testar a 'listaparametro' para ver se não é nula, ou seja, foi informado algo para a lista
                if (listaParametros != null)
                {
                    foreach (SqlParameter item in listaParametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.Connection = ConectarBanco();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExecutarComandoParametro(string meuComandoSQL, SqlParameter[] listaParametros)
        {
            try
            {
                //esse método tem 2 assinaturas 'nomeprocedure' que representa o nome do programa feito dentro do banco de dados e a 'listaparametros' que são as variáveis usadas nesse programa feito no banco de dados
                cmd = new SqlCommand();
                cmd.CommandText = meuComandoSQL;
                cmd.CommandType = CommandType.Text;
                //testar a 'listaparametro' para ver se não é nula, ou seja, foi informado algo para a lista
                if (listaParametros != null)
                {
                    foreach (SqlParameter item in listaParametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.Connection = ConectarBanco();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }







    }
}
