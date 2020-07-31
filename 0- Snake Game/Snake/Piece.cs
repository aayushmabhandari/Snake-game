using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Piece : Label
    {
        public Piece(int x, int y)
        {
            Location = new Point(x, y);
            Size = new Size(25, 25);
            BackColor = Color.Aquamarine;
            Enabled = false;
        }
    }
}