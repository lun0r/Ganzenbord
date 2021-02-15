using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private int _currentBoardPosition;

        public int CurrentBoardPosition
        {
            get { return _currentBoardPosition; }
            set
            {
                _currentBoardPosition = value;
                OnPropertyChanged();
            }
        }

        public int OldBoardPosition { get; set; }
        public string AvatarPath { get; set; }

        private int _dice1;

        public int Dice1
        {
            get { return _dice1; }
            set
            {
                _dice1 = value;
                OnPropertyChanged();
            }
        }

        private int _dice2;

        public int Dice2
        {
            get { return _dice2; }
            set
            {
                _dice2 = value;
                OnPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}