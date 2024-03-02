using System;
using System.Text.RegularExpressions;

namespace Cheesboard
{
    class Program
    {
        static string input = "";
        static string queenCoordinates = "";
        static string figureCoordinates = "";

        static bool IsValidChessCoordinateFormat()
        {
            string patter = @"^[a-h]+[1-8]\s[a-h]+[1-8]$";
            return Regex.IsMatch(input, patter);
        }

        static void EnteringString()
        {
            Console.WriteLine("Введите координаты ферзя x1y1 и координаты фигуры x2y2(Пример:a1 a2): ");
            input = Console.ReadLine().ToLower();
        }

        static void SplittingAString()
        {
            string[] parts = input.Split(' ');
            queenCoordinates = parts[0];
            figureCoordinates = parts[1];
        }

        static void ConvertChessCoordinatesToArray(string str, out int[] shape)
        {
            shape = new int[2];
            switch (str[0])
            {
                case 'a': shape[0] = 0; break;
                case 'b': shape[0] = 1; break;
                case 'c': shape[0] = 2; break;
                case 'd': shape[0] = 3; break;
                case 'e': shape[0] = 4; break;
                case 'f': shape[0] = 5; break;
                case 'g': shape[0] = 6; break;
                case 'h': shape[0] = 7; break;
            }

            shape[1] = Convert.ToInt32(str[1].ToString()) - 1;
        }

        static bool IsQueenTargetingFigure()
        {
            int[] queenPosition = new int[2];

            int[] figurePosition = new int[2];

            ConvertChessCoordinatesToArray(queenCoordinates, out queenPosition);

            ConvertChessCoordinatesToArray(figureCoordinates, out figurePosition);

            int diagonal1Constant = queenPosition[1] - queenPosition[0];
            int diagonal2Constant = queenPosition[1] + queenPosition[0];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i - j) == diagonal1Constant || (i + j) == diagonal2Constant)
                    {
                        if (i == figurePosition[1] && j == figurePosition[0])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static void CanQueenAttack()
        {
            if (IsQueenTargetingFigure() || queenCoordinates[0] == figureCoordinates[0] || queenCoordinates[1] == figureCoordinates[1])
            {
                Console.WriteLine("Ферзь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру");
            }
        }

        static bool CheckQueenMoveValidity()
        {
            if (!(IsValidChessCoordinateFormat()))
            {
                Console.WriteLine("Вы вели строку неправильного формата \n" +
                                  "Формат:a1 a2");
                return true;
            }
            else if (input[0] == input[3] && input[1] == input[4])
            {
                Console.WriteLine("Вы вели одинаковые позиции фигур \n" +
                                  "Введите разные позиции фигур");
                return true;
            }
            return false;
        }

        static void Main()
        {
            do
            {
                EnteringString();

            } while (CheckQueenMoveValidity());

            SplittingAString();

            CanQueenAttack();

        }
    }
}