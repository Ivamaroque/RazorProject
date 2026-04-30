using Microsoft.EntityFrameworkCore;
using RazorProject.Api.Models;

namespace RazorProject.Api.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        if (await context.Categorias.AnyAsync())
        {
            return;
        }

        context.Categorias.AddRange(
            new Categoria { Nome = "Suporte Tecnico" },
            new Categoria { Nome = "Acesso a Sistemas" },
            new Categoria { Nome = "Impressoras" },
            new Categoria { Nome = "Solicitacao de Material" },
            new Categoria { Nome = "Infraestrutura" }
        );

        await context.SaveChangesAsync();
    }
}
