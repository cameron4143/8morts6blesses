using _8M6B.DAL;
using System;

namespace huitMsixB.METIER
{
    /// <summary>
    /// Représente un point dans un repère à 2 dimensions
    /// </summary>
    public class Lignes
    {
        #region champs et accesseurs
        public int ID { get; set; }
        public int Quantite { get; set; }
        public string Reference { get; set; }
        public string Marque { get; set; }




        public int Nbligne { get; set; }


        #endregion

        #region constructeur

        /// <summary>
        /// Construit une ligne
        /// </summary>
        /// <param name="quantite">Quantité du produit</param>
        /// <param name="reference">Référence du produit</param>
        /// <param name="marque">Marque du produit</param>
        public Lignes(int quantite, string reference, string marque)
        {
            Quantite = quantite;
            Reference = reference;
            Marque = marque;
        }

        public Lignes(int id, int quantite, string reference, string marque)
            : this(quantite, reference, marque)
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
            return $"({Quantite},{Reference},{Marque})";
        }
        //comme ça ne fait qu'un return quelque fois
        //vous le verrez comme ça
        //public override string ToString() => $"({X};{Y})";

        /// <summary>
        /// évite les doublons entre la <see cref="Lignes"/> courante (this) par rapport à une autre <see cref="Lignes"/>
        /// </summary>
        /// <param name="autreLigne">Autre <see cref="Lignes"/></param>
        public double EviterDoublons(Lignes autreLigne)
        {
            if (autreLigne == null)
                throw new ArgumentException("L'autre ligne ne peut pas être null", "autreLigne");

            if (autreLigne.Reference == this.Reference)
            {
                Ligne_DAL remboursement = new Ligne_DAL(ID, ID_Personne, ID_Projet, Dette, Created_At, Update_At);
                var depotLinge = new LigneDepot_DAL();

                depotLinge.Delete(autreLigne);

                return Quantite++;

            }
        }

        
        #endregion
    }
}
