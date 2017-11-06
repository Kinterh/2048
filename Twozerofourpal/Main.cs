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
        private Board board;
        public Main()
        {
            InitializeComponent();
            board = new Board();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            board.AddBlock();
            board.AddBlock();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                board.Move(Way.left);
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                board.Move(Way.up);
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                board.Move(Way.right);
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                board.Move(Way.down);
            }

            if(!board.Move(Way.check))
            {
                Gameover();
            }
        }

        private void DisplayBoard()
        {

        }

        private void Gameover()
        {

        }
        
    }
}
