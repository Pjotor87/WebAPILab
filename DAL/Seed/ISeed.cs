using System.Collections.Generic;

namespace DAL.Seed
{
    public interface ISeed<T>
    {
        List<T> GetSeed();
    }
}
