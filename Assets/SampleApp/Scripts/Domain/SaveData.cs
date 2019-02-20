namespace SampleApp.Domain
{
    public class SaveData
    {
        public string Name { get; }
        public int Power { get; }
        public int Speed { get; }
        public int Health { get; }

        public SaveData(string name, int power, int speed, int health)
        {
            Name = name;
            Power = power;
            Speed = speed;
            Health = health;
        }

        public static SaveData Dafault { get; } = new SaveData("Default", 1, 1, 1);
    }
}

