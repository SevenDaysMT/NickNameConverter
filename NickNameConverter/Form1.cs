using System;
using System.Windows.Forms;

namespace NickNameConverter
{
    public partial class Form1 : Form
    {
        private MainWindowViewModel _viewModel;
        public Form1()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            Load += delegate {
                RussianLetters.DataBindings.Add("Text", _viewModel, nameof(_viewModel.RusLetterNick), true, DataSourceUpdateMode.OnPropertyChanged);
                EnglishLetters.DataBindings.Add("Text", _viewModel, nameof(_viewModel.EngLetterNick), true, DataSourceUpdateMode.OnPropertyChanged);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
