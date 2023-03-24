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

namespace WpfPract1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<string> strings = new List<string>() { "Таблица с видами животных", "Таблица с текущими животными", "Таблица для заказа мяса" };
            InitializeComponent();
            bio_species_combbox.ItemsSource = strings;
        }

        private void bio_species_combbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (bio_species_combbox.SelectedItem.ToString() == "Таблица с текущими животными")
            {
                personal window = new personal();
                window.Show();
                Close();
            }
            else if (bio_species_combbox.SelectedItem.ToString() == "Таблица с видами животных")
            {
                bio_species window = new bio_species();
                window.Show();
                Close();
            }
            else
            {
                meat window = new meat();
                window.Show();
                Close();
            }
        }
    }
}
