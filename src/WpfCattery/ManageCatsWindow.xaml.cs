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
    /// Logica di interazione per ManageCatsWindow.xaml
    /// </summary>
    public partial class ManageCatsWindow : Window
    {
        private Cattery _cattery;
        public ManageCatsWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
            dataGridCats.ItemsSource = _cattery.GetAllCats();    
        }

        private void AdoptCat_Click(object sender, EventArgs e)
        {
            //idk
        }
    }
}
