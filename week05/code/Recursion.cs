using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        //1  base case (detiene la ejecucion para que no sea infinita)
        if (n <= 0)
            return 0;
        //2 recursive case (recursividad: hacer mas pequeño el problema)
        return n * n + SumSquaresRecursive(n - 1);
     //imaginate que n es 5, entonces seria  5x5+sumSquaresRecursive(4)
    //llamada1 :(n=5 osea 5x5)=25, guarda el 25 y llama a sumSquaresRecursive(4)osea espera el resultado de n=4
    //llamada2 :(n=4)=16, guarda el 16 y llama a sumSquaresRecursive(3)osea espera el resultado de n=3
    //llamada3 :(n=3)=9, guarda el 9 y llama a sumSquaresRecursive(2)osea espera el resultado de n=2
    //llamada4 :(n=2)=4, guarda el 4 y llama a sumSquaresRecursive(1)osea espera el resultado de n=1
    //llamada5 :(n=1)=1, guarda el 1 y llama a sumSquaresRecursive(0)osea espera el resultado de n=0
    //llamada6 :(n=0)=0, guarda el 0 y como es el caso base, regresa 0 a la llamada5
    //Los resultado rebotas hacia arriba, (a)n=1 recibe el 0 y dice: 1+0 =1, 
    //(b)n=2 recibe el 1 y dice:4+1=5, (c)n=3 recibe el 5 y dice:9+5=14, (d)n=4 recibe el 14 y dice:16+14=30, (e)n=5 recibe el 30 y dice:25+30=55, entonces el resultado final es 55
    } 


    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // 1. Caso Base: Si el tamaño es 0, significa que la palabra está completa
    if (size == 0)
    {
        results.Add(word); // Guardamos la palabra armada en la lista de resultados
        return;
    }

    // 2. Caso Recursivo: Probar cada letra disponible
    for (int i = 0; i < letters.Length; i++)
    {
        // Elegimos la letra actual
        string charSelected = letters[i].ToString();

        // Creamos un nuevo string con las letras que quedan (quitando la que elegimos)
        // Usamos [..i] para lo que está antes y [i+1..] para lo que está después
        string remainingLetters = letters[..i] + letters[(i + 1)..];

        // Llamada recursiva:
        // - Pasamos las letras que sobran
        // - Restamos 1 al tamaño que falta llenar (size - 1)
        // - Le pegamos la letra elegida a la palabra que estamos armando
        PermutationsChoose(results, remainingLetters, size - 1, word + charSelected);
    }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        //1 inicializar el dicc si es la primera vez que se llama a la funcion
        if (remember == null)
            remember = new Dictionary<int, decimal>();  

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;
        
        // 2. Revisar la libreta (Check memo)
        if (remember.ContainsKey(s))
        return remember[s];

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways; // Guardar el resultado en la libreta (memo)
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        //buscar la priemra estrella
        int index = pattern.IndexOf('*');
        //2- caso base: si no hay estrellas, entonces el patron es un string binario completo
        if (index == -1)        {
            results.Add(pattern); // Guardamos el patrón completo en la lista de resultados
            return;
        }   
        //3- paso recursivo
        //creo dos nuevas versiones reemplazando la estrella en index 
        string patternWithZero = pattern[..index] + '0' + pattern[(index + 1)..];
        string patternWithOne = pattern[..index] + '1' + pattern[(index + 1)..];
        WildcardBinary(patternWithZero, results);
        WildcardBinary(patternWithOne, results);        
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        //1- Anadir la posicion actual a la ruta actual (currPath)
        currPath.Add((x,y));
        //2- Revisar si la posicion actual es el final, si es asi, anadir la ruta a los resultados
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
        // 3- Si no es el final, revisar las posiciones adyacentes
            if (maze.IsValidMove(currPath, x + 1, y)) // Derecha
                SolveMaze(results, maze, x + 1, y, currPath);

            if (maze.IsValidMove(currPath, x - 1, y)) // Izquierda
                SolveMaze(results, maze, x - 1, y, currPath);

            if (maze.IsValidMove(currPath, x, y + 1)) // Abajo
                SolveMaze(results, maze, x, y + 1, currPath);

            if (maze.IsValidMove(currPath, x, y - 1)) // Arriba
                SolveMaze(results, maze, x, y - 1, currPath);
        }
        //4- Antes de regresar de la funcion, remover la posicion actual de la ruta actual (backtracking)
        currPath.RemoveAt(currPath.Count - 1);

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}