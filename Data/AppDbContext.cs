using EtecShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EtecShop.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Populando os dados da Gestão de Usuários
        List<IdentityRole> roles = new()
{
new IdentityRole(){
Id = Guid.NewGuid().ToString(),
Name = "Administrador",
NormalizedName = "ADMINISTRADOR"
},
new IdentityRole()
{
Id = Guid.NewGuid().ToString(),
Name = "Funcionário",
NormalizedName = "FUNCIONÁRIO"
},
new IdentityRole()
{
Id = Guid.NewGuid().ToString(),
Name = "Cliente",
NormalizedName = "CLIENTE"
}
};
        builder.Entity<IdentityRole>().HasData(roles);
        IdentityUser user = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = "admin@etecshop.com",
            NormalizedEmail = "ADMIN@ETECSHOP.COM",
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            LockoutEnabled = true,
            EmailConfirmed = true,
        };
        PasswordHasher<IdentityUser> pass = new();
        user.PasswordHash = pass.HashPassword(user, "@Etec123");
        builder.Entity<IdentityUser>().HasData(user);
        List<IdentityUserRole<string>> userRoles = new()
{
new IdentityUserRole<string>() {
UserId = user.Id,
RoleId = roles[0].Id
},
new IdentityUserRole<string>() {
UserId = user.Id,
RoleId = roles[1].Id
},
new IdentityUserRole<string>() {
UserId = user.Id,
RoleId = roles[2].Id
}};
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular Categorias
        List<Categoria> categorias = new(){
            new Categoria() {
            Id = 1,
            Nome = "Livros e papelaria"
            },
            new Categoria() {
            Id = 2,
            Nome = "Games e PC Gamer"
            },
            new Categoria() {
            Id = 3,
            Nome = "Informática"
            },
            new Categoria() {
            Id = 4,
            Nome = "Smartphones"
            },
            new Categoria() {
            Id = 5,
            Nome = "Eletrodomesticos e Casa"
            },
            new Categoria() {
            Id = 6,
            Nome = "Beleza e Perfumaria"
            },
            new Categoria() {
            Id = 7,
            Nome = "Móveis e Decoração"
            }
};
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region Popular Produtos
        List<Produto> produtos = new()
{
new Produto(){
        Id = 1,
        Nome = "Livro - A Biblioteca Da Meia-Noite - 8° Ed.",
        Descricao = "A Biblioteca da Meia-Noite é um romance incrível que fala dos infinitos rumos que a vida pode tomar e da busca incessante pelo rumo certo. Aos 35 anos, Nora Seed é uma mulher cheia de talentos e poucas conquistas.",
        Preco = 34.99M,
        Estoque = 10,
        CategoriaId = 1,
        Foto = "/img/produtos/1.png"
},
new Produto(){
        Id = 2,
        Nome = "Box Trilogia Sombra E Ossos - 1ª Ed.",
        Descricao = "Entre no Grishaverso: visite, em Ravka, um mundo de magia e superstição, onde nem tudo é o que parece ser! Os três livros da aclamada Trilogia Sombra e ossos - que originou a série da Netflix -, agora reunidos em um box especial",
        Preco = 144.54M,
        Estoque = 23,
        CategoriaId = 1,
        Foto = "/img/produtos/2.png"
},
new Produto(){
        Id = 3,
        Nome = "Console Playstation 5 + God Of War Ragnarok",
        Descricao = "Play Has No Limits™ Jogar Não Tem Limites PlayStation®5. O console PS5™ oferece novas possibilidades de jogabilidade que você nunca imaginou. Reproduza jogos para PS5 e PS4 em Blu-ray Disc. Além disso, você também pode baixar jogos ...",
        Preco = 3699.99M,
        Estoque = 6,
        CategoriaId = 2,
        Foto = "/img/produtos/3.png"
},
new Produto(){
        Id = 4,
        Nome = "Cadeira Gamer Fortt Lípsia Vermelha - Cgf002-V",
        Descricao = "Cadeira Gamer Fortt Lípsia Vermelha - CGF002-V Seja para trabalhar, estudar ou para seu lazer, a cadeira tornou-se um item essencial para o dia a dia. Agora ela não só é mais um item de decoração da casa ou de uso esporádico" ,
        Preco = 221.11M,
        Estoque = 30,
        CategoriaId = 2,
        Foto = "/img/produtos/4.png"
},
new Produto(){
        Id = 5,
        Nome = "Notebook 2 Em 1 Positivo Duo C4128b-3",
        Descricao = "Notebook 2 Em 1 Positivo Duo C4128b-3 Intel Celeron Dual Core Windows11 Home 11,6' - Cinza Escuro - Inclui Microsoft 365* Notebook 2 em 1 Positivo Duo C4128B-3 Intel Celeron Dual Core Windows11 Home 11,6' - Cinza Escuro",
        Preco = 1439.10M,
        Estoque = 17,
        CategoriaId = 3,
        Foto = "/img/produtos/5.png"
},
new Produto(){
        Id = 6,
        Nome = "Conjunto Mesa De Jantar 6 Lugares Milano Amêndoa Com Savana",
        Descricao = "Conjunto Mesa De Jantar 6 Lugares Milano Amêndoa Com Savana Conjunto com 6 Cadeiras Milano Conjunto com 6 Cadeiras Milano da Poliman Moveis: nossos modelos de cadeiras sao praticos e resistentes",
        Preco = 521.10M,
        Estoque = 4,
        CategoriaId = 7,
        Foto = "/img/produtos/6.png"
},
new Produto()
    {
        Id = 7,
        Nome = "Smartphone Motorola Moto G04 4g 128gb Tela 6.6' 4gb Ram Câmera 16mp Selfie 5mp - Grafite",
        Descricao = "O novo Moto G04 foi projetado para impressionar com cores vibrantes, material superior e detalhes lindos.Beleza em alto nível!Feito com material de padrão elevado, é fino e confortável ao toque.",
        Preco = 699M,
        Estoque = 40,
        CategoriaId = 4,
        Foto = "/img/produtos/7.png"
},
new Produto()
    {
        Id = 8,
        Nome = "Cervejeira Consul Mais 82 Litros Frost Free Czd12at Titanium - 220v",
        Descricao = "Com uma Cervejeira Consul Mais você não precisa mais sepreocupar se suas cervejas vão congelar ou se elas não vão ficar geladas na hora que opessoal chegar.Você pode mudar a configuração das prateleiras da sua Cervejeira",
        Preco = 2166.03M,
        Estoque = 4,
        CategoriaId = 5,
        Foto = "/img/produtos/8.png"
}
};
builder.Entity<Produto>().HasData(produtos);
#endregion 
    }
}