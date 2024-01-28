﻿using Homework8.Enums;

namespace Homework8.Models
{
	public class Сucumber : PumpkinVegetable
	{
        public double Calories { get; set; }

        public Сucumber(string name, int weight, ShapeType shape, string color, double calories) :
            base(name, weight, shape, color)
        {
            Calories = calories;
        }
	}
}

