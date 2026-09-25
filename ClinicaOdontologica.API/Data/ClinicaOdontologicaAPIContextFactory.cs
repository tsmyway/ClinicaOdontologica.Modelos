using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ClinicaOdontologica.API.Data;

public class ClinicaOdontologicaAPIContextFactory : IDesignTimeDbContextFactory<ClinicaOdontologicaAPIContext>
{
    public ClinicaOdontologicaAPIContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ClinicaOdontologicaAPIContext>();
        
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=clinicaodontologicabdd;Username=postgres");

        return new ClinicaOdontologicaAPIContext(optionsBuilder.Options);
    }
}