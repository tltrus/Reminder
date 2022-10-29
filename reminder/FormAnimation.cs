using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace reminder
{
    class FormAnimation
    {
        public static bool formRightHide = false;
        public static int rightHidewidth = 50;
        public static Point hideFormPos;

        /// <summary>
        /// Сдвиг формы влево (выползание формы) при наведении курсора
        /// 
        /// Arguments:
        ///     Point cur           - текущее положение курсора
        ///     int screenWidth     - ширина экрана
        ///     Point Location      - положение окна
        /// </summary>
        public static Point MoveFormToLeft(Point cur, int screenWidth, Point Location)
        {
            Point loc = new Point(Location.X - 225 + rightHidewidth, Location.Y);
            if (formRightHide == true && cur.X < (screenWidth - 20))
            {
                formRightHide = false;
                return loc;     // Новое положение
            } 
            return Location; // Старое положение
        }


        /// <summary>
        /// Прячем форму при наведении курсора
        /// 
        /// Arguments:
        ///     int screenWidth     - ширина экрана
        ///     Point Location      - положение окна
        /// </summary>
        public static Point MoveFormToRight(int screenWidth, Point Location)
        {
            hideFormPos = new Point(screenWidth - FormAnimation.rightHidewidth, Location.Y);
            FormAnimation.formRightHide = true;
            return hideFormPos;     // Новое положение
        }
    }
}
