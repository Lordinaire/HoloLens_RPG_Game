namespace Assets.Scripts.Models
{
    public class Case
    {
        public int X { get; set; }

        public int Y { get; set; }

        public CaseType Type { get; set; }

        public Case()
        {
            Type = CaseType.Forest;
        }
    }
}