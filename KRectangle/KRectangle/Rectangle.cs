using System;
using System.Globalization;

namespace KRectangle
{
    public class Rectangle:IFormattable
    {
        /// <summary>
        /// Property for peak of rectangle
        /// </summary>
        public Point Point { get; set; }
        /// <summary>
        /// Property for heigth
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// property for width
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Constructor for creating new instance of Rectangle
        /// </summary>
        /// <param name="point">peak of rectangle</param>
        /// <param name="heigth">Heigth of rectangle</param>
        /// <param name="width">width of rectangle</param>
        public Rectangle(Point point, int width, int heigth)
        {

            if (heigth < 0 || width < 0)
                throw new ArgumentException();
            Point = point;
            Height = heigth;
            Width = width;
        }
        /// <summary>
        /// Method for changing size of rectangle
        /// </summary>
        /// <param name="addwidth">Change width</param>
        /// <param name="addheight">Change height</param>
        /// <returns>new rectangle with changing coordinates</returns>
        public Rectangle ChangeSize(int addwidth, int addheight)
        {
            return new Rectangle(Point, Height + addheight, Width + addwidth);
        }
        /// <summary>
        /// Methods for movving rectangle
        /// </summary>
        /// <param name="moveX">move for acis X</param>
        /// <param name="moveY">move for acis Y</param>
        /// <returns>return new rectangle with movving coordinates</returns>
        public Rectangle Move(int moveX, int moveY)
        {
            return new Rectangle(new Point(Point.X + moveX, Point.Y + moveY), Height, Width);
        }
        /// <summary>
        /// Method for finding peaks od rectangle
        /// </summary>
        /// <returns>Array of peaksof rectangle</returns>
        public Point[] GetPoints()
        {
            var points = new Point[4];
            points[0] = Point;
            points[2] = new Point(Point.X + Width, Point.Y + Height);
            points[1] = new Point(points[0].X, points[2].Y);
            points[3] = new Point(points[2].X, points[0].Y);
            return points;
        }
        /// <summary>
        /// Method that represents instance of class to string
        /// </summary>
        /// <returns>string that represents instance of class</returns>
        public override string ToString()
        {
            var points = GetPoints();
            return ToString($"{points[0].ToString()} {points[1].ToString()} {points[2].ToString()} {points[3].ToString()}", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return format;
        }

        /// <summary>
        /// Finding a new rectangles whisc is intersection of two
        /// </summary>
        /// <param name="firstRectangle">first rectangle</param>
        /// <param name="secondRectangle">second rectangle</param>
        /// <returns>return the ne new rectangle which is intersection</returns>
        public Rectangle Intercetion(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (firstRectangle == null || secondRectangle == null)
                throw new ArgumentNullException();
            var firstPoints = firstRectangle.GetPoints();
            var secondPoints = secondRectangle.GetPoints();


            var a1 = Math.Min(firstPoints[3].X, secondPoints[3].X);
            var a2 = Math.Max(firstPoints[0].X, secondPoints[0].X);
            var b1 = Math.Min(firstPoints[0].Y, secondPoints[0].Y);
            var b2 = Math.Min(firstPoints[1].Y, secondPoints[1].Y);

            return new Rectangle(new Point(a2, b1), b2 - b1, a1 - a2);
        }
        /// <summary>
        /// Methods for finding rectangle that contains two rectangles
        /// </summary>
        /// <param name="firstRectangle">first rectangle</param>
        /// <param name="secondRectangle">second rectangle</param>
        /// <returns>new rectangle which has two rectangles</returns>
        public Rectangle HasTwoRectangle(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (firstRectangle == null || secondRectangle == null)
                throw new ArgumentNullException();
            var firstPoints = firstRectangle.GetPoints();
            var secondPoints = secondRectangle.GetPoints();
            int a1 = firstPoints[0].X < secondPoints[0].X ? firstPoints[0].X : secondPoints[0].X;
            int b1 = firstPoints[0].Y < secondPoints[0].Y ? firstPoints[0].Y : secondPoints[0].Y;
            int a2 = firstPoints[2].X > secondPoints[2].X ? firstPoints[2].X : secondPoints[2].X;
            int b2 = firstPoints[2].Y > secondPoints[2].Y ? firstPoints[2].Y : secondPoints[2].Y;

            return new Rectangle(new Point(a1, b1), a2 - a1, b2 - b1);

        }
    }
}
