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
    public partial class FrmModeloConsulta : FrmModeloCadastro
    {
        public FrmModeloConsulta()
        {
            InitializeComponent();
            btnGravar.Visible = false;
        }
    }
}
