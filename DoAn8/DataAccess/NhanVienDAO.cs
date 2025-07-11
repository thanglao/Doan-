using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DoAn11.Models;
using DoAn11.DataAccess;
using System.Windows.Forms;
namespace DoAn11.DataAccess
{
    namespace DoAn11.DataAccess
    {
        public class NhanVienDAO
        {
            public static void Insert(NhanVien nv)
            {
                string query = @"INSERT INTO NhanVien (HoTen, NgaySinh, ChucVu, CaLamViec, LuongCoBan, SoDienThoai) 
                             VALUES (@HoTen, @NgaySinh, @ChucVu, @CaLamViec, @LuongCoBan, @SoDienThoai)";

                SqlParameter[] parameters = {
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@NgaySinh", nv.NgaySinh),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@CaLamViec", nv.CaLamViec),
                new SqlParameter("@LuongCoBan", nv.LuongCoBan),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai ?? "")
            };

                DBHelper.ExecuteNonQuery(query, parameters);
            }

            public static void Update(NhanVien nv)
            {
                string query = @"UPDATE NhanVien 
                             SET HoTen=@HoTen, NgaySinh=@NgaySinh, ChucVu=@ChucVu, CaLamViec=@CaLamViec, 
                                 LuongCoBan=@LuongCoBan, SoDienThoai=@SoDienThoai 
                             WHERE MaNV=@MaNV";

                SqlParameter[] parameters = {
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@NgaySinh", nv.NgaySinh),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@CaLamViec", nv.CaLamViec),
                new SqlParameter("@LuongCoBan", nv.LuongCoBan),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai ?? ""),
                new SqlParameter("@MaNV", nv.MaNV)
            };

                DBHelper.ExecuteNonQuery(query, parameters);
            }

            public static void Delete(int maNV)
            {
                string query = "DELETE FROM NhanVien WHERE MaNV=@MaNV";

                SqlParameter[] parameters = {
                new SqlParameter("@MaNV", maNV)
            };

                DBHelper.ExecuteNonQuery(query, parameters);
            }

            public static List<NhanVien> GetAll()
            {
                string query = "SELECT * FROM NhanVien ORDER BY MaNV";
                DataTable dt = DBHelper.ExecuteQuery(query);
                List<NhanVien> list = new List<NhanVien>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new NhanVien
                    {
                        MaNV = (int)row["MaNV"],
                        HoTen = row["HoTen"].ToString(),
                        NgaySinh = (DateTime)row["NgaySinh"],
                        ChucVu = row["ChucVu"].ToString(),
                        CaLamViec = row["CaLamViec"].ToString(),
                        LuongCoBan = (decimal)row["LuongCoBan"],
                        SoDienThoai = row["SoDienThoai"]?.ToString()
                    });
                }

                return list;
            }

            public static NhanVien GetById(int maNV)
            {
                try
                {
                    string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
                    SqlParameter[] parameters = {
                    new SqlParameter("@MaNV", maNV)
                };

                    DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        return new NhanVien
                        {
                            MaNV = (int)row["MaNV"],
                            HoTen = row["HoTen"].ToString(),
                            NgaySinh = (DateTime)row["NgaySinh"],
                            ChucVu = row["ChucVu"].ToString(),
                            CaLamViec = row["CaLamViec"].ToString(),
                            LuongCoBan = (decimal)row["LuongCoBan"],
                            SoDienThoai = row["SoDienThoai"]?.ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy thông tin nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }

            public static List<NhanVien> Search(string keyword)
            {
                try
                {
                    string query = @"SELECT * FROM NhanVien 
                                WHERE HoTen LIKE @keyword 
                                   OR ChucVu LIKE @keyword 
                                   OR SoDienThoai LIKE @keyword 
                                ORDER BY MaNV";

                    SqlParameter[] parameters = {
                    new SqlParameter("@keyword", $"%{keyword}%")
                };

                    DataTable dt = DBHelper.ExecuteQuery(query, parameters);
                    List<NhanVien> list = new List<NhanVien>();

                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(new NhanVien
                        {
                            MaNV = (int)row["MaNV"],
                            HoTen = row["HoTen"].ToString(),
                            NgaySinh = (DateTime)row["NgaySinh"],
                            ChucVu = row["ChucVu"].ToString(),
                            CaLamViec = row["CaLamViec"].ToString(),
                            LuongCoBan = (decimal)row["LuongCoBan"],
                            SoDienThoai = row["SoDienThoai"]?.ToString()
                        });
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<NhanVien>();
                }
            }

            public static bool IsEmployeeExists(string hoTen, string soDienThoai)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM NhanVien WHERE HoTen = @HoTen OR SoDienThoai = @SoDienThoai";

                    SqlParameter[] parameters = {
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@SoDienThoai", soDienThoai)
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
                    MessageBox.Show($"Lỗi khi kiểm tra nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public static bool IsEmployeeExists(string hoTen, string soDienThoai, int excludeMaNV)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM NhanVien WHERE (HoTen = @HoTen OR SoDienThoai = @SoDienThoai) AND MaNV != @MaNV";

                    SqlParameter[] parameters = {
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@SoDienThoai", soDienThoai),
                    new SqlParameter("@MaNV", excludeMaNV)
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
                    MessageBox.Show($"Lỗi khi kiểm tra nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Thêm phương thức lấy danh sách chức vụ
            public static List<string> GetChucVuList()
            {
                try
                {
                    string query = "SELECT DISTINCT ChucVu FROM NhanVien ORDER BY ChucVu";
                    DataTable dt = DBHelper.ExecuteQuery(query);
                    List<string> list = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(row["ChucVu"].ToString());
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy danh sách chức vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }
            }

            // Thêm phương thức lấy danh sách ca làm việc
            public static List<string> GetCaLamViecList()
            {
                try
                {
                    string query = "SELECT DISTINCT CaLamViec FROM NhanVien ORDER BY CaLamViec";
                    DataTable dt = DBHelper.ExecuteQuery(query);
                    List<string> list = new List<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(row["CaLamViec"].ToString());
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy danh sách ca làm việc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }
            }

            // Thống kê số lượng nhân viên theo chức vụ
            public static Dictionary<string, int> GetThongKeTheoChucVu()
            {
                try
                {
                    string query = "SELECT ChucVu, COUNT(*) as SoLuong FROM NhanVien GROUP BY ChucVu";
                    DataTable dt = DBHelper.ExecuteQuery(query);
                    Dictionary<string, int> result = new Dictionary<string, int>();

                    foreach (DataRow row in dt.Rows)
                    {
                        result[row["ChucVu"].ToString()] = Convert.ToInt32(row["SoLuong"]);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Dictionary<string, int>();
                }
            }
        }
    }
}
