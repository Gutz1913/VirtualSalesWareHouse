using VirtualSalesWareHouse.Data.Entities;
using VirtualSalesWareHouse.Enums;
using VirtualSalesWareHouse.Helpers;
using Microsoft.EntityFrameworkCore;

namespace VirtualSalesWareHouse.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUserHelper _userHelper;
    private readonly IBlobHelper _blobHelper;

    public SeedDb(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper)
    {
        _context = context;
        _userHelper = userHelper;
        _blobHelper = blobHelper;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync(); //Ensure the database is created and applies any pending migrations
        await CheckCategoriesAsync();
        await CheckCountriesAsync();
        await CheckRolesAsync();
        await CheckUserAsync("avatar10.png", "1010", "Andrés", "Gutiérrez", "gutz@yopmail.com", "300 131 04 24", "Calle Luna Calle Sol", UserType.Admin);
        await CheckUserAsync("avatar6.png", "2020", "Carlos", "Londoño", "carlos@yopmail.com", "320 423 34 14", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar3.png", "3030", "Mercedes", "Colorado", "mercedes@yopmail.com", "312 342 43 54", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar1.png", "4040", "Sebastián", "Valencia", "sebas@yopmail.com", "315 647 57 24", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar7.png", "5050", "Oscar", "Valencia", "oscar@yopmail.com", "378 527 42 88", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar8.png", "6060", "Matías", "Velasquez", "matias@yopmail.com", "314 532 64 29", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar5.png", "7070", "Emiliano", "Gutiérrez", "matias@yopmail.com", "350 214 33 56", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar9.png", "8080", "Fabiola", "Colorado", "fabiola@yopmail.com", "313 580 14 44", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar2.png", "9090", "Randy", "Acosta", "randy@yopmail.com", "320 234 76 89", "Calle Luna Calle Sol", UserType.User);
        await CheckUserAsync("avatar4.png", "1111", "Firulais", "Acosta", "randy@yopmail.com", "320 234 76 89", "Calle Luna Calle Sol", UserType.User);
        await CheckProductsAsync();
    }

    private async Task CheckProductsAsync()
    {
        if (!_context.Products.Any())
        {
            await AddProductAsync("Mouse Gamer", 132000M, 12F, new List<string>() { "Gamer", "Tecnología", "Video Juegos" }, new List<string>() { "mouse1.png", "mouse2.png", "mouse3.png", "mouse4.png" });
            await AddProductAsync("Silla Gamer", 450000M, 18F, new List<string>() { "Gamer", "Video Juegos" }, new List<string>() { "Silla1.png", "Silla2.png", "Silla3.png", "Silla4.png" });
            await AddProductAsync("Tenis Adidas", 350000M, 18F, new List<string>() { "Deportes", "Calzado" }, new List<string>() { "Tenis1.png", "Tenis2.png" });
            await AddProductAsync("Iphone 17 Pro Max", 8000000M, 25F, new List<string>() { "Tecnología", "Apple" }, new List<string>() { "Iphone1.png", "Iphone2.png", "Iphone3.png", "Iphone4.png" });
            await AddProductAsync("Conjunto Adidas Anime", 650000M, 2F, new List<string>() { "Deportes", "Moda Para Hombres", "Moda Para Mujeres", "Moda Para Niños", "Moda Para Niñas" }, new List<string>() { "Prenda1.png" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task AddProductAsync(string name, decimal price, float stock, List<string> categories, List<string> images)
    {
        Product prodcut = new()
        {
            Description = name,
            Name = name,
            Price = price,
            Stock = stock,
            ProductCategories = new List<ProductCategory>(),
            ProductImages = new List<ProductImage>()
        };

        foreach (string? category in categories)
        {
            prodcut.ProductCategories.Add(new ProductCategory { Category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category) });
        }


        foreach (string? image in images)
        {
            Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\products\\{image}", "products");
            prodcut.ProductImages.Add(new ProductImage { ImageId = imageId });
        }

        _context.Products.Add(prodcut);
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Arte" });
            _context.Categories.Add(new Category { Name = "Artesanías" });
            _context.Categories.Add(new Category { Name = "Automotriz" });
            _context.Categories.Add(new Category { Name = "Bebés" });
            _context.Categories.Add(new Category { Name = "Belleza" });
            _context.Categories.Add(new Category { Name = "Cuidado Personal" });
            _context.Categories.Add(new Category { Name = "Cine y TV" });
            _context.Categories.Add(new Category { Name = "Tecnología" });
            _context.Categories.Add(new Category { Name = "Deportes" });
            _context.Categories.Add(new Category { Name = "Actividades Al Aire Libre" });
            _context.Categories.Add(new Category { Name = "Electrónicos" });
            _context.Categories.Add(new Category { Name = "Electrodomésticos" });
            _context.Categories.Add(new Category { Name = "Equipaje" });
            _context.Categories.Add(new Category { Name = "Accesorios Para El Hogar" });
            _context.Categories.Add(new Category { Name = "Construcción" });
            _context.Categories.Add(new Category { Name = "Herramientas" });
            _context.Categories.Add(new Category { Name = "Alimentos" });
            _context.Categories.Add(new Category { Name = "Cocina" });
            _context.Categories.Add(new Category { Name = "Industria" });
            _context.Categories.Add(new Category { Name = "Ciencia" });
            _context.Categories.Add(new Category { Name = "Mascotas" });
            _context.Categories.Add(new Category { Name = "Juguetería" });
            _context.Categories.Add(new Category { Name = "Librería" });
            _context.Categories.Add(new Category { Name = "Moda Para Hombres" });
            _context.Categories.Add(new Category { Name = "Moda Para Mujeres" });
            _context.Categories.Add(new Category { Name = "Moda Para Niños" });
            _context.Categories.Add(new Category { Name = "Moda Para Niñas" });
            _context.Categories.Add(new Category { Name = "Música" });
            _context.Categories.Add(new Category { Name = "Ofertas" });
            _context.Categories.Add(new Category { Name = "Prime Video" });
            _context.Categories.Add(new Category { Name = "Salud" });
            _context.Categories.Add(new Category { Name = "Software" });
            _context.Categories.Add(new Category { Name = "Video Juegos" });
            _context.Categories.Add(new Category { Name = "Gamer" });
            _context.Categories.Add(new Category { Name = "Apple" });
            _context.Categories.Add(new Category { Name = "Calzado" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country
            {
                Name = "Colombia",
                States = new List<State>()
                {
                    new State 
                    { 
                        Name = "Antioquia",
                        Cities = new List<City>()
                        {
                            new City { Name = "Medellín" },
                            new City { Name = "Envigado" },
                            new City { Name = "Itagüi" },
                            new City { Name = "Bello" },
                            new City { Name = "Rionegro" },
                        }
                    },
                    new State 
                    {
                        Name = "Bogotá",
                        Cities = new List<City>()
                        {
                            new City { Name = "Usaquen" },
                            new City { Name = "Chapinero" },
                            new City { Name = "Santa Fe" },
                            new City { Name = "Usme" },
                            new City { Name = "Bosa" },
                        }
                    },
                }
            });
            _context.Countries.Add(new Country
            {
                Name = "Estados Unidos",
                States = new List<State>()
                {
                    new State 
                    {
                        Name = "Florida",
                        Cities = new List<City>()
                        {
                            new City { Name = "Orlando" },
                            new City { Name = "Miami" },
                            new City { Name = "Tampa" },
                            new City { Name = "Fort Lauderdale" },
                            new City { Name = "Key West" },
                        }
                    },
                    new State 
                    {
                        Name = "Texas",
                        Cities = new List<City>()
                        {
                            new City { Name = "Houston" },
                            new City { Name = "San Antonio" },
                            new City { Name = "Dallas" },
                            new City { Name = "Austin" },
                            new City { Name = "El paso" },
                        }
                    },
                }
            });            
        }
        await _context.SaveChangesAsync();
    }

    private async Task CheckRolesAsync()
    {
        await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
        await _userHelper.CheckRoleAsync(UserType.User.ToString());
    }

    private async Task<User> CheckUserAsync(
        string image,
        string document, 
        string firstName, 
        string lastName, 
        string email, 
        string phone, 
        string address,
        
        UserType userType)
    {
        User user = await _userHelper.GetUserAsync(email);
        if (user == null)
        {
            Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\Images\\users\\{image}", "users");
            user = new User
            {
                ImageId = imageId,
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = address,
                City = _context.Cities.FirstOrDefault(),
                UserType = userType
            };

            await _userHelper.AddUserAsync(user, "123456");
            await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
            await _userHelper.ConfirmEmailAsync(user, token);
        }
        return user;
    }
}
