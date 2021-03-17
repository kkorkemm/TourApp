using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Hotels());
            NavigationManager.MainFrame = MainFrame;

            ImportTours();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\C#\ToursApp\данные для импорта\турыы.txt");
            var images = Directory.GetFiles(@"C:\C#\ToursApp\данные для импорта\фото Туры");

            foreach (var line in fileData)
            {
                var dataLine = line.Split('\t');

                var newTour = new Tour
                {
                    TourName = dataLine[0].Replace("\"", ""),
                    TicketCount = Convert.ToInt32(dataLine[2]),
                    Price = Convert.ToDecimal(dataLine[3]),
                    IsActual = dataLine[4] != "0"
                };

                foreach (var tourType in dataLine[5].Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = TourAgentDBEntities1.GetContext().TypeOfTour.ToList().FirstOrDefault(a => a.TypeName == tourType);
                    if (currentType != null)
                        newTour.TypeOfTour.Add(currentType);
                }

                try
                {
                    newTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(a => a.Contains(newTour.TourName)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                TourAgentDBEntities1.GetContext().Tour.Add(newTour);
                TourAgentDBEntities1.GetContext().SaveChanges();
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (NavigationManager.MainFrame.CanGoBack)
                Btn_Back.Visibility = Visibility.Visible;
            else
                Btn_Back.Visibility = Visibility.Hidden;
        }
    }
}
