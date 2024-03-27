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
using System.Xml.Linq;

namespace lastpraktika
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        manufactureEntities db = manufactureEntities.GetContext();
        good p1;
        public Change()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Name.Text.Length == 0) errors.AppendLine("Введите название");
            if (Cel.Text.Length == 0) errors.AppendLine("Введите цель");
            if (Type.Text.Length == 0) errors.AppendLine("Введите типовое");
            if (OB.Text.Length == 0) errors.AppendLine("Введите объём");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.Название_изделия = Name.Text;
            p1.Цель = Cel.Text;
            p1.Типовое = Type.Text;
            p1.Объём_выпуска = Convert.ToInt32(OB.Text);


            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.goods.Find(Class1.Id);
            Name.Text = p1.Название_изделия;
            Cel.Text = p1.Цель;
            Type.Text = p1.Типовое;
            OB.Text = Convert.ToString(p1.Объём_выпуска);
        }
    }
}
