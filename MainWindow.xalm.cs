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

namespace wpf_grades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List <Zak> listZakuA = new List<Zak>();
        public static List <Zak> listZakuB = new List<Zak>();
        public static int indexUprava = 0;
        public static bool vyberTrida = false;



        public MainWindow()
        {
            InitializeComponent();
            combo_predmety.ItemsSource = tridaData.jmenaPredmetu;
            foreach(string jmeno in tridaData.jmenaZakuA)
            {
                Zak vytvorenyZak = new Zak { Jmeno = jmeno };
                listZakuA.Add(vytvorenyZak);
            }
            foreach (string jmeno in tridaData.jmenaZakuB)
            {
                Zak vytvorenyZak = new Zak { Jmeno = jmeno };
                listZakuB.Add(vytvorenyZak);
            }
        }

        private void btn_ulozit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            seznam_zaku.ItemsSource = tridaData.jmenaZakuA;
            vyberTrida = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            seznam_zaku.ItemsSource = tridaData.jmenaZakuB;
            vyberTrida = true;
        }

        private void seznam_zaku_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ( seznam_zaku.SelectedItem != null)
            { 
            if (vyberTrida)
            {
                foreach(var  vybranyZak in listZakuB)
                {
                    if (vybranyZak.Jmeno == seznam_zaku.SelectedItem.ToString())

                    {
                        grades.ItemsSource = vybranyZak.Znamky.Keys;
                            indexUprava = listZakuB.IndexOf(vybranyZak);
                        break;
                    }
                }
                


            }
            else
            {
                foreach (var vybranyZak in listZakuA)
                {
                    if (vybranyZak.Jmeno == seznam_zaku.SelectedItem.ToString())
                    {
                        grades.ItemsSource = vybranyZak.Znamky.Keys;
                            indexUprava = listZakuA.IndexOf(vybranyZak);
                            break;
                    }
                }
            }
        
            }
        }
        

        private void grades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string jmeno = seznam_zaku.SelectedItem.ToString();
            string pred = grades.SelectedItem.ToString();
            zadaniZnamky okno = new zadaniZnamky(jmeno, pred);
     
            okno.Show();
            if (vyberTrida)
            {
                listZakuB[indexUprava].ZmenitZnamku(pred, okno.novaZnamka);
            }
            else
            {
                listZakuA[indexUprava].ZmenitZnamku(pred, okno.novaZnamka);
            }
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            string vsechnyZnamky = "";
            
            
            if (vyberTrida)
            {
                vsechnyZnamky = listZakuB[indexUprava].Jmeno + "\n";

                foreach (var znamka in listZakuB[indexUprava].Znamky)
                {
                    vsechnyZnamky += znamka.Key + " - " + znamka.Value + "\n";
                }
            }
            else
            {
                vsechnyZnamky = listZakuA[indexUprava].Jmeno + "\n";
                foreach (var znamka in listZakuA[indexUprava].Znamky)
                {
                    vsechnyZnamky += znamka.Key + " - " + znamka.Value + "\n";
                }
            }
            MessageBox.Show(vsechnyZnamky);
            

        }
    }
}

