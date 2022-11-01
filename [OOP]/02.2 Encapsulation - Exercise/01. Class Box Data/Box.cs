using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Class_Box_Data
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get { return this.length; }
            set
            {
                if (value <= 0) throw new ArgumentException("Length cannot be zero or negative.");
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0) throw new ArgumentException("Width cannot be zero or negative.");
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0) throw new ArgumentException("Height cannot be zero or negative.");
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + (2 * this.Width * this.Height);
        }
        public double Volume()
        {
            return this.length * this.width * this.height;
        }


    }
}
