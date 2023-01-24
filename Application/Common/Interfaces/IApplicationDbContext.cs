using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Reply> Replies { get; }

    DbSet<Topic> Topics { get; }

    DbSet<Section> Sections { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
