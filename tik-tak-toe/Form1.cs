using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tik_tak_toe
{
    public partial class Form1 : Form
    {
        Game game;
        Mode mode = Mode.AI;
        public Form1()
        {          
            InitializeComponent();

            if (aiRadioButton.Checked)
            {
                mode = Mode.AI;
            }
            else mode = Mode.player;

            game = new Game(winOutMessage, outAiMove);
        }

        private void A1_Click(object sender, EventArgs e)
        {
            A1.Text = game.NextMove;
            A1.Enabled = false;
            if(mode == Mode.AI)
                game.moveAI(0);
            else
                game.move(0);
        }

        private void A2_Click(object sender, EventArgs e)
        {
            A2.Text = game.NextMove;
            A2.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(1);
            else
                game.move(1);
        }

        private void A3_Click(object sender, EventArgs e)
        {
            A3.Text = game.NextMove;
            A3.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(2);
            else
                game.move(2);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            B1.Text = game.NextMove;
            B1.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(3);
            else
                game.move(3);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            B2.Text = game.NextMove;
            B2.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(4);
            else
                game.move(4);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            B3.Text = game.NextMove;
            B3.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(5);
            else
                game.move(5);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            C1.Text = game.NextMove;
            C1.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(6);
            else
                game.move(6);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            C2.Text = game.NextMove;
            C2.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(7);
            else
                game.move(7);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            C3.Text = game.NextMove;
            C3.Enabled = false;
            if (mode == Mode.AI)
                game.moveAI(8);
            else
                game.move(8);
        }

        private void winOutMessage(string p)
        {
            if(p == "toe")
            {
                MessageBox.Show("TOE!");
                restartButton_Click(this, new EventArgs());
                return;
            }

            MessageBox.Show("Player " + p.ToUpper() +" won!");
            restartButton_Click(this, new EventArgs());
        }
        private void outAiMove(int index)
        {
            switch (index) {
                case 0:
                    A1.Text = "o";
                    A1.Enabled = false;
                    break;
                case 1:
                    A2.Text = "o";
                    A2.Enabled = false;
                    break;
                case 2:
                    A3.Text = "o";
                    A3.Enabled = false;
                    break;
                case 3:
                    B1.Text = "o";
                    B1.Enabled = false;
                    break;
                case 4:
                    B2.Text = "o";
                    B2.Enabled = false;
                    break;
                case 5:
                    B3.Text = "o";
                    B3.Enabled = false;
                    break;
                case 6:
                    C1.Text = "o";
                    C1.Enabled = false;
                    break;
                case 7:
                    C2.Text = "o";
                    C2.Enabled = false;
                    break;
                case 8:
                    C3.Text = "o";
                    C3.Enabled = false;
                    break;
            }
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            game.restart();

            A1.Text = "";
            A1.Enabled = true;

            A2.Text = "";
            A2.Enabled = true;

            A3.Text = "";
            A3.Enabled = true;

            B1.Text = "";
            B1.Enabled = true;

            B2.Text = "";
            B2.Enabled = true;

            B3.Text = "";
            B3.Enabled = true;

            C1.Text = "";
            C1.Enabled = true;

            C2.Text = "";
            C2.Enabled = true;

            C3.Text = "";
            C3.Enabled = true;
        }

        private void playersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.player;
            restartButton_Click(sender, e);
        }

        private void aiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.AI;
            restartButton_Click(sender, e);
        }
    }
    public enum Mode
    {
        player,
        AI
    }
}
