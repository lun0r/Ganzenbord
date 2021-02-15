using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        public string Name { get; set; }
        public int CurrentBoardPosition { get; set; }

        public int OldBoardPosition { get; set; }
        public string AvatarPath { get; set; }

        public int Dice1 { get; set; }

        public int Dice2 { get; set; }

        public bool HasDied { get; set; } = false;

        public bool IsReversed { get; set; } = false;

        public int SkipTurn { get; set; }

        public PawnColor Pawn { get; set; }

        public Player(string name, string avatarPath, PawnColor pawn)
        {
            Name = name;
            AvatarPath = avatarPath;
            Pawn = pawn;
        }

        public void Move(int newFieldPos)
        {
            IsReversed = newFieldPos > 63 || OldBoardPosition > CurrentBoardPosition;

            if (newFieldPos > 63)
            {
                newFieldPos = 63 - (newFieldPos - 63);
            }

            OldBoardPosition = CurrentBoardPosition;

            CurrentBoardPosition = newFieldPos;
        }
    }
}