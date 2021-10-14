using CatFactAzFunc.Interfaces;

namespace CatFactAzFunc.Services
{
    public class CatFactService : ICatFactService
    {
        public CatFactService()
        {
            // do init stuff
        }
        public string GetFact()
        {
            return "Cats are better than dogs.";
        }
    }
}