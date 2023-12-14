using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Helpers
{
    public static class EnumHelper
    {
        public static T DonneValeurDepuisDescription<T>(string pDescription) where T : Enum
        {
            foreach (FieldInfo lChamp in typeof(T).GetFields())
            {
                DescriptionAttribute lAttribute = (DescriptionAttribute)lChamp.GetCustomAttribute(typeof(DescriptionAttribute), true);

                if (lAttribute != null)
                {
                    if (lAttribute.Description == pDescription)
                    {
                        return (T)lChamp.GetValue(null);
                    }

                    if (lChamp.Name == pDescription)
                    {
                        return (T)lChamp.GetValue(null);
                    }
                }
            }

            throw new Exception($"Le type {typeof(T)} ne contient pas de champ {pDescription}");
        }

        public static string DonneDescription<T>(this T pEnum) where T : Enum
        {
            FieldInfo lChamps = typeof(T).GetField(pEnum.ToString());

            DescriptionAttribute lDescription = (DescriptionAttribute)lChamps.GetCustomAttribute(typeof(DescriptionAttribute), true);

            if(lDescription != null)
            {
                return lDescription.Description;
            }

            return pEnum.ToString();
        }
    }
}
