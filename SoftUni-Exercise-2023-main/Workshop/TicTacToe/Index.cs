namespace TicTacToe
{
    public class Index
    {
        public Index(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public Index(string input)
        {
            var splitted = input.Split(',');
            this.Row = int.Parse(splitted[0]);
            this.Col = int.Parse(splitted[1]);
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            var otherIndex = obj as Index;
            return this.Row == otherIndex.Row && this.Col == otherIndex.Col;
        }

        public override string ToString()
        {
            return $"{this.Row},{this.Col}";
        }
    }
}
