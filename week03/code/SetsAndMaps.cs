using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //Este HashSet nos ayuda a almacenar las palabras que ya hemos visto
        var vistos = new HashSet<string>();
        //Esta lista nos ayuda a almacenar los resultados que vamos a devolver
        var resultados = new List<string>();
        //Iteramos a través de cada palabra en el arreglo de palabras
        foreach (var palabra in words) {
            //Si las dos letras de la palabra son iguales, continuamos con la siguiente iteración
            if (palabra[0] == palabra[1])
            continue;
            //Creamos la palabra reversa invirtiendo las letras de la palabra actual
            string reversa = "" + palabra[1] + palabra[0];
            //Verificamos si la palabra reversa ya ha sido vista
            if (vistos.Contains(reversa)) {
                //Si es así, agregamos el par simétrico a los resultados
                resultados.Add($"{reversa} & {palabra}");
            // Si no ha sido vista, agregamos la palabra actual al conjunto de vistos
            } else {
                vistos.Add(palabra);//guardo la palabra actual en el conjunto de vistos
            }
    }
    //Convertimos la lista de resultados a un arreglo y lo devolvemos
    return resultados.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // 1. Creamos el diccionario vacío. 
        // La llave es string (nombre del título) y el valor es int (el contador).
        var degrees = new Dictionary<string, int>();
        // 2. Leemos el archivo línea por línea.
        foreach (var line in File.ReadLines(filename))
        {
            // 3. Cortamos la línea en cada coma para separar las columnas
            var fields = line.Split(",");
            // 4. El problema dice que el título está en la columna 4.
            // En programación, empezamos a contar desde 0, así que la col 4 es el índice [3].
            string degree = fields[3].Trim(); // Trim() quita espacios extra por si acaso

            // 5. Lógica del contador:
            if (degrees.ContainsKey(degree)) {
                //antes de sumar, preguntamos si la llave de ese titulo ya existe en el diccionario
                // Si ya existe el título en el diccionario, le sumamos 1 al número que ya tenía
                degrees[degree] = degrees[degree] + 1; // o degrees[degree] ++;
            } else {
                // Si es la primera vez que vemos este título, lo agregamos con el valor 1
                degrees[degree] = 1;
            }
        }
        // 6. Devolvemos el diccionario lleno con todos los conteos
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}