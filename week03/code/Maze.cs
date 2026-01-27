public class Maze
{
    private Dictionary<(int x, int y), (bool Left, bool Right, bool Up, bool Down)> _maze;
    private (int x, int y) _currentPosition;

    public Maze(
        Dictionary<(int x, int y), (bool Left, bool Right, bool Up, bool Down)> maze,
        (int x, int y) startPosition)
    {
        _maze = maze;
        _currentPosition = startPosition;
    }

    public (int x, int y) CurrentPosition => _currentPosition;

    public void MoveLeft()
    {
        if (_maze[_currentPosition].Left)
        {
            _currentPosition = (_currentPosition.x - 1, _currentPosition.y);
        }
    }

    public void MoveRight()
    {
        if (_maze[_currentPosition].Right)
        {
            _currentPosition = (_currentPosition.x + 1, _currentPosition.y);
        }
    }

    public void MoveUp()
    {
        if (_maze[_currentPosition].Up)
        {
            _currentPosition = (_currentPosition.x, _currentPosition.y + 1);
        }
    }

    public void MoveDown()
    {
        if (_maze[_currentPosition].Down)
        {
            _currentPosition = (_currentPosition.x, _currentPosition.y - 1);
        }
    }
}
