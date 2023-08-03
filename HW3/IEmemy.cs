namespace HW3
{
    public interface IEnemy : WorldView
    {
        string Name { get; }
        string Element { get; }
        int Health { get; }
    }

    class Enemy : IEnemy
    {
        public string Name { get; private set; }
        public string Element { get; private set; }
        public int Health { get; private set; }
        public int Morality { get; private set; }
        public int Ethic { get; private set; }

        public Enemy(string name, string element, int health, int morality, int ethic)
        {
            Name = name;
            Element = element;
            Health = health;
            Morality = morality;
            Ethic = ethic;
        }
    }
}