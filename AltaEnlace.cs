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
    public partial class AltaEnlace : Form
    {
        public AltaEnlace()
        {
            InitializeComponent();
            DAOSociedad daos = new DAOSociedad();
            cboempresa.DataSource = daos.MostrarSociedades();
            cboempresa.DisplayMember = "IndCod_Sociedad";
            cboempresa.ValueMember = "cod_sociedad";
            cboacceso.SelectedIndex = 0;
            cboprioridad.SelectedIndex = 0;
            cbozona.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {

                if (!ExisteelEnlace(txtcd.Text))
                {
                    Kpi nuevo = new Kpi();
                    nuevo.Cod_sociedad = (int)Int32.Parse(cboempresa.SelectedValue.ToString());
                    nuevo.Ind_KPIDivision = txtnombre.Text;
                    nuevo.Ind_KPIDivisionAbrev = txtabrev.Text;
                    nuevo.Ind_KPIDivisionEstado = "Alta";
                    nuevo.Ind_KPIDivisionCodUni = txtcd.Text;
                    nuevo.Ind_KPITipoData = cboprioridad.SelectedItem.ToString();
                    nuevo.Ind_SLA = CalculodeSLAAcordado(cbozona.SelectedIndex, cboacceso.SelectedIndex);
                    nuevo.IndCod_KPIGen = 1;
                    nuevo.Ind_KPIDivisionTipo = "Porcentaje";

                    DAOKpi dao = new DAOKpi();
                    dao.insertKPI(nuevo);
                    MessageBox.Show("Agregado el Nuevo Enlace");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe un enlace con el CD ingresado.");
                }

            }
            else
            {
                MessageBox.Show("Inserta todo los Datos");
            }
        }

        public Boolean ExisteelEnlace(string codigoCD)
        {
            DAOKpi daok = new DAOKpi();

            return !(daok.ObtenerKPICodxUnicode(codigoCD) == -1);
        }

        public Boolean CamposCompletos()
        {
            if (txtcd.Text.Equals("") || txtabrev.Text.Equals("") || txtnombre.Text.Equals("") || cboempresa.Text.Equals("") || cboacceso.Text.Equals("") || cboprioridad.Text.Equals("") || cbozona.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public decimal CalculodeSLAAcordado(int zona, int acceso)
        {
            decimal val = 0.0M;
            switch (acceso)
            {
                case 0:
                    val = 0.995M;
                    break;
                case 1:

                    switch (zona)
                    {
                        case 0:
                            val = 0.993M;
                            break;
                        case 1:
                            val = 0.985M;
                            break;
                        case 2:
                            val = 0.980M;
                            break;
                    }    

                    break;
                case 2:

                    switch (zona)
                    {
                        case 0:
                            val = 0.993M;
                            break;
                        case 1:
                            val = 0.990M;
                            break;
                        case 2:
                            val = 0.985M;
                            break;
                    }  

                    break;
                case 3:
                    val = 0.996M;
                    break;
                default:
                    val = 0;
                    break;
            }
            return val;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
