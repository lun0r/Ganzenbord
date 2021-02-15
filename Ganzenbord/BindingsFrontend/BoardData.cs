namespace Ganzenbord
{
    public class BoardData
    {
        private static BoardData boardData;
        public PlaySidebar PlaySidebar { get; set; }
        public StartSidebar StartSidebar { get; set; }

        private BoardData()
        {
            PlaySidebar = new PlaySidebar();
            StartSidebar = new StartSidebar();
        }

        public static BoardData GetBoardData()
        {
            if (boardData == null)
            {
                boardData = new BoardData();
            }
            return boardData;
        }
    }
}