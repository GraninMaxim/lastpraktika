using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        manufactureEntities db = manufactureEntities.GetContext();
        good p1 = new good();
        public Add()
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

            try
            {
                if ((int.Parse(OB.Text) > 1))
                {
                    p1.Название_изделия = Name.Text;
                    p1.Цель = Cel.Text;
                    p1.Типовое = Type.Text;
                    p1.Объём_выпуска = int.Parse(OB.Text);
                   


                    db.goods.Add(p1);
                    db.SaveChanges();
                    MessageBox.Show("Сохранение прошло успешно");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
