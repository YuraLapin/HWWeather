namespace HWWeather
{
    internal class Clothes
    {
        public string name;
        public int minTemperature;
        public int maxTemperature;
        public int recommendedTemperature;
        public List<Fallouts> falloutConditions;
        public Slots slot;
        public bool wind;

        public Clothes(string name, int minTemperature, int maxTemperature, int recommendedTemperature, List<Fallouts> falloutConditions, Slots slot, bool wind)
        {
            this.name = name;
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.recommendedTemperature = recommendedTemperature;
            this.falloutConditions = falloutConditions;
            this.slot = slot;
            this.wind = wind;
        }

        public override string ToString()
        {
            return $"{slot}: {name}";
        }
    }
}
