﻿using System;
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
            _board.AddBlock();
            _board.AddBlock();
            DisplayBoard();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_board.Move(Way.check))
            {
                Gameover();
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                _board.Move(Way.left);
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                _board.Move(Way.up);
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                _board.Move(Way.right);
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                _board.Move(Way.down);
            }
            _board.AddBlock();
            DisplayBoard();
        }

        private void DisplayBoard()
        {
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    _blocks[y, x].Text = _board.Numbers[y, x] + "";
        }

        private void Gameover()
        {
            MessageBox.Show("님 졌음 ㅋ");
        }
        
    }
}