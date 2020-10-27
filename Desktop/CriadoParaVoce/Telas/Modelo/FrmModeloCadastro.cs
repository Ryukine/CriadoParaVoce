using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas.Modelo
{
    public partial class FrmModeloCadastro : FrmModelo
    {
        public FrmModeloCadastro()
        {
            InitializeComponent();
        }

        private void Sair(Object o, EventArgs e)
        {
            Close();
        }

        private void SimularEnter(Object o, KeyPressEventArgs k)
        {
            if (k.KeyChar == (char)13)
            {
                k.Handled = false;
                SendKeys.Send("{TAB}");
            }
        }

        private int _Codigo;

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        private byte _Funcionalidade;

        public byte Funcionalidade
        {
            get
            {
                return _Funcionalidade;
            }

            set
            {
                _Funcionalidade = value;
            }
        }

        private int _NívelAcesso;

        public int NívelAcesso
        {
            get
            {
                return _NívelAcesso;
            }

            set
            {
                _NívelAcesso = value;
            }
        }

        private byte _TipoStatus;

        public byte TipoStatus
        {
            get
            {
                return _TipoStatus;
            }

            set
            {
                _TipoStatus = value;
            }
        }


        private byte _TipoUso;
        private int _NivelAcesso;

        public byte TipoUso
        {
            get
            {
                return _TipoUso;
            }

            set
            {
                _TipoUso = value;
            }
        }

        public int NivelAcesso
        {
            get
            {
                return _NivelAcesso;
            }

            set
            {
                _NivelAcesso = value;
            }
        }

       
    }
}
