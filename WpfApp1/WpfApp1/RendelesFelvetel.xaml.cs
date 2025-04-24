using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    public partial class RendelesFelvetel : Window
    {
        private database db = new database();
        int kivalasztotttermek = -1;
        DataRow sor;
        DataRowView selectedRow;
        int newTotal = 0;


        public RendelesFelvetel()
        {
            InitializeComponent();
            termekgrid.ItemsSource = db.GetItems().DefaultView;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            termekgrid.ItemsSource = db.GetItems().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.RendelesTorles(kivalasztotttermek);
        }

        private void hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            selectedRow = (DataRowView)termekgrid.SelectedItem;

            if (selectedRow != null)
            {
                sor = selectedRow.Row;
                string termekNev = sor["Name"].ToString();
                int ar = Convert.ToInt32(sor["Price"]);

                string rendelListaText = rendelolista.Content?.ToString() ?? "";

                Regex regex = new Regex($@"^{Regex.Escape(termekNev)}\s(\d+)x$", RegexOptions.Multiline);
                Match match = regex.Match(rendelListaText);

                if (match.Success)
                {
                    int darabszam = Convert.ToInt32(match.Groups[1].Value) + 1;
                    rendelListaText = regex.Replace(rendelListaText, $"{termekNev} {darabszam}x");
                }
                else
                {
                    rendelListaText += $"{termekNev} 1x\n";
                }

                rendelolista.Content = rendelListaText;

                // Extract only the numeric part from the total cost
                int.TryParse(Regex.Replace(vegosszeg.Content?.ToString() ?? "0", @"\D", ""), out int currentTotal);
                newTotal = currentTotal + ar;

                // Update the label with the formatted text
                vegosszeg.Content = $"Végösszeg: {newTotal} Ft";

                termekgrid.UnselectAll();
                sor = null;
            }
        }


        
        private void termekgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            selectedRow = null;
            sor = null;
            if (termekgrid.SelectedItem != null)
            {
                termekgrid.UnselectAll();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedRow = null;
            sor = null;
            if (termekgrid.SelectedItem != null)
            {
                termekgrid.UnselectAll();
            }
        }

        private void felvetel_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new RendelesFelvetel();
            newWindow.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string searchTerm = textBox.Text;
                DataTable result = db.SearchItems(searchTerm);
                termekgrid.ItemsSource = result.DefaultView;
            }
        }

        private void bezaras_click(object sender, RoutedEventArgs e)
        {
            termekgrid.UnselectAll();
            RendelesFelvetel.GetWindow(this)?.Close();
        }

        private void felvetelmegkezdes_click(object sender, RoutedEventArgs e)
        {
            if (rendelolista.Content == null)
            {
                MessageBox.Show("Nem adott meg rendelést!");
                return;
            }
            else
            {
                string convertlist = rendelolista.Content.ToString();
                string fogyasztastipus = combobox.Text;
                string kuldeslista = convertlist.Substring(0, convertlist.Length - 2);
                db.AdatbazisbaFelvetel(kuldeslista, newTotal, fogyasztastipus);
                termekgrid.UnselectAll();
                vegosszeg.Content = "Végösszeg: 0 Ft";
                rendelolista.Content = null;
                textBox.Text = null;
                combobox.Text = "Helyben";
                bezaras_click(sender, e);
            }
        }




    }
}
