using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Угадай_мелодию
{
    public partial class FMain : Form
    {
        FParam fp = new FParam();
        FGame fg = new FGame();
        public FMain()
        {
            InitializeComponent();
        }
        // Обработчик события нажатия на кнопку Выход
        private void btnExit_Click(object sender, EventArgs e) => Close();
        // Обработчик события нажатия на кнопку Настройка
        private void btnParam_Click(object sender, EventArgs e)
        {
            fp.ShowDialog();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            fg.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            Victorina.ReadParam(); // считывание параметров при загрузкм формы
            Victorina.ReadMusic(); // считывание музыки при загрузкм формы
        }
    }
}