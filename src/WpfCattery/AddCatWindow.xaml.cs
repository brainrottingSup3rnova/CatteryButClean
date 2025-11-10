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
    /// Logica di interazione per AddCatWindow.xaml
    /// </summary>
    public partial class AddCatWindow : Window
    {
        public AddCatWindow()
        {
            InitializeComponent();
        }

        private void AddCatButton_Click(object sender, RoutedEventArgs e)
        {
            // Logica per aggiungere un gatto
            string name = NameTextBox.Text;
            string breed = BreedTextBox.Text;
            //TODO: Aggiungere il gatto al repository e finire la logica
        }
    }
}
