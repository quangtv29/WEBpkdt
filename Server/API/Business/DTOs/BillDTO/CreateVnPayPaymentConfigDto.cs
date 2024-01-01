namespace API.Business.DTOs.BillDTO
{
    public class VnPayPaymentConfig
    {
        public CreateVnPayPaymentConfigDto Create { get; set; }
        public string ApiUrl { get; set; }
    }
    public class CreateVnPayPaymentConfigDto
    {
        public string Version { get; set; } //	Phiên bản api mà merchant kết nối. Phiên bản hiện tại là : 2.1.0
        public string Command { get; set; } //Mã API sử dụng, mã cho giao dịch thanh toán là: pay
        public string Amount { get; set; } //Số tiền thanh toán.  merchant cần nhân thêm 100 lần 
        public string TmnCode { get; set; } //Mã website của merchant trên hệ thống của VNPAY. Ví dụ: 2QXUI4J4
        public string BankCode { get; set; } //Mã phương thức thanh toán, mã loại ngân hàng hoặc ví điện tử thanh toán.
        //        Các mã loại hình thức thanh toán lựa chọn tại website-ứng dụng của merchant
        //vnp_BankCode=VNPAYQRThanh toán quét mã QR
        //vnp_BankCode = VNBANKThẻ ATM - Tài khoản ngân hàng nội địa
        //vnp_BankCode=INTCARDThẻ thanh toán quốc tế
        public string CreateDate { get; set; } //Là thời gian phát sinh giao dịch định dạng yyyyMMddHHmmss 
        public string CurrCode { get; set; } //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
        public string IpAddr { get; set; } //Địa chỉ IP của khách hàng thực hiện giao dịch. Ví dụ: 13.160.92.202
        public string Locale { get; set; } //Ngôn ngữ giao diện hiển thị. Hiện tại hỗ trợ Tiếng Việt (vn), Tiếng Anh (en)
        public string OrderInfo { get; set; } //Tiếng Việt không dấu và không bao gồm các ký tự đặc biệt
        public string OrderType { get; set; } //Mã danh mục hàng hóa.
        public string ReturnUrl { get; set; } //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
        public string ExpireDate { get; set; } //Thời gian hết hạn thanh toán GMT+7, định dạng: yyyyMMddHHmmss
        public string TxnRef { get; set; } //Mã tham chiếu của giao dịch tại hệ thống của merchant.
        public string SecureHash { get; set; } //Mã kiểm tra (checksum) để đảm bảo dữ liệu của giao dịch không bị thay đổi trong quá trình chuyển từ merchant sang VNPAY. Việc tạo ra mã này phụ thuộc vào cấu hình của merchant và phiên bản api sử dụng. Phiên bản hiện tại hỗ trợ SHA256, HMACSHA512.
        public string HashSecret { get; set; } // Chuỗi bí mật
    }
}
