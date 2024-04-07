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

        private HashSet<Slots> ListDupeSlots(List<Clothes> clothes)
        {
            var checkedSlots = new List<Slots>();
            var dupeSlots = new HashSet<Slots>();

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

        private Clothes ChooseBis(List<Clothes> clothesSlotList, int temperature)
        {
            if (clothesSlotList.Count == 0)
            {
                throw new ArgumentException("Список одежды не должен быть пустым!");
            }

            var minD = Math.Abs(clothesSlotList[0].recommendedTemperature - temperature);
            var minCl = clothesSlotList[0];

            foreach (var clothes in clothesSlotList)
            {
                var curD = Math.Abs(clothes.recommendedTemperature - temperature);
                if (curD <= minD)
                {
                    minD = curD;
                    minCl = clothes;
                }
            }

            return minCl;
        }

        private List<Clothes> ChooseBestClothes(List<Clothes> clothes, Weather weather)
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
                resultedList.Add(ChooseBis(currentSlotList, weather.temperature));
            }

            foreach (Slots slot in Enum.GetValues(typeof(Slots)))
            {
                if (!dupeSlots.Contains(slot))
                {
                    foreach (var clothesItem in clothes)
                    {
                        if (clothesItem.slot == slot)
                        {
                            resultedList.Add(clothesItem);
                        }
                    }
                }
            }

            return resultedList;
        }

        public List<Clothes> GetAdvise(Weather currentWeather)
        {
            var acceptableClothes = new List<Clothes>();
            foreach (var clothes in clothesList)
            {
                if (currentWeather.temperature >= clothes.minTemperature && currentWeather.temperature <= clothes.maxTemperature && clothes.falloutConditions.Contains(currentWeather.fallout) && (clothes.wind == true || currentWeather.wind == false))
                {
                    acceptableClothes.Add(clothes);
                }
            }

            return ChooseBestClothes(acceptableClothes, currentWeather);
        }
    }
}
