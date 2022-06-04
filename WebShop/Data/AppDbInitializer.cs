using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.CPU.Any())
                {
                    context.CPU.AddRange(new List<CPU>(){
                        new CPU()
                        {
                            Name="AMD FX-4300 BOX",
                            Price=2700,
                            Power_usage=140,
                            Description="4 x 4 ГГц, L2 - 4 МБ, L3 - 4 МБ, 2хDDR3",
                            CPU_Type=CPU_Type.AM3,
                            RAM_Type=RAM_Type.DDR3
                        },
                        new CPU()
                        {
                            Name="AMD Ryzen 3 1200 BOX",
                            Price=8000,
                            Power_usage=120,
                            Description="4 x 3.1 ГГц, L2 - 2 МБ, L3 - 8 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="AMD Ryzen 5 2600 BOX",
                            Price=14000,
                            Power_usage=123,
                            Description="6 x 3.4 ГГц, L2 - 3 МБ, L3 - 16 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="AMD Ryzen 5 4500 BOX",
                            Price=21000,
                            Power_usage=143,
                            Description="6 x 3.6 ГГц, L2 - 3 МБ, L3 - 8 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="AMD Ryzen 9 5950X BOX",
                            Price=59000,
                            Power_usage=110,
                            Description="16 x 3.4 ГГц, L2 - 8 МБ, L3 - 64 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="Intel Celeron G5905 BOX",
                            Price=5200,
                            Power_usage=140,
                            Description="2 x 3.5 ГГц, L2 - 0.5 МБ, L3 - 4 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.LGA1200,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="Intel Core i3-10100F BOX",
                            Price=9100,
                            Power_usage=120,
                            Description="4 x 3.6 ГГц, L2 - 1 МБ, L3 - 6 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.LGA1200,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="Intel Core i5-9400F BOX",
                            Price=12000,
                            Power_usage=130,
                            Description=" 6 x 2.9 ГГц, L2 - 1.5 МБ, L3 - 9 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.LGA1151,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="Intel Core i5-11600KF BOX",
                            Price=20000,
                            Power_usage=110,
                            Description="6 x 3.9 ГГц, L2 - 3 МБ, L3 - 12 МБ, 2хDDR4",
                            CPU_Type=CPU_Type.LGA1200,
                            RAM_Type=RAM_Type.DDR4
                        },
                        new CPU()
                        {
                            Name="Intel Core i9-12900F BOX",
                            Price=50000,
                            Power_usage=150,
                            Description="8 x 2.4 ГГц, L2 - 14 МБ, L3 - 30 МБ, DDR5",
                            CPU_Type=CPU_Type.LGA1700,
                            RAM_Type=RAM_Type.DDR5
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.GPU.Any())
                {
                    context.GPU.AddRange(new List<GPU>()
                    {
                        new GPU()
                        {
                            Name="MSI AMD Radeon RX 550 AERO ITX OC",
                            Price=12000,
                            Power_usage=400,
                            Description="PCI-E 3.0, 4 ГБ GDDR5, 128 бит, 1102 МГц - 1203 МГц, HDMI, DisplayPort, DVI-D"
                        },
                        new GPU()
                        {
                            Name="MSI AMD Radeon RX 6500 XT MECH 2X OC",
                            Price=28000,
                            Power_usage=400,
                            Description="PCI-E 4.0, 4 ГБ GDDR6, 64 бит, 2610 МГц - 2825 МГц, DisplayPort, HDMI"
                        },
                        new GPU()
                        {
                            Name="Palit GeForce GTX 1660 SUPER Gaming Pro",
                            Price=40000,
                            Power_usage=450,
                            Description="PCI-E 3.0, 6 ГБ GDDR6, 192 бит, 1530 МГц - 1785 МГц, DVI-D, DisplayPort, HDMI"
                        },
                        new GPU()
                        {
                            Name="GIGABYTE GeForce RTX 3050 EAGLE",
                            Price=48000,
                            Power_usage=450,
                            Description="PCI-E 4.0, 8 ГБ GDDR6, 128 бит, 1552 МГц - 1777 МГц, DisplayPort x2, HDMI x2"
                        },
                        new GPU()
                        {
                            Name="KFA2 GeForce RTX 3080 SG",
                            Price=132000,
                            Power_usage=750,
                            Description="PCI-E 4.0, 12 ГБ GDDR6X, 384 бит, 1260 МГц - 1755 МГц, DisplayPort x3, HDMI"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Motherboard.Any())
                {
                    context.Motherboard.AddRange(new List<Motherboard>(){ 
                        new Motherboard()
                        {
                            Name="GIGABYTE B450M S2H V2",
                            Price=4000,
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4,
                            Description="AMD B450, 2xDDR4-2667 МГц, 1xPCI-Ex16, 1xM.2, Micro-ATX"
                        },
                        new Motherboard()
                        {
                            Name="ASRock B450 STEEL LEGEND",
                            Price=7200,
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4,
                            Description="AMD B450, 4xDDR4-3200 МГц, 2xPCI-Ex16, 2xM.2, Standard-ATX"
                        },
                        new Motherboard()
                        {
                            Name="ASUS Pro H410T/CSM",
                            Price=10400,
                            CPU_Type=CPU_Type.LGA1200,
                            RAM_Type=RAM_Type.DDR4,
                            Description="Intel H410, 2xDDR4-2933 МГц, 1xM.2, Mini-ITX"
                        },
                        new Motherboard()
                        {
                            Name="GIGABYTE B550 GAMING X V2",
                            Price=12000,
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4,
                            Description="AMD B550, 4xDDR4-3200 МГц, 2xPCI-Ex16, 2xM.2, Standard-ATX"
                        },
                        new Motherboard()
                        {
                            Name="GIGABYTE B550 VISION D-P",
                            Price=20000,
                            CPU_Type=CPU_Type.AM4,
                            RAM_Type=RAM_Type.DDR4,
                            Description="AMD B550, 4xDDR4-3200 МГц, 3xPCI-Ex16, 2xM.2, Standard-ATX"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.RAM.Any())
                {
                    context.RAM.AddRange(new List<RAM>()
                    {
                        new RAM()
                        {
                            Name="Kingston HyperX FURY Black",
                            Price=4000,
                            Description="4 ГБx2 шт, 2666 МГц, 16-18-18-29",
                            RAM_Type=RAM_Type.DDR4
                        },
                        new RAM()
                        {
                            Name="AMD Radeon R5 Entertainment Series",
                            Price=5000,
                            Description="8 ГБx2 шт, 1600 МГц, 11-11-11-28",
                            RAM_Type=RAM_Type.DDR3
                        },
                        new RAM()
                        {
                            Name="G.Skill RIPJAWS V",
                            Price=6500,
                            Description="8 ГБx2 шт, 3600 МГц, 18-22-22-42",
                            RAM_Type=RAM_Type.DDR4
                        },
                        new RAM()
                        {
                            Name="Kingston FURY Renegade",
                            Price=10000,
                            Description="8 ГБx2 шт, 4000 МГц, 19-23-23",
                            RAM_Type=RAM_Type.DDR4
                        },
                        new RAM()
                        {
                            Name="A-Data XPG Caster RGB",
                            Price=27000,
                            Description="16 ГБx2 шт, 6000 МГц, 40-40-40",
                            RAM_Type=RAM_Type.DDR5
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.PowerSupply.Any())
                {
                    context.PowerSupply.AddRange(new List<PowerSupply>(){
                        new PowerSupply()
                        {
                            Name="Chieftec ELEMENT",
                            Price=3500,
                            Power_output=400,
                            Description="APFC, 20 + 4 pin, 4 pin CPU, 3 SATA, 6+2 pin PCI-E"
                        },
                        new PowerSupply()
                        {
                            Name="ZALMAN GigaMax (GVII)",
                            Price=3800,
                            Power_output=550,
                            Description="80+ Bronze, EPS12V, APFC, 20 + 4 pin, 4+4 pin CPU, 5 SATA, 6+2 pin x2 PCI-E"
                        },
                        new PowerSupply()
                        {
                            Name="Thermaltake TR2 S",
                            Price=4600,
                            Power_output=650,
                            Description="80+, EPS12V, APFC, 20 + 4 pin, 4+4 pin CPU, 5 SATA, 6+2 pin x2 PCI-E"
                        },
                        new PowerSupply()
                        {
                            Name="Chieftec POLARIS 550W",
                            Price=7100,
                            Power_output=550,
                            Description="80+ Gold, EPS12V, APFC, 20 + 4 pin, 4+4 pin x2 CPU, 6 SATA, 6+2 pin x2 PCI-E"
                        },
                        new PowerSupply()
                        {
                            Name="be quiet! STRAIGHT POWER 11",
                            Price=26000,
                            Power_output=1200,
                            Description="80+ Platinum, EPS12V, APFC, 20 + 4 pin, 4+4 pin, 8 pin CPU, 11 SATA, 6+2 pin x6 PCI-E"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.RAM_Motherboard.Any())
                {
                    List<RAM_Motherboard> rAM_Motherboards = new List<RAM_Motherboard>();
                    List<Motherboard> motherb = new List<Motherboard>();
                    foreach (var mother in context.Motherboard)
                        motherb.Add(mother);
                    foreach (var mother in motherb) {
                        foreach (var ram in context.RAM.Where(x => x.RAM_Type == mother.RAM_Type))
                        {
                            rAM_Motherboards.Add(new RAM_Motherboard()
                            {
                                Motherboard_Id = mother.Id,
                                RAM_Id = ram.Id
                            });
                        }
                    }
                    context.RAM_Motherboard.AddRange(rAM_Motherboards);
                    context.SaveChanges();
                }
                if (!context.CPU_Motherboard.Any())
                {
                    List<CPU_Motherboard> cPU_Motherboards = new List<CPU_Motherboard>();
                    List<Motherboard> motherb = new List<Motherboard>();
                    foreach (var mother in context.Motherboard)
                        motherb.Add(mother);
                    foreach (var mother in motherb)
                        foreach (var cpu in context.CPU.Where(x => x.CPU_Type == mother.CPU_Type))
                        {
                            cPU_Motherboards.Add(new CPU_Motherboard()
                            {
                                Motherboard_Id = mother.Id,
                                CPU_Id = cpu.Id
                            });
                        }
                    context.CPU_Motherboard.AddRange(cPU_Motherboards);
                    context.SaveChanges();
                }
                if (!context.CPU_RAM.Any())
                {
                    List<CPU_RAM> cPU_RAMs = new List<CPU_RAM>();
                    List<CPU> cpus = new List<CPU>();
                    foreach (var cpu in context.CPU)
                        cpus.Add(cpu);
                    foreach (var cpu in cpus)
                        foreach (var ram in context.RAM.Where(x => x.RAM_Type == cpu.RAM_Type))
                        {
                            cPU_RAMs.Add(new CPU_RAM()
                            {
                                CPU_Id = cpu.Id,
                                RAM_Id = ram.Id
                            });
                        }
                    context.CPU_RAM.AddRange(cPU_RAMs);
                    context.SaveChanges();
                }
            }
        }
    }
}
