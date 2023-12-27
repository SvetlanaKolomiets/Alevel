using System;

Console.WriteLine("Write the number of elements in the array and press Enter:");
var userInput = Console.ReadLine();
int arrayLength = CheckUserInput(userInput);

int[] numbers = GenerateArray(arrayLength);
Console.WriteLine("Generated array:");
DisplayNumericArray(numbers);

int[] evenNumbers = GenerateArrayWithEvenNumbers(numbers);
Console.WriteLine();
Console.WriteLine("Array with even numbers:");
DisplayNumericArray(evenNumbers);

int[] oddNumbers = GenerateArrayWithOddNumbers(numbers);
Console.WriteLine();
Console.WriteLine("Array with odd numbers:");
DisplayNumericArray(oddNumbers);

string[] englishAlphabetEven = ReplaceNumbersWithLetters(evenNumbers);
Console.WriteLine();
Console.WriteLine("Array with even numbers replaced by the English alphabet:");
DisplayLettersArray(englishAlphabetEven);

string[] englishAlphabetOdd = ReplaceNumbersWithLetters(oddNumbers);
Console.WriteLine();
Console.WriteLine("Array with odd numbers replaced by the English alphabet:");
DisplayLettersArray(englishAlphabetOdd);

string[] withUppercaseLettersEven = ChangeLettersToUpperCase(englishAlphabetEven);
Console.WriteLine();
Console.WriteLine("First array with uppercase letters:");
DisplayLettersArray(withUppercaseLettersEven);

string[] withUppercaseLettersOdd = ChangeLettersToUpperCase(englishAlphabetOdd);
Console.WriteLine();
Console.WriteLine("Second array with uppercase letters:");
DisplayLettersArray(withUppercaseLettersOdd);

int numOfUppercaseLettersFirst = CheckHowManyUppercaseLetters(withUppercaseLettersEven);
int numOfUppercaseLettersSecond = CheckHowManyUppercaseLetters(withUppercaseLettersOdd);

Console.WriteLine();
CheckBiggerNumber(numOfUppercaseLettersFirst, numOfUppercaseLettersSecond);

int CheckUserInput(string? userInput)
{
    // This method parse user input. If it is a number then user input saved in arrayLength
    // variable and returned by this method. If it's not a number than error is displayed
    while (true)
    {
        if (int.TryParse(userInput, out int arrayLength))
        {
            return arrayLength;
        }
        else
        {
            Console.WriteLine("The entered value was not a number. Try again:");
            userInput = Console.ReadLine();
        }
    }
}

int[] GenerateArray(int userInput)
{
    // This method generate random numbers from 1 to 26 and put them into the array,
    // whose length is specified by the user
    int[] array = new int[userInput];
    Random random = new Random();
    for (int element = 0; element < array.Length; element++)
    {
        array[element] = random.Next(1, 27);
    }

    return array;
}

void DisplayNumericArray(int[] array)
{
    foreach (int element in array)
    {
        Console.Write($"{element} ");
    }
}

int[] GenerateArrayWithEvenNumbers(int[] array)
{
    int numOfEvenNumbers = 0;

    // Count how many even numbers in array and put this number of elements in
    // numOfEvenNumbers variable.
    int[] evenNumbers = new int[array.Length];
    for (int element = 0; element < array.Length; element++)
    {
        if (array[element] % 2 == 0)
        {
            evenNumbers[element] = array[element];
            numOfEvenNumbers++;
        }
    }

    int elementsWithoutZeros = 0;

    // Create arrayWithoutZeros with the same lenth as in numOfEvenNumbers variable.
    // Then, copy elements that are not equal to 0 to arrayWithoutZeros.
    // And return array with even numbers only without zeros.
    int[] arrayWithoutZeros = new int[numOfEvenNumbers];
    for (int element = 0; element < evenNumbers.Length; element++)
    {
        if (evenNumbers[element] != 0)
        {
            arrayWithoutZeros[elementsWithoutZeros] = evenNumbers[element];
            elementsWithoutZeros++;
        }
    }

    return arrayWithoutZeros;
}

int[] GenerateArrayWithOddNumbers(int[] array)
{
    int numOfOddNumbers = 0;

    // Count how many odd numbers in array and put this number of elements in
    // numOfOddNumbers variable.
    int[] oddNumbers = new int[array.Length];
    for (int element = 0; element < array.Length; element++)
    {
        if (array[element] % 2 != 0)
        {
            oddNumbers[element] = array[element];
            numOfOddNumbers++;
        }
    }

    int elementsWithoutZeros = 0;

    // Create arrayWithoutZeros with the same lenth as in numOfOddNumbers variable.
    // Then, copy elements that are not equal to 0 to arrayWithoutZeros.
    // And return array with odd numbers only without zeros.
    int[] arrayWithoutZeros = new int[numOfOddNumbers];
    for (int element = 0; element < oddNumbers.Length; element++)
    {
        if (oddNumbers[element] != 0)
        {
            arrayWithoutZeros[elementsWithoutZeros] = oddNumbers[element];
            elementsWithoutZeros++;
        }
    }

    return arrayWithoutZeros;
}

string[] ReplaceNumbersWithLetters(int[] array)
{
    // Replace numbers from the array with letters of the English alphabet using ASCII and
    // add these letters in the englishLetters array.
    // If the number in array equal to 1 it will be replaced by 'a',
    // if it's 2 it will be replaced by 'b' and so on
    string[] englishLetters = new string[array.Length];
    for (int element = 0; element < array.Length; element++)
    {
        char englishLetter = (char)('a' + array[element] - 1);
        englishLetters[element] = englishLetter.ToString();
    }

    return englishLetters;
}

void DisplayLettersArray(string[] array)
{
    foreach (string element in array)
    {
        Console.Write($"{element} ");
    }
}

string[] ChangeLettersToUpperCase(string[] array)
{
    // It letters "a","e","i","d","h","j" are present in array they will become uppercase letters.
    // If it's another letters they will remain lowercase.
    string[] uppercaseLetters = new string[array.Length];
    for (int element = 0; element < array.Length; element++)
    {
        if (array[element] == "a" || array[element] == "e" || array[element] == "i"
            || array[element] == "d" || array[element] == "h" || array[element] == "j")
        {
            string upper = array[element].ToUpper();
            uppercaseLetters[element] = upper;
        }
        else
        {
            uppercaseLetters[element] = array[element];
        }
    }

    return uppercaseLetters;
}

int CheckHowManyUppercaseLetters(string[] array)
{
    // Check how many uppercase letters in the array and return number of those letters
    int count = 0;
    foreach (string element in array)
    {
        if (element.All(char.IsUpper))
        {
            count++;
        }
    }

    return count;
}

void CheckBiggerNumber(int firstNumber, int secondNumber)
{
    Console.Write($"First array contains {firstNumber} uppercase letters, " +
            $"Second array contains {secondNumber} uppercase letters. ");
    if (firstNumber > secondNumber)
    {
        Console.Write($"First array contains more uppercase letters.");
    }
    else if (firstNumber < secondNumber)
    {
        Console.Write($"Second array contains more uppercase letters.");
    }
    else if (firstNumber == 0 && secondNumber == 0)
    {
        Console.Write($"Arrays don't contain uppercase letters.");
    }
    else
    {
        Console.Write($"Arrays contain the same number of uppercase letters.");
    }
}