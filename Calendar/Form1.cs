using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void clearFields()
        {
            txtText.Text = "";
            mcDebut.SelectionStart = DateTime.Today;
            tbDuree.Value = tbDuree.Minimum;
            lblDuree.Text = "Durée: " + tbDuree.Value + " minutes";
            txtColor.BackColor = Color.White;
            editView1.Selection = null;
            btnAjouter.Enabled = true;

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAnnuler.Enabled = false;
            editView1.Invalidate();
        }

        private void tbDuree_Scroll(object sender, EventArgs e)
        {
            tbDuree.Value = ((int)Math.Round((Double)tbDuree.Value / 30, 0)) * 30;
            lblDuree.Text = "Durée: " + tbDuree.Value + " minutes";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            cdColor.ShowDialog();
            txtColor.BackColor = cdColor.Color;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            RendezVous monRdv = new RendezVous();
            monRdv.Texte = txtText.Text;
            monRdv.Debut = mcDebut.SelectionStart.AddMinutes(editView1.DebutJour);
            monRdv.Duree = tbDuree.Value;
            monRdv.Couleur = txtColor.BackColor;
            editView1.Items.Add(monRdv);           
            editView1.Invalidate();
          clearFields();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            RendezVous monRdv = editView1.Selection;
            int indice = editView1.Items.IndexOf(monRdv);
            monRdv.Texte = txtText.Text;
            monRdv.Debut = mcDebut.SelectionStart;
            monRdv.Couleur = txtColor.BackColor;
            monRdv.Duree = tbDuree.Value;
            editView1.Items[indice] = monRdv;
            clearFields();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            editView1.Items.Remove(editView1.Selection);
            clearFields();
        }

        private void editView1_Paint(object sender, PaintEventArgs e)
        {
            int i;
            editView1.LargeurJour = (editView1.Width - editView1.Marge.Width) / editView1.NbJours;
            editView1.HauteurMinute = (editView1.Height - editView1.Marge.Height) / (editView1.FinJour - editView1.DebutJour);
            //Dessine les séparation des jours et le nom des jours
            for (i = 0; i < editView1.NbJours; i++)
            {
                float width = editView1.Marge.Width + (i * editView1.LargeurJour);
                string[] jour = editView1.PremierJour.AddDays(i).ToLongDateString().Split(' ');
                e.Graphics.DrawString(jour[0].Replace(jour[0][0].ToString(),
                jour[0][0].ToString().ToUpper()),
                this.Font, new SolidBrush(Color.Black), new PointF(width, 0));
                e.Graphics.DrawString(jour[1] + " " + jour[2] + " " + jour[3],
                this.Font, new SolidBrush(Color.Black), new PointF(width, 14));
                RectangleF monRect = new RectangleF(new PointF(width, editView1.Marge.Height),
                new SizeF(new PointF(editView1.LargeurJour, this.Height - editView1.Marge.Height)));
                e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(monRect, Color.Gray, Color.LightGray, System.Drawing.Drawing2D.LinearGradientMode.Horizontal), monRect);
                e.Graphics.DrawLine(new Pen(Color.Black), new PointF(width,
                     editView1.Marge.Height), new PointF(width, this.Height));
            }


            //Dessine les horraires et les séparations des crénaux
            for (i = editView1.DebutJour; i <= editView1.FinJour; i += editView1.Intervalle)
            {
                float height = editView1.Marge.Height + ((i - editView1.DebutJour) * editView1.HauteurMinute);
                int heure = i / 60;
                int minute = i - (heure * 60);
                e.Graphics.DrawLine(new Pen(Color.DarkGray), new
                PointF(editView1.Marge.Width, height), new PointF(editView1.Width, height));
                e.Graphics.DrawString(heure.ToString() + "H" + (minute != 0 ?
                minute.ToString() : "00"), editView1.Font,
                new SolidBrush(Color.Black), new PointF(0, height));
            }
            //affiche les RDV
            foreach (RendezVous monRdv in editView1.Items)
            {
                AfficheRDV(monRdv, e.Graphics);
            }
            //affiche le RDV selectionné
            if (editView1.Selection != null)
            {
                AfficheRDVSelectione(editView1.Selection, e.Graphics);
            }

            //affiche le tracker
            if (editView1.tracker != null)
            {
                AfficheRDVTracker(editView1.tracker, e.Graphics);
            }
            if(editView1.Selection!=null)
            {
                ContextMenu();
            }
            
                
        }
        private void AfficheRDVTracker(RdvTracker monTracker, Graphics g)
        {
            TimeSpan dateTemp = monTracker.Debut.Subtract( editView1.PremierJour);
            if (dateTemp.Days >= 0 && dateTemp.Hours >= 0 && dateTemp.Minutes >= 0)
            {
                float x = editView1.Marge.Width + (dateTemp.Days * editView1.LargeurJour);

                float y = editView1.Marge.Height + (((monTracker.Debut.Minute +
                (monTracker.Debut.Hour * 60) - editView1.DebutJour) * editView1.HauteurMinute));

                RectangleF monRect = new RectangleF(new PointF(x, y), new SizeF(new
                PointF(editView1.LargeurJour, monTracker.rdv.Duree * editView1.HauteurMinute)));

                g.DrawRectangle(new Pen(Color.FromArgb(30, Color.Black)),
                monRect.X, monRect.Y, monRect.Width, monRect.Height);
                g.FillRectangle(
                new System.Drawing.Drawing2D.LinearGradientBrush(monRect,
                Color.FromArgb(30, monTracker.rdv.Couleur), Color.FromArgb(30,
                monTracker.rdv.Couleur),
                System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal),
                monRect);
            }
        }
        private void AfficheRDV(RendezVous monRDV, Graphics g)
        {
            TimeSpan dateTemp = monRDV.Debut.Subtract(editView1.PremierJour);
            if (dateTemp.Days >= 0 && dateTemp.Hours >= 0 && dateTemp.Minutes >= 0)
            {
                float x = editView1.Marge.Width + (dateTemp.Days * editView1.LargeurJour);
                float y = editView1.Marge.Height + (((monRDV.Debut.Minute +
                (monRDV.Debut.Hour * 60) - editView1.DebutJour) * editView1.HauteurMinute));
                RectangleF monRect = new RectangleF(new PointF(x, y),
                new SizeF(new PointF(editView1.LargeurJour, monRDV.Duree * editView1.HauteurMinute)));
                g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(
                monRect, monRDV.Couleur, monRDV.Couleur,
                System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal),
                monRect);
                g.DrawRectangle(new Pen(Color.Black), monRect.X, monRect.Y,
                monRect.Width, monRect.Height);
                g.DrawString(monRDV.ToString(), this.Font,
                new SolidBrush(Color.Black), new PointF(monRect.X, monRect.Y));
            }
        }
        private RendezVous RecupRdv(PointF p)
        {
            int i = 0;
            bool trouve = false;
            DateTime dateDuClick = QuelleHeureEstIl(p);
            // le click à eu lieu en dehors du planning
            if (dateDuClick == DateTime.MinValue)
                return null;
            while (trouve == false && i < editView1.Items.Count)
            {
                if (((RendezVous)editView1.Items[i]).EstDedans(dateDuClick))
                    trouve = true;
                else
                    i++;
            }
            if (trouve) return (RendezVous)editView1.Items[i];
            else return null;
        }
        private void editView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                editView1.Selection = RecupRdv(e.Location);
                if (editView1.Selection != null)// Lance le déplacement
                    DoDragDrop(editView1.Selection.ToDataObject(), DragDropEffects.Move |
                    DragDropEffects.Copy | DragDropEffects.None);
                editView1.Invalidate();
             
            }
            if (editView1.Selection != null)
            {
                RendezVous monRdv = editView1.Selection;
                txtText.Text = monRdv.Texte;
                mcDebut.SelectionStart = monRdv.Debut;
                tbDuree.Value = monRdv.Duree;
                lblDuree.Text = "Durée: " + tbDuree.Value + " minutes";
                txtColor.BackColor = monRdv.Couleur;
                btnAjouter.Enabled = false;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAnnuler.Enabled = true;


            }
            else
            {
                clearFields();
                 
            }
        }
        private DateTime QuelleHeureEstIl(PointF p)
        {
            float jour = (p.X - editView1.Marge.Width) / editView1.LargeurJour;
            float minute = ((p.Y - editView1.Marge.Height) / editView1.HauteurMinute) + editView1.DebutJour;
            if (jour >= 0 && minute >= 0)
            {
                return editView1.PremierJour.AddDays(Math.Floor(jour)).AddMinutes(minute);
            }
            return DateTime.MinValue;
           
        }
        private void AfficheRDVSelectione(RendezVous monRDV, Graphics g)
        {
            TimeSpan dateTemp = monRDV.Debut.Subtract(editView1.PremierJour);
            if (dateTemp.Days >= 0 && dateTemp.Hours >= 0 && dateTemp.Minutes >= 0)
            {
                float x = editView1.Marge.Width + (dateTemp.Days * editView1.LargeurJour);
                float y = editView1.Marge.Height + (((monRDV.Debut.Minute +
                (monRDV.Debut.Hour * 60) - editView1.DebutJour) * editView1.HauteurMinute));
                RectangleF monRect = new RectangleF(new PointF(x, y),
                new SizeF(new PointF(editView1.LargeurJour, monRDV.Duree * editView1.HauteurMinute)));
                g.DrawRectangle(new Pen(Color.Red), monRect.X, monRect.Y,
                monRect.Width, monRect.Height);
            }
        }

        private void editView1_DragEnter(object sender, DragEventArgs e)
        {
           editView1.tracker = RdvTracker.FromDataObject(e.Data);
        }

        private void editView1_DragOver(object sender, DragEventArgs e)
        {
            //récupère les coordonnées de la souris dans la fenêtre
            Point loc = PointToClient(new Point(e.X, e.Y));
            // Si le tracker existe
            if (editView1.tracker != null)
            {
                //récupère le curseur de copie si la touche Control est appuyée ou
                //si l'objet en cours de mouvement n'est pas dans l’enploi du temps
                if (((e.KeyState & 8) == 8 || !editView1.Items.Contains(editView1.tracker.rdv)))
                    e.Effect = DragDropEffects.Copy;
                else if (loc.X < editView1.Marge.Width || loc.Y < editView1.Marge.Height)
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = DragDropEffects.Move;
                // on déplace le tracker mais pas l'objet qu'il contient
                if (e.Effect == DragDropEffects.Move || e.Effect == DragDropEffects.Copy)
                {
                    //gestion du chevauchement
                    DateTime date = QuelleHeureEstIl(loc);
                    int minute = ((date.Minute / editView1.Intervalle) * editView1.Intervalle) + 60 * date.Hour;
                    if (minute > editView1.FinJour - editView1.tracker.rdv.Duree)
                    {
                        minute = editView1.FinJour - editView1.tracker.rdv.Duree;
                    }
                    date = date.Date.AddMinutes(minute);
                    RendezVous aComparer = new RendezVous(editView1.Selection.Texte, date,
                    editView1.Selection.Duree, editView1.Selection.Couleur);
                    bool seChevauche = false;
                    foreach (RendezVous rdv in editView1.Items)
                    {
                        if (rdv != editView1.Selection && rdv.SeChevauche(aComparer))
                        {
                            seChevauche = true; break;
                        }
                    }
                    if (!seChevauche)
                    {
                       editView1.tracker.Debut = date.Date;
                       editView1.tracker.Debut = editView1.tracker.Debut.AddMinutes(minute);
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                editView1.Invalidate();
            }
        }
       

        private void editView1_DragDrop(object sender, DragEventArgs e)
        {
            if (editView1.tracker != null)
            {
                //Si en train de copier: on copie et on ajoute l'objet
                if (e.Effect == DragDropEffects.Copy)
                {
                    editView1.Selection = editView1.tracker.rdv.Clone() as RendezVous;
                    editView1.Items.Add(editView1.Selection);
                }
                // on affecte la nouvelle date (et heure)
                editView1.Selection.Debut = editView1.tracker.Debut;
                //on enlève le tracker
                editView1.tracker = null;
                editView1.Invalidate();
            }
        }

        private void editView1_DragLeave(object sender, EventArgs e)
        {
            //on enlève le tracker
            editView1.tracker = null;
            editView1.Invalidate();
        }

        private void mcDebut_DateChanged(object sender, DateRangeEventArgs e)
        {
            editView1.PremierJour = mcDebut.SelectionStart;
            editView1.Invalidate();

        }


        private void ContextMenu()
        {
            System.Windows.Forms.ContextMenu contextMenu1;
            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();

            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem2, menuItem3 });
            
            menuItem2.Index = 0;
            menuItem2.Text = "Modifier";
            menuItem3.Index = 1;
            menuItem3.Text = "Supprimer";

            menuItem2.Click += new System.EventHandler(this.btnModifier_Click);
            menuItem3.Click += new System.EventHandler(this.btnSupprimer_Click);
            

            editView1.ContextMenu = contextMenu1;

        }
        
    }
}
