using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExMySql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio n = new Negocio();
                ObjetoTransferencia t = new ObjetoTransferencia();

                t.nometransportadora = txtNomeTransp.Text;
                t.endereco = txtEndereco.Text;
                t.telefone = txtTelefone.Text;
                t.cidade = txtTelefone.Text;
                t.estadoID = int.Parse(txtEstado.Text);
                t.cep = txtCep.Text;
                t.cnpj = txtCnpj.Text;

                n.InserirTransportadora(t);

                MessageBox.Show("Ola Mundo, cadastrou huhuhuuu");

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Negocio n = new Negocio();
            string nomeTransp = txtPesquisa.Text;

            try
            {
                List<ObjetoTransferencia> lsTransp = new List<ObjetoTransferencia>();
                lsTransp = n.ListarTransportadoras(nomeTransp);

                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = lsTransp;

                dgvPrincipal.Update();
                dgvPrincipal.Refresh();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro.Message);
            }
        }
    }
}
