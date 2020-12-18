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
            cbb_hangszedok.DataSource = Enum.GetValues(typeof(Hangszedo));
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
                Name = "sorozatszam",
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

            DataGridViewColumn ErintoColumn = new DataGridViewColumn()
            {
                Name = "erinto",
                HeaderText = "Érintők száma",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            dgv_gitarok.Columns.Add(ErintoColumn);

            DataGridViewColumn BalkezesColumn = new DataGridViewColumn()
            {
                Name = "balkezes",
                HeaderText = "Balkezes",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            };

            dgv_gitarok.Columns.Add(BalkezesColumn);


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
                DatumCell.Value = gitarokList[i].GyartasDatum.Year + "-" + gitarokList[i].GyartasDatum.Month + "-" + gitarokList[i].GyartasDatum.Day + " ";
                dataGridViewRow.Cells.Add(DatumCell);

                DataGridViewCell ErintoCell = new DataGridViewTextBoxCell();
                ErintoCell.Value = gitarokList[i].ErintokSzama.ToString();
                dataGridViewRow.Cells.Add(ErintoCell);

                DataGridViewCell BalkezesCell = new DataGridViewTextBoxCell();
                if(gitarokList[i].Balkezes)
                {
                    BalkezesCell.Value = "Igen";
                }
                else
                {
                    BalkezesCell.Value = "Nem";
                }
                dataGridViewRow.Cells.Add(BalkezesCell);

                dataGridViewRows[i] = dataGridViewRow;
            }
            dgv_gitarok.Rows.Clear();
            dgv_gitarok.Rows.AddRange(dataGridViewRows);
        }

        private void tb_Sorozatszam_Leave(object sender, EventArgs e)
        {
            string actual = tb_sorozatszam.Text;
            bool Correct = tableManager.CheckSorozatszam(actual);
            tb_sorozatszam.BackColor = Correct ? Color.White : Color.Yellow;
        }

        private void btn_hozzaad_Click(object sender, EventArgs e)
        {
            Gitar gitar = new Gitar
            {
                Sorozatszam = tb_sorozatszam.Text,
                Tipus = tb_tipus.Text,
                Gyarto = tb_gyarto.Text,
                GyartasDatum = dtp_gyartasDatum.Value,
                Balkezes = cb_balkezes.Checked,
                Hangszedok = cbb_hangszedok.SelectedItem.ToString(),
                ErintokSzama = int.Parse(tb_erintokszama.Text)
            };


            tableManager.Insert(gitar);
            bgWorker.RunWorkerAsync();
        }

        private void btn_torol_Click(object sender, EventArgs e)
        {
            int ToroltSorok = 0;
            foreach (DataGridViewRow selectedRows in dgv_gitarok.SelectedRows)
            {
                Gitar TorlendoRekord = new Gitar();
                TorlendoRekord.Sorozatszam = selectedRows.Cells["sorozatszam"].Value.ToString();

                ToroltSorok += tableManager.Delete(TorlendoRekord);
            }

            MessageBox.Show(string.Format("{0} sor lett törölve", ToroltSorok));
            if (ToroltSorok != 0)
            {
                bgWorker.RunWorkerAsync();
            }
        }
    }
}
