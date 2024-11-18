using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour19;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour19
    {
        private Regex _RegexFlux = new Regex(@"(?<Element>[a-z])(?<Comparaison>[<>])(?<Nombre>[0-9]{1,}):(?<Destination>[A-z]{1,})");
        private Regex _RegexElement = new Regex(@"{x=(?<x>[0-9]{1,}),m=(?<m>[0-9]{1,}),a=(?<a>[0-9]{1,}),s=(?<s>[0-9]{1,})}");

        public IEnumerable<DonneesDeTravail> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<FluxDeTravail> lFluxTravail = new List<FluxDeTravail>();
            List<Element> lElements = new List<Element>();


            bool lPause = false;
            foreach(string lEntree in pEntrees)
            {
                if (string.IsNullOrEmpty(lEntree))
                {
                    lPause = true;
                }
                else if (lPause == false)
                {
                    //Flux

                    string[] lEntreeSplit = lEntree.Replace("}", string.Empty).Split("{", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    FluxDeTravail lFlux = new FluxDeTravail()
                    {
                        NomFlux = lEntreeSplit[0],
                    };

                    foreach (string lInstructionTexte in lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    {
                        if (_RegexFlux.IsMatch(lInstructionTexte))
                        {
                            Match lMatches = _RegexFlux.Match(lInstructionTexte);

                            Instruction lInstruction = new Instruction();



                            lInstruction.PartieElementTest = lMatches.Groups["Element"].Value[0];
                            lInstruction.SensComparaison = lMatches.Groups["Comparaison"].Value switch
                            {
                                ">" => Instruction.Comparaison.Superieur,
                                "<" => Instruction.Comparaison.Inferieur,
                                _ => throw new NotImplementedException(),
                            };

                            lInstruction.NombreComparaison = int.Parse(lMatches.Groups["Nombre"].Value);
                            lInstruction.NomFluxSiReussi = lMatches.Groups["Destination"].Value;

                            lFlux.Instructions.Add(lInstruction);
                        }
                        else
                        {
                            lFlux.Instructions.Add(new Instruction()
                            {
                                NomFluxSiReussi = lInstructionTexte,
                                SensComparaison = Instruction.Comparaison.Aucune,
                            });
                        }

                        
                    }
                    lFluxTravail.Add(lFlux);
                }
                else
                {
                    //Element
                    Match lMatches = _RegexElement.Match(lEntree);

                    lElements.Add(new Element()
                    {
                        ExtremementBeauARegarder = int.Parse(lMatches.Groups["x"].Value),
                        Musical = int.Parse(lMatches.Groups["m"].Value),
                        Aerodynamique = int.Parse(lMatches.Groups["a"].Value),
                        Brillant = int.Parse(lMatches.Groups["s"].Value),
                    });
                }
            }


            yield return new DonneesDeTravail(lFluxTravail, lElements);
        }
    }
}
