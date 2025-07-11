// 📁 DoAn11/DataAccess/OrderDAO.cs
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;
using DoAn11.DataAccess;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace DoAn11.DataAccess
{
    public class OrderDAO
    {
        // Tạo đơn hàng mới
        public static int CreateOrder(int tableID)
        {
            try
            {
                string query = @"INSERT INTO Orders (TableID, TotalAmount, Status) 
                                VALUES (@TableID, 0, N'Đang phục vụ');
                                SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = {
                    new SqlParameter("@TableID", tableID)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Lấy đơn hàng đang phục vụ của bàn
        public static Order GetActiveOrderByTableNumber(int tableNumber)
        {
            try
            {
                string query = @"SELECT o.*, t.TableNumber 
                                FROM Orders o 
                                INNER JOIN Tables t ON o.TableID = t.TableID 
                                WHERE t.TableNumber = @TableNumber AND o.Status = N'Đang phục vụ'";

                SqlParameter[] parameters = {
                    new SqlParameter("@TableNumber", tableNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new Order
                    {
                        OrderID = (int)row["OrderID"],
                        TableID = (int)row["TableID"],
                        TotalAmount = (decimal)row["TotalAmount"],
                        Status = row["Status"].ToString(),
                        CreatedDate = (DateTime)row["CreatedDate"],
                        UpdatedDate = (DateTime)row["UpdatedDate"],
                        TableNumber = (int)row["TableNumber"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Cập nhật tổng tiền đơn hàng
        public static bool UpdateOrderTotal(int orderID, decimal totalAmount)
        {
            try
            {
                string query = "UPDATE Orders SET TotalAmount = @TotalAmount WHERE OrderID = @OrderID";
                SqlParameter[] parameters = {
                    new SqlParameter("@TotalAmount", totalAmount),
                    new SqlParameter("@OrderID", orderID)
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tổng tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật trạng thái đơn hàng
        public static bool UpdateOrderStatus(int orderID, string status)
        {
            try
            {
                string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                SqlParameter[] parameters = {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@OrderID", orderID)
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy tất cả đơn hàng
        public static List<Order> GetAllOrders()
        {
            try
            {
                string query = @"SELECT o.*, t.TableNumber 
                                FROM Orders o 
                                INNER JOIN Tables t ON o.TableID = t.TableID 
                                ORDER BY o.CreatedDate DESC";

                DataTable dt = DBHelper.ExecuteQuery(query);
                List<Order> orders = new List<Order>();

                foreach (DataRow row in dt.Rows)
                {
                    orders.Add(new Order
                    {
                        OrderID = (int)row["OrderID"],
                        TableID = (int)row["TableID"],
                        TotalAmount = (decimal)row["TotalAmount"],
                        Status = row["Status"].ToString(),
                        CreatedDate = (DateTime)row["CreatedDate"],
                        UpdatedDate = (DateTime)row["UpdatedDate"],
                        TableNumber = (int)row["TableNumber"]
                    });
                }

                return orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Order>();
            }
        }
    }
}