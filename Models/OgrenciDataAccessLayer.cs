using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace _1._3.Models    
{    
    public class OgrenciDataAccessLayer    
    {    
        string ConnectionString = "Data Source=DESKTOP-IAP563V;" + "Database=Ogrenci;" + "Trusted_Connection=true;";    
    
        //To View all ogrencis details      
        public IEnumerable<Ogrenci> spGetAllOgrenci()    
        {    
            List<Ogrenci> lstogrenci = new List<Ogrenci>();    
    
            using (SqlConnection con = new SqlConnection(ConnectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllOgrenci", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Ogrenci ogrenci = new Ogrenci();    
    
                    ogrenci.ogrenci_no = Convert.ToInt32(rdr["ogrenci_no"]);   //int sıkıntı çıakrabilir 
                    ogrenci.ogrenci_ad = rdr["ogrenci_ad"].ToString();  
                    ogrenci.ogrenci_soyad = rdr["ogrenci_soyad"].ToString();
                    ogrenci.ogrenci_email = rdr["ogrenci_email"].ToString();    
                    ogrenci.ogrenci_sifre = rdr["ogrenci_sifre"].ToString();       
                        
    
                    lstogrenci.Add(ogrenci);    
                }    
                con.Close();    
            }    
            return lstogrenci;    
        }    
    
        //To Add new ogrenci record      
        public void spAddOgrenci(Ogrenci ogrenci)    
        {    
            using (SqlConnection con = new SqlConnection(ConnectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddOgrenci", con);    
                cmd.CommandType = CommandType.StoredProcedure;    

                cmd.Parameters.AddWithValue("@ogrenci_no", ogrenci.ogrenci_no); 
                cmd.Parameters.AddWithValue("@ogrenci_ad", ogrenci.ogrenci_ad);
                cmd.Parameters.AddWithValue("@ogrenci_soyad", ogrenci.ogrenci_soyad); 
                cmd.Parameters.AddWithValue("@ogrenci_email", ogrenci.ogrenci_email);     
                cmd.Parameters.AddWithValue("@ogrenci_sifre", ogrenci.ogrenci_sifre);     
                   
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //To Update the records of a particluar ogrenci    
        public void spUpdateOgrenci(Ogrenci ogrenci)    
        {    
            using (SqlConnection con = new SqlConnection(ConnectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spUpdateOgrenci", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@ogrenci_no", ogrenci.ogrenci_no); 
                cmd.Parameters.AddWithValue("@ogrenci_ad", ogrenci.ogrenci_ad);
                cmd.Parameters.AddWithValue("@ogrenci_soyad", ogrenci.ogrenci_soyad); 
                cmd.Parameters.AddWithValue("@ogrenci_email", ogrenci.ogrenci_email);     
                cmd.Parameters.AddWithValue("@ogrenci_sifre", ogrenci.ogrenci_sifre);       
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular ogrenci    
        public Ogrenci GetOgrenciData(int? id)    
        {    
            Ogrenci ogrenci = new Ogrenci();    
    
            using (SqlConnection con = new SqlConnection(ConnectionString))    
            {    
                string sqlQuery = "SELECT * FROM Ogrenci WHERE ogrenci_no= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    cmd.Parameters.AddWithValue("@ogrenci_no", ogrenci.ogrenci_no); 
                cmd.Parameters.AddWithValue("@ogrenci_ad", ogrenci.ogrenci_ad);
                cmd.Parameters.AddWithValue("@ogrenci_soyad", ogrenci.ogrenci_soyad); 
                cmd.Parameters.AddWithValue("@ogrenci_email", ogrenci.ogrenci_email);     
                cmd.Parameters.AddWithValue("@ogrenci_sifre", ogrenci.ogrenci_sifre);       
                }    
            }    
            return ogrenci;    
        }    
    
        //To Delete the record on a particular ogrenci    
        public void spDeleteOgrenci(int? id)    
        {    
    
            using (SqlConnection con = new SqlConnection(ConnectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spDeleteOgrenci", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@ogrenci_no", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    }    
}