using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application;
using Application.UseCases;
using Infrastructure.Repositories;

namespace WpfCattery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cattery cattery;
        JsonCatRepository jsonCatRepository = new JsonCatRepository();

        public MainWindow()
        {
            InitializeComponent();
            cattery = new Cattery(jsonCatRepository);
            catsCountLabel.Content = cattery.GetAllCats().Length;
            cattery.GetAllAdopters();
            adoptionsCountLabel.Content = cattery.GetAllAdoptions().Length;
            adoptersCountLabel.Content = cattery.GetAllAdopters().Length;
        }

        private void AddCat_Click(object sender, RoutedEventArgs e)
        {
            AddCatWindow addCatWindow = new AddCatWindow(cattery);
            addCatWindow.ShowDialog();
            RefreshCounts();
        }

        private void ManageCats_Click(object sender, RoutedEventArgs e)
        {
            ManageCatsWindow manageCatsWindow = new ManageCatsWindow(cattery);
            manageCatsWindow.ShowDialog();
            RefreshCounts();
        }

        private void RegisterAdoption_Click(object sender, RoutedEventArgs e)
        {
            RegisterAdoptionWindow registerAdoptionWindow = new RegisterAdoptionWindow(cattery);
            registerAdoptionWindow.ShowDialog();
            RefreshCounts();
        }

        private void ManageAdoptions_Click(object sender, RoutedEventArgs e)
        {
            ManageAdoptionsWindow manageAdoptionsWindow = new ManageAdoptionsWindow(cattery);
            manageAdoptionsWindow.ShowDialog();
            RefreshCounts();
        }

        private void AddAdopter_Click(object sender, RoutedEventArgs e)
        {
            AddAdopterWindow addAdopterWindow = new AddAdopterWindow(cattery);
            addAdopterWindow.ShowDialog();
            RefreshCounts();
        }

        private void ManageAdopters_Click(object sender, RoutedEventArgs e)
        {
            ManageAdoptersWindow manageAdoptersWindow = new ManageAdoptersWindow(cattery);
            manageAdoptersWindow.ShowDialog();
            RefreshCounts();
        }

        public void RefreshCounts()
        {
            adoptionsCountLabel.Content = cattery.GetAllAdoptions().Length.ToString();
            catsCountLabel.Content = cattery.GetAllCats().Length.ToString();
            adoptersCountLabel.Content = cattery.GetAllAdopters().Length.ToString();
        }
    }
}