package itb.com.br.criadopravoce;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

import itb.com.br.criadopravoce.dummy.ProdutoContent;


public class MainActivity extends AppCompatActivity implements
        ProdutoFragment.OnListFragmentInteractionListener,
        HomeFragment.OnFragmentInteractionListener,
        LoginFragment.OnFragmentInteractionListener {

    private TextView mTextMessage;

    private BottomNavigationView navigation;
    private Menu menuNav;
    private MenuItem nav_item1;
    private int nivel = 9;

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener = new BottomNavigationView.OnNavigationItemSelectedListener() {
        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {

            FragmentTransaction ft;

            switch (item.getItemId()) {
                case R.id.navigation_home:
                    mTextMessage.setText(R.string.title_home);
                    ft = getSupportFragmentManager().beginTransaction();
                    ft.replace(R.id.fragment_container, new HomeFragment()).addToBackStack(null).commit();
                    return true;
                case R.id.navigation_produtos:
                    mTextMessage.setText(R.string.title_produtos);
                    ft = getSupportFragmentManager().beginTransaction();
                    ft.replace(R.id.fragment_container, new ProdutoFragment()).addToBackStack(null).commit();
                    return true;
                case R.id.navigation_login:
                    mTextMessage.setText(R.string.title_login);
                    ft = getSupportFragmentManager().beginTransaction();
                    ft.replace(R.id.fragment_container, new LoginFragment()).addToBackStack(null).commit();
                    return true;
            }
            return false;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mTextMessage = (TextView) findViewById(R.id.message);
        navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);
    }

    @Override
    public void onListFragmentInteraction(ProdutoContent.ProdutoItem item) {

    }

    @Override

    public void onFragmentInteraction(Uri uri) {
    }


    @Override
    protected void onResume() {
        super.onResume();     //TODO - Programar volta da pausa
        Intent it = getIntent();
        nivel = it.getIntExtra("nivel", 9);
        String textoRecebido = it.getStringExtra("texto");

        menuNav = navigation.getMenu();
        nav_item1 = menuNav.findItem(R.id.navigation_produtos);

        if (nivel == 0) {
            nav_item1.setEnabled(true);
            mTextMessage.setText("Bem vindo, " + textoRecebido.toString() + "!!!");
        } else if (nivel == 1) {
            nav_item1.setEnabled(false);
            mTextMessage.setText("Bem vindo, " + textoRecebido.toString() + "!!!");
        }
    }
}


