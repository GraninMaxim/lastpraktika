using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace lastpraktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        manufactureEntities db = manufactureEntities.GetContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.goods.Load();
            DG.ItemsSource = db.goods.Local.ToBindingList();
            DG2.ItemsSource = db.companies.Local.ToBindingList();
            DG3.ItemsSource = db.materials.Local.ToBindingList();
            DG4.ItemsSource = db.properties.Local.ToBindingList();
            DG5.ItemsSource = db.years.Local.ToBindingList();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.Show();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DG.SelectedIndex;
            if (indexRow != -1)
            {
                good row = (good)DG.Items[indexRow];
                Class1.Id = row.Код_изделия;
                Change f = new Change();
                f.ShowDialog();
                DG.Items.Refresh();

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    good row = (good)DG.SelectedItems[0];
                    db.goods.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
    }
}
