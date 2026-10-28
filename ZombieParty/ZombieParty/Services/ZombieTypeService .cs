using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Services
{
    public class ZombieTypeService: ServiceBaseAsync<ZombieType>, IZombieTypeService
    {
        /* Ici, on passe le dbContext au constructeur de la classe parente ServiceBaseAsync avec base. C’est nécessaire, parce que la classe ZombieTypeService hérite de ServiceBaseAsync qui a une le context en paramètre. */
        public ZombieTypeService(ZombiePartyDbContext dbContext) : base(dbContext) { }

    }
}
