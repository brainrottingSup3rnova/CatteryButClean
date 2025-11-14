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
    /// <summary>  
    /// Logica di interazione per AddCatWindow.xaml  
    /// </summary>  
    public partial class AddCatWindow : Window
    {
        private Cattery _cattery;
        public AddCatWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
        }

        private void AddCatButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string breed = BreedTextBox.Text;
            bool gender = false;
            if (GenderTextBox.Text == "Male" || GenderTextBox.Text == "male")
            {
                gender = true;
            }
            else if (GenderTextBox.Text == "Female" || GenderTextBox.Text == "female")
            {
                gender = false;
            }
            DateTime arrivalDate = ArrivalDatePicker.SelectedDate.HasValue ? ArrivalDatePicker.SelectedDate.Value : DateTime.MinValue;
            DateTime birthdate = BirthdatePicker.SelectedDate.HasValue ? BirthdatePicker.SelectedDate.Value : DateTime.MinValue;
            string description = DescriptionTextBox.Text;
            CatDto cat = new CatDto(name, breed, gender, arrivalDate, null, birthdate, description, null);
            _cattery.AddCat(cat);
            MessageBox.Show("Cat added successfully!");
            Close();
        }
    }
}
