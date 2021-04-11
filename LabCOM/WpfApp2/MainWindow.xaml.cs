using System;
using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Page Page = new Page();
                Page.FormTitlePage(cafedraTextBox.Text, int.Parse(labNumTextBox.Text), themeTextBox.Text, disciplineTextBox.Text,
                    studentTextBox.Text, teacgerTextBox.Text, int.Parse(yearTextBox.Text));
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
