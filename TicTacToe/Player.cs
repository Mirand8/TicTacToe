namespace TicTacToe
{
    public class Player
    {
        public int Id { get; set; }
        public char Letter { get; set; }
        public int WinCount { get; set; }

        public Player(int id)
        {
            Id = id;
        }
    }
}