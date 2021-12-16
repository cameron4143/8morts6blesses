using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8M6B.DAL
{
    public class LigneDepot_DAL : Repo_DAL<Ligne_DAL>
    {
        public override List<Ligne_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, X, Y, IDPolygone from Points";//Pareil ici, la db est pas à jour
            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Ligne_DAL>();

            while (reader.Read())
            {
                var p = new Ligne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2));

                listeDePoints.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePoints;
        }

        public List<Ligne_DAL> GetAllByIDLigne(int IDLigne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, X, Y, IDPolygone from Points where IDPolygone=@IDPolygone";
            commande.Parameters.Add(new SqlParameter("@IDLigne", IDLigne));

            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Ligne_DAL>();

            while (reader.Read())
            {
                var p = new Ligne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                       reader.GetString(2));

                listeDePoints.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePoints;
        }

        public override Ligne_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, X, Y, IDPolygone from Points where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Ligne_DAL>();

            Ligne_DAL p;
            if (reader.Read())
            {
                p = new Ligne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                       reader.GetString(2));
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public override Ligne_DAL Insert(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Points(X, Y, IDPolygone)"
                                    + " values (@X, @Y, @IDPolygone); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@X", ligne.Reference));
            commande.Parameters.Add(new SqlParameter("@X", ligne.Quantite));
            commande.Parameters.Add(new SqlParameter("@Y", ligne.Marque));
            commande.Parameters.Add(new SqlParameter("@IDPolygone", ligne.IDPanier_DAL));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            ligne.ID = ID;

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override Ligne_DAL Update(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Points set X=@X, Y=@Y, IDPolygone=@IDPolygone)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            commande.Parameters.Add(new SqlParameter("@X", ligne.Marque));
            commande.Parameters.Add(new SqlParameter("@Y", ligne.Reference));
            commande.Parameters.Add(new SqlParameter("@Y", ligne.Quantite));
            commande.Parameters.Add(new SqlParameter("@IDPolygone", ligne.IDPanier_DAL));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le point d'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override void Delete(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Points where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le point d'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
