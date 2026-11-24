using System;
using System.Linq;

namespace QLSinhVienWeb
{
    public partial class QuanLySinhVien : System.Web.UI.Page
    {
        QLSVDataContext db = new QLSVDataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLSinhVien;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) HienThi();
        }

        // READ: hiển thị danh sách
        void HienThi()
        {
            gvSinhVien.DataSource = db.SinhViens.OrderBy(s => s.MaSV).ToList();
            gvSinhVien.DataBind();
        }

        // Đưa dữ liệu từ form vào đối tượng sinh viên
        void GanDuLieu(SinhVien sv)
        {
            sv.HoTen = txtHoTen.Text.Trim();
            DateTime ns;
            sv.NgaySinh = DateTime.TryParse(txtNgaySinh.Text, out ns) ? (DateTime?)ns : null;
            sv.GioiTinh = ddlGioiTinh.SelectedValue;
            sv.Lop = txtLop.Text.Trim();
            sv.Email = txtEmail.Text.Trim();
        }

        void LamMoiForm()
        {
            hfMaSV.Value = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtLop.Text = "";
            txtEmail.Text = "";
            ddlGioiTinh.SelectedIndex = 0;
            gvSinhVien.SelectedIndex = -1;
        }

        // CREATE
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                lblThongBao.Text = "Vui lòng nhập họ tên.";
                return;
            }
            SinhVien sv = new SinhVien();
            GanDuLieu(sv);
            db.SinhViens.InsertOnSubmit(sv);
            db.SubmitChanges();
            LamMoiForm();
            HienThi();
            lblThongBao.Text = "Đã thêm sinh viên.";
        }

        // Chọn một dòng trong GridView để sửa/xóa
        protected void gvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(gvSinhVien.SelectedDataKey.Value);
            SinhVien sv = db.SinhViens.SingleOrDefault(s => s.MaSV == ma);
            if (sv == null) return;

            hfMaSV.Value = sv.MaSV.ToString();
            txtHoTen.Text = sv.HoTen;
            txtNgaySinh.Text = sv.NgaySinh.HasValue ? sv.NgaySinh.Value.ToString("yyyy-MM-dd") : "";
            ddlGioiTinh.SelectedValue = sv.GioiTinh;
            txtLop.Text = sv.Lop;
            txtEmail.Text = sv.Email;
            lblThongBao.Text = "";
        }

        // UPDATE
        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (hfMaSV.Value == "")
            {
                lblThongBao.Text = "Hãy chọn một sinh viên trong danh sách trước.";
                return;
            }
            int ma = int.Parse(hfMaSV.Value);
            SinhVien sv = db.SinhViens.SingleOrDefault(s => s.MaSV == ma);
            if (sv != null)
            {
                GanDuLieu(sv);
                db.SubmitChanges();
                LamMoiForm();
                HienThi();
                lblThongBao.Text = "Đã cập nhật sinh viên.";
            }
        }

        // DELETE
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            if (hfMaSV.Value == "")
            {
                lblThongBao.Text = "Hãy chọn một sinh viên trong danh sách trước.";
                return;
            }
            int ma = int.Parse(hfMaSV.Value);
            SinhVien sv = db.SinhViens.SingleOrDefault(s => s.MaSV == ma);
            if (sv != null)
            {
                db.SinhViens.DeleteOnSubmit(sv);
                db.SubmitChanges();
                LamMoiForm();
                HienThi();
                lblThongBao.Text = "Đã xóa sinh viên.";
            }
        }

        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            lblThongBao.Text = "";
        }
    }
}