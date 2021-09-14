using ISO3166API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.DBUtilities
{
    public static class dbInitialializer
    {
        public static void Initialize(ISO3166DbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Countries.Any()) return;


            var countriesList = new Country[]
            {
                new Country { Alpha2Code = "AR", Alpha3Code = "ARG", NumericCode = 032, CountryName = "Argentina", Independent = true, ShortName = "Argentina", 
                    States = new List<State>() { new State { Code = "B", SubdivisionName = "Buenos aires", SubdivisionCategory ="Province" } ,
                             new State { Code = "E", SubdivisionName = "Entre Rios", SubdivisionCategory ="Province" } 
                    } 
                },
                
                new Country { Alpha2Code = "BO", Alpha3Code = "BOL", NumericCode = 068, CountryName = "Estado plurinacional de Bolivia", Independent = true, ShortName = "Bolivia",
                    States = new List<State>() { new State { Code = "C", SubdivisionName = "Cochabamba", SubdivisionCategory ="department" } ,
                             new State { Code = "L", SubdivisionName = "La Paz", SubdivisionCategory ="department" }
                    }
                },


                new Country { Alpha2Code = "BR", Alpha3Code = "BRA", NumericCode = 076, CountryName = "Brazil", Independent = true, ShortName = "Brazil" ,
                 States = new List<State>() { new State { Code = "RJ", SubdivisionName = "Rio de Janeiro", SubdivisionCategory ="State" } ,
                             new State { Code = "SP", SubdivisionName = "Sao Paulo", SubdivisionCategory ="State" }
                    }
                },

                
                new Country { Alpha2Code = "BG", Alpha3Code = "BGR", NumericCode = 100, CountryName = "Bulgaria", Independent = true, ShortName = "Bulgaria",
                 States = new List<State>() { new State { Code = "01", SubdivisionName = "Blagoevgrad", SubdivisionCategory ="Province" } ,
                             new State { Code = "11", SubdivisionName = "Lovech", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "CL", Alpha3Code = "CHL", NumericCode = 152, CountryName = "Republica de Chile", Independent = true, ShortName = "Chile",
                 States = new List<State>() { new State { Code = "VS", SubdivisionName = "Valparaíso", SubdivisionCategory ="Province" } ,
                             new State { Code = "AN", SubdivisionName = "Antofagasta", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "CO", Alpha3Code = "COL", NumericCode = 170, CountryName = "Colombia", Independent = true, ShortName = "Colombia",
                 States = new List<State>() { new State { Code = "LAG", SubdivisionName = "La Guajira", SubdivisionCategory ="department" } ,
                             new State { Code = "ANT", SubdivisionName = "Antioquia", SubdivisionCategory ="department" }
                    }
                },


                new Country { Alpha2Code = "CR", Alpha3Code = "CRI", NumericCode = 188, CountryName = "Costa Rica", Independent = true, ShortName = "Costa Rica",
                 States = new List<State>() { new State { Code = "C", SubdivisionName = "Cartago", SubdivisionCategory ="Province" } ,
                             new State { Code = "SJ", SubdivisionName = "San Jose", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "CU", Alpha3Code = "CUB", NumericCode = 192, CountryName = "Cuba", Independent = true, ShortName = "Cuba" ,
                 States = new List<State>() { new State { Code = "03", SubdivisionName = "La Habana", SubdivisionCategory ="Province" } ,
                             new State { Code = "13", SubdivisionName = "Santiago de Cuba", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "EC", Alpha3Code = "ECU", NumericCode = 218, CountryName = "Ecuador", Independent = true, ShortName = "Ecuador",
                 States = new List<State>() { new State { Code = "W", SubdivisionName = "Galapagos", SubdivisionCategory ="Province" } ,
                             new State { Code = "S", SubdivisionName = "Morona Santiago", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "SV", Alpha3Code = "SLV", NumericCode = 192, CountryName = "El Salvador", Independent = true, ShortName = "Salvador",
                 States = new List<State>() { new State { Code = "UN", SubdivisionName = "La union", SubdivisionCategory ="Province" } ,
                             new State { Code = "MO", SubdivisionName = "Morazan", SubdivisionCategory ="Province" }
                    }
                },


                new Country { Alpha2Code = "FR", Alpha3Code = "FRA", NumericCode = 250, CountryName = "France", Independent = true, ShortName = "France",
                 States = new List<State>() { new State { Code = "75", SubdivisionName = "Paris", SubdivisionCategory ="department" } ,
                             new State { Code = "33", SubdivisionName = "Gironde", SubdivisionCategory ="department" }
                    }
                },


                new Country { Alpha2Code = "GH", Alpha3Code = "GER", NumericCode = 276, CountryName = "Alemania", Independent = true, ShortName = "Germany",
                 States = new List<State>() { new State { Code = "BE", SubdivisionName = "Berlin", SubdivisionCategory ="Province" } ,
                             new State { Code = "HH", SubdivisionName = "Hamburg", SubdivisionCategory ="Province" }
                    }
                }



            };

            dbContext.AddRange(countriesList);
            dbContext.SaveChanges();
        }
    }
}
