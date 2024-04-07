namespace HWWeather
{
    internal class WeatherAdviser
    {
        public List<Clothes> clothesList;

        public WeatherAdviser(List<Clothes> clothesList)
        {
            this.clothesList = clothesList;
        }

        public void SetClothesList(List<Clothes> clothesList)
        {
            this.clothesList = clothesList;
        }

        public void AddClothes(Clothes clothes)
        {
            clothesList.Add(clothes);
        }

        private HashSet<slotEnum> ListDupeSlots(List<Clothes> clothes)
        {
            var checkedSlots = new List<slotEnum>();
            var dupeSlots = new HashSet<slotEnum>();

            foreach(var clothesItem in clothes)
            {
                if (checkedSlots.Contains(clothesItem.slot))
                {
                    dupeSlots.Add(clothesItem.slot);
                }
                else
                {
                    checkedSlots.Add(clothesItem.slot);
                }
            }

            return dupeSlots;
        }

        private List<Clothes> ChooseBestClothes(List<Clothes> clothes)
        {
            var dupeSlots = ListDupeSlots(clothes);
            var resultedList = new List<Clothes>();

            foreach(var slot in dupeSlots)
            {
                var currentSlotList = new List<Clothes>();
                foreach (var clothesItem in clothes)
                {
                    if (clothesItem.slot == slot)
                    {
                        currentSlotList.Add(clothesItem);
                    }
                }

            }
        }

        public List<Clothes> GetAdvise(Weather currentWeather)
        {
            var acceptableClothes = new List<Clothes>();
            foreach (var clothes in clothesList)
            {
                if (currentWeather.temperature >= clothes.minTemperature && currentWeather.temperature <= clothes.maxTemperature && clothes.falloutConditions.Contains(currentWeather.fallout) && currentWeather.windStrength > clothes.minWindStrength && currentWeather.windStrength < clothes.maxWindStrength)
                {
                    acceptableClothes.Add(clothes);
                }
            }

            return ChooseBestClothes(acceptableClothes);
        }
    }
}
