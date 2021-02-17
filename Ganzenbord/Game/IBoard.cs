using System.Collections.Generic;

namespace Ganzenbord
{
    public interface IBoard
    {
        List<Field> BoardList { get; set; }

        void ChangeTheme(int index, IEnumerable<Player> playerList);
        IEnumerable<Field> CreateNewBoard();
        void UpdateField(Player player);
    }
}