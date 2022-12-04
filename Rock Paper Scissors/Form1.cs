using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
    public partial class Form1 : Form
    {


        int rounds = 3;
        int timerPerRound = 4;

        bool gameover = false;

        string[] CPUchoiceList = {"rock", "paper", "scissor", "paper", "scissor", "rock" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CPUchoice;

        string playerChoice;

        int playerwins;
        int AIwins;


        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;
            playerChoice = "none";
            txtTime.Text = "4";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        public void countDownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtTime.Text = timerPerRound.ToString();
            roundsText.Text = "Manche: " + rounds;

            if(timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 4;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);

                CPUchoice = CPUchoiceList[randomNumber];

                switch(CPUchoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        picCPU.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }


                if(rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if(playerwins > AIwins)
                    {
                        MessageBox.Show("Le Joueur gagne la partie!");
                    }
                    else
                    {
                        MessageBox.Show("Le Bot gagne la partie!");
                    }

                    gameover = true;
                }


            }
        }


        public void checkGame()
        {

            // AI and player win rules

            if(playerChoice == "rock" && CPUchoice == "paper")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Bot gagne, la feuille couvre la pierre");

            }
            else if(playerChoice == "scissor" && CPUchoice == "rock")
            {
                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Bot gagne, la pierre casse le ciseau");
            }
            else if (playerChoice == "paper" && CPUchoice == "scissor")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Bot gagne, le ciseau coupe la feuille");

            }
            else if(playerChoice == "rock" && CPUchoice == "scissor")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Joueur gagne, la pierre casse le ciseau");

            }
            else if (playerChoice == "paper" && CPUchoice == "rock")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Joueur gagne, la feuille couvre la pierre");

            }
            else if (playerChoice == "scissor" && CPUchoice == "paper")
            {
                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Le Joueur gagne, le ciseau coupe la feuille");

            }
            else if(playerChoice == "none")
            {
                MessageBox.Show("Veuillez choisir");
            }
            else
            {
                MessageBox.Show("Egalité");

            }

            startNextRound();
        }

        public void startNextRound()
        {

            if (gameover)
            {



                return;
            }

            txtMessage.Text = "Joueur: " + playerwins + " - " + "Bot: " + AIwins;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;
        }

        private void restartGame(object sender, EventArgs e)
        {
            playerwins = 0;
            AIwins = 0;
            rounds = 3;
            txtMessage.Text = "Joueur: " + playerwins + " - " + "Bot: " + AIwins;

            playerChoice = "none";
            txtTime.Text = "5";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;

            gameover = false;
        }
    }
}
