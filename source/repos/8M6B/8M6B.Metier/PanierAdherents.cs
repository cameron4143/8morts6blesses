using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _huitMsixB.METIER
{
    class PanierAdherents
    {
        #region champs et accesseurs

        public int id { get; set; }
        public string societe { get; set; }
        public string NomContact { get; set; }
        public string PrenomContact { get; set; }
        public DateTime DateAdhesion { get; set; }



        #endregion

        #region constructeur

        //public Panier(int abscisse, int ordonnee)
        //{
        //    X = abscisse;
        //    Y = ordonnee;
        //}

        public Panier(int id, string societe, string NomContact, string PrenomContact, DateTime DateAdhesion)
            : this(societe, NomContact, PrenomContact, DateAdhesion)
        {
            ID = id;
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Retourne une représentation sous forme de <see cref="string"/> du <see cref="Point"/>
        /// </summary>
        /// <returns>la chaine de caractères</returns>
        public override string ToString()
        {
            return $"({societe},{NomContact},{PrenomContact},{DateAdhesion})";
        }
        //comme ça ne fait qu'un return quelque fois
        //vous le verrez comme ça
        //public override string ToString() => $"({X};{Y})";

        /// <summary>
        /// Calcule la distance du <see cref="Point"/> courant (this) par rapport à un autre <see cref="Point"/>
        /// </summary>
        /// <param name="autrePoint">Autre <see cref="Point"/></param>
        /// <returns>la distance entre les 2 <see cref="Point"/></returns>
        public double Ajoutadherent(Panier autrePanier)
        {
            if (autrePanier == null)
                throw new ArgumentException("L' ne peut pas être null", "autrePoint");

            return Math.Sqrt(Math.Pow(X - autrePoint.X, 2) + Math.Pow(Y - autrePoint.Y, 2));
        }
        #endregion

    }
}
