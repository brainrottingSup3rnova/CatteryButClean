using Application.UseCases;
using Application.Dto;
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
    /// Logica di interazione per AddAdopterWindow.xaml
    /// </summary>
    public partial class AddAdopterWindow : Window
    {
        private Cattery _cattery;
        public AddAdopterWindow(Cattery cattery)
        {
            InitializeComponent();
            _cattery = cattery;
        }

        private void AddAdopterBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            string surname = txtBoxSurname.Text;
            string email = txtBoxEmail.Text;
            string phoneNumber = txtBoxPhoneNumber.Text;
            string street = txtBoxStreet.Text;
            string civicNumber = txtBoxCivicNumber.Text;    
            string city = txtBoxCity.Text;
            string postalCode = txtBoxPostalCode.Text;
            string tin = txtBoxTin.Text;
            AdopterDto adopter = new AdopterDto(name, surname, email, phoneNumber, street, civicNumber, city, postalCode ,tin);
            _cattery.RegisterAdopter(adopter);   
            MessageBox.Show("Adopter added successfully!");
            this.Close();
        }
    }
}
