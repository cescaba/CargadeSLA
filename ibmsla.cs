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
    public partial class ibmsla : Form
    {
        public ibmsla()
        {
            InitializeComponent();
            llenardataGridView();
        }

        private void llenardataGridView()
        {
            DAOKpi dao = new DAOKpi();

            DataTable dt = dao.ListarSLAIBMLight();

            dt.Columns.Add(new DataColumn("resultado", typeof(string)));

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns[0].HeaderCell.Value = "Código";
            dataGridView1.Columns[1].HeaderCell.Value = "Sistema";
            dataGridView1.Columns[2].HeaderCell.Value = "SLA";
            dataGridView1.Columns[3].HeaderCell.Value = "Valor Esperado";
            dataGridView1.Columns[4].HeaderCell.Value = "Resultado";
        }
        private void PasteInData(DataGridView dgv)
        {
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            char columnSplitter = '\t';         // Tab.

            IDataObject dataInClipboard = Clipboard.GetDataObject();

            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();

            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);

            int r = dgv.SelectedCells[0].RowIndex;
            int c = dgv.SelectedCells[0].ColumnIndex;

            if (dgv.Rows.Count < (r + rowsInClipboard.Length))
                dgv.Rows.Add(r + rowsInClipboard.Length +1 - dgv.Rows.Count);

            // Loop through lines:

            int iRow = 0;
            while (iRow < rowsInClipboard.Length)
            {
                // Split up rows to get individual cells:

                string[] valuesInRow =
                    rowsInClipboard[iRow].Split(columnSplitter);

                // Cycle through cells.
                // Assign cell value only if within columns of grid:

                int jCol = 0;
                while (jCol < valuesInRow.Length)
                {
                    if ((dgv.ColumnCount - 1) >= (c + jCol))
                        dgv.Rows[r + iRow].Cells[c + jCol].Value =
                        valuesInRow[jCol];

                    jCol += 1;
                } // end while

                iRow += 1;
            } // end while
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasteInData(dataGridView1);
            MessageBox.Show("Recuerda que tienes que dejar los número sin texto para los que representantan tiempo");
        }

        private decimal? calcularValorRegistro(string texto){
           
            decimal? valor = null;

            if(!texto.Trim().Equals("NR")){

                if(texto.IndexOf("%")<0){
                    valor = (decimal)Decimal.Parse(texto);
                }else{
                    texto = texto.Trim();
                    texto = texto.Substring(0,texto.Length -1);
                    valor = (decimal)Decimal.Parse(texto)/100M;
                }
            }

            return valor;
            
        }

        private decimal calcularPenalidad(Registro reg)
        {
            decimal valor = 0M;
            DAOKpi daokpi = new DAOKpi();

            DataTable dt = daokpi.ObtenerKPI(reg.IndCod_KPIDivision.Value);
            Kpi kpi = new Kpi();
            foreach (DataRow rw in dt.Rows)
            {
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
            }

            int consecutivos = calcularConsecutivos(kpi);

            decimal tasareduccion = 0.5M;

            if (consecutivos < 9)
            {
                tasareduccion = (consecutivos * 1.0M / 9) * 0.5M;
            }

            decimal falla = calcularFalla(reg, kpi);
            decimal crediFalla = falla * kpi.Tas_multa.Value;
            decimal penalidad = crediFalla * (1M - tasareduccion);

            valor = penalidad;

            return valor;
        }
        public decimal calcularFalla(Registro reg, Kpi k)
        {
            decimal falla = 0M;

            if (k.Ind_KPIDivisionTipo.Equals("Porcentaje"))
            {

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

        public int calcularConsecutivos(Kpi kpi)
        {
            DAORegistro daoregistro = new DAORegistro();

            DataTable dtregistro = daoregistro.MostrarRegistroxKPI(kpi.IndCod_KPIDivision.Value);
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

                listaregistro.Add(reg);
            }

            int meses = 0;

            for (int i = listaregistro.Count - 1; i >= 0; i--)
            {
                if (kpi.Ind_KPIDivisionTipo.Equals("Porcentaje"))
                {
                    if (listaregistro[i].Valor_registro < kpi.Ind_SLA)
                    {
                        break;
                    }
                }
                else
                {
                    if (listaregistro[i].Valor_registro > kpi.Ind_SLA)
                    {
                        break;
                    }
                }

                meses++;
            }

            return meses;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Registro> newregistros = new List<Registro>();
            DAORegistro dao = new DAORegistro();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Registro nuevo = new Registro();

                nuevo.Fecha_registro = dateTimePicker1.Value;
                nuevo.Periodo_registro = dateTimePicker1.Value.ToString("yyyyMM");
                nuevo.IndCod_KPIDivision = (int)Int32.Parse(row.Cells[0].Value.ToString());
                nuevo.Valor_registro = calcularValorRegistro(row.Cells[4].Value.ToString());

                if (nuevo.Valor_registro != null)
                {
                    nuevo.Valor_penalidad = calcularPenalidad(nuevo);
                }

                dao.insertRegistro(nuevo);
            }

            MessageBox.Show("Termino!");
            this.Close();
        }

        private void ibmsla_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int cod = 994;
            DAOKpi daok = new DAOKpi();
            DAORegistro daor = new DAORegistro();

            for (int i = 986; i >= 970; i--)
            {
                DataTable dt = daok.ObtenerKPI(i);
                Kpi kpi = new Kpi();
                foreach (DataRow rw in dt.Rows)
                {
                    kpi.IndCod_KPIDivision = i + 2;
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
                }

                daok.insertKPICompleto(kpi);

                daor.updateRegistros(i,i+2);

                daok.deleteKPI(i);


            }

            MessageBox.Show("Fin");
        } 


    }
}
