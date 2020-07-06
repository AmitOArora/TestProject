using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class ProductService
    {
        // var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
       public static string connectionString = Startup.ConnectionString;
        public static List<ProductModel> getProducts() 
        {
            List<ProductModel> model = new List<ProductModel>();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string sqlStr = "Select * from Products";
                SqlCommand oCmd = new SqlCommand(sqlStr, myConnection);
               // oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    ProductModel pModel = null;
                    while (oReader.Read())
                    {
                        pModel = new ProductModel();
                        pModel.ID = Convert.ToInt32(oReader["ProductId"]);
                        pModel.Name= oReader["Name"].ToString();
                        pModel.Color = oReader["Color"].ToString();
                        pModel.Category = oReader["Category"].ToString();
                        pModel.UnitPrice = Convert.ToDecimal(oReader["UnitPrice"]);
                        pModel.AvailableQuantity = Convert.ToInt32(oReader["AvailableQuantity"]);
                        pModel.CratedDate = Convert.ToDateTime(oReader["CratedDate"]);
                        model.Add(pModel);
                    }
                    


                    myConnection.Close();
                }
            }
            return model;


        }

        public static ProductModel getProduct(int productID)
        {
            ProductModel Model = new ProductModel();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string sqlStr = "Select * from Products where productID = '"+ productID +"'";
                SqlCommand oCmd = new SqlCommand(sqlStr, myConnection);
                // oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    //ProductModel pModel = null;
                    while (oReader.Read())
                    {
                        Model = new ProductModel();
                        Model.ID = Convert.ToInt32(oReader["ProductId"]);
                        Model.Name = oReader["Name"].ToString();
                        Model.Color = oReader["Color"].ToString();
                        Model.Category = oReader["Category"].ToString();
                        Model.UnitPrice = Convert.ToDecimal(oReader["UnitPrice"]);
                        Model.AvailableQuantity = Convert.ToInt32(oReader["AvailableQuantity"]);
                        Model.CratedDate = Convert.ToDateTime(oReader["CratedDate"]);
                    }
                  
                    myConnection.Close();
                }
            }
            return Model;
        }

        public static void addProduct(ProductModel model)
        {
            bool isSuccessful = false;
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string sqlStr = "insert into Products(Name,Color,Category,AvailableQuantity,UnitPrice,CratedDate) values ('"+model.Name+"','"+ model.Color +"','"+ model.Category+"','"+model.AvailableQuantity+"','"+ model.UnitPrice+"','"+ DateTime.Now.ToString()+"')";
                SqlCommand oCmd = new SqlCommand(sqlStr, myConnection);
                // oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                int i = oCmd.ExecuteNonQuery();
                myConnection.Close();

             }
            
               getProducts();
        }


        public static void updateProduct(ProductModel model)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                //string sqlStr = "insert into Products(Name,Color,Category,AvailableQuantity,UnitPrice,CratedDate) values ('" + model.Name + "','" + model.Color + "','" + model.Category + "','" + model.AvailableQuantity + "','" + model.UnitPrice + "'," + DateTime.Now.ToString() + "')";

                string sqlStr = "update Products set Name ='"+ model.Name + "', Category='" + model.Category +"',Color='"+ model.Color +"',UnitPrice='"+ model.UnitPrice +"', AvailableQuantity='"+ model.AvailableQuantity + "' where ProductId='"+ model.ID + "'"; 
                    //"insert into Products(Name,Color,Category,AvailableQuantity,UnitPrice,CratedDate) values ('" + model.Name + "','" + model.Color + "','" + model.Category + "','" + model.AvailableQuantity + "','" + model.UnitPrice + "'," + DateTime.Now.ToString() + "')";
                SqlCommand oCmd = new SqlCommand(sqlStr, myConnection);
                // oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                int i = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            getProducts();
        }


        public static void deleteProduct(int modelID)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                //string sqlStr = "insert into Products(Name,Color,Category,AvailableQuantity,UnitPrice,CratedDate) values ('" + model.Name + "','" + model.Color + "','" + model.Category + "','" + model.AvailableQuantity + "','" + model.UnitPrice + "'," + DateTime.Now.ToString() + "')";

                string sqlStr = "delete from Products where ProductId='" + modelID + "'";
                //"insert into Products(Name,Color,Category,AvailableQuantity,UnitPrice,CratedDate) values ('" + model.Name + "','" + model.Color + "','" + model.Category + "','" + model.AvailableQuantity + "','" + model.UnitPrice + "'," + DateTime.Now.ToString() + "')";
                SqlCommand oCmd = new SqlCommand(sqlStr, myConnection);
                // oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                int i = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            getProducts();
        }


    }
}
