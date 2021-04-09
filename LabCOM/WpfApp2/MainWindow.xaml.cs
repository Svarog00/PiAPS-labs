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
            Page page = new Page();
            page.FormTitlePage(cafedraTextBox.Text, int.Parse(labNumTextBox.Text), themeTextBox.Text, disciplineTextBox.Text,
                studentTextBox.Text, teacgerTextBox.Text, int.Parse(yearTextBox.Text));
        }
    }
}
