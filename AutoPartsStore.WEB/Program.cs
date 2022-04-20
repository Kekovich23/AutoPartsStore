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

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<Role>()
        .AddEntityFrameworkStores<ApplicationContext>();
    builder.Services.AddControllersWithViews();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<BrandService>();
    builder.Services.AddScoped<ModelService>();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<SectionService>();
    builder.Services.AddScoped<TypeTransportService>();
    builder.Services.AddScoped<TypeDetailService>();
    builder.Services.AddScoped<FeatureService>();

    builder.Services.AddScoped(provider => new MapperConfiguration(cfg => {
        cfg.AddProfile(new UserProfile(provider.GetService<UserManager<User>>()));
        cfg.AddProfile(new BrandProfile());
        cfg.AddProfile(new TypeTransportProfile());
        cfg.AddProfile(new ModelProfile());
        cfg.AddProfile(new SectionProfile());
        cfg.AddProfile(new TypeDetailProfile());
        cfg.AddProfile(new FeatureProfile());
    }).CreateMapper());    

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