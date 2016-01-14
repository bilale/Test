using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    [Serializable]
    class RendezVous : ICloneable
    {
        /*Raccordement avec Mairie manager*/
        private string adresse;
        private string description;
        private bool confirmed;





        private string texte;

        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }
        private DateTime debut;

        public DateTime Debut
        {
            get { return debut; }
            set { debut = value; }
        }
        private int duree;

        public int Duree
        {
            get { return duree; }
            set { duree = value; }
        }
        private Color couleur;

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public RendezVous(string _Texte,DateTime _Debut,int _Duree,Color _Couleur)
        {
            this.texte = _Texte;
            this.duree = _Duree;
            this.debut = _Debut;
            this.couleur = _Couleur;
        }

        public RendezVous()
        {
            // TODO: Complete member initialization
        }
        public bool EstDedans(DateTime t)
        {
            DateTime dateFin = Debut.AddMinutes(Duree);
            return t.CompareTo(Debut) >= 0 && t.CompareTo(dateFin) <= 0;
        }
        public override string ToString()
        {
            return this.texte;

            //"\n le " + this.debut.ToShortDateString()
            //            + " \n à " + this.debut.ToShortTimeString();

        }
        public object Clone()
        {
            return new RendezVous(texte, debut, duree, couleur);
        }
        public DataObject ToDataObject()
        {
            DataObject obj = new DataObject();
            obj.SetData(DataFormats.Serializable, this);
            obj.SetData(DataFormats.Text, Texte);
            return obj;
        }
        public static RendezVous FromDataObject(IDataObject obj)
        {
            RendezVous rdv = obj.GetData(DataFormats.Serializable) as RendezVous;
            if (rdv == null)
            {
                string str = obj.GetData(DataFormats.Text) as String;
                rdv = new RendezVous(str, DateTime.Now, 60, Color.Green);
            }
            return rdv;
        }
        public bool SeChevauche(RendezVous rdv)
        {
            return (Debut.CompareTo(rdv.Debut) <= 0 &&
            Debut.AddMinutes(Duree).CompareTo(rdv.Debut) > 0) ||
            (Debut.CompareTo(rdv.Debut) >= 0 &&
            Debut.CompareTo(rdv.Debut.AddMinutes(rdv.Duree)) < 0);
        }
    }


    class RdvTracker
    {
        public RendezVous rdv;
        public DateTime Debut;
        public RdvTracker(RendezVous rdv)
        {
            this.rdv = rdv;
            this.Debut = rdv.Debut;
        }
        public static RdvTracker FromDataObject(IDataObject obj)
        {
            RendezVous rdv = RendezVous.FromDataObject(obj);
            if (rdv != null)
            {
                return new RdvTracker(rdv);
            }
            return null;
        }
        
    }
}
