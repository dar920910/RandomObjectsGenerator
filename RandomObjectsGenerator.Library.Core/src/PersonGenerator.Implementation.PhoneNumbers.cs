//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.PhoneNumbers.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the <see cref="Person"/> class.
/// </summary>
public static partial class PersonGenerator
{
    private static string[] GetRandomPhoneNumbers()
    {
        const byte minumumPhonesCount = 1;
        const byte maximumPhonesCount = 10;

        int creditCardsCount = Random.Shared.Next(minumumPhonesCount, maximumPhonesCount);

        List<string> phones = new ();

        for (int phoneIndex = 0; phoneIndex < creditCardsCount; phoneIndex++)
        {
            string phone = GetRandomPhone();
            phones.Add(phone);
        }

        return phones.ToArray();
    }

    private static string GetRandomPhone()
    {
        byte phoneDigit_00 = GetRandomDigit();
        byte phoneDigit_01 = GetRandomDigit();
        byte phoneDigit_02 = GetRandomDigit();
        byte phoneDigit_03 = GetRandomDigit();
        byte phoneDigit_04 = GetRandomDigit();
        byte phoneDigit_05 = GetRandomDigit();
        byte phoneDigit_06 = GetRandomDigit();
        byte phoneDigit_07 = GetRandomDigit();
        byte phoneDigit_08 = GetRandomDigit();
        byte phoneDigit_09 = GetRandomDigit();
        byte phoneDigit_10 = GetRandomDigit();

        string phoneNumberPart_1 = $"{phoneDigit_01}{phoneDigit_02}{phoneDigit_03}";
        string phoneNumberPart_2 = $"{phoneDigit_04}{phoneDigit_05}{phoneDigit_06}";
        string phoneNumberPart_3 = $"{phoneDigit_07}{phoneDigit_08}";
        string phoneNumberPart_4 = $"{phoneDigit_09}{phoneDigit_10}";

        return $"+{phoneDigit_00} {phoneNumberPart_1}-{phoneNumberPart_2}-{phoneNumberPart_3}-{phoneNumberPart_4}";
    }
}
