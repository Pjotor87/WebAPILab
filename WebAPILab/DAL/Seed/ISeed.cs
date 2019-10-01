using System.Collections.Generic;

namespace WebAPILab.DAL.Seed
{
    public interface ISeed<T>
    {
        List<T> GetSeed();
    }
}
