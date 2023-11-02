// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.CreditCards.cs" company="Demo Projects Workshop">
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
    private static List<CreditCard> GetRandomCreditCards(string personFirstName, string personLastName)
    {
        List<CreditCard> personCreditCards = new ();

        string[] creditCardsNumbers = GetRandomCardNumbers();
        foreach (var cardNumber in creditCardsNumbers)
        {
            CreditCard creditCard = new ()
            {
                OwnerFullName = $"{personFirstName} {personLastName}",
                NumericID = cardNumber,
            };

            personCreditCards.Add(creditCard);
        }

        return personCreditCards;
    }

    private static string[] GetRandomCardNumbers()
    {
        const byte minumumCreditCardsCount = 1;
        const byte maximumCreditCardsCount = 10;

        int creditCardsCount = Random.Shared.Next(minumumCreditCardsCount, maximumCreditCardsCount);

        List<string> creditCards = new ();

        for (int cardIndex = 0; cardIndex < creditCardsCount; cardIndex++)
        {
            string card = GetRandomCardNumber();
            creditCards.Add(card);
        }

        return creditCards.ToArray();
    }

    private static string GetRandomCardNumber()
    {
        byte cardDigit_01 = GetRandomDigit();
        byte cardDigit_02 = GetRandomDigit();
        byte cardDigit_03 = GetRandomDigit();
        byte cardDigit_04 = GetRandomDigit();
        byte cardDigit_05 = GetRandomDigit();
        byte cardDigit_06 = GetRandomDigit();
        byte cardDigit_07 = GetRandomDigit();
        byte cardDigit_08 = GetRandomDigit();
        byte cardDigit_09 = GetRandomDigit();
        byte cardDigit_10 = GetRandomDigit();
        byte cardDigit_11 = GetRandomDigit();
        byte cardDigit_12 = GetRandomDigit();
        byte cardDigit_13 = GetRandomDigit();
        byte cardDigit_14 = GetRandomDigit();
        byte cardDigit_15 = GetRandomDigit();
        byte cardDigit_16 = GetRandomDigit();

        string cardNumberPart_1 = $"{cardDigit_01}{cardDigit_02}{cardDigit_03}{cardDigit_04}";
        string cardNumberPart_2 = $"{cardDigit_05}{cardDigit_06}{cardDigit_07}{cardDigit_08}";
        string cardNumberPart_3 = $"{cardDigit_09}{cardDigit_10}{cardDigit_11}{cardDigit_12}";
        string cardNumberPart_4 = $"{cardDigit_13}{cardDigit_14}{cardDigit_15}{cardDigit_16}";

        return $"{cardNumberPart_1} {cardNumberPart_2} {cardNumberPart_3} {cardNumberPart_4}";
    }
}
