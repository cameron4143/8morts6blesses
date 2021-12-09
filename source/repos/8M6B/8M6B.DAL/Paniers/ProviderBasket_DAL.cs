using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.DAL
{
    public class ProviderBasket_DAL
    {

        public int id { get; private set; }
        public int id_fournisseurs { get; set; }
        public float PrixUnitaireHT { get; set; }
        public int id_PanierDetails { get; set; }


        public void Insert()
        {
            var chaineDeConnexion = "Data Source=DESKTOP-H6H5VR2;Initial Catalog=Geometrie;Integrated Security=True";

            using (var connexion = new SqlConnection(chaineDeConnexion))
            {

                connexion.Open();
                using (var commande = new SqlCommand())
                {

                    commande.Connection = connexion;

                    commande.CommandText = "insert into fournisseurs_panier(id,id_fournisseurs,PrixUnitaireHT,id_PaniersDetails)"
                                           + "values(@ID,@id_fournisseurs,@PrixUnitaireHT,@id_PaniersDetails)";

                    commande.Parameters.Add(new SqlParameter("@id", id));
                    commande.Parameters.Add(new SqlParameter("@id_fournisseurs", id_fournisseurs));
                    commande.Parameters.Add(new SqlParameter("@PrixUnitaireHT", PrixUnitaireHT));
                    commande.Parameters.Add(new SqlParameter("@id_PaniersDetails", id_PaniersDetails));

                }
                connexion.Close();

            }
        }
    }
}
