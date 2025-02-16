﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        int cols = 50, rows = 25, score = 1, dx = 0, dy = 0, front = 0, back = 0;
        Piece[] snake = new Piece[1250];
        List<int> available = new List<int>();
        bool[,] visit;

        Random rand = new Random();

        Timer timeme = new Timer();

        public Snake()
        {
            InitializeComponent();
            intial();
            launchTimer();
        }

        private void launchTimer()
        {
            timeme.Interval = 50;
            timeme.Tick += move;
            timeme.Start();
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            
            if(e.KeyCode == Keys.Right)
            {
                dx = 20;
            }
            else if(e.KeyCode == Keys.Left)
            {
                dx = -20;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dy = -20;
            }
            else
            {
                dy = 20;
            }
        }

        private void move(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0) return;
            if (gameover(x + dx, y + dy))
            {
                timeme.Stop();
                MessageBox.Show("Oops! you lost.");
                return;
            }
            if (collisionFood(x + dx, y + dy))
            {
                score += 1;
                Score.Text = "Score: " + score.ToString();
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                Piece head = new Piece(x + dx, y + dy);
                front = (front - 1 + 1250) % 1250;
                snake[front] = head;
                visit[head.Location.Y / 20, head.Location.X / 20] = true;
                Controls.Add(head);
                randomFood();
            }
            else
            {
                if (hits((y + dy) / 20, (x + dx) / 20)) return;
                visit[snake[back].Location.Y / 20, snake[back].Location.X / 20] = false;
                front = (front - 1 + 1250) % 1250;
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                visit[(y + dy) / 20, (x + dx) / 20] = true;
            }
        }

        private void randomFood()
        {
            available.Clear();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (!visit[i, j]) available.Add(i * cols + j);
            int idx = rand.Next(available.Count) % available.Count;
            Food.Left = (available[idx] * 20) % Width;
            Food.Top = (available[idx] * 20) / Width * 20;
        }

        private bool hits(int x, int y)
        {
           if (visit[x, y])
            {
                timeme.Stop();
                MessageBox.Show("Snake Got Injured");
                return true;
            }
            return false;
        }

        private bool collisionFood(int x, int y)
        {
            return x == Food.Location.X && y == Food.Location.Y;
        }

        private bool gameover(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        private void intial()
        {
            visit = new bool[rows, cols];
            Piece head 
                = new Piece((rand.Next() % cols) * 20, (rand.Next() % rows) * 20);
            Food.Location 
                = new Point((rand.Next() % cols) * 20, (rand.Next() % rows) * 20);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    visit[i, j] = false;
                    available.Add(i * cols + j);
                }
            visit[head.Location.Y / 20, head.Location.X / 20] = true;
            available.Remove(head.Location.Y / 20 * cols + head.Location.X / 20);
            Controls.Add(head); snake[front] = head;
        }
    }
}
