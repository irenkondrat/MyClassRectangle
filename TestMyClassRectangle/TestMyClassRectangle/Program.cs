using System;
using KRectangle;

namespace TestMyClassRectangle
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();

            var firstRectangle = new Rectangle(new Point(rand.Next(1,15), rand.Next(1, 25)), rand.Next(1, 15), rand.Next(1, 25));
            var secondRectangle = new Rectangle(new Point(rand.Next(1, 15), rand.Next(1, 25)), rand.Next(1, 15), rand.Next(1, 25));
            Console.WriteLine($"Перший прямокутник:{firstRectangle.ToString()}");
            Console.WriteLine($"Другий прямокутник:{secondRectangle.ToString()}");

            var newfirstRectangle = firstRectangle.ChangeSize(rand.Next(1, 15), - 1);
            Console.WriteLine($"Зміна розмiр першого прямокутника:{newfirstRectangle.ToString()}");

            var newsecondRectangle = secondRectangle.Move(2, rand.Next(1, 15));
            Console.WriteLine($"Перемiщення другого прямокутника:{newsecondRectangle.ToString()}");

            try
            {
                var newbigRectangle = firstRectangle.HasTwoRectangle(firstRectangle, secondRectangle);
                Console.WriteLine($"Прямокутник, який мiстить два прямокутники:{newbigRectangle.ToString()}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + e.Source);
            }

            try
            {
                var newintersectRentangle = firstRectangle.Intercetion(firstRectangle, secondRectangle);
                Console.WriteLine($"Перетин:{newintersectRentangle.ToString()}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + e.Source);
            }

            Console.ReadLine();
        }
    }
}