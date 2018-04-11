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

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for Tiskanje.xaml
    /// </summary>
    public partial class Tiskanje : Window
    {
        private string pot = Resource1.datoteka;
        List<Darovi> vsi = new List<Darovi>();
        List<Darovi> spremembe1 = new List<Darovi>();
        double znesekVDobro = 0;
        double znesekVBreme = 0;
        double saldo = 0;
        //Font printFont = new Font("Arial", 14);
        public Tiskanje()
        {
            InitializeComponent();
        }
        
        private void btnPredogled_Click(object sender, RoutedEventArgs e)
        {
          /*  PreveriDatume();//kaj se tiska
            //RacunanjeVsote();
            pd.DocumentName = "Izpis";
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            printPreviewDialog1.ShowDialog();*/

        }
        
        /*
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0; // število vrstic na stran
            float yPos = 0; // y pozicija
            int count = 0; // število vseh izpisanih vrstic
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null; // vrstica za izpis
            int štVrstice = 0;
            RacunanjeVsote(); // metoda za izračun vsot
            // število vrstic na eno stran, zapisov je lahko veliko
            linesPerPage = ev.MarginBounds.Height /
            printFont.GetHeight(ev.Graphics);
            //prva vrstica – naslov dokumenta
            line = "Izpis vseh darov in izdatkov za Karitas";
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black,
            leftMargin, yPos, new StringFormat());
            count++;
            //izris slike
            // Bitmap bi = new Bitmap(@"D:\Pro2\Društvo\Društvo\Resources\a.gif");
            // ev.Graphics.DrawImage(bi, ev.MarginBounds.Right - 70, yPos - 10);
            //zaradi velikosti slike zgornjemu robu prištejem 32 (velikost=32x32)
            topMargin += 32;
            line = "";
            //izris prazne vrstice
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black,
            leftMargin, yPos, new StringFormat());
            count++;
            //izris črte
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawLine(new Pen(Color.Black), ev.MarginBounds.Left, yPos, ev.MarginBounds.Right, yPos);
            count++;
            //izpis glave tabele
            line = "  Poz.   Datum       Namen V dobro   V breme   Opombe";
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black,
            leftMargin, yPos, new StringFormat());
            count++;
            //izris črte
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawLine(new Pen(Color.Black), ev.MarginBounds.Left, yPos, ev.MarginBounds.Right, yPos);
            count++;
            // Izpis podatkov iz datoteke.
            while (count < linesPerPage && štVrstice < spremembe1.Count)
            {
                string a; //namen skrajšan na 10 znakov
                string b; //opombe skrajšane na 10 znakov
                if (spremembe1[štVrstice].Namen.Length > 10)
                    a = spremembe1[štVrstice].Namen.Substring(0, 10);
                else a = spremembe1[štVrstice].Namen;
                if (spremembe1[štVrstice].Opombe.Length > 10)
                    b = spremembe1[štVrstice].Opombe.Substring(0, 10);
                else b = spremembe1[štVrstice].Opombe;
                double c = spremembe1[štVrstice].Znesek; //v dobro ali breme?
                if (c > 0)
                    line = String.Format("{0,3}", (štVrstice + 1)) + " " + spremembe1[štVrstice].Datum.ToShortDateString() + " " +
                    String.Format("{0,10}", a) + " " +
                    String.Format("{0,10:c}", spremembe1[štVrstice].Znesek) + " " +
                    String.Format("{0,10}", b);
                else
                    line = String.Format("{0,3}", (štVrstice + 1)) + " " + spremembe1[štVrstice].Datum.ToShortDateString() + " " +
                    String.Format("{0,10}", a) + " " +
                    String.Format("{0,10:c}", spremembe1[štVrstice].Znesek) + " " +
                    String.Format("{0,10}", b);
                štVrstice++;
                yPos = topMargin + (count *
                printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                leftMargin, yPos, new StringFormat());
                count++;
                line = "";
            }
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawLine(new Pen(Color.Black), ev.MarginBounds.Left, yPos, ev.MarginBounds.Right, yPos);
            count++;
            //izpis vrstice skupaj
            line = String.Format("{0,24}", "Skupaj") + " " +
            String.Format("{0,10:c}", znesekVDobro) + " " +
            String.Format("{0,10:c}", znesekVBreme) + " " +
            String.Format("{0,10:c}", saldo);
            yPos = topMargin + (count *
            printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black,
            leftMargin, yPos, new StringFormat());
            count++;
            // če še nismo na koncu datoteke, pojdi na novo stran
            if (štVrstice != spremembe1.Count)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
        private void PreveriDatume()
        {

            spremembe1 = new List<Darovi>();
            DateTime dt1 = dp1tiskanje.SelectedDate.Value;
            DateTime dt2 = dp2tiskanje.SelectedDate.Value;
            foreach (Darovi d in vsi)
            {
                if (d.Datum >= dt1 & d.Datum <= dt2)
                {
                    spremembe1.Add(d);
                }
            }

        }
        */

    }
}
