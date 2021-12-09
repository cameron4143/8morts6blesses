using System;

namespace 8M6B.Metier
{
    /// <summary>
    /// Représente un point dans un repère à 2 dimensions
    /// </summary>
    public class Lignes
{
    #region champs et accesseurs

    public int Quantite { get; set; }
    public string Reference { get; set; }
    public string Marque { get; set; }
    //accesseur simplifié
    /// <summary>
    /// Ordonnée du point
    /// </summary>



    /// <summary>
    /// ID du point dans la BDD
    /// </summary>
    public int Nbligne { get; set; }


    #endregion

    #region constructeur

    /// <summary>
    /// Construit un point
    /// </summary>
    /// <param name="abscisse">Abscisse du point (X)</param>
    /// <param name="ordonnee">Ordonnée du point (Y)</param>
    public Lignes(int quantite, string reference,string marque )
    {
        Quantite = quantite;
        Reference = reference;
        Marque = marque;
    }

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
