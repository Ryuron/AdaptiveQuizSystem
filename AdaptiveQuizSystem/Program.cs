using AdaptiveQuizSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình kết nối DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Đăng ký dịch vụ Session kèm cấu hình
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 👈 Cho timeout cụ thể
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 3. Đăng ký IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// 4. Thêm MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 5. Middleware xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // ⚠️ Bạn có thể thêm dòng này nếu muốn hỗ trợ HTTPS tốt hơn
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 6. Kích hoạt Session
app.UseSession();

app.UseAuthorization();

// 7. Định tuyến
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
