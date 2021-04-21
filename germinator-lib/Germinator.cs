using System;
using System.Collections.Generic;

namespace germinator_lib
{
    public class Germinator
    {
        private ValueTuple<int, int> _currentPosition;
        private HashSet<ValueTuple<int, int>> _cleanedTiles = new HashSet<ValueTuple<int, int>>();

		
        public Germinator(int startX, int startY)
        {
            EnterTile(startX, startY);
        }

        public int NumberOfTilesCleaned => _cleanedTiles.Count;

        public void Move(char direction, int steps)
        {
            var (startX, startY) = _currentPosition;

            switch (direction)
            {
                case 'N':
                    for (var i = 1; i <= steps; i++)
                    {
                        EnterTile(startX, startY + i);
                    }
                    break;
                case 'S':
                    for (var i = 1; i <= steps; i++)
                    {
                        EnterTile(startX, startY - i);
                    }
                    break;
                case 'W':
                    for (var i = 1; i <= steps; i++)
                    {
                        EnterTile(startX - i, startY);
                    }
                    break;
                case 'E':
                    for (var i = 1; i <= steps; i++)
                    {
                        EnterTile(startX + i, startY);
                    }
                    break;
            }
        }

        private void EnterTile(int x, int y)
        {
            var position = new ValueTuple<int, int>(x, y);
            if (!_cleanedTiles.Contains(position))
            {
                _cleanedTiles.Add(position);
            }

            _currentPosition = position;
        }
    }
}
