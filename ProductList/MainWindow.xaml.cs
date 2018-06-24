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

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            productsCollection = new ObservableCollection<Products>()
            {
                new Products("AA","śruba",122,"Poznań"),
                new Products("DD","wkręt",1222,"Warszawa"),
                new Products("BB","łożysko",62,"Lublin"),
                new Products("CC","wał",8,"Ełk"),
            };
            lstProducts.ItemsSource = productsCollection;
        }
    }
}
