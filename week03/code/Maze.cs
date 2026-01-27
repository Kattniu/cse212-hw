/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {   //el indice 0 es left, moverse a la izquierda resta 1 a la x
        if(_mazeMap[(_currX, _currY)][0]) //left
        {
            _currX--; //mover a la izquierda
        }
        else
        {   //si no se puede mover a la izquierda
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight() //el indice 1 es right, moverse a la derecha suma 1 a la x
    {
        if (_mazeMap[(_currX, _currY)][1]) //right
        {
            _currX++; //mover a la derecha
        }
        else
        {   //si no se puede mover a la derecha
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        //el indice 2 es up, moverse hacia arriba resta 1 a la y
        if (_mazeMap[(_currX, _currY)][2]) //up
        {
            _currY--; //mover hacia arriba
        }
        else
        {   //si no se puede mover hacia arriba
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown() //el indice 1 es right, moverse a la derecha suma 1 a la x
    {
        //el indice 3 es down, moverse hacia abajo suma 1 a la y
        if (_mazeMap[(_currX, _currY)][3]) //down
        {
            _currY++; //mover hacia abajo
        }
        else
        {   //si no se puede mover hacia abajo
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}