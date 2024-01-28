using Homework8.Entities;
using Homework8.Models;

namespace Homework8.Services.Abstractions
{
	public interface IVegetableService
	{
        void PrintVegetables();
        Vegetable GetVegetableByNumber(int number);
        Vegetable ChooseVegetable();
        public int ChooseVegetableQuantity();
        VegetableEntity[] GenerateVegetables();
        VegetableEntity GetVegetableEntity(int number);
        void SearchForAVegetable();
    }
}

