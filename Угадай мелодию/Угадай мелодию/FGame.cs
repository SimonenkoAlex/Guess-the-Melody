using System;
using System.Windows.Forms;

namespace Угадай_мелодию
{
    public partial class FGame : Form
    {
        Random rnd = new Random();
        int musicDuration = Victorina.MusicDuration;
        bool[] players = new bool[2];

        public FGame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            if (Victorina.list.Count == 0) EndGame();
            else
            {
                musicDuration = Victorina.MusicDuration;
                int n = rnd.Next(0, Victorina.list.Count);
                WMP.URL = Victorina.list[n];
                Victorina.answer = System.IO.Path.GetFileNameWithoutExtension(WMP.URL);
                //WMP.Ctlcontrols.play();
                Victorina.list.RemoveAt(n);
                lbMusicCount.Text = Victorina.list.Count.ToString();
                players[0] = false;
                players[1] = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void FGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void FGame_Load(object sender, EventArgs e)
        {
            lbMusicCount.Text = Victorina.list.Count.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Victorina.GameDuration;
            lbMusicDuration.Text = musicDuration.ToString();
        }

        void EndGame()
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
            //if (Convert.ToInt32(lbCounter1.Text) == Convert.ToInt32(lbCounter2.Text))
            //{
            //    lbWin.Visible = true;
            //    lbWin.Text = "Ничья";
            //}
            //if (Convert.ToInt32(lbCounter1.Text) > Convert.ToInt32(lbCounter2.Text))
            //{
            //    lbWin.Visible = true;
            //    lbWin.Text = "Победил Игрок 1";
            //}
            //if (Convert.ToInt32(lbCounter1.Text) < Convert.ToInt32(lbCounter2.Text))
            //{
            //    lbWin.Visible = true;
            //    lbWin.Text = "Победил Игрок 2";
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            musicDuration--;
            lbMusicDuration.Text = musicDuration.ToString();
            if (progressBar1.Value==progressBar1.Maximum)
            {
                EndGame();
                return;
            }
            if (musicDuration == 0) MakeMusic();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            GamePause();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }

        void GameStart()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        private void FGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer1.Enabled) return;
            if (players[0] == false && e.KeyData == Keys.A)
            {
                GamePause();
                FMessage fm = new FMessage();
                fm.lb1Message.Text = "Игрок 1";
                players[0] = true;
                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lbCounter1.Text = Convert.ToString(Convert.ToInt32(lbCounter1.Text) + 1);
                    MakeMusic();
                }
                GameStart();
            }
            if (players[1] == false && e.KeyData == Keys.P)
            {
                GamePause();
                FMessage fm = new FMessage();
                fm.lb1Message.Text = "Игрок 2";
                players[1] = true;
                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lbCounter2.Text = Convert.ToString(Convert.ToInt32(lbCounter2.Text) + 1);
                    MakeMusic();
                }
                GameStart();
            }
        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (Victorina.randomStart)
            {   // Если в настройках стоит галочка начинать "Со случайного места" и
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                {
                    WMP.Ctlcontrols.currentPosition = rnd.Next(0, (int) WMP.currentMedia.duration / 2);
                }
            }
        }

        private void lbCounter1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) + 1);
            if (e.Button == MouseButtons.Right) (sender as Label).Text = Convert.ToString(Convert.ToInt32((sender as Label).Text) - 1);
        }
    }
}
