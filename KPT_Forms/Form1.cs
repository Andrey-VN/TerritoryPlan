using KPT_Forms.GetTextBoxXml;
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
using System.Xml.Linq;

namespace KPT_Forms
{
    public partial class Form1 : Form
    {
        XDocument xdoc;
        public Form1()
        {
            InitializeComponent();
            xdoc = XDocument.Load("24_21_1003001_2017-05-29_kpt11.xml"); //создание XML файла
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;

            saveFileDialog1.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";  //фильтр для сохранения файла только в xml формате
        }

        #region Обработчики событий кнопок, результаты действий которых явлеяется отображение ключей объектов в "гриде"
        private void button1_Click(object sender, EventArgs e)
        {
            GetStringRow("ParcelID", "Parcel", GetNumberObject(StaticGetXml.GetLandRecords(xdoc)));             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetStringRow("BuildID", "Build", GetNumberObject(StaticGetXml.GetBuild(xdoc)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetStringRow("SpatialDataID", "SpatialData", GetNumberObject(StaticGetXml.GetSpetialData(xdoc)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetStringRow("BoundID", "Bound", GetNumberObject(StaticGetXml.GetMunicipalBoundaries(xdoc)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetStringRow("ZoneID", "Zone", GetNumberObject(StaticGetXml.GetZonesAndTerritoriesBoundaries(xdoc)));
        }
        private void button8_Click(object sender, EventArgs e)
        {
            GetStringRow("ConstructionID", "Construction", GetNumberObject(StaticGetXml.GetConstruction(xdoc)));
        }
        #endregion


        /// <summary>
        /// Обработчк события кнопки, результатом нажатия которой является отображение в richTextBox информации в XML формате выделеной строки ключа в "гриде"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                string cadastralNumber = dataGridView1[0, index].Value.ToString();
                string nameRows = dataGridView1.Columns[0].Name;
                if (cadastralNumber == null & nameRows == null)
                    return;

                GetXmlToText getXmlToText = GetXmlToText.Create(nameRows);
                richTextBox1.Text = getXmlToText.GetItem(xdoc, cadastralNumber);
            }
            catch
            {
                MessageBox.Show("Объект не выбран.");
            }

        }

        /// <summary>
        /// Событие кнопки, с помощью которого возможно сохранение текста в XML формате из richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;

            // сохраняем текст в файл
            File.WriteAllText(filename,richTextBox1.Text);
        }

        /// <summary>
        /// Метод позволяет заполнть строки в "гриде" и заголовки.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="listString"></param>
        private void GetStringRow(string id1, string id2, List<string> listString)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.TopLeftHeaderCell.Value = "Id";

            dataGridView1.Columns.Add(id1, id2);

            int numberRow = 1;
            foreach (var i in listString)
            {               
                dataGridView1.Rows.Add(i);
                dataGridView1.Rows[numberRow - 1].HeaderCell.Value = numberRow.ToString();

                numberRow++;
            }

        }


        /// <summary>
        /// Метод для получения листа со строками, которые будут отображаться в "гриде".
        /// </summary>
        /// <param name="xElements"></param>
        /// <returns></returns>
        private static List<string> GetNumberObject(IEnumerable<XElement> xElements)
        {
            List<string> list = new List<string>();

            foreach (XElement cadastrElement in xElements)
            {
                list.Add(cadastrElement.Value);
            }
            return list;
        }


    }
}
