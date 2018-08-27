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
    public partial class GMD : Form
    {
        public GMD()
        {
            InitializeComponent();
            llenardataGridView();
        }

        private void llenardataGridView()
        {
            DAOKpi dao = new DAOKpi();

            DataTable dt = dao.ListarSLAGMDLight();

            dt.Columns.Add(new DataColumn("resultado", typeof(string)));

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns[0].HeaderCell.Value = "Código";
            dataGridView1.Columns[1].HeaderCell.Value = "Nivel";
            dataGridView1.Columns[2].HeaderCell.Value = "SLA";
            dataGridView1.Columns[3].HeaderCell.Value = "Valor Esperado";
            dataGridView1.Columns[4].HeaderCell.Value = "Resultado";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PasteInData(dataGridView1);
            MessageBox.Show("Recuerda que tienes que dejar los número sin texto para los que representantan tiempo");
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
                dgv.Rows.Add(r + rowsInClipboard.Length + 1 - dgv.Rows.Count);

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
                dao.insertRegistro(nuevo);
            }

            DAOKpi daok = new DAOKpi();
            DataTable dti = daok.ListarSLAGMDBinarios("Informe");
            DataTable dtr = daok.ListarSLAGMDBinarios("Reunión");


            foreach (DataRow rw in dti.Rows)
            {
                Registro nuevo = new Registro();
                nuevo.Fecha_registro = dateTimePicker1.Value;
                nuevo.Periodo_registro = dateTimePicker1.Value.ToString("yyyyMM");
                nuevo.IndCod_KPIDivision = (int)Int32.Parse(rw[0].ToString());

                if (checkBox1.Checked){
                    nuevo.Valor_registro = 1;
                }else{
                    nuevo.Valor_registro = 0;
                }
                dao.insertRegistro(nuevo);
            }

            foreach (DataRow rw in dtr.Rows)
            {
                Registro nuevo = new Registro();
                nuevo.Fecha_registro = dateTimePicker1.Value;
                nuevo.Periodo_registro = dateTimePicker1.Value.ToString("yyyyMM");
                nuevo.IndCod_KPIDivision = (int)Int32.Parse(rw[0].ToString());

                if (checkBox2.Checked)
                {
                    nuevo.Valor_registro = 1;
                }
                else
                {
                    nuevo.Valor_registro = 0;
                }
                dao.insertRegistro(nuevo);
            }

            MessageBox.Show("Termino!");
            this.Close();
        }

        private decimal? calcularValorRegistro(string texto)
        {

            decimal? valor = null;

            if (!texto.Trim().Equals("N/A"))
            {

                if (texto.IndexOf("%") < 0)
                {
                    valor = (decimal)Decimal.Parse(texto);
                }
                else
                {
                    texto = texto.Trim();
                    texto = texto.Substring(0, texto.Length - 1);
                    valor = (decimal)Decimal.Parse(texto) / 100M;
                }
            }

            return valor;

        }

    }
}
