using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlConnectionTest
{
    internal class Program
    {

       static string sqlKomut = @"Select * from Shippers";

       static string baglantiCumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";

        static void Main(string[] args)
        {
            //sql baglanti();
            //SqlBaglanti();
            // KayitSayisi();
            GetShippers();

        }

        private static void GetShippers()
        {
            List<Shipper> kargocular = new List<Shipper>();

            SqlConnection sqlConnection = new SqlConnection(baglantiCumlesi);
            try
            {

                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();
                //ExecuteScalar geriye sabit bir deger dondugunde kullanılır
                SqlDataReader rdr= sqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["CompanyName"]+" " + rdr["Phone"]);
                    Shipper kargocu = new Shipper();
                    kargocu.ShipperId = (int)rdr["ShipperId"];
                    kargocu.CompanyName = (string)rdr["CompanyName"];
                    kargocu.Phone = (string)rdr["Phone"];

                    kargocular.Add(kargocu);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static void KayitSayisi()
        {
            string sqlKomut = @"Select count(*) from Orders";

            string baglantiCumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
            SqlConnection sqlConnection = new SqlConnection(baglantiCumlesi);
            try
            {

                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();
                //ExecuteScalar geriye sabit bir deger dondugunde kullanılır
                int sonuc = (int)sqlCommand.ExecuteScalar();
                if (sonuc > 0)
                {
                    Console.WriteLine("Toplam Siparis sayisi:"+sonuc);
                }
                else
                {
                    Console.WriteLine("Basarisiz Islem");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static void SqlKayitEkle()
        {
            string sqlKomut = @"Insert into shippers(CompanyName,Phone) 
                               Values('Mng Kargo','212 44 0999')";

            string baglantiCumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
                SqlConnection sqlConnection = new SqlConnection(baglantiCumlesi);
            try
            {

                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();
                //ExecuteNonQuery adi üzerinde
                int sonuc = sqlCommand.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Console.WriteLine("İslem Basarili");
                }
                else
                {
                    Console.WriteLine("Kayit Yapilamadi");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private static void SqlBaglanti()
        {
            //calıştıracagımız komut
            string sqlKomut = "Select * from Customers";
            //sql server a baglanti için bir connectionstring tanımlamamız gerekir
            string baglantiCumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
            //sqlserver a baglanacak Ado.Net Nesnesi
            //sqlConnection nesnesi sadece baglantı kurmaya yarar
            //komut calıştırmaz baglantıyı acar kapar
            SqlConnection db = new SqlConnection(baglantiCumlesi);
            db.Open();
            Console.WriteLine("Baglanti Durumu:" + db.State);

            //Komut calıstirmak için gerekli nesne
            SqlCommand cmd = new SqlCommand(sqlKomut, db);

            //verilen komut sonuc seti geri donuyorsa  SqlDataReader ile verileri karşılarız 
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr["CustomerId"] + " " + rdr["CompanyName" + " " + rdr["ContactName"]]);
            }

            Console.WriteLine("Hello World!");

            db.Close();
            Console.WriteLine("Baglanti Durumu:" + db.State);
        }
    }
}
