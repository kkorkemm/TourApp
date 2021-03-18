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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        /// <summary>
        /// Страница с турами
        /// </summary>
        public ToursPage()
        {
            InitializeComponent();

            var types = TourAgentDBEntities1.GetContext().TypeOfTour.ToList();
            types.Insert(0, new TypeOfTour { TypeName = "Все категории" });
            ComboType.ItemsSource = types;
            ComboType.SelectedIndex = 0;

            UpdateTours();
        }

        /// <summary>
        /// Фильтрация по названию тура, категории и актуальности
        /// </summary>
        private void UpdateTours()
        {
            var currentTours = TourAgentDBEntities1.GetContext().Tour.ToList();

            if (TextBoxSearch.Text.Length > 0)
                currentTours = currentTours.Where(p => p.TourName.ToLower().Contains(TextBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked == true)
                currentTours = currentTours.Where(p => p.IsActual).ToList();

            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.TypeOfTour.Contains(ComboType.SelectedItem as TypeOfTour)).ToList();

            ListViewTours.ItemsSource = currentTours.ToList();
        }


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
