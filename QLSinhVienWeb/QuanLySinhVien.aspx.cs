using System;
using System.Linq;
using System.Web.Configuration;

namespace QLSinhVienWeb
{
    public partial class QuanLySinhVien : System.Web.UI.Page
    {
        QLSVDataContext db = new QLSVDataContext(WebConfigurationManager.ConnectionStrings["QLSVConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NapDanhMuc();
                HienThi();
            }
        }

        // Nạp danh sách chức vụ, bộ phận vào DropDownList
        void NapDanhMuc()
        {
            ddlChucVu.DataSource = db.ChucVus.ToList();
            ddlChucVu.DataTextField = "TenCV";
            ddlChucVu.DataValueField = "MaCV";
            ddlChucVu.DataBind();

            ddlBoPhan.DataSource = db.Bophans.ToList();
            ddlBoPhan.DataTextField = "TenBP";
            ddlBoPhan.DataValueField = "MaBP";
            ddlBoPhan.DataBind();
        }

        // READ: hiển thị danh sách
        void HienThi()
        {
            gvNhanVien.DataSource = db.NhanViens.OrderBy(n => n.MaNV).ToList();
            gvNhanVien.DataBind();
        }

        // Đưa dữ liệu từ form vào đối tượng nhân viên
        void GanDuLieu(NhanVien nv)
        {
            nv.HoNV = txtHoNV.Text.Trim();
            nv.TenNV = txtTenNV.Text.Trim();
            double luong;
            nv.Luong = double.TryParse(txtLuong.Text, out luong) ? (double?)luong : null;
            nv.Phai = ddlPhai.SelectedValue;
            DateTime ns;
            nv.NgaySinh = DateTime.TryParse(txtNgaySinh.Text, out ns) ? (DateTime?)ns : null;
            nv.MaCV = ddlChucVu.SelectedValue;
            nv.MaBP = ddlBoPhan.SelectedValue;
        }

        void LamMoiForm()
        {
            hfMaNV.Value = "";
            txtMaNV.Text = "";
            txtMaNV.Enabled = true;
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            txtLuong.Text = "";
            txtNgaySinh.Text = "";
            ddlPhai.SelectedIndex = 0;
            ddlChucVu.SelectedIndex = 0;
            ddlBoPhan.SelectedIndex = 0;
            gvNhanVien.SelectedIndex = -1;
        }

        // CREATE
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtTenNV.Text.Trim() == "")
            {
                lblThongBao.Text = "Vui lòng nhập mã và tên nhân viên.";
                return;
            }
            NhanVien nv = new NhanVien();
            nv.MaNV = txtMaNV.Text.Trim();
            GanDuLieu(nv);
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            LamMoiForm();
            HienThi();
            lblThongBao.Text = "Đã thêm nhân viên.";
        }

        // Chọn một dòng trong GridView để sửa/xóa
        protected void gvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = gvNhanVien.SelectedDataKey.Value.ToString();
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNV == ma);
            if (nv == null) return;

            hfMaNV.Value = nv.MaNV;
            txtMaNV.Text = nv.MaNV;
            txtMaNV.Enabled = false;
            txtHoNV.Text = nv.HoNV;
            txtTenNV.Text = nv.TenNV;
            txtLuong.Text = nv.Luong.HasValue ? nv.Luong.Value.ToString() : "";
            txtNgaySinh.Text = nv.NgaySinh.HasValue ? nv.NgaySinh.Value.ToString("yyyy-MM-dd") : "";
            ddlPhai.SelectedValue = (nv.Phai != null && nv.Phai.ToLower() == "nam") ? "Nam" : "Nữ";
            ddlChucVu.SelectedValue = nv.MaCV;
            ddlBoPhan.SelectedValue = nv.MaBP;
            lblThongBao.Text = "";
        }

        // UPDATE
        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (hfMaNV.Value == "")
            {
                lblThongBao.Text = "Hãy chọn một nhân viên trong danh sách trước.";
                return;
            }
            string ma = hfMaNV.Value;
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNV == ma);
            if (nv != null)
            {
                GanDuLieu(nv);
                db.SubmitChanges();
                LamMoiForm();
                HienThi();
                lblThongBao.Text = "Đã cập nhật nhân viên.";
            }
        }

        // DELETE
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            if (hfMaNV.Value == "")
            {
                lblThongBao.Text = "Hãy chọn một nhân viên trong danh sách trước.";
                return;
            }
            string ma = hfMaNV.Value;
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNV == ma);
            if (nv != null)
            {
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                LamMoiForm();
                HienThi();
                lblThongBao.Text = "Đã xóa nhân viên.";
            }
        }

        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            lblThongBao.Text = "";
        }
    }
}
