// 📁 DoAn11/DataAccess/OrderDetailDAO.cs
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;
using DoAn11.DataAccess;

namespace DoAn11.DataAccess
{
    public class OrderDetailDAO
    {
        // Thêm món vào đơn hàng
        public static bool AddOrderDetail(int orderID, int itemID, int quantity, decimal unitPrice)
        {
            try
            {
                // Kiểm tra xem món đã có trong đơn hàng chưa
                string checkQuery = "SELECT OrderDetailID, Quantity FROM OrderDetails WHERE OrderID = @OrderID AND ItemID = @ItemID";
                SqlParameter[] checkParams = {
                    new SqlParameter("@OrderID", orderID),
                    new SqlParameter("@ItemID", itemID)
                };

                DataTable checkResult = DBHelper.ExecuteQuery(checkQuery, checkParams);

                if (checkResult.Rows.Count > 0)
                {
                    // Nếu món đã có, cập nhật số lượng
                    int existingQuantity = (int)checkResult.Rows[0]["Quantity"];
                    int newQuantity = existingQuantity + quantity;
                    decimal newTotalPrice = newQuantity * unitPrice;

                    string updateQuery = @"UPDATE OrderDetails 
                                          SET Quantity = @Quantity, TotalPrice = @TotalPrice 
                                          WHERE OrderID = @OrderID AND ItemID = @ItemID";
                    SqlParameter[] updateParams = {
                        new SqlParameter("@Quantity", newQuantity),
                        new SqlParameter("@TotalPrice", newTotalPrice),
                        new SqlParameter("@OrderID", orderID),
                        new SqlParameter("@ItemID", itemID)
                    };

                    return DBHelper.ExecuteNonQuery(updateQuery, updateParams) > 0;
                }
                else
                {
                    // Nếu món chưa có, thêm mới
                    decimal totalPrice = quantity * unitPrice;
                    string insertQuery = @"INSERT INTO OrderDetails (OrderID, ItemID, Quantity, UnitPrice, TotalPrice) 
                                          VALUES (@OrderID, @ItemID, @Quantity, @UnitPrice, @TotalPrice)";
                    SqlParameter[] insertParams = {
                        new SqlParameter("@OrderID", orderID),
                        new SqlParameter("@ItemID", itemID),
                        new SqlParameter("@Quantity", quantity),
                        new SqlParameter("@UnitPrice", unitPrice),
                        new SqlParameter("@TotalPrice", totalPrice)
                    };

                    return DBHelper.ExecuteNonQuery(insertQuery, insertParams) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món vào đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy chi tiết đơn hàng
        public static List<OrderDetail> GetOrderDetails(int orderID)
        {
            try
            {
                string query = @"SELECT od.*, m.ItemName 
                                FROM OrderDetails od 
                                INNER JOIN MenuItemss m ON od.ItemID = m.ItemID 
                                WHERE od.OrderID = @OrderID 
                                ORDER BY od.CreatedDate";

                SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", orderID)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                List<OrderDetail> details = new List<OrderDetail>();

                foreach (DataRow row in dt.Rows)
                {
                    details.Add(new OrderDetail
                    {
                        OrderDetailId = (int)row["OrderDetailID"],
                        OrderID = orderID,
                        ItemID = (int)row["ItemID"],
                        ItemName = row["ItemName"].ToString(),
                        SoLuong = (int)row["Quantity"],
                        Price = (decimal)row["UnitPrice"],
                        ThanhTien = (decimal)row["TotalPrice"],
                        ThoiGian = (DateTime)row["CreatedDate"]
                    });
                }

                return details;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<OrderDetail>();
            }
        }

        // Cập nhật số lượng món
        public static bool UpdateQuantity(int orderDetailID, int quantity)
        {
            try
            {
                string query = @"UPDATE OrderDetails 
                                SET Quantity = @Quantity, 
                                    TotalPrice = @Quantity * UnitPrice 
                                WHERE OrderDetailID = @OrderDetailID";

                SqlParameter[] parameters = {
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@OrderDetailID", orderDetailID)
                };

                return DBHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa món khỏi đơn hàng
        public static bool RemoveOrderDetail(int orderDetailID)
        {
            try
            {
                string query = "DELETE FROM OrderDetails WHERE OrderDetailID = @OrderDetailID";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", orderDetailID)
                };

                return DBHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Tính tổng tiền của đơn hàng
        public static decimal CalculateOrderTotal(int orderID)
        {
            try
            {
                string query = "SELECT SUM(TotalPrice) FROM OrderDetails WHERE OrderID = @OrderID";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", orderID)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    return (decimal)dt.Rows[0][0];
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Xóa tất cả chi tiết đơn hàng
        public static bool ClearOrderDetails(int orderID)
        {
            try
            {
                string query = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", orderID)
                };

                return DBHelper.ExecuteNonQuery(query, parameters) >= 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}