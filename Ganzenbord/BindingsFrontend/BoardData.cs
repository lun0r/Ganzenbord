namespace Ganzenbord
{
    internal class BoardData
    {
        //bevat setupgame en userinteraction

        public PlaySidebar PlaySidebar { get; set; }
        public StartSidebar StartSidebar { get; set; }

        public BoardData()
        {
            PlaySidebar = new PlaySidebar();
            StartSidebar = new StartSidebar();
        }
    }
}