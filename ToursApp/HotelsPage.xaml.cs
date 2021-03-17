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
    /// Логика взаимодействия для Hotels.xaml
    /// </summary>
    public partial class Hotels : Page
    {
        public Hotels()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var removingHotels = GridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (removingHotels.Count == 0)
            {
                MessageBox.Show("Выберите элементы для удаления");
            }

            else
            {
                MessageBoxResult result = MessageBox.Show($"Вы точно хотите удалить {removingHotels.Count} элемента(-ов)?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        TourAgentDBEntities1.GetContext().Hotel.RemoveRange(removingHotels);
                        TourAgentDBEntities1.GetContext().SaveChanges();

                        MessageBox.Show("Данные удалены!");

                        GridHotels.ItemsSource = TourAgentDBEntities1.GetContext().Hotel.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }          
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TourAgentDBEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                GridHotels.ItemsSource = TourAgentDBEntities1.GetContext().Hotel.ToList();
            }
        }
    }
}
