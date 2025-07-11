// 📁 DoAn11/DataAccess/MenuDAO.cs
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;
using DoAn11.DataAccess;

namespace DoAn11.DataAccess
{
    public class MenuDAO
    {
        public static void Insert(MenuItem item)
        {
            string query = @"INSERT INTO MenuItemss (ItemName, Category, Price, IsAvailable, ImagePath) 
                             VALUES (@ItemName, @Category, @Price, @IsAvailable, @ImagePath)";

            SqlParameter[] parameters = {
                new SqlParameter("@ItemName", item.ItemName),
                new SqlParameter("@Category", item.Category),
                new SqlParameter("@Price", item.Price),
                new SqlParameter("@IsAvailable", item.IsAvailable),
                new SqlParameter("@ImagePath", item.ImagePath ?? "")
            };

            DBHelper.ExecuteNonQuery(query, parameters);
        }

        public static void Update(MenuItem item)
        {
            string query = @"UPDATE MenuItemss 
                             SET ItemName=@ItemName, Category=@Category, Price=@Price, 
                                 IsAvailable=@IsAvailable, ImagePath=@ImagePath 
                             WHERE ItemID=@ItemID";

            SqlParameter[] parameters = {
                new SqlParameter("@ItemName", item.ItemName),
                new SqlParameter("@Category", item.Category),
                new SqlParameter("@Price", item.Price),
                new SqlParameter("@IsAvailable", item.IsAvailable),
                new SqlParameter("@ImagePath", item.ImagePath ?? ""),
                new SqlParameter("@ItemID", item.ItemID)
            };

            DBHelper.ExecuteNonQuery(query, parameters);
        }

        public static void Delete(int itemId)
        {
            string query = "DELETE FROM MenuItemss WHERE ItemID=@ItemID";

            SqlParameter[] parameters = {
                new SqlParameter("@ItemID", itemId)
            };

            DBHelper.ExecuteNonQuery(query, parameters);
        }

        public static List<MenuItem> GetMenuByCategory(string category)
        {
            string query = string.IsNullOrEmpty(category) || category == "Tất Cả"
                ? "SELECT * FROM MenuItemss WHERE IsAvailable = 1"
                : "SELECT * FROM MenuItemss WHERE Category = @Category AND IsAvailable = 1";

            SqlParameter[] parameters = (string.IsNullOrEmpty(category) || category == "Tất Cả")
                ? null
                : new SqlParameter[] { new SqlParameter("@Category", category) };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);
            List<MenuItem> list = new List<MenuItem>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MenuItem
                {
                    ItemID = (int)row["ItemID"],
                    ItemName = row["ItemName"].ToString(),
                    Category = row["Category"].ToString(),
                    Price = (decimal)row["Price"],
                    IsAvailable = (bool)row["IsAvailable"],
                    ImagePath = row["ImagePath"]?.ToString()
                });
            }

            return list;
        }
        public static MenuItem GetMenuItemById(int itemId)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM MenuItemss WHERE ItemID = @ItemID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MenuItem
                                {
                                    ItemID = reader.GetInt32("ItemID"),
                                    ItemName = reader.GetString("ItemName"),
                                    Category = reader.GetString("Category"),
                                    Price = reader.GetDecimal("Price"),
                                    IsAvailable = reader.GetBoolean("IsAvailable"),
                                    ImagePath = reader.IsDBNull("ImagePath") ? null : reader.GetString("ImagePath")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public static bool IsItemNameExists(string itemName, int excludeItemId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM MenuItemss WHERE ItemName = @ItemName AND ItemID != @ItemID";

                SqlParameter[] parameters = {
            new SqlParameter("@ItemName", itemName),
            new SqlParameter("@ItemID", excludeItemId)
        };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0][0]);
                    return count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tên món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool IsItemNameExists(string itemName)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM MenuItemss WHERE ItemName = @ItemName";

                SqlParameter[] parameters = {
            new SqlParameter("@ItemName", itemName)
        };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0][0]);
                    return count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tên món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
