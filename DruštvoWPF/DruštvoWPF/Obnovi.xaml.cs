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
    /// Interaction logic for Obnovi.xaml
    /// </summary>
    public partial class Obnovi : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> vsi1 = new List<Darovi>();
        public Obnovi()
        {
            InitializeComponent();
        }

        private void btnObnovi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //beri iz binarne datoteke
                string imed = @"D:\INFORMATIKA2\zascita" + dpObnovi1.SelectedDate.Value.ToLongDateString() + ".xml";
                FileStream fs = new FileStream(imed, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                XmlSerializer sr = new XmlSerializer(typeof(List<Darovi>));

                vsi1 = (List<Darovi>)bf.Deserialize(fs);

                FileInfo fi = new FileInfo(pot);
                fi.Delete();

                FileStream fs1 = new FileStream(pot, FileMode.Create);

                foreach (Darovi d in vsi1)
                {
                    bf.Serialize(fs, d);
                }
                fs.Close();
                fs1.Close();
                //piši v xml datoteko
                MessageBox.Show("Opravljeno");

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Na ta dan ni bilo zaščite");
            }
        }
    }
}
