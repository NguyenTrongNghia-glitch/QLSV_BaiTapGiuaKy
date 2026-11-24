<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLySinhVien.aspx.cs" Inherits="QLSinhVienWeb.QuanLySinhVien" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý nhân viên</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>QUẢN LÝ NHÂN VIÊN</h2>

        <asp:HiddenField ID="hfMaNV" runat="server" />

        <table>
            <tr>
                <td>Mã NV:</td>
                <td><asp:TextBox ID="txtMaNV" runat="server" Width="100px" MaxLength="5" /></td>
            </tr>
            <tr>
                <td>Họ NV:</td>
                <td><asp:TextBox ID="txtHoNV" runat="server" Width="250px" MaxLength="30" /></td>
            </tr>
            <tr>
                <td>Tên NV:</td>
                <td><asp:TextBox ID="txtTenNV" runat="server" Width="150px" MaxLength="10" /></td>
            </tr>
            <tr>
                <td>Lương:</td>
                <td><asp:TextBox ID="txtLuong" runat="server" Width="150px" /></td>
            </tr>
            <tr>
                <td>Phái:</td>
                <td>
                    <asp:DropDownList ID="ddlPhai" runat="server">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ngày sinh:</td>
                <td><asp:TextBox ID="txtNgaySinh" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Chức vụ:</td>
                <td><asp:DropDownList ID="ddlChucVu" runat="server" /></td>
            </tr>
            <tr>
                <td>Bộ phận:</td>
                <td><asp:DropDownList ID="ddlBoPhan" runat="server" /></td>
            </tr>
        </table>

        <br />
        <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
        <asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click" />
        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click"
            OnClientClick="return confirm('Bạn có chắc muốn xóa?');" />
        <asp:Button ID="btnLamMoi" runat="server" Text="Làm mới" OnClick="btnLamMoi_Click" />

        <br /><br />
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red" />
        <br />

        <asp:GridView ID="gvNhanVien" runat="server" AutoGenerateColumns="False"
            DataKeyNames="MaNV" AutoGenerateSelectButton="True" SelectText="Chọn"
            OnSelectedIndexChanged="gvNhanVien_SelectedIndexChanged" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="MaNV" HeaderText="Mã NV" />
                <asp:BoundField DataField="HoNV" HeaderText="Họ NV" />
                <asp:BoundField DataField="TenNV" HeaderText="Tên NV" />
                <asp:BoundField DataField="Luong" HeaderText="Lương" DataFormatString="{0:N0}" HtmlEncode="false" />
                <asp:BoundField DataField="Phai" HeaderText="Phái" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                <asp:BoundField DataField="MaCV" HeaderText="Mã CV" />
                <asp:BoundField DataField="MaBP" HeaderText="Mã BP" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
