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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{

    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel currentHotel = new Hotel();

        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                currentHotel = selectedHotel;

            DataContext = currentHotel;
            ComboCountry.ItemsSource = TourAgentDBEntities1.GetContext().Country.ToList();
        }

        private void Btn_AddSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentHotel.HotelName))
                errors.AppendLine("Укажите название отеля");
            if (currentHotel.StarCount < 1 || currentHotel.StarCount > 5)
                errors.AppendLine("Укажите количество звезд от 1 до 5");
            if (currentHotel.Country == null)
                errors.AppendLine("Укажите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (currentHotel.ID == 0)
                    TourAgentDBEntities1.GetContext().Hotel.Add(currentHotel);

                try
                {
                    TourAgentDBEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");
                    NavigationManager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
