// ---------------------------------------------------------------------------------------------------------
// <copyright file="CreditCard.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a credit card owned by a person.
/// </summary>
public record CreditCard
{
    /// <summary>
    /// Gets or sets the numeric identifier of the credit card.
    /// </summary>
    [Key]
    public string NumericID { get; set; }

    /// <summary>
    /// Gets or sets the full name of the owner of the credit card.
    /// </summary>
    public string OwnerFullName { get; set; }
}
