package itb.com.br.criadopravoce;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.support.v7.widget.SearchView;

import java.util.ArrayList;

import itb.com.br.criadopravoce.dummy.ProdutoContent;


/**
 * A fragment representing a list of Items.
 * <p/>
 * Activities containing this fragment MUST implement the {@link OnListFragmentInteractionListener}
 * interface.
 */
public class ProdutoFragment extends Fragment {

    // TODO: Customize parameter argument names
    private static final String ARG_COLUMN_COUNT = "column-count";
    // TODO: Customize parameters
    private int mColumnCount = 1;
    private OnListFragmentInteractionListener mListener;
    private ArrayList<ProdutoContent.ProdutoItem> lista = new ArrayList<ProdutoContent.ProdutoItem>();
    private int pesquisou = 0;
    SearchView texto;
    private View view;

    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public ProdutoFragment() {
    }

    // TODO: Customize parameter initialization
    @SuppressWarnings("unused")
    public static ProdutoFragment newInstance(int columnCount) {
        ProdutoFragment fragment = new ProdutoFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_COLUMN_COUNT, columnCount);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments() != null) {
            mColumnCount = getArguments().getInt(ARG_COLUMN_COUNT);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        view = inflater.inflate(R.layout.fragment_produto_list, container, false);

        // Realizar a pesquisa personalizada no banco de dados
        // Através da SearchView svPesquisar
        // Busca o texto digitado no objeto svPesquisar (SearchView)
        texto = view.findViewById(R.id.svPesquisar);

        // O texto comentado abaixo é referente à ação na perda do foco do SearchView
        /*texto.setOnQueryTextFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {

            }
        });*/

        // perform set on query text listener event
        texto.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                // do something on text submit
                lista = Conexao.pesquisarProdutosFiltro(query);
                pesquisou = 1;

                Context context = view.getContext();
                //Alterei o código neste ponto para carregar o RecyclerView
                RecyclerView recyclerView = (RecyclerView) view.findViewById(R.id.list);
                if (mColumnCount <= 1) {
                    recyclerView.setLayoutManager(new LinearLayoutManager(context));
                } else {
                    recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
                }
                // Se realizou pesquisa por filtro, envia a lista acima criada
                if(pesquisou == 0)
                    recyclerView.setAdapter(new MyProdutoRecyclerViewAdapter(ProdutoContent.ITEMS, mListener));
                else
                    recyclerView.setAdapter(new MyProdutoRecyclerViewAdapter(lista, mListener));
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                // do something when text changes
                return false;
            }
        });

        // Código original comentado, para carregamento do RecyclerView sem filtro
        /*// Set the adapter
        if (view instanceof RecyclerView) {
            Context context = view.getContext();
            RecyclerView recyclerView = (RecyclerView) view;
            if (mColumnCount <= 1) {
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            } else {
                recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
            }
            // Se realizou pesquisa por filtro, envia a lista acima criada
            if(pesquisou == 0)
                recyclerView.setAdapter(new MyProdutoRecyclerViewAdapter(ProdutoContent.ITEMS, mListener));
            else
                recyclerView.setAdapter(new MyProdutoRecyclerViewAdapter(lista, mListener));
        }*/
        return view;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnListFragmentInteractionListener) {
            mListener = (OnListFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnListFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnListFragmentInteractionListener {
        // TODO: Update argument type and name
        void onListFragmentInteraction(ProdutoContent.ProdutoItem item);
    }
}
