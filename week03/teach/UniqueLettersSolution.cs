public static class UniqueLettersSolution
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));
        Console.WriteLine(AreUniqueLettersAlternate(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));
        Console.WriteLine(AreUniqueLettersAlternate(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
        Console.WriteLine(AreUniqueLettersAlternate(test3));
    }

    /**
     * <summary>Determine if there are any duplicate letters in the text provided</summary>
     * <param name="text">Text to check for duplicate letters</param>
     * <returns>true if all letters are unique, otherwise false</returns>
     */
    private static bool AreUniqueLetters(string text)
    {
        var found = new HashSet<char>(); //Aqui iniciamos un conjunto vacio para guardar las letras encontradas
        foreach (var letter in text) // Recorremos cada letra en el texto proporcionado solo una vez
        {
            // Look in set to see if letter was seen before
            if (found.Contains(letter)) // Si la letra ya esta en el conjunto, significa que es un duplicado
                return false; // We found a duplicate letter, so return false
            // Otherwise we will add it to the set and move on
            found.Add(letter); // Agregamos la letra al conjunto de letras encontradas
        }

        return true; // Si terminamos de recorrer el texto sin encontrar duplicados, todas las letras son unicas
    }

    /**
     * <summary>Determine if there are any duplicate letters in the text provided</summary>
     * <param name="text">Text to check for duplicate letters</param>
     * <returns>true if all letters are unique, otherwise false</returns>
     */
    private static bool AreUniqueLettersAlternate(string text)
    {
        var unique = new HashSet<char>(text);
        return unique.Count == text.Length;
    }
}