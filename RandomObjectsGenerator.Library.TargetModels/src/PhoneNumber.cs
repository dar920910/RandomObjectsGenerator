// ---------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumber.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a phone number owned by a person.
/// </summary>
public record PhoneNumber
{
    /// <summary>
    /// Gets or sets the phone code in the numeric format.
    /// </summary>
    [Key]
    public string NumericCode { get; set; }

    /// <summary>
    /// Gets or sets the full name of the owner of the phone number.
    /// </summary>
    public string OwnerFullName { get; set; }
}
