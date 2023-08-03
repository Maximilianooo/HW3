namespace HW3
{
    public interface ICard : WorldView
    {
        string Name { get; }
        string Element { get; }
        int Power { get; }
    }

    class Card : ICard
    {
        public string Name { get; private set; }
        public string Element { get; private set; }
        public int Power { get; private set; }
        public int Morality { get; private set; }
        public int Ethic { get; private set; }

        public Card(string name, string element, int power, int morality, int ethic)
        {
            Name = name;
            Element = element;
            Power = power;
            Morality = morality;
            Ethic = ethic;

        }
    }
}