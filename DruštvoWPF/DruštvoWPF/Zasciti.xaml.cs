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
using System.Xml.Serialization;

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Zasciti.xaml
    /// </summary>
    public partial class Zasciti : Window
    {
        string pot = Resource1.datoteka;
        List<Darovi> vsi = new List<Darovi>();


        public Zasciti()
        {
            InitializeComponent();
        }

        private void btnZascita_Click(object sender, RoutedEventArgs e)
        {
            //beri iz binarne datoteke
            FileStream fs = new FileStream(pot, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                while (true)
                {
                    //preberi naslednjega
                    Darovi d = (Darovi)bf.Deserialize(fs);
                    vsi.Add(d);

                }
            }
            catch (SerializationException)
            {
                //piši v xml datoteko
                string imed = @"D:\INFORMATIKA2\zascita" + DateTime.Now.ToLongDateString() + ".xml";
                FileStream fs1 = new FileStream(imed, FileMode.Create);
                XmlSerializer sr = new XmlSerializer(typeof(List<Darovi>));
                sr.Serialize(fs1, vsi);
                MessageBox.Show("Opravljeno");
            }

        }
    }
}
