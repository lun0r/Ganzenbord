namespace Ganzenbord
{
    internal class BoardData
    {
        //bevat setupgame en userinteraction

        public SetupGame SetGame { get; set; }
        public UserInteractionWindow SetUI { get; set; }

        public BoardData()
        {
            SetGame = SetupGame.GetSetupWindow();
            SetUI = UserInteractionWindow.GetUserInteractionWindow();
        }
    }
}