namespace HWWeather
{
    public partial class MainForm : Form
    {
        WeatherAdviser adviser;

        private const int LOW_BORDER = -35;
        private const int HIGH_BORDER = 35;

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

            clothesList.Add(new Clothes("�����", -5, 20, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));
            clothesList.Add(new Clothes("�����", -25, 10, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));
            clothesList.Add(new Clothes("����� ������", LOW_BORDER - 1, -10, -25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Head, true));

            clothesList.Add(new Clothes("�����", 5, 20, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain}, Slots.OuterBody, true));
            clothesList.Add(new Clothes("��������", 0, 15, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterBody, true));
            clothesList.Add(new Clothes("������", -20, 0, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterBody, true));
            clothesList.Add(new Clothes("�������", LOW_BORDER - 1, -10, -25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterBody, true));

            clothesList.Add(new Clothes("��������", LOW_BORDER - 1, HIGH_BORDER + 1, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.InnerBody, true));
            clothesList.Add(new Clothes("�������", LOW_BORDER - 1, HIGH_BORDER + 1, 25, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.InnerBody, false));

            clothesList.Add(new Clothes("�����", 15, HIGH_BORDER + 1, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain }, Slots.OuterPants, true));
            clothesList.Add(new Clothes("�����", -15, HIGH_BORDER + 1, 5, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterPants, true));
            clothesList.Add(new Clothes("����� � �������������", LOW_BORDER - 1, -10, -15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterPants, true));

            clothesList.Add(new Clothes("�����", LOW_BORDER - 1, HIGH_BORDER + 1, 20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.InnerPants, true));

            //clothesList.Add(new Clothes("������", -10, HIGH_BORDER + 1, 0, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));
            clothesList.Add(new Clothes("��������", -20, -5, -10, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));
            clothesList.Add(new Clothes("�������", LOW_BORDER - 1, -10, -20, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.Gloves, true));

            clothesList.Add(new Clothes("�������", 20, HIGH_BORDER + 1, 30, new List<Fallouts>() { Fallouts.No }, Slots.OuterShoes, true));
            clothesList.Add(new Clothes("����c����", 10, HIGH_BORDER + 1, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterShoes, true));
            clothesList.Add(new Clothes("������ ��������", -10, 15, 5, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterShoes, true));
            clothesList.Add(new Clothes("������ �������", LOW_BORDER - 1, 0, -15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.OuterShoes, true));

            clothesList.Add(new Clothes("�����", -10, 22, 15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.InnerShoes, true));
            clothesList.Add(new Clothes("������ �����", LOW_BORDER - 1, 0, -15, new List<Fallouts>() { Fallouts.No, Fallouts.Rain, Fallouts.Snow }, Slots.InnerShoes, true));

            clothesList.Add(new Clothes("������", -5, HIGH_BORDER + 1, 15, new List<Fallouts>() { Fallouts.Rain }, Slots.Accessory, true));

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
