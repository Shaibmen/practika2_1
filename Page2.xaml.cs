using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using _1PractPractika.DataSet1TableAdapters;

namespace _1PractPractika
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public List<String> IerarchDolz = new List<String>();
        PriestTableAdapter priest = new PriestTableAdapter();


        public Page2()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = priest.GetData();

            IerarchDolz.Add("Священник");
            IerarchDolz.Add("Священница");
            IerarchDolz.Add("Папа");
            IerarchDolz.Add("Кардинал");
            ierach.ItemsSource = IerarchDolz;

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            priest.InsertQuery(name.Text, secondname.Text, middlename.Text, ierach.Text);
            SecondGrid.ItemsSource = priest.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object Id = (SecondGrid.SelectedItem as DataRowView).Row[0];

            priest.UpdateQuery(name.Text, secondname.Text, middlename.Text, ierach.Text, Convert.ToInt32(Id));
            SecondGrid.ItemsSource = priest.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SecondGrid.SelectedItem as DataRowView != null)
                {
                    object id = (SecondGrid.SelectedItem as DataRowView).Row[0];
                    priest.DeleteQuery(Convert.ToInt32(id));
                    SecondGrid.ItemsSource = priest.GetData();

                }
            }
            catch
            {
                MessageBox.Show("анлак");
            }
            
        }

        private void ierach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
