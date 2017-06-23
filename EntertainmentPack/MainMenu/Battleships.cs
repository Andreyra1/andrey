using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Battleships
    {
        public enum State { Empty, Miss, Alive, Damaged, Dead }

        public enum Direction { Left, Right, Up, Down, Null }


        static public bool NextShip(ref int horizontal, ref int vertical, ref int shipAmmount)
        {
            shipAmmount++;
            switch (shipAmmount)
            {
                case 0: horizontal = 4; vertical = 1; return true;
                case 1: case 2: horizontal = 3; vertical = 1; return true;
                case 3: case 4: case 5: horizontal = 2; vertical = 1; return true;
                case 6: case 7: case 8: case 9: horizontal = 1; vertical = 1; return true;
                default: return false;
            }
        }

        static public void NullArray(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        static public void Rotate(ref int horizontal, ref int vertical)
        {
            int buf = 0;
            buf = vertical;
            vertical = horizontal;
            horizontal = buf;
        }

        static public void SetShip(ref int[,] array, int x, int y, bool alive, int horizontal, int vertical)
        {
            x++;
            y++;
            for (int i = x; i < x + horizontal; i++)
            {
                for (int j = y; j < y + vertical; j++)
                {
                    if (alive == true)
                    {
                        array[i, j] = (int)State.Alive;
                    }
                    else
                    {
                        array[i, j] = (int)State.Dead;
                    }
                }
            }
            for (int i = x - 1; i < x + horizontal + 1; i++)
            {
                for (int j = y - 1; j < y + vertical + 1; j++)
                {
                    if (array[i, j] != (int)State.Alive && array[i, j] != (int)State.Dead)
                        array[i, j] = (int)State.Miss;
                }
            }
        }

        static public bool CheckPlace(int x, int y, int horizontal, int vertical, int[,] array, ref bool place)
        {
            for (int i = x + 1; i < x + horizontal + 1; i++)
            {
                for (int j = y + 1; j < y + vertical + 1; j++)
                {
                    if (array[i, j] != 0)
                    {
                        place = false;
                        return false;
                    }
                }
            }
            place = true;
            return true;
        }

        static public void ShootingMode(ref int[,] array)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (array[i, j] == 1)
                    {
                        array[i, j] = 0;
                    }
                }
            }
        }

        static public bool CheckShipState(int x, int y, int[,] array)
        {
            Direction direction1 = Direction.Null;
            Direction direction2 = Direction.Null;
            if (FindDirection(x, y, array, ref direction1, ref direction2) == true)
                return true;
            else
                return false;
        }

        static public bool FindDirection(int x, int y, int[,] array, ref Direction direction1, ref Direction direction2)
        {
            if (array[x + 2, y + 1] == (int)State.Alive || array[x + 2, y + 1] == (int)State.Damaged)
            {
                if (direction1 == Direction.Null)
                    direction1 = Direction.Right;
                else
                    direction2 = Direction.Right;

            }
            if (array[x, y + 1] == (int)State.Alive || array[x, y + 1] == (int)State.Damaged)
            {
                if (direction1 == Direction.Null)
                    direction1 = Direction.Left;
                else
                    direction2 = Direction.Left;
            }
            if (array[x + 1, y] == (int)State.Alive || array[x + 1, y] == (int)State.Damaged)
            {
                if (direction1 == Direction.Null)
                    direction1 = Direction.Up;
                else
                    direction2 = Direction.Up;
            }
            if (array[x + 1, y + 2] == (int)State.Alive || array[x + 1, y + 2] == (int)State.Damaged)
            {
                if (direction1 == Direction.Null)
                    direction1 = Direction.Down;
                else
                    direction2 = Direction.Down;
            }
            if (CheckDirection(x, y, array, ref direction1, ref direction2, State.Alive) == true)
                return true;
            else
                return false;
        }

        static public void FindDamagedDirection(int x, int y, int[,] array, ref Direction direction1, ref Direction direction2)
        {
            if (array[x + 2, y + 1] == (int)State.Damaged)
            {
                direction1 = Direction.Right;
                direction2 = Direction.Left;
            }
            if (array[x, y + 1] == (int)State.Damaged)
            {
                direction1 = Direction.Left;
                direction2 = Direction.Right;
            }
            if (array[x + 1, y] == (int)State.Damaged)
            {
                direction1 = Direction.Up;
                direction2 = Direction.Down;
            }
            if (array[x + 1, y + 2] == (int)State.Damaged)
            {
                direction1 = Direction.Down;
                direction2 = Direction.Up;
            }

        }

        static public bool CheckDirection(int x, int y, int[,] array, ref Direction direction1,ref  Direction direction2, State state)
        {
            if (direction1 != Direction.Null && direction2 != Direction.Null)
            {
                if (state == State.Alive)
                {
                    if (FindAlive(x, y, array, direction1) == true || FindAlive(x, y, array, direction2) == true)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (FindDamagedNeighbour(x, y, array, direction1) == true || FindDamagedNeighbour(x, y, array, direction2) == true)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (direction1 != Direction.Null)
                {
                    if (state == State.Alive)
                    {
                        if (FindAlive(x, y, array, direction1) == true)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (FindDamagedNeighbour(x, y, array, direction1) == true)
                            return true;
                        else
                            return false;
                    }
                }
                if (direction2 != Direction.Null)
                {
                    if (state == State.Alive)
                    {
                        if (FindAlive(x, y, array, direction2) == true)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (FindDamagedNeighbour(x, y, array, direction2) == true)
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }



        static public bool FindAlive(int x, int y, int[,] array, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    {
                        for (int i = y + 2; i < 12; i++)
                        {
                            switch (array[x + 1, i])
                            {
                                case (int)State.Alive: return true;
                                case (int)State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Direction.Left:
                    {
                        for (int i = x; i > 0; i--)
                        {
                            switch (array[i, y + 1])
                            {
                                case (int)State.Alive: return true;
                                case (int)State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Direction.Right:
                    {
                        for (int i = x + 2; i < 12; i++)
                        {
                            switch (array[i, y + 1])
                            {
                                case (int)State.Alive: return true;
                                case (int)State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Direction.Up:
                    {
                        for (int i = y; i >= 1; i--)
                        {
                            switch (array[x + 1, i])
                            {
                                case (int)State.Alive: return true;
                                case (int)State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
            }
            return false;
        }

        static public bool FindDamagedNeighbour(int x, int y, int[,] array, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    {
                        if (array[x + 1, y + 2] == (int)State.Damaged)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case Direction.Left:
                    {
                        if (array[x, y + 1] == (int)State.Damaged)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case Direction.Right:
                    {
                        if (array[x + 2, y + 1] == (int)State.Damaged)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case Direction.Up:
                    {
                        if (array[x + 1, y] == (int)State.Damaged)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
            }
            return false;
        }

        static public void KillDirection(int x, int y, int[,] array, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                case Direction.Right:
                    {
                        for (int i = x + 1; i > 0; i--)
                        {
                            if (array[i - 1, y + 1] != (int)State.Alive && array[i - 1, y + 1] != (int)State.Damaged)
                            {
                                for (int j = i; j < 12; j++)
                                {
                                    if (array[j + 1, y + 1] != (int)State.Alive && array[j + 1, y + 1] != (int)State.Damaged)
                                    {
                                        SetShip(ref array, i - 1, y, false, j - i + 1, 1);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;

                case Direction.Up:
                case Direction.Down:
                    {
                        for (int i = y + 1; i > 0; i--)
                        {
                            if (array[x + 1, i - 1] != (int)State.Alive && array[x + 1, i - 1] != (int)State.Damaged)
                            {
                                for (int j = i; j < 12; j++)
                                {
                                    if (array[x + 1, j + 1] != (int)State.Alive && array[x + 1, j + 1] != (int)State.Damaged)
                                    {
                                        SetShip(ref array, x, i - 1, false, 1, j - i + 1);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;

                case Direction.Null:
                    {
                        SetShip(ref array, x, y, false, 1, 1);
                    }
                    break;
            }
        }

        static public void KillShip(int x, int y, int[,] array)
        {
            Direction direction1 = Direction.Null;
            Direction direction2 = Direction.Null;
            FindDirection(x, y, array, ref direction1, ref direction2);
            KillDirection(x, y, array, direction1);
        }

        static public void WriteCoordinatesIntoArray(ref int[,] shoots, int x, int y, ref int j)
        {
            while (x >= 0 && y >= 0 && x <= 9 && y <= 9)
            {
                shoots[0, j] = x;
                shoots[1, j] = y;
                x++;
                y--;
                j++;
            }
        }

        static public void RemoveArrayLine(ref int[,]array, int j)
        {
            while (j < array.GetLength(1)-1)
            {
                array[0, j] = array[0, j + 1];
                array[1, j] = array[1, j + 1];
                j++;
            }
            array[0, array.GetLength(1) - 1] = 0;
            array[1, array.GetLength(1) - 1] = 0;
        }

        static public int CountArrayLines(int[,]array)
        {
            int n = 0;
            for(int i=0;i<array.GetLength(1);i++)
            {
                if (i + 1 == array.GetLength(1))
                {
                    return array.GetLength(1);
                }
                if(array[0,i]==0&& array[0, i]==0&& array[0, i+1] == 0 && array[0, i+1] == 0)
                {
                    return n;
                }
                n++;
            }
            return 0;
        }

        static public void WriteLeftCoordinatesIntoArray(ref int[,] shoots)
        {
            int n = 0;
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                    {
                        shoots[0, n] = i;
                        shoots[1, n] = j;
                        n++;
                    }
                }
            }
        }

        static public void SetPCShips(ref int[,] array)
        {
            Random r = new Random();
            int rand = r.Next(0, 2);
            SetShip(ref array, 0, 0, true, 1, 4);
            SetShip(ref array, 0, 5, true, 1, 2);
            SetShip(ref array, 0, 8, true, 1, 2);
            if (rand == 0)
            {
                SetShip(ref array, 2, 0, true, 1, 3);
                SetShip(ref array, 2, 4, true, 1, 3);
                SetShip(ref array, 2, 8, true, 1, 2);

            }
            else
            {
                SetShip(ref array, 9, 0, true, 1, 3);
                SetShip(ref array, 9, 4, true, 1, 3);
                SetShip(ref array, 9, 8, true, 1, 2);
            }
            for (int i = 0; i < 4; i++)
            {
                int x = 0;
                int y = 0;
                while (array[x + 1, y + 1] != (int)State.Empty)
                {
                    if (x == 0)
                    {
                        x = r.Next(4, 10);
                    }
                    else
                    {
                        x = r.Next(2, 8);
                    }
                    y = r.Next(0, 10);
                }
                SetShip(ref array, x, y, true, 1, 1);
            }
            int n = r.Next(0, 4);
            for (int i = 0; i < n; i++)
            {
                Tetris.Rotate(ref array);
            }
        }

        static public void ChooseRandomCoordinates(ref int[,] shoots, out int x, out int y)
        {
            Random r = new Random();
            int rand = r.Next(CountArrayLines(shoots));
            x = shoots[0, rand];
            y = shoots[1, rand];
            RemoveArrayLine(ref shoots, rand);
        }

        static public void CreateShootArrays(ref int[,] shoots1, ref int[,] shoots2, ref int[,] shoots3)
        {
            int j = 0;
            WriteCoordinatesIntoArray(ref shoots1, 0, 3, ref j);
            WriteCoordinatesIntoArray(ref shoots1, 0, 7, ref j);
            WriteCoordinatesIntoArray(ref shoots1, 2, 9, ref j);
            WriteCoordinatesIntoArray(ref shoots1, 6, 9, ref j);
            j = 0;
            WriteCoordinatesIntoArray(ref shoots2, 0, 1, ref j);
            WriteCoordinatesIntoArray(ref shoots2, 0, 5, ref j);
            WriteCoordinatesIntoArray(ref shoots2, 0, 9, ref j);
            WriteCoordinatesIntoArray(ref shoots2, 4, 9, ref j);
            WriteCoordinatesIntoArray(ref shoots2, 8, 9, ref j);
            WriteLeftCoordinatesIntoArray(ref shoots3);
        }

        static public bool SearchDamaged(int [,]array, out int[,] damaged)
        {
            damaged = new int[2,4];
            int n = 0;
            for(int i=0;i<array.GetLength(0)-1;i++)
            {
                for(int j=0;j<array.GetLength(1)-1;j++)
                {
                    if(array[i+1,j+1]==(int)State.Damaged)
                    {
                        damaged[0,n] = i;
                        damaged[1, n] = j;
                        n++;
                    }
                }
            }
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


    }
}
