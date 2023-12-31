// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Utilities.CommonPurposeMethods.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the <see cref="Person"/> class.
/// </summary>
public static partial class PersonGenerator
{
    private static bool GetRandomBooleanValue() => Random.Shared.Next() > int.MaxValue / 2;

    private static byte GetRandomDigit() => Convert.ToByte(Random.Shared.Next(0, 10));
}
