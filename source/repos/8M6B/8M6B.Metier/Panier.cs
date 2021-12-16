using System;

namespace huitMsixB.METIER
{
    public class Panier
    {
        #region champs et accesseurs

         public int id { get; set; }


        #endregion

        #region constructeur

        //public Panier(int abscisse, int ordonnee)
        //{
        //    X = abscisse;
        //    Y = ordonnee;
        //}

        public Panier(int id, int abscisse, int ordonnee)
            : this(abscisse, ordonnee)
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
            return $"({X},{Y})";
        }
        //comme ça ne fait qu'un return quelque fois
        //vous le verrez comme ça
        //public override string ToString() => $"({X};{Y})";

        /// <summary>
        /// Calcule la distance du <see cref="Point"/> courant (this) par rapport à un autre <see cref="Point"/>
        /// </summary>
        /// <param name="autrePoint">Autre <see cref="Point"/></param>
        /// <returns>la distance entre les 2 <see cref="Point"/></returns>
        public double CalculerDistance(Panier autrePanier)
        {
            if (autrePoint == null)
                throw new ArgumentException("L'autre point ne peut pas être null", "autrePoint");

            return Math.Sqrt(Math.Pow(X - autrePoint.X, 2) + Math.Pow(Y - autrePoint.Y, 2));
        }
        #endregion
    }
}
