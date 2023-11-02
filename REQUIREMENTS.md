# Requirements to This Project

This document describes the initial requirements to an implementation of this project.

These requirements defines the minimal set of software features to match the test project level.

## :pencil: Initial Requirements

### :small_orange_diamond: Core Requirements

Create a program which will execute the next steps:

1. Create a collection of randomly generated objects in-memory by provided models, the number of objects is 10000.

2. Serialize it to JSON format.

3. Write the serialization result to the current user desktop directory, the text file name should be "Persons.json".

4. Clear the in-memory collection;

5. Read objects from the file.

6. Display in console the count of persons, persons' credit card count, and the average value of the child age.

### :small_orange_diamond: Extra Requirements

- Use POSIX format for dates.
- Use lowerCamelCase JSON notation in the result file.

### :small_orange_diamond: Required Data Models

The **Person** type definition:

    class Person
    {
        public Int32 Id { get; set; }
        public Guid TransportId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 SequenceId { get; set; }
        public String[] CreditCardNumbers { get; set; }
        public Int32 Age { get; set; }
        public String[] Phones { get; set; }
        public Int64 BirthDate { get; set; }
        public Double Salary { get; set; }
        public Boolean IsMarried { get; set; }
        public Gender Gender { get; set; }
        public Child[] Children { get; set; }
    }

The **Child** type definition:

    class Child
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 BirthDate { get; set; }
        public Gender Gender { get; set; }
    }

The **Gender** type definition:

    enum Gender
    {
        Male,
        Female
    }

---

## :pencil2: Changes of Initial Requirements

This section describes changes of initial requirements made by me when creating the project:

- Properties of predefined models were defined via built-in C# keywords for data types.
- The TransportId property of the Person class were used as the key for its EF Core entity.
- There was added the Guid property to the Child class definition to be the key for its EF Core entity.
- The data type for the CreditCardNumbers, Phones, Children properties of the Person class was replaced from the array type to the generic List collection type to resolve problems when creating EF Core entities for the database context.
- There were created the CreditCard and the PhoneNumber record types for the CreditCardNumbers an the Phones properties of the Person class to define correct entities for creating the database context via EF Core.
- There was changed the data type for the Salary property of the Person class from the System.Double to the [System.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal?view=net-6.0) (the decimal type is the safe primitive types for money calculation).
- There was changed the data type for the Age property of the Person class from signed integer to the [System.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0) unsigned integer as a better data type to represent human age in years.

---
