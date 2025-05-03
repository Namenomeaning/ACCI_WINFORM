USE ACCI;

-- =========================================
-- 1. Drop tables if they exist (in reverse dependency order)
-- =========================================
SET FOREIGN_KEY_CHECKS = 0; -- Tạm thời tắt kiểm tra khóa ngoại để DROP không lỗi thứ tự

DROP TABLE IF EXISTS ChungChi;
DROP TABLE IF EXISTS ChiTietHoaDon;
DROP TABLE IF EXISTS HoaDon;
DROP TABLE IF EXISTS PhieuGiaHan;
DROP TABLE IF EXISTS PhiGiaHan;
DROP TABLE IF EXISTS ChiTietPhieuDK;
DROP TABLE IF EXISTS PhieuDK;
DROP TABLE IF EXISTS ThiSinh;
DROP TABLE IF EXISTS LichThi;
DROP TABLE IF EXISTS PhongThi;
DROP TABLE IF EXISTS DanhGia;
DROP TABLE IF EXISTS KhachHang;
DROP TABLE IF EXISTS ThongTinDangNhap;
DROP TABLE IF EXISTS NhanVien;
DROP TABLE IF EXISTS UuDai;

SET FOREIGN_KEY_CHECKS = 1; -- Bật lại kiểm tra khóa ngoại

-- Xóa toàn bộ các trigger cũ nếu tồn tại
DROP TRIGGER IF EXISTS trg_NhanVien_ai;
DROP TRIGGER IF EXISTS trg_ThongTinDangNhap_ai;
DROP TRIGGER IF EXISTS trg_KhachHang_ai;
DROP TRIGGER IF EXISTS trg_DanhGia_ai;
DROP TRIGGER IF EXISTS trg_PhongThi_ai;
DROP TRIGGER IF EXISTS trg_LichThi_ai;
DROP TRIGGER IF EXISTS trg_ThiSinh_ai;
DROP TRIGGER IF EXISTS trg_PhieuDK_ai;
DROP TRIGGER IF EXISTS trg_PhiGiaHan_ai;
DROP TRIGGER IF EXISTS trg_PhieuGiaHan_ai;
DROP TRIGGER IF EXISTS trg_UuDai_ai;
DROP TRIGGER IF EXISTS trg_HoaDon_ai;
DROP TRIGGER IF EXISTS trg_ChiTietHoaDon_ai;
DROP TRIGGER IF EXISTS trg_ChungChi_ai;
DROP TRIGGER IF EXISTS trg_ChungChi_bi;

-- =========================================
-- 2. Create tables
-- =========================================

CREATE TABLE NhanVien (
  MaNhanVien      VARCHAR(10) PRIMARY KEY,
  HoTen           NVARCHAR(100) NOT NULL,
  VaiTro          ENUM('TiepNhan','KeToan','NhapLieu') NOT NULL,
  TrangThai       ENUM('DangLam','NghiViec') NOT NULL
);

CREATE TABLE ThongTinDangNhap (
  MaThongTinDangNhap VARCHAR(10) PRIMARY KEY,
  TenDangNhap        VARCHAR(50) NOT NULL UNIQUE,
  MatKhauHash        VARCHAR(255) NOT NULL,
  MaNhanVien         VARCHAR(10) NOT NULL,
  CONSTRAINT fk_tdn_nv FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE KhachHang (
  MaKhachHang     VARCHAR(10) PRIMARY KEY,
  LoaiKhach       ENUM('TuDo','DonVi') NOT NULL,
  HoTen           NVARCHAR(100) NULL,
  TenDonVi        NVARCHAR(150) NULL,
  DiaChi          NVARCHAR(200) NOT NULL,
  Email           VARCHAR(100) NOT NULL UNIQUE,
  DienThoai       VARCHAR(15) NOT NULL
);

CREATE TABLE DanhGia (
  MaDanhGia       VARCHAR(10) PRIMARY KEY,
  TenDanhGia      NVARCHAR(100) NOT NULL,
  MoTa            NVARCHAR(200) NULL,
  DonGia          DECIMAL(12,2) NOT NULL
);

CREATE TABLE PhongThi (
  MaPhongThi      VARCHAR(10) PRIMARY KEY,
  TenPhong        NVARCHAR(50) NOT NULL,
  SucChua         INT NOT NULL
);

CREATE TABLE LichThi (
  MaLichThi       VARCHAR(10) PRIMARY KEY,
  MaDanhGia       VARCHAR(10) NOT NULL,
  MaPhongThi      VARCHAR(10) NOT NULL,
  NgayThi         DATE NOT NULL,
  GioThi          TIME NOT NULL,
  SoLuongMax      INT NOT NULL,
  SoLuongDK       INT NOT NULL DEFAULT 0,
  TrangThai       ENUM('MoDangKy','DuCho','Dong','DaThi') NOT NULL,
  CHECK (SoLuongDK <= SoLuongMax)
);

CREATE TABLE ThiSinh (
  MaThiSinh       VARCHAR(10) PRIMARY KEY,
  HoTen           NVARCHAR(100) NOT NULL,
  NgaySinh        DATE NULL,
  GioiTinh        ENUM('Nam','Nu','Khac') NULL
);

CREATE TABLE PhieuDK (
  MaPhieuDK       VARCHAR(10) PRIMARY KEY,
  MaKhachHang     VARCHAR(10) NOT NULL,
  MaNV_TiepNhan   VARCHAR(10) NOT NULL,
  NgayTao         DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  SoLanGiaHan     TINYINT NOT NULL DEFAULT 0,
  TrangThai       ENUM('Moi','ChoThanhToan','DaThanhToan','Huy','DaHoanTat') NOT NULL,
  CHECK (SoLanGiaHan <= 2)
);

CREATE TABLE ChiTietPhieuDK (
  MaPhieuDK       VARCHAR(10) NOT NULL,
  ThuTu           TINYINT NOT NULL,
  MaThiSinh       VARCHAR(10) NULL,
  MaLichThi       VARCHAR(10) NOT NULL,
  SoBaoDanh       VARCHAR(20) NULL UNIQUE,
  TrangThaiCT     ENUM('DK','CoSBD','Vang','DaThi','Dat','KhongDat') NOT NULL,
  Diem            DECIMAL(5,2) NULL,
  KetQua          ENUM('Dat','KhongDat') NULL,
  NgayCoKetQua    DATE NULL,
  MaNV_NhapLieu   VARCHAR(10) NULL,
  PRIMARY KEY (MaPhieuDK, ThuTu)
);

CREATE TABLE PhiGiaHan (
  MaPhiGiaHan     VARCHAR(10) PRIMARY KEY,
  TenLoaiPhi      NVARCHAR(100) NOT NULL,
  DonGia          DECIMAL(12,2) NOT NULL
);

CREATE TABLE PhieuGiaHan (
  MaPhieuGiaHan   VARCHAR(10) PRIMARY KEY,
  MaPhieuDK       VARCHAR(10) NOT NULL,
  ThuTu_CT        TINYINT NOT NULL,
  MaLichThi_Cu    VARCHAR(10) NOT NULL,
  MaLichThi_Moi   VARCHAR(10) NOT NULL,
  LyDo            NVARCHAR(200) NOT NULL,
  NgayYC          DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  MaNV_XuLy       VARCHAR(10) NOT NULL,
  TrangThai       ENUM('YeuCau','DaDuyet','ChoThanhToan','HoanTat','TuChoi') NOT NULL,
  MaPhiGiaHan     VARCHAR(10) NULL
);

CREATE TABLE UuDai (
  MaUuDai         VARCHAR(10) PRIMARY KEY,
  TenUuDai        NVARCHAR(100) NOT NULL,
  Loai            ENUM('TLPhanTram','TienMat') NOT NULL,
  GiaTri          DECIMAL(5,2) NOT NULL,
  DieuKien        NVARCHAR(200) NOT NULL,
  NgayBD          DATE NOT NULL,
  NgayKT          DATE NOT NULL,
  TrangThai       ENUM('DangApDung','HetHan') NOT NULL
);

CREATE TABLE HoaDon (
  MaHoaDon        VARCHAR(10) PRIMARY KEY,
  MaPhieuDK       VARCHAR(10) NULL,
  MaPhieuGiaHan   VARCHAR(10) NULL,
  MaUuDai         VARCHAR(10) NULL,
  MaNV_KeToan     VARCHAR(10) NOT NULL,
  NgayLap         DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PhuongThuc      ENUM('TienMat','ChuyenKhoan') NULL,
  MaGiaoDich      VARCHAR(50) NULL,
  TongTienGoc     DECIMAL(14,2) NOT NULL,
  SoTienGiam      DECIMAL(14,2) NOT NULL DEFAULT 0,
  TongThu         DECIMAL(14,2) NOT NULL,
  NgayThanhToan   DATETIME NULL,
  TrangThaiTT     ENUM('ChuaTT','DaTT','Huy') NOT NULL,
  CHECK (MaPhieuDK IS NOT NULL OR MaPhieuGiaHan IS NOT NULL)
);

CREATE TABLE ChiTietHoaDon (
  MaChiTietHoaDon VARCHAR(10) PRIMARY KEY,
  MaHoaDon        VARCHAR(10) NOT NULL,
  MaDanhGia       VARCHAR(10) NULL,
  MaPhiGiaHan     VARCHAR(10) NULL,
  SoLuong         INT NOT NULL DEFAULT 1,
  DonGia          DECIMAL(12,2) NOT NULL,
  ThanhTien       DECIMAL(14,2) NOT NULL,
  CHECK (MaDanhGia IS NOT NULL OR MaPhiGiaHan IS NOT NULL)
);

CREATE TABLE ChungChi (
  MaChungChi      VARCHAR(10) PRIMARY KEY,
  SoHieu          VARCHAR(20) NOT NULL UNIQUE,
  MaPhieuDK       VARCHAR(10) NOT NULL,
  ThuTu           TINYINT NOT NULL,
  MaThiSinh       VARCHAR(10) NOT NULL,
  NgayCap         DATE NOT NULL,
  NgayHetHan      DATE NULL,
  PhuongThucNhan  ENUM('TaiTT','BuuDien') NOT NULL,
  DiaChiNhan      NVARCHAR(200) NULL,
  NgayNhan        DATE NULL,
  TrangThaiNhan   ENUM('ChuaNhan','DaNhan') NOT NULL,
  MaNV_CapNhat    VARCHAR(10) NULL
);

-- =========================================
-- 3. Add FOREIGN KEY constraints via ALTER TABLE
-- =========================================

ALTER TABLE LichThi
  ADD CONSTRAINT fk_lt_dg FOREIGN KEY (MaDanhGia) REFERENCES DanhGia(MaDanhGia),
  ADD CONSTRAINT fk_lt_pt FOREIGN KEY (MaPhongThi) REFERENCES PhongThi(MaPhongThi);

ALTER TABLE PhieuDK
  ADD CONSTRAINT fk_pdk_kh FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
  ADD CONSTRAINT fk_pdk_nv FOREIGN KEY (MaNV_TiepNhan) REFERENCES NhanVien(MaNhanVien);

ALTER TABLE ChiTietPhieuDK
  ADD CONSTRAINT fk_ct_pdk FOREIGN KEY (MaPhieuDK) REFERENCES PhieuDK(MaPhieuDK),
  ADD CONSTRAINT fk_ct_ts FOREIGN KEY (MaThiSinh) REFERENCES ThiSinh(MaThiSinh),
  ADD CONSTRAINT fk_ct_lt FOREIGN KEY (MaLichThi) REFERENCES LichThi(MaLichThi),
  ADD CONSTRAINT fk_ctdk_nv_nhap FOREIGN KEY (MaNV_NhapLieu) REFERENCES NhanVien(MaNhanVien);

ALTER TABLE PhieuGiaHan
  ADD CONSTRAINT fk_gh_pdk FOREIGN KEY (MaPhieuDK) REFERENCES PhieuDK(MaPhieuDK),
  ADD CONSTRAINT fk_gh_ltc FOREIGN KEY (MaLichThi_Cu) REFERENCES LichThi(MaLichThi),
  ADD CONSTRAINT fk_gh_ltm FOREIGN KEY (MaLichThi_Moi) REFERENCES LichThi(MaLichThi),
  ADD CONSTRAINT fk_gh_nv FOREIGN KEY (MaNV_XuLy) REFERENCES NhanVien(MaNhanVien),
  ADD CONSTRAINT fk_gh_phi FOREIGN KEY (MaPhiGiaHan) REFERENCES PhiGiaHan(MaPhiGiaHan);

ALTER TABLE HoaDon
  ADD CONSTRAINT fk_hd_pdk FOREIGN KEY (MaPhieuDK) REFERENCES PhieuDK(MaPhieuDK),
  ADD CONSTRAINT fk_hd_gh FOREIGN KEY (MaPhieuGiaHan) REFERENCES PhieuGiaHan(MaPhieuGiaHan),
  ADD CONSTRAINT fk_hd_ud FOREIGN KEY (MaUuDai) REFERENCES UuDai(MaUuDai),
  ADD CONSTRAINT fk_hd_nv FOREIGN KEY (MaNV_KeToan) REFERENCES NhanVien(MaNhanVien);

ALTER TABLE ChiTietHoaDon
  ADD CONSTRAINT fk_cthd_hd FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
  ADD CONSTRAINT fk_cthd_dg FOREIGN KEY (MaDanhGia) REFERENCES DanhGia(MaDanhGia),
  ADD CONSTRAINT fk_cthd_phi FOREIGN KEY (MaPhiGiaHan) REFERENCES PhiGiaHan(MaPhiGiaHan);

ALTER TABLE ChungChi
  ADD CONSTRAINT fk_cc_ts FOREIGN KEY (MaThiSinh) REFERENCES ThiSinh(MaThiSinh),
  ADD CONSTRAINT fk_cc_nv FOREIGN KEY (MaNV_CapNhat) REFERENCES NhanVien(MaNhanVien),
  ADD CONSTRAINT fk_cc_ct FOREIGN KEY (MaPhieuDK, ThuTu) REFERENCES ChiTietPhieuDK (MaPhieuDK, ThuTu);

-- =========================================
-- 4. Create triggers
-- =========================================

DELIMITER $$

-- 1. NhanVien → NV1, NV2, …
CREATE TRIGGER trg_NhanVien_ai
BEFORE INSERT ON NhanVien
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaNhanVien IS NULL OR NEW.MaNhanVien = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaNhanVien, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM NhanVien WHERE MaNhanVien LIKE 'NV%';
    SET NEW.MaNhanVien = CONCAT('NV', max_id + 1);
  END IF;
END$$

-- 2. ThongTinDangNhap → TTDN1, TTDN2, …
CREATE TRIGGER trg_ThongTinDangNhap_ai
BEFORE INSERT ON ThongTinDangNhap
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaThongTinDangNhap IS NULL OR NEW.MaThongTinDangNhap = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaThongTinDangNhap, 5) AS UNSIGNED)), 0)
      INTO max_id
      FROM ThongTinDangNhap WHERE MaThongTinDangNhap LIKE 'TTDN%';
    SET NEW.MaThongTinDangNhap = CONCAT('TTDN', max_id + 1);
  END IF;
END$$

-- 3. KhachHang → KH1, KH2, …
CREATE TRIGGER trg_KhachHang_ai
BEFORE INSERT ON KhachHang
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaKhachHang IS NULL OR NEW.MaKhachHang = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaKhachHang, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM KhachHang WHERE MaKhachHang LIKE 'KH%';
    SET NEW.MaKhachHang = CONCAT('KH', max_id + 1);
  END IF;
END$$

-- 4. DanhGia → DG1, DG2, …
CREATE TRIGGER trg_DanhGia_ai
BEFORE INSERT ON DanhGia
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaDanhGia IS NULL OR NEW.MaDanhGia = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaDanhGia, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM DanhGia WHERE MaDanhGia LIKE 'DG%';
    SET NEW.MaDanhGia = CONCAT('DG', max_id + 1);
  END IF;
END$$

-- 5. PhongThi → PT1, PT2, …
CREATE TRIGGER trg_PhongThi_ai
BEFORE INSERT ON PhongThi
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaPhongThi IS NULL OR NEW.MaPhongThi = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaPhongThi, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM PhongThi WHERE MaPhongThi LIKE 'PT%';
    SET NEW.MaPhongThi = CONCAT('PT', max_id + 1);
  END IF;
END$$

-- 6. LichThi → LT1, LT2, …
CREATE TRIGGER trg_LichThi_ai
BEFORE INSERT ON LichThi
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaLichThi IS NULL OR NEW.MaLichThi = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaLichThi, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM LichThi WHERE MaLichThi LIKE 'LT%';
    SET NEW.MaLichThi = CONCAT('LT', max_id + 1);
  END IF;
END$$

-- 7. ThiSinh → TS1, TS2, …
CREATE TRIGGER trg_ThiSinh_ai
BEFORE INSERT ON ThiSinh
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaThiSinh IS NULL OR NEW.MaThiSinh = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaThiSinh, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM ThiSinh WHERE MaThiSinh LIKE 'TS%';
    SET NEW.MaThiSinh = CONCAT('TS', max_id + 1);
  END IF;
END$$

-- 8. PhieuDK → PDK1, PDK2, …
CREATE TRIGGER trg_PhieuDK_ai
BEFORE INSERT ON PhieuDK
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaPhieuDK IS NULL OR NEW.MaPhieuDK = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaPhieuDK, 4) AS UNSIGNED)), 0)
      INTO max_id
      FROM PhieuDK WHERE MaPhieuDK LIKE 'PDK%';
    SET NEW.MaPhieuDK = CONCAT('PDK', max_id + 1);
  END IF;
END$$

-- 9. PhiGiaHan → PHG1, PHG2, …
CREATE TRIGGER trg_PhiGiaHan_ai
BEFORE INSERT ON PhiGiaHan
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaPhiGiaHan IS NULL OR NEW.MaPhiGiaHan = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaPhiGiaHan, 4) AS UNSIGNED)), 0)
      INTO max_id
      FROM PhiGiaHan WHERE MaPhiGiaHan LIKE 'PHG%';
    SET NEW.MaPhiGiaHan = CONCAT('PHG', max_id + 1);
  END IF;
END$$

-- 10. PhieuGiaHan → PGH1, PGH2, …
CREATE TRIGGER trg_PhieuGiaHan_ai
BEFORE INSERT ON PhieuGiaHan
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaPhieuGiaHan IS NULL OR NEW.MaPhieuGiaHan = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaPhieuGiaHan, 4) AS UNSIGNED)), 0)
      INTO max_id
      FROM PhieuGiaHan WHERE MaPhieuGiaHan LIKE 'PGH%';
    SET NEW.MaPhieuGiaHan = CONCAT('PGH', max_id + 1);
  END IF;
END$$

-- 11. UuDai → UD1, UD2, …
CREATE TRIGGER trg_UuDai_ai
BEFORE INSERT ON UuDai
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaUuDai IS NULL OR NEW.MaUuDai = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaUuDai, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM UuDai WHERE MaUuDai LIKE 'UD%';
    SET NEW.MaUuDai = CONCAT('UD', max_id + 1);
  END IF;
END$$

-- 12. HoaDon → HD1, HD2, …
CREATE TRIGGER trg_HoaDon_ai
BEFORE INSERT ON HoaDon
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaHoaDon IS NULL OR NEW.MaHoaDon = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaHoaDon, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM HoaDon WHERE MaHoaDon LIKE 'HD%';
    SET NEW.MaHoaDon = CONCAT('HD', max_id + 1);
  END IF;
END$$

-- 13. ChiTietHoaDon → CTHD1, CTHD2, …
CREATE TRIGGER trg_ChiTietHoaDon_ai
BEFORE INSERT ON ChiTietHoaDon
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaChiTietHoaDon IS NULL OR NEW.MaChiTietHoaDon = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaChiTietHoaDon, 5) AS UNSIGNED)), 0)
      INTO max_id
      FROM ChiTietHoaDon WHERE MaChiTietHoaDon LIKE 'CTHD%';
    SET NEW.MaChiTietHoaDon = CONCAT('CTHD', max_id + 1);
  END IF;
END$$

-- 14. ChungChi → CC1, CC2, …
CREATE TRIGGER trg_ChungChi_ai
BEFORE INSERT ON ChungChi
FOR EACH ROW
BEGIN
  DECLARE max_id INT DEFAULT 0;
  IF NEW.MaChungChi IS NULL OR NEW.MaChungChi = '' THEN
    SELECT COALESCE(MAX(CAST(SUBSTRING(MaChungChi, 3) AS UNSIGNED)), 0)
      INTO max_id
      FROM ChungChi WHERE MaChungChi LIKE 'CC%';
    SET NEW.MaChungChi = CONCAT('CC', max_id + 1);
  END IF;
END$$

-- 15. Kiểm tra MaThiSinh trong ChungChi
CREATE TRIGGER trg_ChungChi_bi
BEFORE INSERT ON ChungChi
FOR EACH ROW
BEGIN
  DECLARE thi_sinh_id VARCHAR(10);
  SELECT MaThiSinh INTO thi_sinh_id
  FROM ChiTietPhieuDK
  WHERE MaPhieuDK = NEW.MaPhieuDK AND ThuTu = NEW.ThuTu;
  IF thi_sinh_id IS NULL OR thi_sinh_id != NEW.MaThiSinh THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'MaThiSinh trong ChungChi không khớp với ChiTietPhieuDK';
  END IF;
END$$

DELIMITER ;

-- =========================================
-- 5. Thêm dữ liệu giả (INSERT mẫu)
-- =========================================

-- 1. NhanVien
INSERT INTO NhanVien (HoTen, VaiTro, TrangThai) VALUES
('Nguyễn Văn A', 'TiepNhan', 'DangLam'),
('Trần Thị B', 'KeToan', 'DangLam'),
('Lê Văn C', 'NhapLieu', 'DangLam');

-- 2. ThongTinDangNhap
INSERT INTO ThongTinDangNhap (TenDangNhap, MatKhauHash, MaNhanVien) VALUES
('nguyenvana', 'hash1', 'NV1'),
('tranthib', 'hash2', 'NV2'),
('levanc', 'hash3', 'NV3');

-- 3. KhachHang
INSERT INTO KhachHang (LoaiKhach, HoTen, TenDonVi, DiaChi, Email, DienThoai) VALUES
('TuDo', 'Phạm Văn D', NULL, '123 Lê Lợi, HCMC', 'phamvd@gmail.com', '0912345678'),
('DonVi', NULL, 'ABC Corp', '456 Nguyễn Trãi, HN', 'contact@abccorp.com', '02422334455'),
('TuDo', 'Hồ Thị E', NULL, '789 Trần Phú, ĐN', 'hote@gmail.com', '0888877665');

-- 4. DanhGia
INSERT INTO DanhGia (TenDanhGia, MoTa, DonGia) VALUES
('Toán', 'Thi thử Toán', 200000),
('Anh Văn', 'Thi thử Anh Văn', 250000),
('Tin học', 'Thi thử Tin học', 220000);

-- 5. PhongThi
INSERT INTO PhongThi (TenPhong, SucChua) VALUES
('Phòng A', 20),
('Phòng B', 25);

-- 6. LichThi
INSERT INTO LichThi (MaDanhGia, MaPhongThi, NgayThi, GioThi, SoLuongMax, TrangThai) VALUES
('DG1', 'PT1', '2025-05-10', '09:00:00', 20, 'MoDangKy'),
('DG2', 'PT2', '2025-05-11', '14:00:00', 25, 'MoDangKy');

-- 7. ThiSinh
INSERT INTO ThiSinh (HoTen, NgaySinh, GioiTinh) VALUES
('Trần Thị F', '2000-06-15', 'Nu'),
('Lê Văn G', '1998-12-01', 'Nam'),
('Nguyễn Thị H', '2001-03-20', 'Nu');

-- 8. PhieuDK
INSERT INTO PhieuDK (MaKhachHang, MaNV_TiepNhan, TrangThai) VALUES
('KH1', 'NV1', 'Moi'),
('KH2', 'NV2', 'ChoThanhToan');

-- 9. ChiTietPhieuDK
INSERT INTO ChiTietPhieuDK (MaPhieuDK, ThuTu, MaThiSinh, MaLichThi, SoBaoDanh, TrangThaiCT, Diem, KetQua, NgayCoKetQua, MaNV_NhapLieu) VALUES
('PDK1', 1, 'TS1', 'LT1', 'SBD2025001', 'DK', 8.5, 'Dat', '2025-04-15', 'NV3'),
('PDK1', 2, 'TS2', 'LT1', 'SBD2025002', 'DK', 6.0, 'KhongDat', '2025-04-15', 'NV3'),
('PDK2', 1, 'TS3', 'LT2', 'SBD2025003', 'Vang', NULL, NULL, NULL, NULL);

-- 10. PhiGiaHan
INSERT INTO PhiGiaHan (TenLoaiPhi, DonGia) VALUES
('Gia hạn 1 lần', 50000),
('Gia hạn 2 lần', 80000);

-- 11. PhieuGiaHan
INSERT INTO PhieuGiaHan (MaPhieuDK, ThuTu_CT, MaLichThi_Cu, MaLichThi_Moi, LyDo, MaNV_XuLy, TrangThai) VALUES
('PDK1', 1, 'LT1', 'LT2', 'Mượn thêm 1 lần', 'NV3', 'YeuCau'),
('PDK2', 1, 'LT2', 'LT1', 'Mượn thử', 'NV3', 'ChoThanhToan');

-- 12. UuDai
INSERT INTO UuDai (TenUuDai, Loai, GiaTri, DieuKien, NgayBD, NgayKT, TrangThai) VALUES
('Giảm 10%', 'TLPhanTram', 10, 'Cho KH TuDo', '2025-04-01', '2025-06-30', 'DangApDung');

-- 13. HoaDon
INSERT INTO HoaDon (MaPhieuDK, MaUuDai, MaNV_KeToan, PhuongThuc, TongTienGoc, SoTienGiam, TongThu, TrangThaiTT) VALUES
('PDK1', 'UD1', 'NV2', 'TienMat', 500000, 50000, 450000, 'ChuaTT'),
('PDK2', NULL, 'NV2', 'ChuyenKhoan', 250000, 0, 250000, 'DaTT');

-- 14. ChiTietHoaDon
INSERT INTO ChiTietHoaDon (MaHoaDon, MaDanhGia, SoLuong, DonGia, ThanhTien) VALUES
('HD1', 'DG1', 1, 200000, 200000);

INSERT INTO ChiTietHoaDon (MaHoaDon, MaPhiGiaHan, SoLuong, DonGia, ThanhTien) VALUES
('HD2', 'PHG1', 1, 50000, 50000);

-- 15. ChungChi
INSERT INTO ChungChi (SoHieu, MaPhieuDK, ThuTu, MaThiSinh, NgayCap, PhuongThucNhan, DiaChiNhan, NgayNhan, TrangThaiNhan, MaNV_CapNhat) VALUES
('CC20250001', 'PDK1', 1, 'TS1', '2025-04-20', 'TaiTT', '123 Lê Lợi', '2025-04-21', 'DaNhan', 'NV3');

-- =========================================
-- 6. Cập nhật dữ liệu mẫu (UPDATE mẫu)
-- =========================================

SET SQL_SAFE_UPDATES = 0;

-- 1. Khách tự do vừa đăng ký xong, chuyển trạng thái Phiếu ĐK sang 'ChoThanhToan'
UPDATE PhieuDK
SET TrangThai = 'ChoThanhToan'
WHERE MaPhieuDK = 'PDK1';

-- 2. Sau khi thêm 1 bản ghi ChiTietPhieuDK (thuTu mới) cho lịch LT1, tăng SoLuongDK lên 1
UPDATE LichThi
SET SoLuongDK = SoLuongDK + 1
WHERE MaLichThi = 'LT1';

-- 3. Khách đã thanh toán hoá đơn HD1, cập nhật trạng thái và thời điểm thanh toán
UPDATE HoaDon
SET TrangThaiTT = 'DaTT',
    NgayThanhToan = NOW()
WHERE MaHoaDon = 'HD1';

-- 4. Huỷ các Phiếu ĐK quá hạn thanh toán (>3 ngày từ NgayTao, vẫn ở 'ChoThanhToan')
UPDATE PhieuDK
SET TrangThai = 'Huy'
WHERE TrangThai = 'ChoThanhToan'
  AND NgayTao < DATE_SUB(NOW(), INTERVAL 3 DAY);

-- 5. Gia hạn miễn phí (trường hợp đặc biệt) PGH1 đã được duyệt, chuyển sang 'HoanTat'
UPDATE PhieuGiaHan
SET TrangThai = 'HoanTat'
WHERE MaPhieuGiaHan = 'PGH1';

-- 6. Tăng số lần gia hạn của PDK1 sau khi ghi nhận thành công
UPDATE PhieuDK
SET SoLanGiaHan = SoLanGiaHan + 1
WHERE MaPhieuDK = 'PDK1';

-- 7. Nhập kết quả thi: cập nhật điểm & kết quả cho ChiTietPhieuDK
UPDATE ChiTietPhieuDK
SET Diem = 9.0,
    KetQua = 'Dat'
WHERE MaPhieuDK = 'PDK1' AND ThuTu = 2;

-- 8. Khách nhận chứng chỉ CC1, cập nhật trạng thái và ngày nhận
UPDATE ChungChi
SET TrangThaiNhan = 'DaNhan',
    NgayNhan = CURDATE()
WHERE MaChungChi = 'CC1';

SET SQL_SAFE_UPDATES = 1;

