using System;
using System.Windows.Forms;
using System.IO;

namespace Угадай_мелодию
{
    public partial class FParam : Form
    {
        public FParam()
        {
            InitializeComponent();
        }
        // Обработчик события нажатия на кнопку ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            Victorina.AllDirectores = cBAllDirectory.Checked;
            Victorina.GameDuration = Convert.ToInt32(cBGameDuration.Text);
            Victorina.MusicDuration = Convert.ToInt32(cBMusicDuration.Text);
            Victorina.randomStart = cBRandomStart.Checked;
            Victorina.WriteParam();
            Hide();
        }
        // Обработчик события нажатия на кнопку Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set();
            Hide();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] music_list = Directory.GetFiles(fbd.SelectedPath, "*.mp3", cBAllDirectory.Checked?SearchOption.AllDirectories: SearchOption.TopDirectoryOnly);
                Victorina.LastFolder = fbd.SelectedPath;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(music_list);
                Victorina.list.Clear();
                Victorina.list.AddRange(music_list);
            }
        }

        void Set()
        {
            cBAllDirectory.Checked = Victorina.AllDirectores;
            cBGameDuration.Text = Victorina.GameDuration.ToString();
            cBMusicDuration.Text = Victorina.MusicDuration.ToString();
            cBRandomStart.Checked = Victorina.randomStart;
        }

        private void FParam_Load(object sender, EventArgs e)
        {
            Set();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Victorina.list.ToArray());
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Victorina.list.Clear();
        }
    }
}
