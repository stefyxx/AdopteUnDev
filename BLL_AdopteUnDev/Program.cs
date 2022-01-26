﻿using DAL_AdopteUnDev.DTO;
using System;
using System.Text.Json;

namespace BLL_AdopteUnDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new Developer
            {
                idDev = 4,
                DevName = "Dame",
                DevFirstName = "Eboshi",
                DevBirthDate = new DateTime(1945 - 02 - 02),
                DevPicture = "Eboshi.jpg",
                DevHourCost = 25,
                DevDayCost = 250,
                DevMonthCost = 1800,
                DevMail = "dame.Eboshi@ghibli.jp",
                DevCategPrincipal = "4",
            };
            Console.WriteLine(JsonSerializer.Serialize(dev));
        }
    }
}
