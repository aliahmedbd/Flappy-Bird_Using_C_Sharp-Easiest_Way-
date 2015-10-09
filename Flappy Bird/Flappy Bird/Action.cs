using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Flappy_Bird
{
   
    public partial class Action : Form
    {
        
        private int score=0;
        
        int highScore =Convert.ToInt32( System.IO.File.ReadAllText(@"..\high.txt"));

        public Action()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(key_press);
            timer1.Start();
           
            SoundPlayer simpleSound = new SoundPlayer(@"..\back.wav");
            simpleSound.Play();
            txtHigh.Text = System.IO.File.ReadAllText(@"..\high.txt");

        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\collision.wav");
            simpleSound.Play();
        }

        private void key_press(object sender, KeyEventArgs e)
        {

            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
         
            int jumpy = pictureBox1.Location.Y;
            bool a = true;
            bool b = true;
           
             
            if (e.KeyCode == Keys.Right)
            {
                if (a == true)
                {
                    this.pictureBox1.Image = global::Flappy_Bird.Properties.Resources.flappy;
                    a = false;
                    b = true;

                }
                if (pictureBox1.Bounds.IntersectsWith(pictureBoxMostRight.Bounds))
                {
                    
                    x += 0;
                }
                else
                    x += 10;

            }

            else if (e.KeyCode == Keys.Left)
            {
                if (b == true)
                {
                    b = false;
                    a = true;
                    this.pictureBox1.Image = global::Flappy_Bird.Properties.Resources.flapy2;
                }
                if (pictureBox1.Bounds.IntersectsWith(pictureBoxMostLeft.Bounds))
                {
                    x -= 0;
                }
                else
                    x -= 10;
            }

            else if (e.KeyCode == Keys.Up)
            {
                if (pictureBox1.Bounds.IntersectsWith(pictureBoxTop.Bounds))
                {
                    y -= 0; ;
                }
                else
                    y -= 10;

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (pictureBox1.Bounds.IntersectsWith(pictureBoxDown.Bounds))
                {
                    y += 0; ;
                }
                else
                    y += 10;


            }
            else if (e.KeyCode == Keys.Space)
            {
              
                if (pictureBox1.Bounds.IntersectsWith(pictureBoxTop.Bounds))
                {
                    y -= 0; ;
                }
                else
                    y -= 30;
            }
            


            pictureBox1.Location = new Point(x, y);

            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score = score + 5;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds)
               || pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                playSimpleSound();
               
                panel1.Hide();
                
                btnRestart.Visible = true;
                label3.Visible = true;
                lblS.Visible = true;
                label4.Visible = true;
                lblS.Text = (score).ToString();
                timer1.Stop();
                if (score > highScore)
                {
                    highScore = score;
                    System.IO.File.WriteAllText(@"..\high.txt", highScore.ToString());
                    
                    MessageBox.Show("Congratulations..!!!This is HIGH SCORE..");
                    txtHigh.Text = highScore.ToString();
                }
                
               

            }
            Random _random = new Random();
            double d=0, q=0;
            d = d + 1;
            q = q + 1;
            int x = _random.Next(0, (int)(30+q));
            int y = _random.Next(0, (int)(30+d));
            // pictureBox2.Top += y;
            // pictureBox2.Left -= x;
            if (pictureBox2.Bounds.IntersectsWith(pictureBoxL.Bounds)) {
                pictureBox2.Location = pictureBoxL1.Location;
                pictureBox2.Left -= x;
            }
            else
             pictureBox2.Left -= x;
            if (pictureBox3.Bounds.IntersectsWith(pictureBoxL.Bounds))
            {
                pictureBox3.Location = pictureBoxL1.Location;
                pictureBox3.Left -= x;
            }
            else
                pictureBox3.Left -= x;
            if (pictureBox4.Bounds.IntersectsWith(pictureBoxR1.Bounds))
            {
                pictureBox4.Location = pictureBoxR.Location;
                pictureBox4.Left -= x;
            }
            else
                pictureBox4.Left -= x;
            if (pictureBox5.Bounds.IntersectsWith(pictureBoxR1.Bounds))
            {
                pictureBox5.Location = pictureBoxR.Location;
                pictureBox5.Left -= x;
            }
            else
                pictureBox5.Left -= x;

           
            txtScore.Text = score.ToString();




            
           
        }

        private void Action_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void pictureBoxL_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            txtScore.Text = "0";
           
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxMostRight_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
