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
    /// <summary>
    /// Логика взаимодействия для meat.xaml
    /// </summary>
    public partial class meat : Window
    {
        meatTableAdapter meatTableAdapter = new meatTableAdapter();
        public meat()
        {
            InitializeComponent();
            Meat_DataGrid.ItemsSource = meatTableAdapter.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && number.Text != "")
            {
                meatTableAdapter.InsertQuery(name.Text, Convert.ToInt32(number.Text));
                Meat_DataGrid.ItemsSource = meatTableAdapter.GetData();
                name.Text = "";
                number.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Meat_DataGrid.SelectedItem as DataRowView) != null)
            {
                meatTableAdapter.DeleteQuery(Convert.ToInt32((Meat_DataGrid.SelectedItem as DataRowView).Row[0]));
                Meat_DataGrid.ItemsSource = meatTableAdapter.GetData();
                MessageBox.Show("Удаление прошло успешно!");
                name.Text = "";
                number.Text = "";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if ((Meat_DataGrid.SelectedItem as DataRowView) != null && name.Text != "" && number.Text != "")
            {
                meatTableAdapter.UpdateQuery(name.Text, Convert.ToInt32(number.Text), Convert.ToInt32((Meat_DataGrid.SelectedItem as DataRowView).Row[0]));
                Meat_DataGrid.ItemsSource = meatTableAdapter.GetData();
                MessageBox.Show("Изменение прошло успешно!");
                name.Text = "";
                number.Text = "";
            }
        }

        private void Meat_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Meat_DataGrid.SelectedItem as DataRowView) != null)
            { 
                name.Text = (Meat_DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                number.Text = (Meat_DataGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }
    }
}
