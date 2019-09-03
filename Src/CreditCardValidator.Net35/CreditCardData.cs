﻿using System.Collections.Generic;

namespace CreditCardValidator
{
    /// <summary>
    ///     Issuing institutes accepted.
    /// </summary>
    public enum CardIssuer
    {
        AmericanExpress,
        ChinaUnionPay,
        Dankort,
        DinersClub,
        Discover,
        Hipercard,
        JCB,
        Laser,
        Maestro,
        MasterCard,
        RuPay,
        Solo,
        Switch,
        Visa,
        Unknown,
        Elo
    }

    internal static class CreditCardData
    {
        public static IDictionary<CardIssuer, BrandInfo> BrandsData;

        /// <summary>
        ///     A static constructor is used to initialize any static data, or to perform a particular
        ///     action that needs to be performed once only. It is called automatically before the
        ///     first instance is created or any static members are referenced.
        /// </summary>
        static CreditCardData()
        {
            BrandsData = new Dictionary<CardIssuer, BrandInfo>();
            LoadData();
        }

        private static void LoadData()
        {
            BrandsData.Add(CardIssuer.Visa, new BrandInfo
            {
                BrandName = "Visa",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {13, 16, 19},
                        Prefixes = new List<string> {"4"}
                    }
                }
            });


            var masterCard = new BrandInfo();
            masterCard.BrandName = "MasterCard";
            masterCard.Rules = new List<Rule>();

            var masterCardRule1 = new Rule();
            masterCardRule1.Lengths = new List<int> { 16 };
            masterCardRule1.Prefixes = new List<string>();
            masterCardRule1.Prefixes.AddRange(GenerateRange(51, 55));
            masterCardRule1.Prefixes.AddRange(GenerateRange(2221, 2720));

            masterCard.Rules.Add(masterCardRule1);

            BrandsData.Add(CardIssuer.MasterCard, masterCard);

            BrandsData.Add(CardIssuer.AmericanExpress, new BrandInfo
            {
                BrandName = "American Express",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {15},
                        Prefixes = new List<string> {"34", "37"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.DinersClub, new BrandInfo
            {
                BrandName = "Diners Club",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {14, 16},
                        Prefixes = new List<string> { "300", "301", "302", "303", "304", "305", "3095", "36", "38" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Discover, new BrandInfo
            {
                BrandName = "Discover",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16},
                        Prefixes = new List<string> {"6011", "644", "645", "646", "647", "648", "649", "65"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.JCB, new BrandInfo
            {
                BrandName = "JCB",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {15, 16},
                        Prefixes = new List<string> {"3528", "3529", "353", "354", "355", "356", "357", "358"}
                    },
                    new Rule
                    {
                        Lengths = new List<int> {15},
                        Prefixes = new List<string> {"1800", "2131"}
                    },
                    new Rule
                    {
                        Lengths = new List<int> {19},
                        Prefixes = new List<string> {"357266"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.Laser, new BrandInfo
            {
                BrandName = "Laser",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16, 17, 18, 19},
                        Prefixes = new List<string> {"6304"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.Solo, new BrandInfo
            {
                BrandName = "Solo",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16, 18, 19},
                        Prefixes = new List<string> {"6334", "6767"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.Switch, new BrandInfo
            {
                BrandName = "Switch",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16, 18, 19},
                        Prefixes = new List<string> {"633110", "633312", "633304", "633303", "633301", "633300"}
                    }
                }
            });


            var maestro = new BrandInfo();
            maestro.BrandName = "Maestro";
            maestro.Rules = new List<Rule>();

            var maestroRule1 = new Rule();
            maestroRule1.Lengths = new List<int> { 12, 13, 14, 15, 16, 17, 18, 19 };
            maestroRule1.Prefixes = new List<string>();
            maestroRule1.Prefixes.AddRange(GenerateRange(56, 58));
            maestroRule1.Prefixes.AddRange(GenerateRange(500, 500));
            maestroRule1.Prefixes.AddRange(GenerateRange(502, 509));
            maestroRule1.Prefixes.AddRange(GenerateRange(602, 605));
            maestroRule1.Prefixes.AddRange(GenerateRange(670, 679));
            maestroRule1.Prefixes.AddRange(GenerateRange(5010, 5018));
            maestroRule1.Prefixes.AddRange(GenerateRange(6000, 6060));
            maestroRule1.Prefixes.AddRange(GenerateRange(6760, 6769));

            maestro.Rules.Add(maestroRule1);

            BrandsData.Add(CardIssuer.Maestro, maestro);

            BrandsData.Add(CardIssuer.ChinaUnionPay, new BrandInfo
            {
                BrandName = "China UnionPay",
                SkipLuhn = true,
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16, 17, 18, 19},
                        Prefixes = new List<string> {"62"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.Dankort, new BrandInfo
            {
                BrandName = "Dankort",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16},
                        Prefixes = new List<string> {"5019"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.RuPay, new BrandInfo
            {
                BrandName = "RuPay",
                SkipLuhn = true,
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {16},
                        Prefixes = new List<string>
                        {
                            "6061",
                            "6062",
                            "6063",
                            "6064",
                            "6065",
                            "6066",
                            "6067",
                            "6068",
                            "6069",
                            "607",
                            "608"
                        }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Hipercard, new BrandInfo
            {
                BrandName = "Hipercard",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {19},
                        Prefixes = new List<string> {"384"}
                    }
                }
            });

            BrandsData.Add(CardIssuer.Unknown, new BrandInfo
            {
                BrandName = "Unknown",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Lengths = new List<int> {15},
                        Prefixes = new List<string>()
                    }
                }
            });

          BrandsData.Add(CardIssuer.Elo, new BrandInfo()
          {
            BrandName = "Elo",
            Rules = new List<Rule>()
            {
              new Rule()
              {
                Lengths = new List<int>() { 16 },
                Prefixes = new List<string>() { "4011", "438935", "451416", "4576", "504175", "506699", "5067", "50904", "509040", "509042", "509043", "509045", "509046", "509047", "509048", "509049", "509050", "509051", "509052", "509064", "509066", "509067", "509068", "509069", "509074", "636297", "636368" }
              }
            }
          });

      /*BrandsData.Add(CardIssuer., new BrandInfo()
      {
          BrandName = "",
          Rules = new List<Rule>() 
          { 
              new Rule() 
              { 
                  Lengths = new List<int>() {  }, 
                  Prefixes = new List<string>() {  }
              }
          }
      });*/
    }

        /// <summary>
        /// Includes start and end values in the result.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static List<string> GenerateRange(int start, int end)
        {
            List<string> ret = new List<string>();
            for(int i = start; i <= end; i++)
            {
                ret.Add(i.ToString());
            }
            return ret;
        }
    }
}