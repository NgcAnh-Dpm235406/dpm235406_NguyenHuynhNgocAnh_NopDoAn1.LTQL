USE master;
GO

-- 1. XÓA VÀ TẠO MỚI DATABASE
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLKS2')
BEGIN
    ALTER DATABASE QLKS2 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLKS2;
END
GO

CREATE DATABASE QLKS2;
GO

USE QLKS2;
GO

-----------------------------------------------------------
-- 2. TẠO CÁC BẢNG DỮ LIỆU
-----------------------------------------------------------

CREATE TABLE TaiKhoan (
    MaTK INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL, 
    HoTen NVARCHAR(100),
    LoaiTaiKhoan NVARCHAR(20) NOT NULL CHECK (LoaiTaiKhoan IN ('Admin', 'User')),
    TrangThai BIT DEFAULT 1
);

CREATE TABLE LoaiPhong (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(50) NOT NULL,
    GiaNgay DECIMAL(18, 0) DEFAULT 0,
    GiaGio DECIMAL(18, 0) DEFAULT 0,
    SoNgay INT DEFAULT 0, 
    SoGio INT DEFAULT 0
);

CREATE TABLE Phong (
    MaPhong INT PRIMARY KEY IDENTITY(1,1),
    TenPhong NVARCHAR(20) NOT NULL UNIQUE,
    MaLoai INT,
    TrangThai NVARCHAR(30) DEFAULT N'Trống' CHECK (TrangThai IN (N'Trống', N'Có khách', N'Sửa chữa', N'Đã đặt')),
    TongTien DECIMAL(18, 0) DEFAULT 0,
    CONSTRAINT FK_Phong_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai) ON DELETE SET NULL
);

CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE,
    SDT VARCHAR(15),
    DiaChi NVARCHAR(255),
    QuocTich NVARCHAR(50) DEFAULT N'Việt Nam'
);

CREATE TABLE PhieuThue (
    MaPhieu INT PRIMARY KEY IDENTITY(1,1),
    MaPhong INT,
    MaKH INT,
    NgayCheckIn DATETIME DEFAULT GETDATE(),
    NgayCheckOutDuKien DATETIME,
    TrangThai NVARCHAR(50) DEFAULT N'Chưa thanh toán' CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy')),
    CONSTRAINT FK_Phieu_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_Phieu_Khach FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE DichVu (
    MaDV INT PRIMARY KEY IDENTITY(1,1),
    TenDV NVARCHAR(100) NOT NULL,
    GiaDV DECIMAL(18, 0) NOT NULL
);

CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    MaPhieu INT UNIQUE, -- Một phiếu thuê chỉ có một hóa đơn
    MaTK_NguoiLap INT,
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    TongTienPhong DECIMAL(18, 0) DEFAULT 0,
    TongTienDV DECIMAL(18, 0) DEFAULT 0,
    TongTienThanhToan DECIMAL(18, 0) DEFAULT 0, 
    CONSTRAINT FK_HD_Phieu FOREIGN KEY (MaPhieu) REFERENCES PhieuThue(MaPhieu),
    CONSTRAINT FK_HD_TaiKhoan FOREIGN KEY (MaTK_NguoiLap) REFERENCES TaiKhoan(MaTK)
);
GO

-----------------------------------------------------------
-- 3. CHÈN DỮ LIỆU MẪU (THỨ TỰ CHUẨN)
-----------------------------------------------------------

-- 3.1. Loại Phòng & Tài Khoản
INSERT INTO LoaiPhong (TenLoai, GiaNgay, GiaGio, SoNgay, SoGio) VALUES 
(N'Phòng Đơn Tiêu Chuẩn', 300000, 50000, 1, 12),
(N'Phòng Đôi Tiêu Chuẩn', 500000, 80000, 1, 10),
(N'Phòng Family', 800000, 120000, 1, 8),
(N'Phòng Đơn Cao cấp', 300000, 50000, 1, 12),
(N'Phòng Đôi Cao Cấp', 500000, 80000, 1, 10),
(N'Phòng VIP Family', 800000, 120000, 1, 8);

INSERT INTO TaiKhoan(TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan) VALUES 
('admin', '123', N'Nguyễn Ngọc Anh', 'Admin'), 
('user', '123', N'Nhân Viên A', 'User');

-- 3.2. Phòng
INSERT INTO Phong (TenPhong, MaLoai, TrangThai) VALUES 
(N'P.101', 1, N'Có khách'), (N'P.102', 1, N'Trống'), 
(N'P.201', 2, N'Trống'), (N'P.202', 2, N'Trống'),
(N'P.301', 3, N'Trống'), (N'P.302', 3, N'Đã Đặt');

-- 3.3. Khách hàng (13 khách)
INSERT INTO KhachHang (HoTen, CCCD, SDT, DiaChi, QuocTich) VALUES 
(N'Trần Thị Thanh Ngân', '012345678902', '0912345678', N'Ninh Kiều, Cần Thơ', N'Việt Nam'),
(N'John Smith', '012345678905', '0966888999', N'New York, USA', N'USA'),
(N'Phạm Minh Tuấn', '012345678904', '0977123456', N'Ba Đình, Hà Nội', N'Việt Nam'),
(N'Nguyễn Văn Hải', '012345678001', '0901234567', N'Quận 1, TP. Hồ Chí Minh', N'Việt Nam'),
(N'Lê Thị Mai', '012345678002', '0987654321', N'Hải Châu, Đà Nẵng', N'Việt Nam'),
(N'David Beckham', '012345678003', '0933445566', N'London, UK', N'Anh Quốc'),
(N'Trần Hoàng Long', '012345678004', '0911223344', N'Ninh Kiều, Cần Thơ', N'Việt Nam'),
(N'Kim Soo Hyun', '012345678005', '0922888777', N'Seoul, South Korea', N'Hàn Quốc'),
(N'Vũ Bích Phương', '012345678006', '0944556677', N'Hồng Bàng, Hải Phòng', N'Việt Nam'),
(N'Michael Jordan', '012345678007', '0955667788', N'Chicago, USA', N'Mỹ'),
(N'Hoàng Thanh Tùng', '012345678008', '0966778899', N'TP. Thái Nguyên', N'Việt Nam'),
(N'Yuki Tanaka', '012345678009', '0977889900', N'Tokyo, Japan', N'Nhật Bản'),
(N'Đỗ Thùy Linh', '012345678010', '0900112233', N'TP. Hạ Long, Quảng Ninh', N'Việt Nam');
GO

-- 3.4. Phiếu Thuê (Tạo 12 phiếu để làm 12 hóa đơn)
INSERT INTO PhieuThue (MaPhong, MaKH, NgayCheckIn, TrangThai) VALUES 
(1, 1, '2026-04-10', N'Đã thanh toán'), (2, 2, '2026-04-11', N'Đã thanh toán'),
(3, 4, '2026-04-01', N'Đã thanh toán'), (4, 5, '2026-04-02', N'Đã thanh toán'),
(5, 6, '2026-04-03', N'Đã thanh toán'), (6, 7, '2026-04-04', N'Đã thanh toán'),
(1, 8, '2026-04-05', N'Đã thanh toán'), (2, 9, '2026-04-06', N'Đã thanh toán'),
(3, 10, '2026-04-07', N'Đã thanh toán'), (4, 11, '2026-04-08', N'Đã thanh toán'),
(5, 12, '2026-04-09', N'Đã thanh toán'), (6, 13, '2026-04-10', N'Đã thanh toán');
GO

-- 3.5. Hóa Đơn (Khớp với MaPhieu từ 1 đến 12)
INSERT INTO HoaDon (MaPhieu, MaTK_NguoiLap, NgayThanhToan, TongTienPhong, TongTienDV, TongTienThanhToan) VALUES 
(1, 1, GETDATE(), 300000, 50000, 350000), 
(2, 1, GETDATE(), 800000, 120000, 920000),
(3, 1, '2026-04-03', 600000, 45000, 645000),
(4, 1, '2026-04-04', 1000000, 0, 1000000),
(5, 1, '2026-04-05', 1600000, 250000, 1850000),
(6, 1, '2026-04-06', 600000, 35000, 635000),
(7, 1, '2026-04-07', 600000, 15000, 615000),
(8, 1, '2026-04-08', 1000000, 120000, 1120000),
(9, 1, '2026-04-09', 1600000, 80000, 1680000),
(10, 1, '2026-04-10', 600000, 40000, 640000),
(11, 1, '2026-04-11', 1000000, 150000, 1150000),
(12, 1, '2026-04-12', 1600000, 300000, 1900000);
GO


SELECT * FROM PhieuThue