using System.Text;
using WinFormsCTech.Parser;

namespace WinFormsCTech
{
    public partial class Form1 : Form
    {
        private ResponsibleExecutorStorage _storage;
        private IResponsibleExecutorsParser _parserRKK;
        private IResponsibleExecutorsParser _parserAppeal;

        private bool _rKKIsLoaded = false;
        private bool _appealIsLoaded = false;
        private DateTime _currentDate;
        public Form1()
        {
            InitializeComponent();
            _storage = new ResponsibleExecutorStorage();
            _parserRKK = new ResponsibleExecutorsParserRKK();
            _parserAppeal = new ResponsibleExecutorsParserAppeal();

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            saveFileDialog1.FileName = "��������� ������ ���������";
            saveFileDialog1.DefaultExt = "rtf";
            saveFileDialog1.Filter = "RichTextBox files(*.rtf)|*.rtf|All files(*.*)|*.*";

            _currentDate = DateTime.Now.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                DateTime time = DateTime.Now;

                _rKKIsLoaded = true;
                label1.Text = getFileNameToShow(openFileDialog1.FileName);
                string[] fileTextLines = File.ReadAllLines(openFileDialog1.FileName);

                _storage = _parserRKK.Parse(fileTextLines, _storage);

                button1.Enabled = false;

                label3.Text = "����� �������� ������ ���: " + (DateTime.Now - time).TotalSeconds.ToString()[..6] + "c.";

                if (_appealIsLoaded && _rKKIsLoaded)
                    fillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�� ������� ������� ������!", "������");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                DateTime time = DateTime.Now;

                _appealIsLoaded = true;
                label2.Text = getFileNameToShow(openFileDialog1.FileName);
                string[] fileTextLines = File.ReadAllLines(openFileDialog1.FileName);

                _storage = _parserAppeal.Parse(fileTextLines, _storage);

                button2.Enabled = false;
                label4.Text = "����� �������� ������ �� ����������: " + (DateTime.Now - time).TotalSeconds.ToString()[..6] + "c.";

                if (_appealIsLoaded && _rKKIsLoaded)
                    fillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�� ������� ������� ������!", "������");
            }
        }

        private string getFileNameToShow(string fileName)
        {
            return fileName[(fileName.LastIndexOf('\\') + 1)..];
        }

        private void fillDataGridView()
        {
            DateTime time = DateTime.Now;
            var columns = new DataGridViewColumn[5];

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = new DataGridViewColumn();
            }

            columns[0].HeaderText = "� �.�.";
            columns[0].Name = "serial_number";

            columns[1].HeaderText = "������������� �����������";
            columns[1].Name = "executor_name";
            columns[1].Width = 200;

            columns[2].HeaderText = "���������� ������������� �������� ����������";
            columns[2].Name = "RKK";

            columns[3].HeaderText = "���������� ������������� ���������� ��������� �������";
            columns[3].Name = "appeal";

            columns[4].HeaderText = "����� ���������� ���������� � ���������";
            columns[4].Name = "sum";

            foreach (var column in columns)
            {
                gridViewColumnSettings(column);
                dataGridView1.Columns.Add(column);
            }
            List<ResponsibleExecutor> sortedList = _storage.GetAll();
            for (int i = 0; i < sortedList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = sortedList[i].Name;
                dataGridView1.Rows[i].Cells[2].Value = sortedList[i].RKKCount;
                dataGridView1.Rows[i].Cells[3].Value = sortedList[i].AppealCount;
                dataGridView1.Rows[i].Cells[4].Value = sortedList[i].RKKCount + sortedList[i].AppealCount;
            }
            label5.Text = "����� ���������� �� ����������� ������: " + (DateTime.Now - time).TotalSeconds.ToString()[..6] + "c.";
        }

        private DataGridViewColumn gridViewColumnSettings(DataGridViewColumn column)
        {
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.ReadOnly = true;
            column.Frozen = true;
            column.CellTemplate = new DataGridViewTextBoxCell();
            return column;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "���� �� ��� �� ������";
            label2.Text = "���� �� ���������� �� ������";
            _storage = new ResponsibleExecutorStorage();
            _rKKIsLoaded = false;
            _appealIsLoaded = false;
            button1.Enabled = true;
            button2.Enabled = true;
            dataGridView1.Columns.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!_appealIsLoaded || !_rKKIsLoaded)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "�� ��� ������ ���������, �� ������� ��� ������ ����������?",
                    "��������������",
                    MessageBoxButtons.YesNo
                    );
                if (dialogResult == DialogResult.No)
                    return;
            }
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                ReportSaver.Save(_storage, _currentDate, richTextBox1, saveFileDialog1.FileName);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "������");
            }
        }
    }
}