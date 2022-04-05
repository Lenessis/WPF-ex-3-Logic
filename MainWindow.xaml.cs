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

namespace zad3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Price price;
        string formats = "";
        string gm = "";
        string print = "";
        string color = "";
        

        public MainWindow()
        {
            price = new Price();
            InitializeComponent();
        }

        // NAKŁAD

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             int amount = int.Parse(edition.Text); // nakład - zamiana tekstu na int
            if (amount < 0)
                amount = 0;
            price.Amount = amount;
            ChangeSummary();
        }

        // FORMAT PAPIERU

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double format_price = 0.2;
            string text = "";
            
            switch(sheetSize.Value)
            {
                case 5:
                    format_price = 0.2;
                    text = "A5 - cena " + Math.Round(format_price, 2) * 100 + "gr/szt";
                    formats = "A5";
                    break;
                case 4:
                    format_price = 0.2 * 2.5;
                    text = "A4 - cena " + Math.Round(format_price, 2) * 100 + "gr/szt";
                    formats = "A4";
                    break;
                case 3:
                    format_price = 0.2 * Math.Pow(2.5,2);
                    text = "A3 - cena " + Math.Round(format_price, 2) + "zł/szt";
                    formats = "A3";
                    break;
                case 2:
                    format_price = 0.2 * Math.Pow(2.5, 3);
                    text = "A2 - cena " + Math.Round(format_price, 2) + "zł/szt";
                    formats = "A2";
                    break;
                case 1:
                    format_price = 0.2 * Math.Pow(2.5, 4);
                    text = "A1 - cena " + Math.Round(format_price, 2) + "zł/szt";
                    formats = "A1";
                    break;
                case 0:
                    format_price = 0.2 * Math.Pow(2.5, 5);
                    text = "A0 - cena " + Math.Round(format_price, 2) + "zł/szt";
                    formats = "A0";
                    break;
            }

            try
            {
                sheetSizeText.Content = text;
            }
            catch
            {

            }
                
            price.FormatPrice = format_price;
            ChangeSummary();
        }

        // KOLOR PAPIERU

        private void color_paper_Checked(object sender, RoutedEventArgs e)
        {
            color_of_paper.IsEnabled = true;
        }

        private void color_paper_Unchecked(object sender, RoutedEventArgs e)
        {
            color_of_paper.IsEnabled = false;
            price.color_paper = false;
            ChangeSummary();
        }

        private void color_of_paper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            price.color_paper = true; 
            color = color_of_paper.SelectedValue.ToString();
            ChangeSummary();
        }

        // GRAMATURA

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            price.grammage = 1;
            gm = "80 g/m";
            ChangeSummary();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            price.grammage = 2;
            gm = "120 g/m";
            ChangeSummary();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            price.grammage = 2.5;
            gm = "200 g/m";
            ChangeSummary();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            price.grammage = 3;
            gm = "240 g/m";
            ChangeSummary();
        }

        // OPCJE WYDRUKU

        private void ColorInk_Checked(object sender, RoutedEventArgs e)
        {
            price.color_ink = true;
            PrintInfo();
            ChangeSummary();
        }

        private void ColorInk_Unchecked(object sender, RoutedEventArgs e)
        {
            price.color_ink = false;
            PrintInfo();
            ChangeSummary();
        }

        private void TwoSided_Checked(object sender, RoutedEventArgs e)
        {
            price.two_sided = true;
            PrintInfo();
            ChangeSummary();
        }

        private void TwoSided_Unchecked(object sender, RoutedEventArgs e)
        {
            price.two_sided = false;
            PrintInfo();
            ChangeSummary();
        }

        private void UV_Checked(object sender, RoutedEventArgs e)
        {
            price.uv = true;
            PrintInfo();
            ChangeSummary();
        }

        private void UV_Unchecked(object sender, RoutedEventArgs e)
        {
            price.uv = false;
            PrintInfo();
            ChangeSummary();
        }

        //REALIZACJA

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            price.standard = true;
            ChangeSummary();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            price.standard = false;
            ChangeSummary();
        }

        private void PrintInfo()
        {
            print = "";
            if (price.color_ink == true)
                print = "druk kolorowy; ";
            if (price.two_sided == true)
                print += "dwustronny; ";
            if (price.uv == true)
                print += "z lakierem uv; ";
        }

        private void ChangeSummary()
        {
            price.Count();

            string text = "Przedmiot zamówienia: ";
            text += price.Amount + " szt. ";
            text += "format " + formats + ", ";
            text += gm + ", ";
            text += print + "\n";
            text += "Cena przed rabatem: " + price.price_before_discount +"\n";
            text += "Rabat: "+ price.discount + "% \n";
            text += "Cena po rabacie: " + price.price_after_discount;

            try
            {
                Summary.Text = text;
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twoje zamówienie zostało przyjęte.");
        }
    }
}
