using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Xml.Serialization;

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Obnova.xaml
    /// </summary>
    public partial class Obnova : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> vsi = new List<Darovi>();
        public Obnova()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string imeD = @"D:\PRO2\ZascitaWPF" + dtpDatum.SelectedDate.Value.ToShortDateString() + ".xml";
                FileStream fs1 = new FileStream(imeD, FileMode.Open);
                XmlSerializer sr = new XmlSerializer(typeof(List<Darovi>));
                vsi = (List<Darovi>)sr.Deserialize(fs1);

                FileInfo f = new FileInfo(pot);
                f.Delete();
                FileStream fs = new FileStream(pot, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();

                foreach (Darovi d in vsi)
                {
                    bf.Serialize(fs, d);
                }
                fs1.Close();
                fs.Close();
                MessageBox.Show("Opravljeno");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Na ta dan ni bilo zaščite");
            }
        }
    }
}
