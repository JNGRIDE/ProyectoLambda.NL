using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLambda.Data.Context;

public static class Seeding
{
    public static async Task AddSeeding(this IServiceCollection services)
    {
        string destino = Path.Combine(FileSystem.AppDataDirectory, "app.db");

        if (!File.Exists(destino))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("app.db");
            using var dest = File.Create(destino);
            await stream.CopyToAsync(dest);
        }

        using var scope = services.BuildServiceProvider().CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();
    }
}