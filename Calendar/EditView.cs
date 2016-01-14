using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calendar
{
    public partial class EditView : UserControl
    {
        public int NbJours;
        public int FinJour;
        public DateTime PremierJour;
        public int Intervalle;
        public SizeF Marge;
        private RendezVous selection;

        internal RendezVous Selection
        {
            get { return selection; }
            set { selection = value; }
        }
        public ArrayList Items;
        public int DebutJour;
        public float LargeurJour;
        public float HauteurMinute;
        private RdvTracker trackers ;

        internal RdvTracker tracker
        {
            get { return trackers; }
            set { trackers = value; }
        }
        public EditView()
        {
            
            this.NbJours = 5;
            this.DebutJour = 480;
            this.FinJour = 1140;
            this.PremierJour = DateTime.Today;
            this.Marge = new SizeF(48, 32);
            this.selection = null;
            this.Intervalle = 60;
            trackers = null;
            /*Penser à initialiser avec la liste de rendez-vous de la base*/
            this.Items = new ArrayList();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

      
        /*Aprés raccordement penser à activer/désactiver le bouton enregister en fonction de modification*/

        
    }
}
