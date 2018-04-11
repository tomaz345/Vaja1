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

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Vnos.xaml
    /// </summary>
    public partial class Vnos : Window
    {
        string pot =Resource1.datoteka;
        public Vnos()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Darovi d = new Darovi();
            try
            {
                d.ZapSt = int.Parse(txtZapSt.Text);
            }
            catch
            {

            }
            d.Datum = dpDatum.SelectedDate.Value;
            d.Namen = txtNamen.Text;
            try
            {
                d.Znesek = double.Parse(txtZnesek.Text);
            }
            catch
            {
                
            }
            d.Opombe = txtOpombe.Text;
            if (d.ZapSt != 0 && d.ZapSt != 0)
            {
                FileStream fs = new FileStream(pot, FileMode.Append);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, d);
                fs.Close();
            }
        }
    }
}
