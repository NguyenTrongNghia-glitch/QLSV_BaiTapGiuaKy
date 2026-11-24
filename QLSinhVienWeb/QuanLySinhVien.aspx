<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLySinhVien.aspx.cs" Inherits="QLSinhVienWeb.QuanLySinhVien" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sinh viên</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>QUẢN LÝ SINH VIÊN</h2>

        <asp:HiddenField ID="hfMaSV" runat="server" />

        <table>
            <tr>
                <td>Họ tên:</td>
                <td><asp:TextBox ID="txtHoTen" runat="server" Width="250px" /></td>
            </tr>
            <tr>
                <td>Ngày sinh:</td>
                <td><asp:TextBox ID="txtNgaySinh" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Giới tính:</td>
                <td>
                    <asp:DropDownList ID="ddlGioiTinh" runat="server">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lớp:</td>
                <td><asp:TextBox ID="txtLop" runat="server" Width="150px" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server" Width="250px" /></td>
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

        <asp:GridView ID="gvSinhVien" runat="server" AutoGenerateColumns="False"
            DataKeyNames="MaSV" AutoGenerateSelectButton="True" SelectText="Chọn"
            OnSelectedIndexChanged="gvSinhVien_SelectedIndexChanged" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="MaSV" HeaderText="Mã SV" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="Lop" HeaderText="Lớp" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>