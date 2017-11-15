using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twozerofourpal
{
    public partial class Main : Form
    {
        private Label[,] _blocks;
        private Board _board;

        public Main()
        {
            InitializeComponent();
            _board = new Board();

            _blocks = new Label[4, 4]
            {
                { label1,  label2,  label3,  label4 },
                { label5,  label6,  label7,  label8 },
                { label9,  label10, label11, label12},
                { label13, label14, label15, label16}
            };
            
            foreach (Control c in this.Controls)
            {
                c.KeyDown += Main_KeyDown;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // 색깔 보기위한 디버깅용
            //_board.AddBlock(2, 0, 0);
            //_board.AddBlock(2 * 2, 0, 1);
            //_board.AddBlock(2 * 4, 0, 2);
            //_board.AddBlock(2 * 8, 0, 3);
            //_board.AddBlock(2 * 8 * 2, 1, 0);
            //_board.AddBlock(2 * 8 * 4, 1, 1);
            //_board.AddBlock(2 * 8 * 8, 1, 2);
            //_board.AddBlock(2 * 64 * 2, 1, 3);
            //_board.AddBlock(2 * 64 * 4, 2, 0);
            //_board.AddBlock(2 * 64 * 8, 2, 1);
            //_board.AddBlock(2 * 64 * 8 * 2, 2, 2);
            //_board.AddBlock(2 * 64 * 8 * 4, 2, 3);
            //_board.AddBlock(2 * 64 * 8 * 8, 3, 0);
            //_board.AddBlock(2 * 64 * 64 * 2, 3, 1);
            //_board.AddBlock(2 * 64 * 64 * 4, 3, 2);
            //_board.AddBlock(2 * 64 * 64 * 8, 3, 3);

            _board.AddBlock();
            _board.AddBlock();
            DisplayBoard();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            

            bool result = false;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                result = _board.Move(Way.left);
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                result = _board.Move(Way.up);
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                result = _board.Move(Way.right);
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                result = _board.Move(Way.down);
            }

            if(result)_board.AddBlock();

            DisplayBoard();

            if (!_board.Move(Way.check))
            {
                Gameover();
            }
        }

        private void DisplayBoard()
        {
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                {
                    _blocks[y, x].Text = _board.Numbers[y, x] + "";
                    _blocks[y, x].BackColor = SetColor(_board.Numbers[y, x], x, y);
                    if (_board.Numbers[y, x] == 0) _blocks[y, x].Text=String.Empty;
                }
            Score.Text = _board.score + "";
            MaxScore.Text = _board.maxScore + "";
        }

        private Color SetColor(int num, int x, int y)
        {
            if (num == 0) return Color.White;

            double red = 255 - Math.Log(num, 2) * 50 + (int)Math.Log(num, 32) * 250,
                green = 200 - (int)Math.Log(num, 32) * 50,
                blue = 50;
            
            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        private void Gameover()
        {
            MessageBox.Show("님 졌음 ㅋ");
        }
    }
}
