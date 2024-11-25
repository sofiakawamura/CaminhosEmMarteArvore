using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCidadesEmMarte
{
    public partial class FrmCidades : Form
    {
        public FrmCidades()
        {
            InitializeComponent();
        }

        string nomeArquivoCidades;
        string nomeArquivoCaminhos;

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                nomeArquivoCidades = dlgAbrir.FileName;
            }
        }
    }
}
