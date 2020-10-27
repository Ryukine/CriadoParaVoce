package itb.com.br.criadopravoce.dummy;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import itb.com.br.criadopravoce.Conexao;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 * <p>
 * TODO: Replace all uses of this class before publishing your app.
 */

public class ProdutoContent {

    /**
     * An array of sample (dummy) items.
     */


    public static final ArrayList<ProdutoItem> ITEMS = new ArrayList<ProdutoItem>();

    /**
     * A map of sample (dummy) items, by ID.
     */


    public static final Map<Integer, ProdutoItem> ITEM_MAP = new HashMap<Integer, ProdutoItem>();


    static {
        ArrayList<ProdutoItem> lista = Conexao.pesquisarProdutos();
        for(ProdutoItem produtoItem: lista){
            addItem(createProdutoItem(produtoItem));
        }
    }

    private static void addItem(ProdutoItem item) {
        ITEMS.add(item);
        ITEM_MAP.put(item.codigo, item);
    }

    private static ProdutoItem createProdutoItem(ProdutoItem produto) {
        return new ProdutoItem(produto.codigo, produto.nomeProduto, produto.categoriaid, produto.statusProduto,  produto.precoProduto,produto.fornecedorid);
    }
        private static String makeDetails(int position) {
        StringBuilder builder = new StringBuilder();
        builder.append("Detalhes sobre o produto: ").append(position);
        for (int i = 0; i < position; i++) {
            builder.append("\nMais informações sobre o produto.");
        }
        return builder.toString();
    }
    /**
     * A dummy item representing a piece of content.
     */
    public static class ProdutoItem {
        /*public final String codigo;
        public final String descricao;
        public final int qtde;
        public final double valor_unit;
        public final int status;*/

        public final int codigo;
        public final String nomeProduto;
        public final int categoriaid;
        public final double precoProduto;
        public final int statusProduto;
        public final int fornecedorid;

        public ProdutoItem(int codigo, String nomeProduto, int categoriaid, int statusProduto, double precoProduto, int fornecedorid) {
            this.codigo = codigo;
            this.nomeProduto = nomeProduto;
            this.categoriaid = categoriaid;
            this.precoProduto = precoProduto;
            this.statusProduto = statusProduto;
            this.fornecedorid = fornecedorid;
        }

        @Override
        public String toString() {
            return nomeProduto;
        }
    }
}
