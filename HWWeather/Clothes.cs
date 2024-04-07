namespace HWWeather
{
    enum slotEnum
    {
        Head,
        BodyInner,
        BodyMiddle,
        BodyOuter,
        PantsInner,
        PantsMiddle,
        PantsOuter,
        Accessory,
        Gloves,
        Shoes,
    }

    enum falloutEnum
    {
        Rain,
        Snow,
        ClearSky,
    }

    internal class Clothes
    {
        public string name;
        public int minTemperature;
        public int maxTemperature;
        public int recommendedTemperature;
        public List<falloutEnum> falloutConditions;
        public slotEnum slot;
        public int minWindStrength;
        public int maxWindStrength;
        public int recommendedWindStrength;

        public Clothes(string name, int minTemperature, int maxTemperature, int recommendedTemperature, List<falloutEnum> falloutConditions, slotEnum slot, int minWindStrength, int maxWindStrength, int recommendedWindStrength)
        {
            this.name = name;
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.recommendedTemperature = recommendedTemperature;
            this.falloutConditions = falloutConditions;
            this.slot = slot;
            this.minWindStrength = minWindStrength;
            this.maxWindStrength = maxWindStrength;
            this.recommendedWindStrength = recommendedWindStrength;
        }
    }
}
