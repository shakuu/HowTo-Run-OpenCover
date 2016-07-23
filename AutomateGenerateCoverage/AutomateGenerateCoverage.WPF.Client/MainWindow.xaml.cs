using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AutomateGenerateCoverage.WPF.Client
{
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void SelectTargetTestingLibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            var myDialog = new OpenFileDialog();

            myDialog.ShowDialog();

            SelectedFileTextBox.Text = myDialog.FileName;
        }
    }
}
