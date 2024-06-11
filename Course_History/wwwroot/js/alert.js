
    document.getElementById("sua").addEventListener("submit", function(event) {
        // Hỏi người dùng xác nhận trước khi submit form
        if (!confirm("Bạn có chắc chắn muốn sửa phiếu giảm giá này?")) {
        event.preventDefault();
        }
    });

document.getElementById("addToCart").addEventListener("click", function (event) {
    // Hỏi người dùng xác nhận trước khi submit form
    if (!confirm("Bạn có thêm vào giỏ hàng?")) {
        event.preventDefault();
    }
});
