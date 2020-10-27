package itb.com.br.criadopravoce;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import android.widget.Switch;

import itb.com.br.criadopravoce.dummy.ProdutoContent;

import java.util.ArrayList;
import java.util.List;

/**
 * {@link RecyclerView.Adapter} that can display a {@link ProdutoItem} and makes a call to the
 * specified {@link OnListFragmentInteractionListener}.
 * TODO: Replace the implementation with code for your data type.
 */
public class MyProdutoRecyclerViewAdapter extends RecyclerView.Adapter<MyProdutoRecyclerViewAdapter.ViewHolder> {

    private final ArrayList<ProdutoContent.ProdutoItem> mValues;
    private final ProdutoFragment.OnListFragmentInteractionListener mListener;

    public MyProdutoRecyclerViewAdapter(ArrayList<ProdutoContent.ProdutoItem> items, ProdutoFragment.OnListFragmentInteractionListener listener) {
        mValues = items;
        mListener = listener;
        //Adicionei este método para informar alterações no objeto de pesquisa
        notifyDataSetChanged();
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.fragment_produto, parent, false);
        return new ViewHolder(view);
    }

    /*
    Aqui nesta método cada valor capturado é adicionado na tela,
            no seu objeto correspondente
    */
    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {

        holder.mItem = mValues.get(position);
        // O código será apresentado no objeto da tela
        holder.mCodigoView.setText(String.valueOf(mValues.get(position).codigo));
        // A descrição será apresentada no objeto correspondente da tela
        holder.mDescricaoView.setText(mValues.get(position).nomeProduto);
        // a quantidade será apresentada no objeto correspondente da tela
        holder.mQtdeView.setText(String.valueOf(mValues.get(position).categoriaid));
        // O valor unitário será apresentado no objeto correspondente da tela
        holder.mValorView.setText(String.valueOf(mValues.get(position).precoProduto));

        // O status capturado é apresentado, de acordo com o valor
        // Se o valor for 1 o produto mostra que está disponível
        // Senão o produto será apresentado como indisponível
        if(mValues.get(position).statusProduto == 1){
            holder.mStatusView.setChecked(true);
            holder.mStatusView.setTextOn("Disponível");
        }else{
            holder.mStatusView.setChecked(false);
            holder.mStatusView.setTextOff("Indisponível");
        }

        // Este método aguarda um clique no item selecionado da listagem
        // Aqui faremos o link para o detalhamento do produto selecionado
        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (null != mListener) {
                    // Notify the active callbacks interface (the activity, if the
                    // fragment is attached to one) that an item has been selected.
                    mListener.onListFragmentInteraction(holder.mItem);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    // Método para estabelecer o vínculo entre os objetos da tela XML
    // e os objetos criados no Java
    public class ViewHolder extends RecyclerView.ViewHolder {
        // Objetos Java
        public final View mView;
        public final TextView mCodigoView;
        public final TextView mDescricaoView;
        public final TextView mQtdeView;
        public final TextView mValorView;
        public final Switch mStatusView;
        public ProdutoContent.ProdutoItem mItem;

        // Vínculo dos objetos Java acima e os objetos da tela.
        //  Exemplo - R.id.codigo_produto é o mCodigoView
        public ViewHolder(View view) {
            super(view);
            mView = view;
            mCodigoView = (TextView) view.findViewById(R.id.codigo_produto);
            mDescricaoView = (TextView) view.findViewById(R.id.descricao_produto);
            mQtdeView = (TextView) view.findViewById(R.id.quantidade_produto);
            mValorView = (TextView) view.findViewById(R.id.valor_produto);
            mStatusView = (Switch) view.findViewById(R.id.status_produto);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mDescricaoView.getText() + "'";
        }
    }
}
