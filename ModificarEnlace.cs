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
    public partial class ModificarEnlace : Form
    {
        public ModificarEnlace()
        {
            InitializeComponent();
            DAOSociedad daos = new DAOSociedad();
            cboempresaM.DataSource = daos.MostrarSociedades();
            cboempresaM.DisplayMember = "IndCod_Sociedad";
            cboempresaM.ValueMember = "cod_sociedad";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAOKpi daok = new DAOKpi();
            DAOSociedad daos = new DAOSociedad();

            LimpiarControladores();

            int cod_unico = daok.ObtenerKPICodxUnicode(txtcd2.Text);

            if (cod_unico == -1)
            {

                if (txtnombus.Text.Equals(""))
                {
                    MessageBox.Show("La busqueda no tiene resultados");
                    return;
                }

                DataTable db = daok.getBuscadorEnlaces(txtnombus.Text);

                if (db == null)
                {
                    MessageBox.Show("La busqueda no tiene resultados");
                    return;
                }

                int l = 1;

                foreach (DataRow rw in db.Rows)
                {
                    txtresultado.Text = txtresultado.Text + "" + l + ". " + rw["Ind_KPIDivisionCodUni"].ToString() + " - " + rw["Ind_KPIDivisionAbrev"].ToString()+Environment.NewLine;
                    l++;
                }

            }
            else
            {
                DataTable dt = daok.ObtenerKPI(cod_unico);
                txtcodsis.Text =  cod_unico.ToString();
                txtcodigoM.Text = dt.Rows[0]["Ind_KPIDivisionCodUni"].ToString();
                txtnombreM.Text = dt.Rows[0]["Ind_KPIDivision"].ToString();
                txtabrevM.Text = dt.Rows[0]["Ind_KPIDivisionAbrev"].ToString();
                cboprioridadM.SelectedItem = dt.Rows[0]["Ind_KPITipoData"].ToString();
                cboempresaM.SelectedValue = (int)Int32.Parse(dt.Rows[0]["cod_sociedad"].ToString());
                cboestadoM.SelectedIndex = valueEstado(dt.Rows[0]["Ind_KPIDivisionEstado"].ToString());
                txtsla.Text = (Double)double.Parse(dt.Rows[0]["Ind_SLA"].ToString()) * 100 + "%";


                DataTable dr = daok.getRegistrosxKPI(cod_unico);

                if (dr != null)
                {
                    foreach (DataRow rw in dr.Rows)
                    {
                        textBox1.Text = textBox1.Text + " " + rw["periodo_registro"].ToString() + " - " + (Double)double.Parse(rw["valor_registro"].ToString()) * 100 +"%" + Environment.NewLine;
                    }
                }

                txtcd2.Text = "";
          
            }
        }

        public int valueEstado(String texto)
        {
            if (texto.Trim().Equals("Baja"))
            {
                return 1;
            }

            return 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtresultado.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarEnlace_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarControladores()
        {
            
            txtcodsis.Text = "";
            txtcodigoM.Text= "";
            txtnombreM.Text= "";
            txtabrevM.Text= "";
            txtsla.Text = "";
            textBox1.Text = "";
            cboprioridadM.SelectedValue = -1;
            cboempresaM.SelectedValue = -1;
            cboestadoM.SelectedValue = -1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kpi kmodif = new Kpi();
            kmodif.IndCod_KPIDivision = (int)Int32.Parse(txtcodsis.Text);
            kmodif.Ind_KPIDivisionCodUni = txtcodigoM.Text;
            kmodif.Ind_KPIDivision = txtnombreM.Text;
            kmodif.Ind_KPIDivisionAbrev = txtabrevM.Text;

            if (cboprioridadM.SelectedIndex == 0)
            {
                kmodif.Ind_KPITipoData = "Otros";
            }
            else
            {
                kmodif.Ind_KPITipoData = "Principal";
            }

            kmodif.Cod_sociedad = (int)Int32.Parse(cboempresaM.SelectedValue.ToString());

            if (cboestadoM.SelectedIndex == 0)
            {
                kmodif.Ind_KPIDivisionEstado = "Alta";
            }
            else
            {
                kmodif.Ind_KPIDivisionEstado = "Baja";
            }

            DAOKpi dao = new DAOKpi();
            dao.updateKPI(kmodif);

            MessageBox.Show("Guardado!");
        }


    }
}
