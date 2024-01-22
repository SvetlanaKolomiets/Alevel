using Homework8.Entities;
namespace Homework8.Repositories.Abstractions
{
	public interface IVegetablesRepository
	{
		VegetableEntity[] GenerateVegetables();
		VegetableEntity GetVegetableByIndex(int index);
    }
}

