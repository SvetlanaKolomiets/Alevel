using Homework18.Dtos;

namespace Homework18.Services.Abstractions
{
	public interface IResourceService
	{
        Task<ResourceDto[]> GetResourceList();
        Task<ResourceDto> GetResourceById(int id);
    }
}

