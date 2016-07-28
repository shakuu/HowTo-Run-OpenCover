namespace AutomateGenerateCoverage.WPF.Client
{
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Windows;

    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports;
    using AutomateGenerateCoverage.Models.Reports.FolderManagers;

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
                SelectedFileTextBox.Text = $"Executing {latestReport.RunTestsBAT.Name} - Complete.";
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
                SelectedFileTextBox.Text = $"Opening {latestReport.ReportHTML.Name} in default browser - Complete.";
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
