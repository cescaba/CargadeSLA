using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAOLibrary.DTO;
using DAOLibrary.DAO;

namespace CargadeSLA
{
    public partial class BajaEnlace : Form
    {
        public BajaEnlace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAOKpi daok = new DAOKpi();
            DAOSociedad daos = new DAOSociedad();

            int cod_unico = daok.ObtenerKPICodxUnicode(txtcd2.Text);

            if (cod_unico == -1)
            {
                MessageBox.Show("No existe el CD: " + txtcd2.Text);
            }
            else
            {
                DataTable dt = daok.ObtenerKPI(cod_unico);
                txtcodigo.Text = cod_unico.ToString() ;
                txtnombre2.Text = dt.Rows[0]["Ind_KPIDivision"].ToString();
                txtabrev2.Text = dt.Rows[0]["Ind_KPIDivisionAbrev"].ToString();
                txtprioridad2.Text = dt.Rows[0]["Ind_KPITipoData"].ToString();
                txtempresa2.Text = daos.encontrarSociedad((int)Int32.Parse(dt.Rows[0]["cod_sociedad"].ToString())).Rows[0]["IndCod_Sociedad"].ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAOKpi daok = new DAOKpi();
            Kpi kpi = new Kpi();
            kpi.IndCod_KPIDivision = (int)Int32.Parse(txtcodigo.Text);
            kpi.Ind_KPIDivisionEstado = "Baja";
            daok.updateKPI(kpi);
            MessageBox.Show("Se ha dado de baja el enlace!");
            this.Close();
        }
    }
}
