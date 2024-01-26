using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Services;

namespace WebApplication1
{

	public class Startup
	{

		public Startup(IConfiguration configuration) =>
			Configuration = configuration;

		public IConfiguration? Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddHttpClient();
			services.AddControllers();
			services.AddTransient<ProductService>();
			services.AddTransient<UserService>();
			services.AddTransient<LoginService>();
			services.AddControllers();
            services.AddAuthentication("Cookies").AddCookie(options =>
            {
	            options.LoginPath = "/Login";
                options.Cookie.Name = "PetrosLotusShop";
				options.Cookie.MaxAge = TimeSpan.MaxValue;
                // Additional configuration options such as ExpireTime, LoginPath, AccessDeniedPath, etc.
            });
            services.AddDbContext<LutosContext>(options =>
	            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddAuthorization();
            //google login
            //services
            //    .AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //    })
            //    .AddCookie()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "**CLIENT ID**";
            //        options.ClientSecret = "**CLIENT SECRET**";
            //    });

        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapControllers();
                app.UseHttpsRedirection();
                app.UseAuthentication();
                //app.Run(async (context) =>
                //{
                //    if (context.User.Identity is { IsAuthenticated: false })
                //    {
                //        await context.ChallengeAsync();
                //    }

                //    if (context.User.Identity != null)
                //        await context.Response.WriteAsync("Hello " + context.User.Identity.Name + "!\r");
                //});
            });
		}
	}
}

