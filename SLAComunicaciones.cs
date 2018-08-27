using DAOLibrary.DTO;
using DAOLibrary.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargadeSLA
{
    public partial class SLAComunicaciones : Form
    {
        private DateTime mescarga;
        List<int>sociedades;

        public SLAComunicaciones(DateTime dt)
        {
            InitializeComponent();
            mescarga = dt;
            sociedades = new List<int>();
            sociedades.Add(251); //0
            sociedades.Add(101); //1
            sociedades.Add(501); //2
            sociedades.Add(153); //3
            sociedades.Add(901);
            sociedades.Add(156);
            sociedades.Add(301);
            sociedades.Add(1000);
        }

        private void SLAComunicaciones_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("LAN", "", "", "", "", "", "","","");
            dataGridView1.Rows.Add("Telefonia", "", "", "", "", "", "", "", "");
            dataGridView1.Rows.Add("CCTV", "", "", "", "", "", "", "", "");
            dataGridView1.Rows.Add("NOC-DC", "", "", "", "", "", "", "", "");

            dataGridView1.Font = new System.Drawing.Font("Verdana", 12.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         }

        private void btnGuardarSLATel_Click(object sender, EventArgs e)
        {
            int indServicio = 0;
            List<Registro> registros = new List<Registro>();
            DAOKpi daok = new DAOKpi();
          
            foreach(DataGridViewRow row in dataGridView1.Rows){
              
                switch (indServicio)
                {
                    case 0:
                        for (int i = 0; i < sociedades.Count; i++)
                        {
                            int codKPI = daok.ObtenerKPICodEmpresa(sociedades[i], 21);
                            Registro reg = new Registro();
                            reg.Fecha_registro = mescarga;
                            reg.IndCod_KPIDivision = codKPI;
                            reg.Periodo_registro = reg.Fecha_registro.Value.ToString("yyyyMM");
                            reg.Valor_penalidad = 0;
                            reg.Valor_registro = (decimal)Decimal.Parse(row.Cells[i + 1].Value.ToString()) / 100M;
                            registros.Add(reg);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < sociedades.Count; i++)
                        {
                            if (i != 3)
                            {
                                int codKPI = daok.ObtenerKPICodEmpresa(sociedades[i], 25);
                                Registro reg = new Registro();
                                reg.Fecha_registro = mescarga;
                                reg.IndCod_KPIDivision = codKPI;
                                reg.Periodo_registro = reg.Fecha_registro.Value.ToString("yyyyMM");
                                reg.Valor_penalidad = 0;
                                reg.Valor_registro = (decimal)Decimal.Parse(row.Cells[i + 1].Value.ToString()) / 100M;
                                registros.Add(reg);
                            }
                        }
                        break;

                    case 2:
                            Registro r = new Registro();
                            r.Fecha_registro = mescarga;
                            r.IndCod_KPIDivision = 565;
                            r.Periodo_registro = r.Fecha_registro.Value.ToString("yyyyMM");
                            r.Valor_penalidad = 0;
                            r.Valor_registro = (decimal)Decimal.Parse(row.Cells[1].Value.ToString()) / 100M;
                            registros.Add(r);
                        
                        break;
                    case 3:
                        Registro rc = new Registro();
                        rc.Fecha_registro = mescarga;
                        rc.IndCod_KPIDivision = 573;
                        rc.Periodo_registro = rc.Fecha_registro.Value.ToString("yyyyMM");
                        rc.Valor_penalidad = 0;
                        rc.Valor_registro = (decimal)Decimal.Parse(row.Cells[3].Value.ToString()) / 100M;
                        registros.Add(rc);

                        break;
                }

                indServicio++;
            }

            Registro regis = registros[0];

            DAORegistro daor = new DAORegistro();

            foreach (Registro r in registros)
            {
                daor.insertRegistro(r);
            }

            MessageBox.Show("Se cargo los SLAs!");
        }
    }
}
