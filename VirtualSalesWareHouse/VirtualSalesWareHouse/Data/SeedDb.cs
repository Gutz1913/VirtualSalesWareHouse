using VirtualSalesWareHouse.Data.Entities;
using VirtualSalesWareHouse.Enums;
using VirtualSalesWareHouse.Helpers;

namespace VirtualSalesWareHouse.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUserHelper _userHelper;
    public SeedDb(DataContext context, IUserHelper userHelper)
    {
        _context = context;
        _userHelper = userHelper;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync(); //Ensure the database is created and applies any pending migrations
        await CheckCategoriesAsync();
        await CheckCountriesAsync();
        await CheckRolesAsync();
        await CheckUserAsync("1010", "Andrés", "Gutiérrez", "gutz@yopmail.com", "300 131 04 24", "Calle Luna Calle Sol", UserType.Admin);
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
            user = new User
            {
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
        }
        return user;
    }
}
