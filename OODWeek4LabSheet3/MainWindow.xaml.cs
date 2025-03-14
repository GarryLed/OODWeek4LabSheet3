﻿using System;
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

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            // linq query 
            var query = from c in db.Customers
                        select c.CompanyName;
            // get results 
            Ex1ListBox.ItemsSource = query.ToList();
        }
    }
}
