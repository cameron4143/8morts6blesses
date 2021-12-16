using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8M6B.DAL
{
    public class Ligne_DAL
    {
        public int Quantite { get; private set; }
        public string Marque { get; private set; }
        public string Reference { get; private set; }
        public int IDPanier_DAL { get; set; }

        public int ID { get; set; }

        //public Point_DAL(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //}
        //version abrégée d'un constructeur qui ne fait qu'affecter dans 
        //ses propriétés les paramètres reçus
        public Ligne_DAL(int quantite, string reference, string marque) => (Quantite, Reference,Marque) = (quantite, reference,marque);

        public Ligne_DAL(int id, int quantite, string reference, string marque, int idPanier)
                => (ID, Quantite, Reference,Marque, IDPanier_DAL) = (id, quantite, reference,marque, idPanier);
        
        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())//TODO à FAIRE LES INSERT DANS LA BDD AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Lignes(Marque,Reference,,IDPolygone) values (@X, @Y, @IDPolygone)";
                commande.Parameters.Add(new SqlParameter("@X", Quantite));
                commande.Parameters.Add(new SqlParameter("@Y", Reference));
                commande.Parameters.Add(new SqlParameter("@Y", Marque));
                commande.Parameters.Add(new SqlParameter("@IDPolygone", IDPanier_DAL));

                commande.ExecuteNonQuery();
            }
        }
    }
}
