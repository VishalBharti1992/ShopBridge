using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ShopBridge.DALFile
{
    public class ManageInventoryDal
    {
        public static string connString = "Server=DESKTOP-VFCRA4H\\MSSQL2019;Database=ShopBridge;User Id=sa;Password=Admin123";
        public static List<ProductMdl> GetProductList()
        {
            try
            {
                List<ProductMdl> result = new List<ProductMdl>();
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("sp_getproductlist", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();

                using(SqlDataReader rd = cmd.ExecuteReader())
                {
                    while(rd.Read())
                    {
                        ProductMdl bindList = new ProductMdl();
                        bindList.ProductCode = Convert.ToInt32(rd["product_code"]);
                        bindList.ProductName = Convert.ToString(rd["product_name"]);
                        bindList.ProductDescription = Convert.ToString(rd["product_description"]);
                        bindList.ProductCategory = Convert.ToString(rd["product_category"]);
                        bindList.Price = Convert.ToDecimal(rd["price"]);
                        bindList.Qty = Convert.ToInt32(rd["Qty"]);
                        result.Add(bindList);
                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                
            }
        }

        public static int AddNewProduct(ProductMdl formData)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("sp_addproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pProductCode", formData.ProductCode);
                cmd.Parameters.AddWithValue("@pProductName", formData.ProductName == null ? "" : formData.ProductName);
                cmd.Parameters.AddWithValue("@pProductDescription", formData.ProductDescription == null ? "" : formData.ProductDescription);
                cmd.Parameters.AddWithValue("@pProductCategory", formData.ProductCategory == null ? "" : formData.ProductCategory);
                cmd.Parameters.AddWithValue("@pPrice", formData.Price);
                cmd.Parameters.AddWithValue("@pQty", formData.Qty);

                SqlParameter res = new SqlParameter("@res", SqlDbType.Int);
                res.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(res);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

               

                return Convert.ToInt32(res.Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
        }

        public static int DeleteProduct(int productCode)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("sp_deleteproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pProductCode", productCode);
                

                SqlParameter res = new SqlParameter("@res", SqlDbType.Int);
                res.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(res);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();



                return Convert.ToInt32(res.Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
        }

    }
}