using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.DAL
{
    public class AdherentBasketRepo_DAL<type_DAl> : Repo_DAL<Adherent_DAL>
    {
        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID,societe,Nomcontact,PrenomContact,Email,DateAdhesion from Adherent";
            var reader = commande.ExecuteReader();

            var listeDAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var p = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),

                listeDAdherents.Add(p));
            }

            DetruireConnexionEtCommande();

            return listeDAdherents;
        }

        public List<Adherent_DAL> GetAllByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID from Adherent where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var p = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));

                listeDAdherents.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDAdherents;
        }

        public override Adherent_DAL Insert(Adherent_DAL Adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Adherent(id,societe,Nomcontact,PrenomContact,Email,DateAdhesion )"
                                    + " values (@id, @societe, @Nomcontact, @PrenomContact, @Email, @DateAdhesion); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id", id));
            commande.Parameters.Add(new SqlParameter("@Nomcontact", Nomcontact));
            commande.Parameters.Add(new SqlParameter("@PrenomContact", PrenomContact));
            commande.Parameters.Add(new SqlParameter("@Email", Email));
            commande.Parameters.Add(new SqlParameter("@DateAdhesion", DateAdhesion));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            Adherent = ID;

            DetruireConnexionEtCommande();

            return Adherent;
        }

        public override Adherent_DAL Update(Adherent_DAL AdherentUPT)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Adherent set id=@id, societe=@societe, Nomcontact=@Nomcontact, PrenomContact=@PrenomContact, Email=@Email, DateAdhesion=@DateAdhesion )"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@id", id));
            commande.Parameters.Add(new SqlParameter("@societe", societe));
            commande.Parameters.Add(new SqlParameter("@Nomcontact", Nomcontact));
            commande.Parameters.Add(new SqlParameter("@PrenomContact", PrenomContact));
            commande.Parameters.Add(new SqlParameter("@Email", Email));
            commande.Parameters.Add(new SqlParameter("@DateAdhesion", DateAdhesion));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre ? jour l'adherent d'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return AdherentUPT;
        }

        public override void Delete(Adherent_DAL Adherents)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Adherent where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", id));
            
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent d'ID {ID}");
            }

            DetruireConnexionEtCommande();
        }

    }
}
