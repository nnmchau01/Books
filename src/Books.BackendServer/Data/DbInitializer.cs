using Books.BackendServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security;

namespace Books.BackendServer.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string AdminRoleName = "Admin";
        private readonly string UserRoleName = "Member";



        public DbInitializer(ApplicationDbContext context,
          UserManager<User> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task  Seed()
        {
            
            #region Quyền

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = AdminRoleName,
                    Name = AdminRoleName,
                    NormalizedName = AdminRoleName.ToUpper(),
                });
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = UserRoleName,
                    Name = UserRoleName,
                    NormalizedName = UserRoleName.ToUpper(),
                });
            }

            #endregion Quyền

            #region Người dùng

            if (!_userManager.Users.Any())
            {
                var result = await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    FirstName = "Quản trị",
                    LastName = "1",
                    Email = "nguyenchauvz0926@gmail.com",
                    LockoutEnabled = false
                }, "Admin@123");
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync("admin");
                    await _userManager.AddToRoleAsync(user, AdminRoleName);
                }
            }

            #endregion Người dùng

            #region Author
            if (!_context.Authors.Any())
            {
                _context.Authors.AddRange(new List<Author>
                {
                    new Author {Name = "Steve Harvey", Female = false, Born = 1957  },
                    new Author {Name = "James Allen", Female = false, Born = 1864, Died = 1912  },
                    new Author {Name = "Robin Norwood", Female = true, Born = 1945  },
                    new Author {Name = "Ramit Sethi", Female = false, Born = 1982  },
                    new Author {Name = "Melody Beattie", Female = true, Born = 1948  },
                    new Author {Name = "Dale Carnegie", Female = false, Born = 1888, Died = 1955  },
                    new Author {Name = "Wayne Dyer", Female = false, Born = 1940  },
                    new Author {Name = "John T. Molloy", Female = false, Born = 1937  },
                    new Author {Name = "Allen Carr", Female = false, Born = 1934, Died = 2006  },
                    new Author {Name = "Robert Greene", Female = false, Born = 1959  },
                    new Author {Name = "Wendy Kaminer", Female = true, Born = 1949  },
                    new Author {Name = "David Schwartz", Female = false, Born = 1927, Died = 1987  },
                    new Author {Name = "Robin Sharma", Female = false, Born = 1964  },
                    new Author {Name = "Norman Vincent Peale", Female = false, Born = 1898, Died = 1993  },
                    new Author {Name = "Maxwell Maltz", Female = false, Born = 1899, Died = 1975  },
                    new Author {Name = "Rhonda Byrne", Female = true, Born = 1951  },
                    new Author {Name = "Stephen Covey", Female = false, Born = 1932, Died = 2012},
                    new Author {Name = "Napoleon Hill", Female = false, Born = 1883, Died = 1970  },
                    new Author {Name = "Anthony Robbins", Female = false, Born = 1960  },
                    new Author {Name = "Louise Hay", Female = true, Born = 1926, Died = 2017  },
                    new Author {Name = "Charles F. Haanel", Female = false, Born = 1866, Died = 1949  },
                    new Author {Name = "Eckhart Tolle", Female = false, Born = 1948  },
                    new Author {Name = "Diane Muldrow", Female = true, Born = 1950  },
                    new Author {Name = "David Gillespie", Female = false, Born = 1957  },
                    new Author {Name = "Burra Venkatesham", Female = false, Born = 1968  },
                    new Author {Name = "Dr. Walter Doyle Staples", Female = false, Born = 1955  },
                    new Author {Name = "Wahiduddin Khan", Female = false, Born = 1925, Died = 2021 },
                    new Author {Name = "Paulo Coelho", Female = false, Born = 1947  }                    

                });
                await _context.SaveChangesAsync();
            }
            #endregion Author

            #region Book
            if (!_context.Books.Any())
            {
                _context.Books.AddRange(new List<Book>
                {
                    new Book { Title = "Act like a Lady, Think like a Man", Topic = "relationship", PublishYear = 2009 , AuthorId = 1 ,Price = 20.00M , Rating = 1 },
                    new Book { Title = "As a Man Thinketh", Topic = "positive thinking", PublishYear = 1902 , AuthorId = 2 , Price = 50.00M , Rating = 2 },
                    new Book { Title = "Women Who Love Too Much", Topic = "relationship", PublishYear = 1985 , AuthorId = 3 , Price = 15.40M , Rating = 3 },
                    new Book { Title = "I Will Teach You To Be Rich", Topic = "success", PublishYear = 2009 , AuthorId = 4 , Price = 20.00M , Rating = 4 },
                    new Book { Title = "Codependent No More", Topic = "relationship", PublishYear = 1986 , AuthorId = 5, Price = 32.00M , Rating = 2 },
                    new Book { Title = "How to Stop Worrying and Start Living", Topic = "optimism", PublishYear = 1948 , AuthorId = 6 , Price = 50.00M , Rating = 4 },
                    new Book { Title = "Your Erroneous Zones", Topic = "health", PublishYear = 1976 , AuthorId = 7 , Price = 24.00M , Rating = 5 },
                    new Book { Title = "Dress for Success", Topic = "success", PublishYear = 1975, AuthorId = 8 , Price = 54.20M , Rating = 3 },
                    new Book { Title = "The Easy Way to Stop Smoking", Topic = "health", PublishYear = 2006 , AuthorId = 9 , Price = 45.60M , Rating = 2 },
                    new Book { Title = "How to Win Friends and Influence People", Topic = "success", PublishYear = 1936 , AuthorId = 6 , Price = 10.20M , Rating = 4 },
                    new Book { Title = "The 48 Laws of Power", Topic = "success", PublishYear = 1998 , AuthorId = 10 , Price = 100.00M , Rating = 2 },
                    new Book { Title = "I'm Dysfunctional, You're Dysfunctional", Topic = "anti-self-help", PublishYear = 1992 , AuthorId = 11 , Price = 39.55M , Rating = 3 },
                    new Book { Title = "The Magic of Thinking Big", Topic = "success", PublishYear = 1959 , AuthorId = 12 , Price = 12.34M , Rating = 5 },
                    new Book { Title = "The Monk Who Sold His Ferrari", Topic = "health", PublishYear = 1997 , AuthorId = 13 , Price = 104.50M , Rating = 3 },
                    new Book { Title = "The Power of Positive Thinking", Topic = "optimism", PublishYear = 1952 , AuthorId = 14 , Price = 20.50M , Rating = 5 },

                    new Book { Title = "Psycho-Cybernetics", Topic = "self image", PublishYear = 1960 , AuthorId = 15 , Price = 50.30M , Rating = 2 },
                    new Book { Title = "The Secret", Topic = "optimism", PublishYear = 2006 , AuthorId =16 , Price = 25.50M , Rating = 4 },
                    new Book { Title = "The Seven Habits of Highly Effective People", Topic = "success", PublishYear = 1989 , AuthorId = 17 , Price = 50.30M , Rating = 1 },
                    new Book { Title = "Think and Grow Rich", Topic = "success", PublishYear = 1937 , AuthorId = 18 , Price = 25.50M , Rating = 5 },
                    new Book { Title = "Unlimited Power", Topic = "success", PublishYear = 1986 , AuthorId = 19 , Price = 20.50M , Rating = 5 },
                    new Book { Title = "You Can Heal Your Life", Topic = "health", PublishYear = 1984 , AuthorId = 20 , Price = 100.00M , Rating = 4 },
                    new Book { Title = "The Master Key System", Topic = "optimism", PublishYear = 1916 , AuthorId = 21 , Price = 69.60M , Rating = 1 },
                    new Book { Title = "The Power of Now", Topic = "optimism", PublishYear = 1997 , AuthorId = 22 , Price = 45.56M , Rating = 4 },
                    new Book { Title = "The Magic Ladder To Success", Topic = "", PublishYear = 1930 , AuthorId = 18 , Price = 100.05M , Rating = 5 },
                    new Book { Title = "Outwitting the Devil", Topic = "success", PublishYear = 2011 , AuthorId = 18 , Price = 32.45M , Rating = 3 },
                    new Book { Title = "Selfie Of Success", Topic = "success", PublishYear = 2019 , AuthorId = 25 , Price = 20.60M , Rating = 4 },
                    new Book { Title = "Think Like a Winner!", Topic = "optimism", PublishYear = 1991 , AuthorId = 26 , Price = 20.50M , Rating = 3 },
                    new Book { Title = "Raaz-e-Hayat\to", Topic = "optimism", PublishYear = 1987 , AuthorId = 27 , Price = 14.30M , Rating = 5 },

                });
                await _context.SaveChangesAsync();
            }
            #endregion Book
            await _context.SaveChangesAsync();
        }
    }
}
