using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		private static int horizontalIntersectionLength;
		private static int verticalIntersectionLength;

		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			horizontalIntersectionLength = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
			verticalIntersectionLength = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);
			return horizontalIntersectionLength >= 0 && verticalIntersectionLength >= 0;					
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1, r2))
            {
				int area = horizontalIntersectionLength * verticalIntersectionLength;
				return area;
			}	
			else return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			bool areIntersected = AreIntersected(r1, r2);
			if (!areIntersected)
				return -1;
			if (r1.Top >= r2.Top && r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom)
				return 0;
			if (r2.Top >= r1.Top && r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom)
				return 1;
			else return -1;			
		}
	}
}