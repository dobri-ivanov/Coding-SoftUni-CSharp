using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Windth = width;
            this.Height = height;
        }
        private int width;
        private int height;

        public int Windth
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }

        }
        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
                DrawLine(this.width, '*', ' ');
            DrawLine(this.width, '*', '*');
        }
        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
                Console.Write(mid);
            Console.WriteLine(end);
        }

    }
}
