namespace ZombieParty.Services
{
    public interface IServiceBaseAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);         //Retourne T où T est une entity  
        Task DeleteAsync(int id);              // Pas valeur de retour, supprime l’entité selon le id
        Task<IReadOnlyList<T>> GetAllAsync();  // Retourne une liste d’entités en lecture seule
        Task<T?> GetByIdAsync(int id);         // Peut retourner null si l’entité est introuvable
        Task EditAsync(T entity);              // Pas valeur de retour, édite l’entité.
    }

}
