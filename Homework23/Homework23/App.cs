using Homework23.Services.Abstractions;

namespace Homework23
{
    public class App
    {
        private readonly IBreedService _breedService;
        private readonly IPetService _petService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;

        public App(
            IBreedService breedService,
            IPetService petService,
            ILocationService locationService,
            ICategoryService categoryService)
        {
            _breedService = breedService;
            _petService = petService;
            _locationService = locationService;
            _categoryService = categoryService;
        }

        public async Task Start()
        {
            var categoryName1 = "Cat";
            var categoryName2 = "Dog";

            var category1 = await _categoryService.AddCategoryAsync(categoryName1);
            var category2 = await _categoryService.AddCategoryAsync(categoryName2);

            var locationName1 = "Ukraine";
            var locationName2 = "Poland";

            var location1 = await _locationService.AddLocationAsync(locationName1);
            var location2 = await _locationService.AddLocationAsync(locationName2);

            var breedName1 = "Sphynx";
            var breedName2 = "Bulldog";
            var breedName3 = "Siamese";

            var breed1 = await _breedService.AddBreedAsync(breedName1, category1);
            var breed2 = await _breedService.AddBreedAsync(breedName2, category2);
            var breed3 = await _breedService.AddBreedAsync(breedName3, category1);

            var pet1 = await _petService.AddPetAsync("Pushok", category1, breed1, location1, 5);
            var pet2 = await _petService.AddPetAsync("Barsik", category2, breed2, location1, 4);
            var pet3 = await _petService.AddPetAsync("Dymok", category1, breed3, location2, 2);

            await _petService.GetPetAsync(pet1);
            await _petService.GetPetAsync(pet2);
            await _petService.GetPetAsync(pet3);

            await _petService.UpdatePetAsync(8, "Pushok", category1, breed1, location1, 6, "http://surl.li/sfbbh", "Cat");

            await _petService.GetPetByCategoryDto();

            await _petService.DeletePetAsync(10);
        }
    }
}
