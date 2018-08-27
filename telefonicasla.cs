using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DAOLibrary.DTO;
using DAOLibrary.DAO;

namespace CargadeSLA
{
    public partial class telefonicasla : Form
    {
        public telefonicasla()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today.AddMonths(-1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<Registro> listaregistro = new List<Registro>();

            MessageBox.Show("Comenzamos La Carga, solo tiene que tener columnas CD, Sede, Empresa y Valor Actual. El excel solo debe tener una hoja.");

            DAOKpi daok = new DAOKpi();
            DAORegistro daor = new DAORegistro();

            string Chosen_File = "";
            openFileDialog1.Title = "Ingresa la Solicitud";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Archivos Excel *.xls|*.xls*";
            openFileDialog1.ShowDialog();

            Chosen_File = openFileDialog1.FileName;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
         

            if (Chosen_File == "")
            {
                MessageBox.Show("No ha Seleccionado ningun Archivo");
            }
            else
            {
                //Sentencias Excel
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Chosen_File, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                int lastRow = -1;

                foreach (Excel.Worksheet element in xlWorkBook.Worksheets)
                {
                    
                    lastRow = element.UsedRange.Rows.Count;
                    Excel.Range rango = (Excel.Range)element.get_Range("A2", "D" + lastRow);

                    for (int row = 1; row <= rango.Rows.Count; row++)
                    {
                        Registro reg = new Registro();

                        //reg.Fecha_registro = monthCalendar1.SelectionStart;
                        reg.Fecha_registro = dateTimePicker1.Value;
                        reg.Periodo_registro = reg.Fecha_registro.Value.ToString("yyyyMM");
                        reg.IndCod_KPIDivision = daok.ObtenerKPICodxUnicode(rango.Cells[row, 1].Value2.ToString());

                        if (reg.IndCod_KPIDivision == -1)
                        {
                            MessageBox.Show("El CD " + rango.Cells[row, 1].Value2.ToString() + " no esta registrado");
                        }
                        else
                        {
                            reg.Valor_registro = (decimal)decimal.Parse(rango.Cells[row, 4].Value2.ToString());
                            daor.insertRegistro(reg);
                        }     
                    }
                    break;
                 }

                MessageBox.Show("Terminado!");

                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkBook);
                releaseObject(xlApp);

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaEnlace c = new AltaEnlace();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BajaEnlace c = new BajaEnlace();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SLAComunicaciones c = new SLAComunicaciones(dateTimePicker1.Value);
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ModificarEnlace c = new ModificarEnlace();
            c.Show();

        }

    }
}
