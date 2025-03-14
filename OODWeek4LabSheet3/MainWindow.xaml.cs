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

namespace OODWeek4LabSheet3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities(); // referenct the database model 
        public MainWindow()
        {
            InitializeComponent();
        }

        // Exercise 1: Company names 
        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            // linq query 
            var query = from c in db.Customers
                        select c.CompanyName;
            // get results for list box 
            Ex1ListBox.ItemsSource = query.ToList();
        }

        // Exercise 2: Customer objects 
        private void Ex2Button_CLick(object sender, RoutedEventArgs e)
        {
            // linq query 
            var query = from c in db.Customers
                        select c; 

            // get results for Data Grid 
            Ex2DataGrid.ItemsSource = query.ToList();
        }

        // Exercise 3: Order Information 
        private void Ex3Button_CLick(object sender, RoutedEventArgs e)
        {
            // linq query 
            var query = from o in db.Orders
                        where o.Customer.City.Equals("London")
                        || o.Customer.City.Equals("Paris")
                        || o.Customer.Country.Equals("USA")
                        orderby o.Customer.CompanyName
                        select new
                        {
                            CustomerName = o.Customer.CompanyName,
                            City = o.Customer.City,
                            Address = o.ShipAddress
                        };

            Ex3DataGrid.ItemsSource = query.ToList().Distinct();   
        }

        // Exercise 4: Product information 
        private void Ex4Button_CLick(object sender, RoutedEventArgs e)
        {
            // linq query 
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };

            Ex4DataGrid.ItemsSource = query.ToList();    

        }
    }
}
