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
                        array[i, j] = (int)Battleships.State.Alive;
                    }
                    else
                    {
                        array[i, j] = (int)Battleships.State.Dead;
                    }
                }
            }
            for (int i = x - 1; i < x + horizontal + 1; i++)
            {
                for (int j = y - 1; j < y + vertical + 1; j++)
                {
                    if (array[i, j] != (int)Battleships.State.Alive && array[i, j] != (int)Battleships.State.Dead)
                        array[i, j] = (int)Battleships.State.Miss;
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
            Battleships.Direction direction1 = Battleships.Direction.Null;
            Battleships.Direction direction2 = Battleships.Direction.Null;
            if (FindDirection(x, y, array, ref direction1, ref direction2) == true)
                return true;
            else
                return false;
        }

        static public bool FindDirection(int x, int y, int[,] array, ref Battleships.Direction direction1, ref Battleships.Direction direction2)
        {
            if (array[x + 2, y + 1] == (int)Battleships.State.Alive || array[x + 2, y + 1] == (int)Battleships.State.Damaged)
            {
                if (direction1 == Battleships.Direction.Null)
                    direction1 = Battleships.Direction.Right;
                else
                    direction2 = Battleships.Direction.Right;

            }
            if (array[x, y + 1] == (int)Battleships.State.Alive || array[x, y + 1] == (int)Battleships.State.Damaged)
            {
                if (direction1 == Battleships.Direction.Null)
                    direction1 = Battleships.Direction.Left;
                else
                    direction2 = Battleships.Direction.Left;
            }
            if (array[x + 1, y] == (int)Battleships.State.Alive || array[x + 1, y] == (int)Battleships.State.Damaged)
            {
                if (direction1 == Battleships.Direction.Null)
                    direction1 = Battleships.Direction.Up;
                else
                    direction2 = Battleships.Direction.Up;
            }
            if (array[x + 1, y + 2] == (int)Battleships.State.Alive || array[x + 1, y + 2] == (int)Battleships.State.Damaged)
            {
                if (direction1 == Battleships.Direction.Null)
                    direction1 = Battleships.Direction.Down;
                else
                    direction2 = Battleships.Direction.Down;
            }
            if (CheckDirection(x, y, array, direction1, direction2) == true)
                return true;
            else
                return false;
        }

        static public bool CheckDirection(int x, int y, int[,] array, Battleships.Direction direction1, Battleships.Direction direction2)
        {
            if (direction1 != Battleships.Direction.Null && direction2 != Battleships.Direction.Null)
            {
                if (FindAlive(x, y, array, direction1) == true || FindAlive(x, y, array, direction2) == true)
                    return true;
                else
                    return false;
            }
            else
            {
                if (direction1 != Battleships.Direction.Null)
                {
                    if (FindAlive(x, y, array, direction1) == true)
                        return true;
                    else
                        return false;
                }
                if (direction2 != Battleships.Direction.Null)
                {
                    if (FindAlive(x, y, array, direction2) == true)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        static public bool FindAlive(int x, int y, int[,] array, Battleships.Direction direction)
        {
            switch (direction)
            {
                case Battleships.Direction.Down:
                    {
                        for (int i = y + 2; i < 12; i++)
                        {
                            switch (array[x + 1, i])
                            {
                                case (int)Battleships.State.Alive: return true;
                                case (int)Battleships.State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Battleships.Direction.Left:
                    {
                        for (int i = x; i > 0; i--)
                        {
                            switch (array[i, y + 1])
                            {
                                case (int)Battleships.State.Alive: return true;
                                case (int)Battleships.State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Battleships.Direction.Right:
                    {
                        for (int i = x + 2; i < 12; i++)
                        {
                            switch (array[i, y + 1])
                            {
                                case (int)Battleships.State.Alive: return true;
                                case (int)Battleships.State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
                case Battleships.Direction.Up:
                    {
                        for (int i = y; i >= 1; i--)
                        {
                            switch (array[x + 1, i])
                            {
                                case (int)Battleships.State.Alive: return true;
                                case (int)Battleships.State.Damaged: break;
                                default: return false;
                            }
                        }
                    }
                    break;
            }
            return false;
        }

        static public void KillDirection(int x, int y, int[,] array, Battleships.Direction direction)
        {
            switch (direction)
            {
                case Battleships.Direction.Left:
                case Battleships.Direction.Right:
                    {
                        for (int i = x + 1; i > 0; i--)
                        {
                            if (array[i - 1, y + 1] != (int)Battleships.State.Alive && array[i - 1, y + 1] != (int)Battleships.State.Damaged)
                            {
                                for (int j = i; j < 12; j++)
                                {
                                    if (array[j + 1, y + 1] != (int)Battleships.State.Alive && array[j + 1, y + 1] != (int)Battleships.State.Damaged)
                                    {
                                        Battleships.SetShip(ref array, i - 1, y, false, j - i + 1, 1);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;

                case Battleships.Direction.Up:
                case Battleships.Direction.Down:
                    {
                        for (int i = y + 1; i > 0; i--)
                        {
                            if (array[x + 1, i - 1] != (int)Battleships.State.Alive && array[x + 1, i - 1] != (int)Battleships.State.Damaged)
                            {
                                for (int j = i; j < 12; j++)
                                {
                                    if (array[x + 1, j + 1] != (int)Battleships.State.Alive && array[x + 1, j + 1] != (int)Battleships.State.Damaged)
                                    {
                                        Battleships.SetShip(ref array, x, i - 1, false, 1, j - i + 1);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;

                case Battleships.Direction.Null:
                    {
                        Battleships.SetShip(ref array, x, y, false, 1, 1);
                    }
                    break;
            }
        }

        static public void KillShip(int x, int y, int[,] array)
        {
            Battleships.Direction direction1 = Battleships.Direction.Null;
            Battleships.Direction direction2 = Battleships.Direction.Null;
            Battleships.FindDirection(x, y, array, ref direction1, ref direction2);
            Battleships.KillDirection(x, y, array, direction1);
        }
    }
}
