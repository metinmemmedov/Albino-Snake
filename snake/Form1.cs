// Süni intellektdən yardım aldığım məqamlar:
// 1) Yeni yaradılan panelin kordinatları valideyn panelə nəzərən olduğundan doğru şəkildə əlavə etmək (panel1.Controls.Add(bodyPart))
// 2) İlanın hərəkətini düzgün həyata keçirmək üçün Panel List yaratmaq fikri

namespace snake
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int score;
        Panel newPanel = new Panel();


        List<Panel> snakeBody = new List<Panel>();

        private void CheckFood()
        {
            if (panel2.Bounds.IntersectsWith(newPanel.Bounds))
            {
                int x = r.Next(0, 353);
                int y = r.Next(0, 313);
                newPanel.Location = new Point(x / 10 * 10 + 1, y / 10 * 10 + 1);
                score++;
                label2.Text = $"Score: {score.ToString()}";


                Panel bodyPart = new Panel();
                bodyPart.Width = panel2.Width;
                bodyPart.Height = panel2.Height;
                bodyPart.BackColor = panel2.BackColor;
                bodyPart.Location = snakeBody[snakeBody.Count - 1].Location;

                panel1.Controls.Add(bodyPart);
                snakeBody.Add(bodyPart);
            }
        }

        private void MoveSnakeBody()
        {
            for (int i = snakeBody.Count - 1; i > 0; i--)
            {
                snakeBody[i].Location = snakeBody[i - 1].Location;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            score = 0;


            snakeBody.Add(panel2);

            int random_x = r.Next(0, 353);
            int random_y = r.Next(0, 313);
            random_x = random_x / 10 * 10 + 1;
            random_y = random_y / 10 * 10 + 1;

            newPanel.Width = 16;
            newPanel.Height = 16;
            newPanel.Location = new Point(random_x, random_y);
            newPanel.BackColor = Color.Red;
            panel1.Controls.Add(newPanel);
            CheckFood();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer3.Stop();
            timer4.Stop();

            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X + 10 < 352)
            {
                MoveSnakeBody();
                panel2.Location = new Point(panel2.Location.X + 10, panel2.Location.Y);
                CheckFood();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                DialogResult r = MessageBox.Show("You've lost the game. Press OK to start a new game.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer4.Stop();

            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.Y + 10 < 312)
            {
                MoveSnakeBody();
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 10);
                CheckFood();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                DialogResult r = MessageBox.Show("You've lost the game. Press OK to start a new game.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.Y - 10 >= 0)
            {
                MoveSnakeBody();
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 10);
                CheckFood();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                DialogResult r = MessageBox.Show("You've lost the game. Press OK to start a new game.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X - 10 >= 0)
            {
                MoveSnakeBody();
                panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
                CheckFood();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                DialogResult r = MessageBox.Show("You've lost the game. Press OK to start a new game.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}