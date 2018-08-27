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
using System.Deployment.Application;

namespace CargadeSLA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAOKpi daokpi = new DAOKpi();
            DAORegistro daoregistro = new DAORegistro();

            DataTable dtkpi = daokpi.ListarSLAIBM();

            List<Kpi> listakpi = new List<Kpi>();

            foreach (DataRow rw in dtkpi.Rows)
            {
                Kpi kpi = new Kpi();
                kpi.IndCod_KPIDivision = (int)Int32.Parse(rw[0].ToString());
                kpi.Ind_KPIDivision = rw[1].ToString();
                kpi.Ind_KPIDivisionAbrev = rw[2].ToString();
                kpi.Ind_KPIDivisionEstado = rw[3].ToString();
                kpi.Ind_KPIDivisionCodUni = rw[4].ToString();
                kpi.Ind_KPITipoData = rw[5].ToString();
                kpi.Ind_SLA = (decimal)Decimal.Parse(rw[6].ToString());
                kpi.IndCod_KPIGen = (int)Int32.Parse(rw[7].ToString());
                kpi.Cod_sociedad = (int)Int32.Parse(rw[8].ToString());
                kpi.Ind_KPIDivisionTipo = rw[9].ToString();
                kpi.Uni_falla = (decimal)Decimal.Parse(rw[10].ToString());
                kpi.Tas_multa = (decimal)Decimal.Parse(rw[11].ToString());
                listakpi.Add(kpi);
            }

            foreach (Kpi k in listakpi)
            {
                DataTable dtregistro = daoregistro.MostrarRegistroxKPI(k.IndCod_KPIDivision.Value);
                List<Registro> listaregistro = new List<Registro>();
                foreach (DataRow rw in dtregistro.Rows)
                {
                    Registro reg = new Registro();
                    reg.Fecha_registro = DateTime.ParseExact(rw[0].ToString(), "yyyy-MM-dd HH:mm:ss", null);
                    reg.Periodo_registro = rw[1].ToString();
                    reg.IndCod_KPIDivision = (int)Int32.Parse(rw[2].ToString());

                    if (!rw[3].ToString().Equals(""))
                    {
                        reg.Valor_registro = (decimal)Decimal.Parse(rw[3].ToString());
                    }

                    if (!rw[4].ToString().Equals(""))
                    {
                        reg.Valor_penalidad = (decimal)Decimal.Parse(rw[4].ToString());
                    }


                    if (reg.Valor_registro != null)
                    {
                        int consecutivos = calcularConsecutivos(listaregistro, k.Ind_SLA.Value, k.Ind_KPIDivisionTipo);
                        decimal tasareduccion = 0.5M;

                        if (consecutivos < 9)
                        {
                            tasareduccion = (consecutivos * 1.0M / 9) * 0.5M;
                        }

                        listaregistro.Add(reg);

                        decimal falla = calcularFalla(reg, k);
                        decimal crediFalla = falla * k.Tas_multa.Value;
                        decimal penalidad = crediFalla * (1M - tasareduccion);

                        reg.Valor_penalidad = penalidad;

                        daoregistro.updateRegistro(reg);
                    }
                   
                }

            }
            MessageBox.Show("FIN");
        }

        public decimal calcularFalla(Registro reg, Kpi k)
        {
            decimal falla = 0M;

            if(k.Ind_KPIDivisionTipo.Equals("Porcentaje")){
                   
                if (reg.Valor_registro < k.Ind_SLA.Value)
                {
                    decimal valor_minimo = k.Ind_SLA.Value - k.Uni_falla.Value;

                    if (reg.Valor_registro < valor_minimo)
                    {
                        falla = 1M;
                    }
                    else
                    {
                        falla = (k.Ind_SLA.Value - reg.Valor_registro.Value) / k.Uni_falla.Value;
                    }
                }
            }
            else
            {
                if (reg.Valor_registro > k.Ind_SLA.Value)
                {
                    decimal valor_minimo = k.Ind_SLA.Value + k.Uni_falla.Value;

                    if (reg.Valor_registro > valor_minimo)
                    {
                        falla = 1M;
                    }
                    else
                    {
                        falla = (reg.Valor_registro.Value - k.Ind_SLA.Value) / k.Uni_falla.Value;
                    }
                }
            }

         

            return falla;
        }

        public int calcularConsecutivos(List<Registro> registros, decimal sla,string tipo)
        {
            int meses = 0;

            for (int i = registros.Count-1; i >= 0; i--)
            {
                if (tipo.Equals("Porcentaje"))
                {
                    if (registros[i].Valor_registro < sla)
                    {
                        break;
                    }
                }
                else
                {
                    if (registros[i].Valor_registro > sla)
                    {
                        break;
                    }
                }

                meses++;
            }

            return meses;
        }

        private void btnibm_Click(object sender, EventArgs e)
        {
            ibmsla c = new ibmsla();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            telefonicasla c = new telefonicasla();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GMD c = new GMD();
            c.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text = "SLA's de Proveedores version: " + ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            
        }

    }
}
