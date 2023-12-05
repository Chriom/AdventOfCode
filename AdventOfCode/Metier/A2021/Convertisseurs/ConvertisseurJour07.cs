using AdventOfCode.Interfaces;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour07 : IConvertisseurEntree<int>
    {
        public IEnumerable<int> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.First()
                           .Split(',')
                           .Select(o => int.Parse(o));
        }
    }
}
