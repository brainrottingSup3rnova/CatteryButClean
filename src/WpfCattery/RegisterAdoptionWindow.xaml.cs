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
    /// Logica di interazione per RegisterAdoptionWindow.xaml
    /// </summary>
    public partial class RegisterAdoptionWindow : Window
    {
        private Cattery _cattery;
        public RegisterAdoptionWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
        }
    }
}
