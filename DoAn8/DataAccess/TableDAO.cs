
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;
using DoAn11.DataAccess;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;

namespace DoAn11.DataAccess
{
    public class TableDAO
    {
        // Lấy danh sách tất cả bàn
        public static List<Table> GetAllTables()
        {
            try
            {
                string query = "SELECT * FROM Tables ORDER BY TableNumber";
                DataTable dt = DBHelper.ExecuteQuery(query);
                List<Table> tables = new List<Table>();

                foreach (DataRow row in dt.Rows)
                {
                    tables.Add(new Table
                    {
                        TableID = (int)row["TableID"],
                        TableNumber = (int)row["TableNumber"],
                        TableName = row["TableName"].ToString(),
                        Status = row["Status"].ToString(),
                        CreatedDate = (DateTime)row["CreatedDate"],
                        UpdatedDate = (DateTime)row["UpdatedDate"]
                    });
                }

                return tables;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Table>();
            }
        }

        // Lấy thông tin bàn theo số bàn
        public static Table GetTableByNumber(int tableNumber)
        {
            try
            {
                string query = "SELECT * FROM Tables WHERE TableNumber = @TableNumber";
                SqlParameter[] parameters = {
                    new SqlParameter("@TableNumber", tableNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new Table
                    {
                        TableID = (int)row["TableID"],
                        TableNumber = (int)row["TableNumber"],
                        TableName = row["TableName"].ToString(),
                        Status = row["Status"].ToString(),
                        CreatedDate = (DateTime)row["CreatedDate"],
                        UpdatedDate = (DateTime)row["UpdatedDate"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Cập nhật trạng thái bàn
        public static bool UpdateTableStatus(int tableNumber, string status)
        {
            try
            {
                string query = "UPDATE Tables SET Status = @Status WHERE TableNumber = @TableNumber";
                SqlParameter[] parameters = {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@TableNumber", tableNumber)
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Kiểm tra bàn có đang được sử dụng không
        public static bool IsTableOccupied(int tableNumber)
        {
            try
            {
                string query = "SELECT Status FROM Tables WHERE TableNumber = @TableNumber";
                SqlParameter[] parameters = {
                    new SqlParameter("@TableNumber", tableNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    string status = dt.Rows[0]["Status"].ToString();
                    return status == "Có khách";
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra trạng thái bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy ID bàn theo số bàn
        public static int GetTableID(int tableNumber)
        {
            try
            {
                string query = "SELECT TableID FROM Tables WHERE TableNumber = @TableNumber";
                SqlParameter[] parameters = {
                    new SqlParameter("@TableNumber", tableNumber)
                };

                DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return (int)dt.Rows[0]["TableID"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy ID bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}