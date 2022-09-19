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
using System.Windows.Shapes;

namespace wpf_grades
{
    /// <summary>
    /// Interakční logika pro zadaniZnamky.xaml
    /// </summary>
    public partial class zadaniZnamky : Window
    {
        public int novaZnamka = 0;
        private string predmet = "";

        public zadaniZnamky(string jmenoZaka, string jmenoPredmetu)
        {
            InitializeComponent();
            label_jmeno.Content = jmenoZaka;
            predmet = jmenoPredmetu;
            label_predmet.Content = jmenoPredmetu;
        }
       
        private void button_ulozit_Click(object sender, RoutedEventArgs e)
        {
            novaZnamka = Convert.ToInt32 (slider_slide.Value);
          
           if (MainWindow.vyberTrida)
            {
                MainWindow.listZakuB[MainWindow.indexUprava].ZmenitZnamku(predmet, novaZnamka);
            }
            else
            {
                MainWindow.listZakuA[MainWindow.indexUprava].ZmenitZnamku(predmet, novaZnamka);
            }
           Close();
        }

      
    }
}
