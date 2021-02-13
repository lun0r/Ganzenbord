using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        public string Name { get; set; }
        public int CurrentBoardPosition { get; set; }
        public int OldBoardPosition { get; set; }
        public Image Avatar { get; set; }
        public int Dice1 { get; set; }

        public int Dice2 { get; set; }
        public bool HasDied { get; set; } = false;

        public bool IsReversed { get; set; } = false;
        public int SkipTurn { get; set; }

        public PawnColor Pawn { get; set; }

        public Player(string name, Image avatar, PawnColor pawn)
        {
            Name = name;
            Avatar = avatar;
            Pawn = pawn;
        }

        public void Move(int newFieldPos)
        {
            IsReversed = newFieldPos > 63;
            //dees klopt nog niet altijd. Als hij 63 passeerd, op een zwaan komt, en dan nog eens op een zwaan komt,
            //is zijn "isreversed weer op false gezet door deze check (na de eerste zwaan)

            if (newFieldPos > 63)
            {
                newFieldPos = 63 - (newFieldPos - 63);
            }

            OldBoardPosition = CurrentBoardPosition;

            CurrentBoardPosition = newFieldPos;
        }
    }
}