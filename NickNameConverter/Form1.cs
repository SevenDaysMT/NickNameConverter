using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NickNameConverter
{
    public partial class Form1 : Form
    {
        private MainWindowViewModel _viewModel;
        //private NicknameProvider nicknameProvider;
        public Form1()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            Load += delegate {
                RussianLetters.DataBindings.Add("Text", _viewModel, nameof(_viewModel.RusLetterNick), true, DataSourceUpdateMode.OnPropertyChanged);
                EnglishLetters.DataBindings.Add("Text", _viewModel, nameof(_viewModel.EngLetterNick), true, DataSourceUpdateMode.OnPropertyChanged);
            };
        }
        
    }
}
