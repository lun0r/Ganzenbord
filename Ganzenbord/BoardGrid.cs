using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ganzenbord
{
    internal class BoardGrid
    {
        private List<Field> _boardGrid;

        public List<Field> BoardGridView
        {
            get { return _boardGrid; }
            set
            {
                if (_boardGrid != value)
                {
                    _boardGrid = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}