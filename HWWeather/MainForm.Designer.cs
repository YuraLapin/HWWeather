namespace HWWeather
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            confirmButton = new Button();
            falloutComboBox = new ComboBox();
            windCheckBox = new CheckBox();
            temperatureTrackBar = new TrackBar();
            temparatureLabel = new Label();
            resultListBox = new ListBox();
            temperatureValueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)temperatureTrackBar).BeginInit();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(12, 175);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(188, 23);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Посоветуй!";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // falloutComboBox
            // 
            falloutComboBox.FormattingEnabled = true;
            falloutComboBox.Location = new Point(12, 133);
            falloutComboBox.Name = "falloutComboBox";
            falloutComboBox.Size = new Size(188, 23);
            falloutComboBox.TabIndex = 1;
            // 
            // windCheckBox
            // 
            windCheckBox.AutoSize = true;
            windCheckBox.Location = new Point(12, 86);
            windCheckBox.Name = "windCheckBox";
            windCheckBox.Size = new Size(78, 19);
            windCheckBox.TabIndex = 2;
            windCheckBox.Text = "Ветренно";
            windCheckBox.UseVisualStyleBackColor = true;
            // 
            // temperatureTrackBar
            // 
            temperatureTrackBar.Location = new Point(12, 35);
            temperatureTrackBar.Maximum = 35;
            temperatureTrackBar.Minimum = -35;
            temperatureTrackBar.Name = "temperatureTrackBar";
            temperatureTrackBar.Size = new Size(368, 45);
            temperatureTrackBar.TabIndex = 3;
            temperatureTrackBar.ValueChanged += temperatureTrackBar_Changed;
            // 
            // temparatureLabel
            // 
            temparatureLabel.AutoSize = true;
            temparatureLabel.Location = new Point(12, 9);
            temparatureLabel.Name = "temparatureLabel";
            temparatureLabel.Size = new Size(78, 15);
            temparatureLabel.TabIndex = 4;
            temparatureLabel.Text = "Температура";
            // 
            // resultListBox
            // 
            resultListBox.FormattingEnabled = true;
            resultListBox.ItemHeight = 15;
            resultListBox.Location = new Point(386, 9);
            resultListBox.Name = "resultListBox";
            resultListBox.Size = new Size(218, 184);
            resultListBox.TabIndex = 5;
            // 
            // temperatureValueLabel
            // 
            temperatureValueLabel.AutoSize = true;
            temperatureValueLabel.Location = new Point(109, 9);
            temperatureValueLabel.Name = "temperatureValueLabel";
            temperatureValueLabel.Size = new Size(13, 15);
            temperatureValueLabel.TabIndex = 6;
            temperatureValueLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 210);
            Controls.Add(temperatureValueLabel);
            Controls.Add(resultListBox);
            Controls.Add(temparatureLabel);
            Controls.Add(temperatureTrackBar);
            Controls.Add(windCheckBox);
            Controls.Add(falloutComboBox);
            Controls.Add(confirmButton);
            Name = "MainForm";
            Text = "Weather Adviser";
            ((System.ComponentModel.ISupportInitialize)temperatureTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmButton;
        public ComboBox falloutComboBox;
        public CheckBox windCheckBox;
        public TrackBar temperatureTrackBar;
        private Label temparatureLabel;
        public ListBox resultListBox;
        public Label temperatureValueLabel;
    }
}
