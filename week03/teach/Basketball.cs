/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");//abre el archivo basketball.csv
        reader.TextFieldType = FieldType.Delimited; //indica que los campos están delimitados
        reader.SetDelimiters(","); //indica que el delimitador es la coma, indica separador entre columnas
        reader.ReadFields(); // ignore header row, leer la primera fila (encabezados) y no hacer nada con ella (lo ignora)
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!; 
            var playerId = fields[0]; // Player ID está en la columna 0
            var points = int.Parse(fields[8]); // Points está en la columna 8 y lo convertimos a entero
            
            if (players.ContainsKey(playerId)) //Si el jugador ya está en el diccionario
                players[playerId] += points; //sumamos los puntos a los puntos existentes
            else
                players[playerId] = points; //Si no está, lo agregamos con sus puntos iniciales
        }

        Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        var topPlayers = new string[10];
    }
}