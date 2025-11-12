using Application.Dto;
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
    public partial class RegisterAdoptionWindow : Window
    {
        private Cattery _cattery;
        public RegisterAdoptionWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
            comboBoxCats.ItemsSource = _cattery.GetAllCats();
            comboBoxAdopters.ItemsSource = _cattery.GetAllAdopters();
        }

        public RegisterAdoptionWindow(Cattery cattery, string name)
        {
            InitializeComponent();
            _cattery = cattery;
            comboBoxCats.SelectedItem = name;   
        }

        private void RegisterAdoptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCats.SelectedItem == null || comboBoxAdopters.SelectedItem == null)
            {
                MessageBox.Show("Please select both a cat and an adopter.");
                return;
            }
            var selectedCatName = (CatDto)comboBoxCats.SelectedItem;
            var selectedAdopterName = (AdopterDto)comboBoxAdopters.SelectedItem;
            //idk how to proceed...
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
