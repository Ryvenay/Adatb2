using Beadando.Models.Manager;
using Beadando.Models.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando
{
    public partial class Form1 : Form
    {

        GitarokTabla tableManager;
        List<Gitar> gitarokList;
        BackgroundWorker bgWorker;

        public Form1()
        {
            tableManager = new GitarokTabla();
            gitarokList = new List<Gitar>();
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerComplete;

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            bgWorker.RunWorkerAsync();
        }


        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            gitarokList = tableManager.Select();
        }

        private void BgWorker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDataGridView();
        }



        private void InitDataGridView()
        {
            dgv_gitarok.Rows.Clear();
            dgv_gitarok.Columns.Clear();


            DataGridViewColumn SorozatszamColumn = new DataGridViewColumn
            {
                Name = "sorozatzam",
                HeaderText = "Sorozatszám",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };
            dgv_gitarok.Columns.Add(SorozatszamColumn);

            DataGridViewColumn TipusColumn = new DataGridViewColumn()
            {
                Name = "tipus",
                HeaderText = "Típus",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            dgv_gitarok.Columns.Add(TipusColumn);

            DataGridViewColumn GyartoColumn = new DataGridViewColumn()
            {
                Name = "gyarto",
                HeaderText = "Gyártó",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            dgv_gitarok.Columns.Add(GyartoColumn);

            DataGridViewColumn GyartasColumn = new DataGridViewColumn()
            {
                Name = "gyartas",
                HeaderText = "Gyártás Dátuma",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            dgv_gitarok.Columns.Add(GyartasColumn);
        }

        private void FillDataGridView()
        {
            DataGridViewRow[] dataGridViewRows = new DataGridViewRow[gitarokList.Count];

            for (int i = 0; i < gitarokList.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                DataGridViewCell SorozatszamCell = new DataGridViewTextBoxCell();
                SorozatszamCell.Value = gitarokList[i].Sorozatszam;
                dataGridViewRow.Cells.Add(SorozatszamCell);

                DataGridViewCell GyartoCell = new DataGridViewTextBoxCell();
                GyartoCell.Value = gitarokList[i].Gyarto;
                dataGridViewRow.Cells.Add(GyartoCell);

                DataGridViewCell TipusCell = new DataGridViewTextBoxCell();
                TipusCell.Value = gitarokList[i].Tipus;
                dataGridViewRow.Cells.Add(TipusCell);

                DataGridViewCell DatumCell = new DataGridViewTextBoxCell();
                DatumCell.Value = gitarokList[i].GyartasDatum;
                dataGridViewRow.Cells.Add(DatumCell);

                dataGridViewRows[i] = dataGridViewRow;
            }
            dgv_gitarok.Rows.Clear();
            dgv_gitarok.Rows.AddRange(dataGridViewRows);
        }

    }
}
