namespace HWWeather
{
    public partial class MainForm : Form
    {
        WeatherAdviser adviser;

        public MainForm()
        {
            InitializeComponent();
            adviser = new WeatherAdviser(PreSetClothesList());

            foreach (Fallouts fallout in Enum.GetValues(typeof(Fallouts)))
            {
                falloutComboBox.Items.Add(fallout);
            }

            falloutComboBox.SelectedIndex = 0;
        }

        private List<Clothes> PreSetClothesList()
        {
            var clothesList = new List<Clothes>();

            clothesList.Add(new Clothes("������", 0, 36, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));
            clothesList.Add(new Clothes("�����", -5, 36, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));
            clothesList.Add(new Clothes("�����", -25, 10, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));
            clothesList.Add(new Clothes("����� ������", -36, -10, -25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));

            clothesList.Add(new Clothes("��������", 15, 36, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain}, Slots.Body, true));
            clothesList.Add(new Clothes("�������", 15, 36, 25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain}, Slots.Body, false));
            clothesList.Add(new Clothes("�����", 5, 20, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain}, Slots.Body, true));
            clothesList.Add(new Clothes("��������", 0, 15, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Body, true));
            clothesList.Add(new Clothes("������", -20, 0, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Body, true));
            clothesList.Add(new Clothes("�������", -36, -10, -25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Body, true));

            clothesList.Add(new Clothes("�����", 15, 36, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain}, Slots.Pants, true));
            clothesList.Add(new Clothes("�����", -15, 25, 5, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Pants, true));
            clothesList.Add(new Clothes("����� � �������������", -36, -10, -15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Pants, true));

            clothesList.Add(new Clothes("������", -10, 36, 0, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));
            clothesList.Add(new Clothes("��������", -20, 5, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));
            clothesList.Add(new Clothes("�������", -36, -10, -20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));

            clothesList.Add(new Clothes("�������", 20, 36, 30, new List<Fallouts>() { Fallouts.No }, Slots.Shoes, true));
            clothesList.Add(new Clothes("��������", 10, 36, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain }, Slots.Shoes, true));
            clothesList.Add(new Clothes("������ ��������", -10, 15, 5, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Shoes, true));
            clothesList.Add(new Clothes("������ �������", -36, 0, -15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Shoes, true));

            clothesList.Add(new Clothes("������", -5, 36, 15, new List<Fallouts>() { Fallouts.Rain }, Slots.Accessory, true));

            return clothesList;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var curWeather = new Weather();

            curWeather.temperature = temperatureTrackBar.Value;
            curWeather.wind = windCheckBox.Checked;
            curWeather.fallout = (Fallouts)falloutComboBox.Items[falloutComboBox.SelectedIndex];

            var resultList = adviser.GetAdvise(curWeather);

            resultList.Sort((elem1, elem2) => elem1.slot.CompareTo(elem2.slot));

            resultListBox.Items.Clear();

            foreach (var item in resultList)
            {
                resultListBox.Items.Add(item);
            }
        }

        private void temperatureTrackBar_Changed(object sender, EventArgs e)
        {
            temperatureValueLabel.Text = temperatureTrackBar.Value.ToString();
        }
    }
}
