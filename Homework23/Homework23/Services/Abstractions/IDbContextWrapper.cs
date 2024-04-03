using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Homework23.Services.Abstractions
{
    public interface IDbContextWrapper<T>
    where T : DbContext
    {
        T DbContext { get; }
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}

