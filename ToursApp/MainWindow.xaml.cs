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
            MainFrame.Navigate(new ToursPage());
            NavigationManager.MainFrame = MainFrame;

            // ImportTours();
        }

        /// <summary>
        /// Импорт данных о турах и изображений (уже импортированы)
        /// </summary>
        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\C#\TourApp\данные для импорта\турыы.txt");
            var images = Directory.GetFiles(@"C:\C#\TourApp\данные для импорта\фото Туры");

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

        /// <summary>
        /// Кнопка Назад
        /// </summary>
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.GoBack();
        }

        /// <summary>
        /// Кнопка Перейти к списку отелей
        /// </summary>
        private void Btn_Hotels_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new Hotels());
            TextMain.Text = "Список отелей";
        }

        /// <summary>
        ///  Отображение и скрытие кнопок Назад и Перейти к списке отелей
        /// </summary>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (NavigationManager.MainFrame.CanGoBack)
                Btn_Back.Visibility = Visibility.Visible;
            else
                Btn_Back.Visibility = Visibility.Hidden;

            if (NavigationManager.MainFrame.CanGoBack)
                Btn_Hotels.Visibility = Visibility.Hidden;
            else
                Btn_Hotels.Visibility = Visibility.Visible;
        }
    }
}
