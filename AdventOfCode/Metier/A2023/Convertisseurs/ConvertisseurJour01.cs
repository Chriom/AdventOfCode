﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour01;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour01 : IConvertisseurEntree<Instruction>
    {
        IEnumerable<Instruction> IConvertisseurEntree<Instruction>.ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return new Instruction(lEntree);
            }            
        }
    }
}
