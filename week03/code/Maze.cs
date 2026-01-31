using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int x, int y), bool[]> _maze;
    private (int x, int y) _currentPosition;

    public Maze(Dictionary<(int, int), bool[]> maze)
    {
        _maze = maze;
        _currentPosition = (1, 1);
        Console.WriteLine($"Maze created. Start at {_currentPosition}");
    }

    public (int x, int y) CurrentPosition => _currentPosition;

    public string GetStatus() => $"Current location (x={_currentPosition.x}, y={_currentPosition.y})";

    public void MoveLeft()
    {
        Console.WriteLine($"Attempting MoveLeft from {_currentPosition}. Left allowed: {_maze[_currentPosition][0]}");
        if (!_maze[_currentPosition][0])
            throw new InvalidOperationException("Can't go that way!");
        _currentPosition = (_currentPosition.x - 1, _currentPosition.y);
        Console.WriteLine($"Moved to {_currentPosition}");
    }

    public void MoveRight()
    {
        Console.WriteLine($"Attempting MoveRight from {_currentPosition}. Right allowed: {_maze[_currentPosition][1]}");
        if (!_maze[_currentPosition][1])
            throw new InvalidOperationException("Can't go that way!");
        _currentPosition = (_currentPosition.x + 1, _currentPosition.y);
        Console.WriteLine($"Moved to {_currentPosition}");
    }

    public void MoveUp()
    {
        Console.WriteLine($"Attempting MoveUp from {_currentPosition}. Up allowed: {_maze[_currentPosition][2]}");
        if (!_maze[_currentPosition][2])
            throw new InvalidOperationException("Can't go that way!");
        _currentPosition = (_currentPosition.x, _currentPosition.y + 1);
        Console.WriteLine($"Moved to {_currentPosition}");
    }

    public void MoveDown()
    {
        Console.WriteLine($"Attempting MoveDown from {_currentPosition}. Down allowed: {_maze[_currentPosition][3]}");
        if (!_maze[_currentPosition][3])
            throw new InvalidOperationException("Can't go that way!");
        _currentPosition = (_currentPosition.x, _currentPosition.y - 1);
        Console.WriteLine($"Moved to {_currentPosition}");
    }
}