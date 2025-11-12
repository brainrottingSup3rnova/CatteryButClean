using Application.UseCases;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
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
            Email email = new Email(txtBoxEmail.Text);
            PhoneNumber phoneNumber = new PhoneNumber(txtBoxPhoneNumber.Text);
            string street = txtBoxStreet.Text;
            string civicNumber = txtBoxCivicNumber.Text;    
            string city = txtBoxCity.Text;
            string postalCode = txtBoxPostalCode.Text;
            Address address = new Address(street, civicNumber, city, postalCode);
            TIN tin = new TIN(txtBoxTin.Text);
            Adopter adopter = new Adopter(name, surname, email, phoneNumber, address, tin);
            _cattery.RegisterAdopter(adopter);
            MessageBox.Show("Adopter added successfully!");
            this.Close();
        }
    }
}
