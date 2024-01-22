using Homework8.Models;

namespace Homework8.Services.Abstractions
{
	public interface ISaladService
	{
        Vegetable ChooseVegetable();
        int ChooseVegetableQuantity();
        int CalculateTotalWeight();
        Vegetable[] MakeASalad();
        void AddToASalad(Vegetable vegetable, int quantity);
        bool CheckIfUserWantToContinue();
        double CalculateCalories(Vegetable vegetable);
    }
}

