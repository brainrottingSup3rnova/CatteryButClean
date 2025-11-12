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
    public partial class ManageAdoptionsWindow : Window
    {
        private Cattery _cattery;
        public ManageAdoptionsWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
            dataGridAdoptions.ItemsSource = _cattery.GetAllAdoptions();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveAdoption_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button && button.DataContext is Application.Dto.AdoptionDto adoptionDto)
            {
                _cattery.CancelAdoption(adoptionDto);
                MessageBox.Show("Adoption removed successfully.");
                dataGridAdoptions.ItemsSource = _cattery.GetAllAdoptions();
            } 
        }
    }
}
