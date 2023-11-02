// ---------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.DatabaseContext.InMemory;

using Microsoft.EntityFrameworkCore;
using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the database in-memory context for the storage of generated objects.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Gets or sets the storage which can be used to query and save instances of the <see cref="Person"/> class.
    /// </summary>
    public DbSet<Person> Persons { get; set; }

    /// <summary>
    /// Implements actions when configuring the database context.
    /// </summary>
    /// <param name="optionsBuilder">Builder options for the database context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "RandomObjectsDatabase");
    }
}
