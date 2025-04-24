using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private database db = new database();
        int elmentettid = -1;
        DataRow sor;
        DataRowView selectedRow;


        public MainWindow()
        {   
            InitializeComponent();
            datagrid2.ItemsSource = db.GetOrders().DefaultView;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            selectedRow = (DataRowView)datagrid2.SelectedItem;
            if (selectedRow != null)
            {
                sor = selectedRow.Row;
            }
            else
            {
                datagrid2.ItemsSource = db.GetOrders().DefaultView;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            datagrid2.ItemsSource = db.GetOrders().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                db.RendelesTorles(elmentettid);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            selectedRow = (DataRowView)datagrid2.SelectedItem;

            if (selectedRow != null)
            {
                sor = selectedRow.Row;
                elmentettid = Convert.ToInt32(sor["UploadedOrderId"]);
                db.RendelesTorles(elmentettid);
                datagrid2.UnselectAll();
                datagrid2.ItemsSource = db.GetOrders().DefaultView;
            }
            else if (sor != null)
            {
                elmentettid = Convert.ToInt32(sor["UploadedOrderId"]);
                db.RendelesTorles(elmentettid);
                datagrid2.UnselectAll();
                datagrid2.ItemsSource = db.GetOrders().DefaultView;
            }
        }

        private void datagrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedRow = null;
            sor = null;
            if (datagrid2.SelectedItem != null)
            {
                datagrid2.UnselectAll();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedRow = null;
            sor = null;
            if (datagrid2.SelectedItem != null)
            {
                datagrid2.UnselectAll();
            }
        }

        private void felvetel_Click(object sender, RoutedEventArgs e)
        {
            datagrid2.UnselectAll();
            var newWindow = new RendelesFelvetel();
            newWindow.ShowDialog();
        }
    }
}
