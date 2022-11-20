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

namespace random
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string datum = "";
            DateTime datumVandaag = DateTime.Today;
            datum = datumVandaag.ToLongDateString();
            LblTime.Content = datum;
            NieuweSpel();
        }
        int teller = 0;
        Random ran = new Random();
        int getal = 0;

        private void BtnSpel_Click(object sender, RoutedEventArgs e)
        {
            EvalueerSpel(TxtInvoer.Text);
        }
        private void EvalueerSpel(string textWaarde)
        {
            int waarde = 0;
            if(int.TryParse(textWaarde, out waarde))
            {
                teller++;
                if(getal == waarde)
                {
                    BtnSpel.IsEnabled = false;
                    TxtInvoer.IsEnabled = false;
                    TxtUitvoer1.Text = "Gefelisiteerd !";
                    TxtUitvoer2.Text = $" U heeft het getal in {teller} pogingen";
                }
                else
                {
                    if(getal < waarde)
                    {
                        TxtUitvoer1.Text = "Hoger raden";
                    }
                    else
                    {
                        TxtUitvoer2.Text = "Lager raden";

                    }
                }
            }
            else
            {
                MessageBox.Show("Error", "Error");
            }
        }

        private void BtnNieuwe_Click(object sender, RoutedEventArgs e)
        {
            NieuweSpel();
        }
        private void NieuweSpel()
        {
            BtnSpel.IsEnabled = true;
            TxtInvoer.IsEnabled = true;
            TxtInvoer.Clear();
            TxtUitvoer1.Text = String.Empty;
            TxtUitvoer2.Text = "";
            teller = 0;
            getal = ran.Next(1, 100);
        }
    }
}
