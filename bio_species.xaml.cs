using WpfPract1.FermaDataSetTableAdapters;
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
using System.Windows.Shapes;
using System.Data;

namespace WpfPract1
{
    public partial class bio_species : Window
    {
        Biological_speciesTableAdapter bio_SpeciesTableAdapter = new Biological_speciesTableAdapter();
        public bio_species()
        {
            InitializeComponent();
            Bio_speciesDataGrid.ItemsSource = bio_SpeciesTableAdapter.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MyTextBox.Text != "")
            {
                bio_SpeciesTableAdapter.InsertQuery(MyTextBox.Text);
                Bio_speciesDataGrid.ItemsSource = bio_SpeciesTableAdapter.GetData();
                MyTextBox.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Bio_speciesDataGrid.SelectedItem as DataRowView) != null)
            {
                bio_SpeciesTableAdapter.DeleteQuery(Convert.ToInt32((Bio_speciesDataGrid.SelectedItem as DataRowView).Row[0]));
                MessageBox.Show("Удаление прошло успешно!");
                Bio_speciesDataGrid.ItemsSource = bio_SpeciesTableAdapter.GetData();
                MyTextBox.Text = "";
            }   
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if ((Bio_speciesDataGrid.SelectedItem as DataRowView) != null && MyTextBox.Text != "")
            {
                bio_SpeciesTableAdapter.UpdateQuery(MyTextBox.Text, Convert.ToInt32((Bio_speciesDataGrid.SelectedItem as DataRowView).Row[0]));
                Bio_speciesDataGrid.ItemsSource = bio_SpeciesTableAdapter.GetData();
                MessageBox.Show("Изменение прошло успешно!");
                MyTextBox.Text = "";
            }
        }

        private void Bio_speciesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Bio_speciesDataGrid.SelectedItem as DataRowView) != null)
                MyTextBox.Text = (Bio_speciesDataGrid.SelectedItem as DataRowView).Row[1].ToString();
        }
    }
}

