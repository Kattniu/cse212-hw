public class Node
{
    //aqui se guardara el valor del nodo
    public int Data { get; set; }
    //hijos izquierdo y derecho
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }


    //constructor del nodo
    public Node(int data)
    {
        this.Data = data;
    }
    //Osea, cuando se crea un nodo, se le asigna un valor y sus hijos son nulos (no tiene hijos) 

    //metodo importante (Insert) para insertar un nuevo valor en el arbol, siguiendo las reglas del arbol binario de busqueda
    public void Insert(int value)
    {

        //primera decision
        if (value < Data)
        //El valor nuevo es menor que el valor actual del nodo actual?
        {
            // Insert to the left, si el valor nuevo es menor, se inserta a la izquierda
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
            //Si ya existe, sigue bajando por el lado izquierdo hasta encontrar un lugar para insertar el nuevo valor
        }

        //este valor es mayor que el valor actual del nodo actual?
        else if (value > Data)
        //else <--- este else inluye valores mayores y menores ✖️
        {     //Es decir si insertas 10 dos veces, el arbol tendra dos 10 
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    //METODO para buscar un valor en el arbol
    //CONTAINS, Jamas guarda nada, aunque vea un espacio vacio, no inserta.
    public bool Contains(int value)
    {
        // 1. ¿Es el valor que tengo yo (el nodo actual)?
        if (value == Data)
        {
            return true; //si el valor que estoy buscando es igual al valor del nodo actual, entonces lo encontré
        }                  //y ya no se ejecuta lo demas!

        // 2. Si es menor, busco a mi izquierda
        if (value < Data)
        { //como 3<5,es verdad, entramos a ese bloque de codigo 
           //ESCENARIO 1: No hay nadie      
            if (Left is null) //Si left es null significa que el camino se acabo. 
                return false; // Si no hay nadie a la izquierda, no existe
           //ESCENARIO 2: Hay otro nodo
            else //ejemplo un 2, si left no es nulo, entonces 5 le dice al 2 de buscar al 3 
                return Left.Contains(value); // ¡Recursividad! Le pregunto a mi hijo
        }
        // 3. Si es mayor, busco a mi derecha
        else
        {
            if (Right is null)
                return false; // Si no hay nadie a la derecha, no existe
            else
                return Right.Contains(value); // ¡Recursividad! Le pregunto a mi hijo
            //Le pregunto al hijo derecho si él tiene el valor, y devuelvo lo que me diga
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // 1. Preguntamos la altura de la izquierda (si no hay, es 0)
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        // 2. Preguntamos la altura de la derecha (si no hay, es 0)
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();
        // 3. El resultado es 1 (yo mismo) + el camino más largo que encontramos
        return 1 + Math.Max(leftHeight, rightHeight);
        //return 0; // Replace this line with the correct return statement(s)
    }
}