using Application.UseCases;
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

namespace WpfCattery
{
    /// <summary>
    /// Logica di interazione per ManageAdoptersWindow.xaml
    /// </summary>
    public partial class ManageAdoptersWindow : Window
    {
        private Cattery _cattery;
        public ManageAdoptersWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
            dataGridAdopters.ItemsSource = _cattery.GetAllAdopters();
        }
        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
