using Bierbrouwerij.Application.DTO.Bier;
using Bierbrouwerij.Application.DTO.Ingredient;
using Bierbrouwerij.Application.Service;
using Bierbrouwerij.Domain.Entities;
using Bierbrouwerij.Domain.Interfaces;

namespace Bierbrouwerij.Tests
{
    public class FakeBierRepository : IBierRepository
    {
        public Task<List<Bier>> GetAllAsync() => Task.FromResult(new List<Bier>());
        public Task<Bier?> GetByIdAsync(int id) => Task.FromResult<Bier?>(null);
        public Task<Bier?> GetByIdWithIngredientenAsync(int id) => Task.FromResult<Bier?>(null);
        public Task AddAsync(Bier entity) => Task.CompletedTask;
    }



    public class BierbrouwerijTests
    {
        private readonly BierService _bierService;


        public BierbrouwerijTests()
        {
            _bierService = new BierService(new FakeBierRepository());

        }

        [Fact]
        public async Task CreateBier_GeldigAlcoholpercentage_GooidGeenException()
        {
            var dto = new CreateBierDto { Naam = "Testbier", Beschrijving = "Test", Alcoholpercentage = 5.0 };
            var exception = await Record.ExceptionAsync(() => _bierService.CreateAsync(dto));
            Assert.Null(exception);
        }

        [Fact]
        public async Task CreateBier_AlcoholpercentageOnder0_GooidArgumentException()
        {
            var dto = new CreateBierDto { Naam = "Testbier", Beschrijving = "Test", Alcoholpercentage = -1 };
            await Assert.ThrowsAsync<ArgumentException>(() => _bierService.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateBier_AlcoholpercentageBoven100_GooidArgumentException()
        {
            var dto = new CreateBierDto { Naam = "Testbier", Beschrijving = "Test", Alcoholpercentage = 101 };
            await Assert.ThrowsAsync<ArgumentException>(() => _bierService.CreateAsync(dto));
        }
    }
}