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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProductList
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Products> productsCollection;
        CollectionView view;

        public MainWindow()
        {
            InitializeComponent();
            PrepareBinding();
         
        }

        internal void PrepareBinding()
        {
            productsCollection = new ObservableCollection<Products>()
            {
                new Products("AA","śruba",122,"Poznań"),
                new Products("DD","wkręt",1222,"Warszawa"),
                new Products("BB","łożysko",62,"Lublin"),
                new Products("CC","wał",8,"Ełk"),
            };
            lstProducts.ItemsSource = productsCollection;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Symbol", ListSortDirection.Ascending));
            view.Filter = Filtr;

        }

        private bool Filtr(object item)
        {
            if (String.IsNullOrEmpty(txtFiltr.Text)) return true;
            else return ((item as Products).Name.IndexOf(txtFiltr.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstProducts.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productsCollection.Add(new Products("null", "null", 0, "null"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Products products = lstProducts.SelectedItem as Products;
            MessageBoxResult result = MessageBox.Show("Czy na pewno usunąć produkt: " + products.Name,"Warning", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            productsCollection.Remove(products);
        }
    }
}
