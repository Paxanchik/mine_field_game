using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mine_game
{
    public partial class Form1 : Form
    {
        private DateTime gameStartTime;
        private const int ButtonSize = 50;
        private const int MineCount = 10;
        private const int TotalAttempts = 30;
        private const int GameDuration = 180; // in seconds

        private Button mineButton;
        private Label labelX;
        private Label labelY;
        private Label labelD;
        private Label labelS;
        private Timer gameTimer;
        private int attemptsLeft;
        private int minesFound;
        private bool gameStarted;

        private Random random;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameStartTime = DateTime.Now;
            string password = ReadPasswordFromFile("Key.txt");
            if (string.IsNullOrEmpty(password))
            {
                password = GetPasswordFromUser();
                WritePasswordToFile("Key.txt", password);
            }
            gameStarted = false;
            attemptsLeft = TotalAttempts;
            minesFound = 0;

            random = new Random();

            

            mineButton = new Button
            {
                Size = new Size(ButtonSize, ButtonSize),
                Location = GetRandomLocation(panelMineField),
                Visible = false
            };
            Buttonmine.Click += Buttonmine_Click;
            panelMineField.Controls.Add(mineButton);

            labelX = new Label
            {
                Location = new Point(5, 5),
                Text = "X: 0"
            };
            Controls.Add(labelX);

            labelY = new Label
            {
                Location = new Point(5, 30),
                Text = "Y: 0"
            };
            Controls.Add(labelY);

            labelD = new Label
            {
                Location = new Point(105, 5),
                Text = "Расстояние: 0"
            };
            Controls.Add(labelD);

            labelS = new Label
            {
                Location = new Point(105, 10),
                Text = $"Осталось попыток: {attemptsLeft}"
            };
            Controls.Add(labelS);

            timer_game = new Timer();
            timer_game.Interval = 1000; // 1 second
            timer_game.Tick += timer_game_Tick;
            timer_game.Start();
        }
        private string ReadPasswordFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }
            return null;
        }
        private void WritePasswordToFile(string fileName, string password)
        {
            File.WriteAllText(fileName, password);
        }
        private string GetPasswordFromUser()
        {
            using (var passwordDialog = new PasswordDialog())
            {
                if (passwordDialog.ShowDialog() == DialogResult.OK)
                {
                    return passwordDialog.Password;
                }
            }
            return null;
        }
        private Point GetRandomLocation(Control container)
        {
            int maxX = container.Width - ButtonSize;
            int maxY = container.Height - ButtonSize;
            return new Point(random.Next(maxX), random.Next(maxY));
        }
        private double GetDistance(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        private void UpdateLabels(int x, int y)
        {
            labelX.Text = $"X: {x}";
            labelY.Text = $"Y: {y}";
            double distance = GetDistance(x, y, Buttonmine.Location.X + ButtonSize / 2, Buttonmine.Location.Y + ButtonSize / 2);
            labelD.Text = $"Расстояние: {distance}";

            if (gameStarted)
            {
                double oldDistance = double.Parse(labelD.Text.Substring(11)); // Extract the previous distance value
                if (distance < oldDistance)
                {
                    label_S.Text = $"Ближе! Осталось попыток: {attemptsLeft}";
                }
                else if (distance > oldDistance)
                {
                    label_S.Text = $"Дальше! Осталось попыток: {attemptsLeft}";
                }
                else
                {
                    label_S.Text = $"То же расстояние! Осталось попыток: {attemptsLeft}";
                }
            }

            if (distance < ButtonSize)
            {
                Buttonmine.Visible = true;
            }
            else
            {
                Buttonmine.Visible = false;
            }
        }

        private void timer_game_Tick(object sender, EventArgs e)
        {
            gameStarted = true;
            int elapsedTime = (int)(DateTime.Now - gameStartTime).TotalSeconds;
            int remainingTime = GameDuration - elapsedTime;
            labelS.Text = $"Мины найдены: {minesFound}/{MineCount}   Осталось попыток: {attemptsLeft}   Time left: {remainingTime} seconds";

            if (remainingTime <= 0)
            {
                timer_game.Stop();
                MessageBox.Show("Время вышло! Вы не нашли все мины.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void Buttonmine_Click(object sender, EventArgs e)
        {
            Buttonmine.Visible = false;
            minesFound++;
            attemptsLeft--;

            if (minesFound == MineCount)
            {
                timer_game.Stop();
                MessageBox.Show("Поздравляем! Вы нашли все мины.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            if (attemptsLeft == 0)
            {
                timer_game.Stop();
                MessageBox.Show("Игра закончена!Попытки закончились", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            labelS.Text = $"Mines found: {minesFound}/{MineCount}   Attempts left: {attemptsLeft}";
            Buttonmine.Size = new Size(Buttonmine.Width - 10, Buttonmine.Height - 10);
            Buttonmine.Location = GetRandomLocation(panelMineField);
            Buttonmine.Visible = true;
        }

        private void panelMineField_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateLabels(e.X, e.Y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Хотите сменить пароль?", "Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newPassword = GetPasswordFromUser();
                if (!string.IsNullOrEmpty(newPassword))
                {
                    WritePasswordToFile("Key.txt", newPassword);
                }
            }
        }
    }
}
