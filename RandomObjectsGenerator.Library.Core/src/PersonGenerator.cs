//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.cs" company="Demo Projects Workshop">
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
    static PersonGenerator()
    {
        TestFemaleFirstNamesPlaceholders = GenerateFemaleFirstNames();
        TestMaleFirstNamesPlaceholders = GenerateMaleFirstNames();
        TestLastNamesPlaceholders = GenerateLastNames();
    }

    /// <summary>
    /// Generates a random instance of the Person class.
    /// </summary>
    /// <param name="personId">The unique identifier of the instance.</param>
    /// <returns>A randomly generated instance of the Person class.</returns>
    public static Person CreateRandomPerson(int personId)
    {
        bool isFemale = GetRandomBooleanValue();
        Gender personGender = isFemale ? Gender.Female : Gender.Male;
        byte personAge = GetRandomAdultAgeInYears(personGender);
        long personBirthDate = GetRandomBirthDate(personAge);

        string personFirstName = GetRandomFirstNamePlaceholder(personGender);
        string personLastName = GetRandomLastNamePlaceholder();

        string[] creditCardsNumbers = GetRandomCreditCardsNumbers();
        List<CreditCard> personCreditCards = new ();
        foreach (var cardNumber in creditCardsNumbers)
        {
            CreditCard creditCard = new ()
            {
                OwnerFullName = personFirstName + " " + personLastName,
                NumericID = cardNumber,
            };

            personCreditCards.Add(creditCard);
        }

        string[] personPhones = GetRandomPhoneNumbers();
        List<PhoneNumber> personPhoneNumbers = new ();
        foreach (var phoneNumber in personPhones)
        {
            PhoneNumber phone = new ()
            {
                OwnerFullName = personFirstName + " " + personLastName,
                NumericCode = phoneNumber,
            };

            personPhoneNumbers.Add(phone);
        }

        decimal personSalary = GetRandomMonthlySalarySizeInRussianRubles();

        bool isMarriedPerson = GetRandomBooleanValue();

        byte personChildrenCount = GetRandomChildrenCount();
        List<Child> personChildren = GetRandomChildren(personChildrenCount, personLastName);

        return new Person()
        {
            Id = personId,
            SequenceId = personId,

            Gender = personGender,
            Age = personAge,
            BirthDate = personBirthDate,

            FirstName = personFirstName,
            LastName = personLastName,

            CreditCardNumbers = personCreditCards,
            Phones = personPhoneNumbers,
            Salary = personSalary,
            TransportId = Guid.NewGuid(),

            IsMarried = isMarriedPerson,
            Children = personChildren,
        };
    }
}
