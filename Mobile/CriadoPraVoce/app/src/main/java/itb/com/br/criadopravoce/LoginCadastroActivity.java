package itb.com.br.criadopravoce;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;

public class LoginCadastroActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_cadastro);

        inicializarComponentes();
        Intent it = getIntent();
        usu = it.getStringExtra("usu1");
        usuario.setText(usu);
        btnCadastrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //TODO - CONECTAR NO BANCO E 
                usu = usuario.getText().toString();
                String sen = senha.getText().toString();
                String ema = email.getText().toString();
                Conexao.inserirUsuario(v, usu, sen, ema);
                finish();
            }
        });

    }

    private void inicializarComponentes() {
        layoutLoginCadastro = findViewById(R.id.layoutLoginCadastro);
        registroLayout = findViewById(R.id.edtUsuarioCadastro);
        usuario = findViewById(R.id.edtUsuarioCadastro);
        senha = findViewById(R.id.edtSenhaCadastro);
        email = findViewById(R.id.edtEmailCadastro);
        btnCadastrar = findViewById(R.id.btnCadastrar);
    }

    private EditText usuario, senha, email;
    private Button btnCadastrar;
    private EditText registroLayout;
    private String usu;
    private LinearLayout layoutLoginCadastro;
    private int nivel = 9;


}
