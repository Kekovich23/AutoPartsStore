using AutoMapper;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.DAL.Configure;
using AutoPartsStore.DAL.Context;
using AutoPartsStore.DAL.Interfaces;
using AutoPartsStore.DAL.Repositories;
using AutoPartsStore.WEB.AutoMapperProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try {
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    //builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    //    .AddEntityFrameworkStores<ApplicationContext>();

    builder.Services.AddIdentity<User, Role>(opts => {
        opts.Password.RequiredLength = 5;   // ����������� �����
        opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
        opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
        opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
        opts.Password.RequireDigit = false; // ��������� �� �����
    })
        .AddEntityFrameworkStores<ApplicationContext>();

    builder.Services.AddRazorPages();


    //builder.Services.ConfigureApplicationCookie(options => {
    //    // Cookie settings
    //    options.Cookie.HttpOnly = true;
    //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    //    options.LoginPath = "/Identity/Account/Login";
    //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    //    options.SlidingExpiration = true;
    //});
    //builder.Services.AddDefaultIdentity<User>()
    //            .AddRoles<Role>()
    //            .AddEntityFrameworkStores<ApplicationContext>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddAutoMapper(typeof(BrandProfile), typeof(UserProfile));
    builder.Services.AddScoped<BrandService>();
    builder.Services.AddScoped<ModelService>();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<TypeTransportService>();
    builder.Services.AddScoped(provider => new MapperConfiguration(cfg => {
        cfg.AddProfile(new UserProfile(provider.GetService<UserManager<User>>()));
    }).CreateMapper());



    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    using (var scope = app.Services.CreateScope()) {
        var services = scope.ServiceProvider;
        var userManager = services.GetRequiredService<UserManager<User>>();
        var rolesManager = services.GetRequiredService<RoleManager<Role>>();
        await RoleInitializer.InitializeAsync(userManager, rolesManager);
    }


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseMigrationsEndPoint();
    }
    else {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.Run();
}
catch (Exception exception) {
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally {
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}