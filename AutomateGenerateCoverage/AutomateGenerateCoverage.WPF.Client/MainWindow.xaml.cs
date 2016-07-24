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
    using System.Diagnostics;

    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports;
    using AutomateGenerateCoverage.Models.Reports.FolderManagers;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Startup : Window
    {
        private const string DefaultFolder = "D:\\Github";

        private IReportManager reportManager;
        private IReport latestReport;

        public Startup()
        {
            InitializeComponent();
            InitializeReportManager();
        }

        private void SelectTargetTestingLibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            var myDialog = new OpenFileDialog();
            myDialog.InitialDirectory = Startup.DefaultFolder;
            myDialog.ShowDialog();
            SelectedFileTextBox.Text = myDialog.FileName;
        }

        private void GenerateBatFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetDll = SelectedFileTextBox.Text;
                this.latestReport = this.reportManager.GenerateReport(targetDll);
                SelectedFileTextBox.Text = $"Successfully generated {latestReport.RunTestsBAT.Name}.";
            }
            catch (Exception)
            {
                SelectedFileTextBox.Text = "Select a valid testing library first.";
            }
        }

        private void RunTestsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedFileTextBox.Text = $"Executing {latestReport.RunTestsBAT.Name}.";
                Process.Start(latestReport.RunTestsBAT.FullName);
            }
            catch (Exception)
            {
                SelectedFileTextBox.Text = "Select a valid testing library and generate a batch file.";
            }
        }

        private void OpenInBroserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedFileTextBox.Text = $"Opening {latestReport.ReportHTML.Name} in default browser.";
                Process.Start(latestReport.ReportHTML.FullName);
            }
            catch (Exception)
            {
                SelectedFileTextBox.Text = "Select a valid testing library and generate a batch file.";
            }
        }

        private void InitializeReportManager()
        {
            var folderManager = new BasicFolderManager(Environment.CurrentDirectory);
            this.reportManager = new ReportManager(folderManager);
        }
    }
}
