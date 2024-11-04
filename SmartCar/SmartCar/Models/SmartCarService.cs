using Newtonsoft.Json;
using System.Text;
using SmartCar.Services;

namespace SmartCar.Models
{
    public class SmartCarService
    {
        public static SmarterCar? GetSmartCarByTag(string tag)
        {
            return new List<SmarterCar>
            {
                new SmarterCar
                {
                    Tag = "A1",
                    Name = "Audi A1",
                    Price = 27000,
                    Spec = new Specs
                    {
                        Engine = "1.0L 3-cylinder TFSI",
                        Acceleration = "0-100 km/h in 9.5 seconds",
                        Transmission = "6-speed manual",
                    }
                },
                new SmarterCar
                {
                    Tag = "A3",
                    Name = "Audi A3",
                    Price = 39000,
                    Spec = new Specs
                    {
                        Engine = "2.0L turbocharged 4-cylinder",
                        Acceleration = "0-100 km/h in 6.8 seconds",
                        Transmission = "7-speed S tronic dual-clutch",
                    }
                },
                new SmarterCar
                {
                    Tag = "A4",
                    Name = "Audi A4",
                    Price = 44000,
                    Spec = new Specs
                    {
                        Engine = "2.0L TFSI with 261 hp",
                        Acceleration = "0-100 km/h in 5.8 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "A5",
                    Name = "Audi A5",
                    Price = 48000,
                    Spec = new Specs
                    {
                        Engine = "2.0L TFSI with 261 hp",
                        Acceleration = "0-100 km/h in 5.6 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "A6",
                    Name = "Audi A6",
                    Price = 60000,
                    Spec = new Specs
                    {
                        Engine = "3.0L V6 turbocharged",
                        Acceleration = "0-100 km/h in 5.1 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "A6-etron",
                    Name = "Audi A6 e-tron",
                    Price = 72500,
                    Spec = new Specs
                    {
                        Engine = "Dual-motor setup, approx. 470 hp",
                        Acceleration = "0-100 km/h in 4.0 seconds",
                        Transmission = "Single-speed automatic (electric)",
                    }
                },
                new SmarterCar
                {
                    Tag = "A7",
                    Name = "Audi A7",
                    Price = 76500,
                    Spec = new Specs
                    {
                        Engine = "3.0L V6 TFSI with 335 hp",
                        Acceleration = "0-100 km/h in 5.3 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },  
                new SmarterCar
                {
                    Tag = "A8",
                    Name = "Audi A8",
                    Price = 90000,
                    Spec = new Specs
                    {
                        Engine = "4.0L twin-turbo V8",
                        Acceleration = "0-100 km/h in 4.5 seconds",
                        Transmission = "8-speed Tiptronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "e-tronGT",
                    Name = "Audi e-tron GT",
                    Price = 116500,
                    Spec = new Specs
                    {
                        Engine = "Dual-motor setup with up to 522 hp",
                        Acceleration = "0-100 km/h in 3.9 seconds",
                        Transmission = "Single-speed automatic (electric)",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q2",
                    Name = "Audi Q2",
                    Price = 32000,
                    Spec = new Specs
                    {
                        Engine = "1.5L TFSI with 150 hp",
                        Acceleration = "0-100 km/h in 8.6 seconds",
                        Transmission = "6-speed manual",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q3",
                    Name = "Audi Q3",
                    Price = 40000,
                    Spec = new Specs
                    {
                        Engine = "2.0L TFSI with 228 hp",
                        Acceleration = "0-100 km/h in 6.3 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q4-etron",
                    Name = "Audi Q4 e-tron",
                    Price = 53000,
                    Spec = new Specs
                    {
                        Engine = "Dual-motor setup with 295 hp",
                        Acceleration = "0-100 km/h in 6.2 seconds",
                        Transmission = "Single-speed automatic (electric)",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q5",
                    Name = "Audi Q5",
                    Price = 51000,
                    Spec = new Specs
                    {
                        Engine = "2.0L turbocharged 4-cylinder",
                        Acceleration = "0-100 km/h in 6.1 seconds",
                        Transmission = "7-speed S tronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q6-etron",
                    Name = "Audi Q6 e-tron",
                    Price = 65000,
                    Spec = new Specs
                    {
                        Engine = "Dual-motor setup with 375 hp",
                        Acceleration = "0-100 km/h in approx. 4.5 seconds",
                        Transmission = "Single-speed automatic (electric)",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q7",
                    Name = "Audi Q7",
                    Price = 62500,
                    Spec = new Specs
                    {
                        Engine = "3.0L V6 turbocharged",
                        Acceleration = "0-100 km/h in 5.7 seconds",
                        Transmission = "8-speed Tiptronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q8",
                    Name = "Audi Q8",
                    Price = 78000,
                    Spec = new Specs
                    {
                        Engine = "3.0L V6 TFSI with 335 hp",
                        Acceleration = "0-100 km/h in 5.9 seconds",
                        Transmission = "8-speed Tiptronic",
                    }
                },
                new SmarterCar
                {
                    Tag = "Q8-etron",
                    Name = "Audi Q8 e-tron",
                    Price = 75000,
                    Spec = new Specs
                    {
                        Engine = "Dual-motor setup with up to 402 hp",
                        Acceleration = "0-100 km/h in 5.1 seconds",
                        Transmission = "Single-speed automatic (electric)",
                    }
                }

            }.FirstOrDefault(smartcar => smartcar.Tag == tag);
        }

        public static SmarterCarDTO MapToDto(SmarterCar entry)
        {
            return new SmarterCarDTO
            {
                Tag = entry.Tag,
                OldPrice = entry.OldPrice,
                NewPrice = entry.NewPrice,
                Photo = "testtest"
            };
        }


        public static async Task AddNewCar(SmarterCarDTO smartercar)
        {
            await APIService<SmarterCarDTO>.PostAsync("Car/", smartercar);
        }
        public static async Task InsertDamageIntoApi(DamageEntry damageEntry)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(damageEntry);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("Request Content: " + json); // Log the JSON to see if it matches the API's requirements

                var response = await client.PostAsync("http://localhost:5285/api/Damages/", content);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Request failed with status code {response.StatusCode}: {responseContent}");
                }

            }
        }

    }
}
