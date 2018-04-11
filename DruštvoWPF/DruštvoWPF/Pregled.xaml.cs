using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> spremembe = new List<Darovi>();
        int stSprememb = 0;
        public Pregled()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
        private void ShraniSpremembe()
        {
            FileInfo fi = new FileInfo(pot);
            fi.Delete();
            //za progressbar
            

            FileStream fs = new FileStream(pot, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            foreach (Darovi d in spremembe)
            {
                bf.Serialize(fs, d);
               
            }
            stSprememb = 0;

            fs.Close();
        }
        */
        private void NaloziPodatke(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(pot, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Darovi d;
            try
            {
                while (true)
                {
                    d = (Darovi)bf.Deserialize(fs);
                    spremembe.Add(d);
                }
            }
            catch (SerializationException)
            {
                // MessageBox.Show("Konec datoteke");
            }
           dgPodatki.ItemsSource = spremembe;
            fs.Close();
        }
    }
}
