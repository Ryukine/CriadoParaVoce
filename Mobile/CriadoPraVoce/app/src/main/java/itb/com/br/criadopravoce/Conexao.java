package itb.com.br.criadopravoce;

import java.sql.Connection;

import android.os.StrictMode;
import android.support.design.widget.Snackbar;
import android.util.Log;
import android.view.View;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import itb.com.br.criadopravoce.dummy.ProdutoContent;

public class Conexao {
    public static Connection conexaoBD() {
        Connection conexao = null;
        try {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
            Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
            //NÃO ESQUECER DE DESCOBRIR O IP DA MÁQUINA ONDE ESTA O SQL SERVER
            String IP = "172.19.1.113";
            conexao = DriverManager.getConnection("jdbc:jtds:sqlserver://" + IP + ";" + "databaseName=CriadoParaVoce;user=sa;password=123456;");
        } catch (Exception e) {
            e.getMessage().toString();
        }
        return conexao;
    }

    //Método de pesquisa de produtos na base SQL Server
    public static ArrayList<ProdutoContent.ProdutoItem> pesquisarProdutos() {
        ArrayList<ProdutoContent.ProdutoItem> lista = new ArrayList<ProdutoContent.ProdutoItem>();
        try {
            //Pesquisa no banco de dados
            PreparedStatement pst = Conexao.conexaoBD().prepareStatement("select * from tbProduto");
            //Resultado da pesquisa realizada
            ResultSet res = pst.executeQuery();
            //Se existir linhas no objeto res, a lista será carregada com produtos
            while (res.next()) {
                ProdutoContent.ProdutoItem produto = new ProdutoContent.ProdutoItem(
                        res.getInt(1),
                        res.getString(2),
                        res.getInt(3),
                        res.getInt(4),
                        res.getDouble(5),
                        res.getInt(6));
                lista.add(produto);
            }
        } catch (SQLException e) {
            e.getMessage().toString();
        }
        return lista;
    }


    public static ArrayList<ProdutoContent.ProdutoItem> pesquisarProdutosFiltro(String texto) {
        ArrayList<ProdutoContent.ProdutoItem> lista = new ArrayList<ProdutoContent.ProdutoItem>();
        try {
            //Pesquisa no banco de dados
            PreparedStatement pst = Conexao.conexaoBD().prepareStatement("select * from tbProduto "
                    + "where NomeProduto like '%" + texto.toString() + "%'");
            ResultSet res = pst.executeQuery();
            while (res.next()) {
                ProdutoContent.ProdutoItem produto = new ProdutoContent.ProdutoItem(
                        res.getInt(1),
                        res.getString(2),
                        res.getInt(3),
                        res.getInt(4),
                        res.getDouble(5),
                        res.getInt(6));
                lista.add(produto);
            }
        } catch (SQLException e) {
            e.getMessage().toString();
        }
        return lista;
    }

    public static int pesquisarUsuario(String usuario, String senha, View view) {
        try {
            PreparedStatement pst = Conexao.conexaoBD().prepareStatement("select * from login WHERE usuario = ? and senha = ?");
            pst.setString(1, usuario);
            pst.setString(2, senha);
            ResultSet res = pst.executeQuery();

            if (res.next()) {
                Snackbar.make(view.findViewById(R.id.layoutLogin), "LOGIN ENCONTRADO!!!", Snackbar.LENGTH_LONG).show();
                return res.getInt(5);
            } else {
                Snackbar.make(view.findViewById(R.id.layoutLogin), "LOGIN NÃO ENCONTRADO!!!", Snackbar.LENGTH_LONG).show();
            }
        } catch (SQLException e) {
            Snackbar.make(view.findViewById(R.id.layoutLogin), e.getMessage().toString(), Snackbar.LENGTH_LONG).show();
        }
        return 9;
    }

    public static void inserirUsuario(View view, String usuario, String
            senha, String email){
        try{
            PreparedStatement pst =
                    Conexao.conexaoBD().prepareStatement("insert into login values ?,?,?,?)");
            pst.setString(1, usuario);
            pst.setString(2, senha);
            pst.setString(3, email);
            int nivel = 1;
            pst.setInt(4, nivel);
            pst.executeUpdate();
            Snackbar.make(view.findViewById(R.id.layoutLoginCadastro),
                    "LOGIN INSERIDO!!!", Snackbar.LENGTH_LONG).show();
        }catch(SQLException e){
            Snackbar.make(view.findViewById(R.id.layoutLoginCadastro),
                    e.getMessage().toString(), Snackbar.LENGTH_LONG).show();
        }
}
}








