using System;

namespace Main
{
    [Flags]
    enum MoveType
    {
        None = 0,
        Diagonal = 1,  
        Straight = 2,  
        LShape = 4     
    }

    enum ChessPiece
    {
        King = 1,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    internal class ChessGame
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Выберите фигуру:");
            foreach (ChessPiece piece in Enum.GetValues(typeof(ChessPiece)))
            {
                Console.WriteLine($"{(int)piece}. {piece}");
            }

            Console.Write("Введите номер фигуры: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || !Enum.IsDefined(typeof(ChessPiece), choice))
            {
                Console.WriteLine("Неверный ввод!");
                return;
            }

            ChessPiece selected = (ChessPiece)choice;
            MoveType moves = GetMoveType(selected);

            Console.WriteLine($"\nВы выбрали: {selected}");
            Console.WriteLine("Возможные типы ходов:");

            if ((moves & MoveType.Diagonal) != 0) Console.WriteLine("- По диагонали");
            if ((moves & MoveType.Straight) != 0) Console.WriteLine("- По прямой линии");
            if ((moves & MoveType.LShape) != 0) Console.WriteLine("- Ход конем (буква Г)");

            if (moves == MoveType.None) Console.WriteLine("- Нет доступных ходов");
        }

        static MoveType GetMoveType(ChessPiece piece)
        {
            return piece switch
            {
                ChessPiece.King => MoveType.Diagonal | MoveType.Straight,
                ChessPiece.Queen => MoveType.Diagonal | MoveType.Straight,
                ChessPiece.Rook => MoveType.Straight,
                ChessPiece.Bishop => MoveType.Diagonal,
                ChessPiece.Knight => MoveType.LShape,
                ChessPiece.Pawn => MoveType.Straight,
                _ => MoveType.None
            };
        }
    }
}

