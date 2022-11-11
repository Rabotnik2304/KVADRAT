using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Draw
    {
        static float x, y;
        static Graphics graphic;

        public static void Start(Graphics newGraphic)
        {
            graphic = newGraphic;
            graphic.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }


        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphic.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float Variable1 = 0.375f;
        private const float Variable2 = 0.04f;

        public static void Draw(int width, int height, double anglePovorota, Graphics graphica)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            RefactorMe.Draw.Start(graphica);

            var sz = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (sz * Variable1 + sz * Variable2) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            RefactorMe.Draw.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            FirstSide(sz);

            //Рисуем 2-ую сторону
            SecondSide(sz);

            //Рисуем 3-ю сторону
            ThirdSide(sz);

            //Рисуем 4-ую сторону
            FourthSide(sz);
        }

        private static void FourthSide(int sz)
        {
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, Math.PI / 2);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable2 * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, Math.PI / 2 + Math.PI);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1 - sz * Variable2, Math.PI / 2 + Math.PI / 2);

            RefactorMe.Draw.Change(sz * Variable2, Math.PI / 2 - Math.PI);
            RefactorMe.Draw.Change(sz * Variable2 * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void ThirdSide(int sz)
        {
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, Math.PI);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable2 * Math.Sqrt(2), Math.PI + Math.PI / 4);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, Math.PI + Math.PI);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1 - sz * Variable2, Math.PI + Math.PI / 2);

            RefactorMe.Draw.Change(sz * Variable2, Math.PI - Math.PI);
            RefactorMe.Draw.Change(sz * Variable2 * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
        }

        private static void SecondSide(int sz)
        {
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, -Math.PI / 2);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable2 * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, -Math.PI / 2 + Math.PI);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1 - sz * Variable2, -Math.PI / 2 + Math.PI / 2);

            RefactorMe.Draw.Change(sz * Variable2, -Math.PI / 2 - Math.PI);
            RefactorMe.Draw.Change(sz * Variable2 * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void FirstSide(int sz)
        {
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, 0);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable2 * Math.Sqrt(2), Math.PI / 4);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1, Math.PI);
            RefactorMe.Draw.MakeIt(Pens.Yellow, sz * Variable1 - sz * Variable2, Math.PI / 2);

            RefactorMe.Draw.Change(sz * Variable2, -Math.PI);
            RefactorMe.Draw.Change(sz * Variable2 * Math.Sqrt(2), 3 * Math.PI / 4);
        }
    }
}