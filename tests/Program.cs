﻿using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.DAO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Text.Json;
using AdopteUnDev_Common.IRepositories;
using BLL_AdopteUnDev01.Repository;
using BLL_AdopteUnDev01.Models;
using BLL_AdopteUnDev01.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Client user = new Client();
            DAL_AdopteUnDev.DTO.Developer dev = new DAL_AdopteUnDev.DTO.Developer
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

            //Console.WriteLine(JsonSerializer.Serialize(dev));
            //la classe é una lista di Methods, ma mi mancano le entità , in questo caso ' Developer'
            /*DeveloperServices dev2 = new DeveloperServices();
            dev2.Get(4);
            Console.WriteLine(JsonSerializer.Serialize(dev2)); */ //non ha niente

            //questa si che é una lista di entità 'Developer' con tutti i servizi
            IDeveloperRepository<BLL_AdopteUnDev01.Models.Developer> service = new BLL_AdopteUnDev01.Repository.DeveloperService(new DAL_AdopteUnDev.DAO.DeveloperServices());
            IEnumerable<BLL_AdopteUnDev01.Models.Developer> gruppoDev = service.Get();
            foreach (BLL_AdopteUnDev01.Models.Developer d in gruppoDev)
            {
                Console.WriteLine(JsonSerializer.Serialize(d));
            }
            BLL_AdopteUnDev01.Models.Developer dev4 = service.Get(4);
            Console.WriteLine(dev4.DevFirstName);


            int lingua = Int32.Parse(dev4.DevCategPrincipal);
            int idDev = dev4.idDev;

            ITLang lang = new ITLang();
            //int idIT;
            //string ITLabel;

            //x avere la lista delle lingue:
            IDeveloperRepository<ITLang> serviceLang = new DAL_AdopteUnDev.DAO.ITLangServices();
            IEnumerable<ITLang> listaLang = serviceLang.Get();
            List<ITLang> lista = listaLang.ToList();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idIT == lingua) 
                { 
                    lang.idIT = lista[i].idIT;
                    lang.ITLabel = lista[i].ITLabel; 
                }
            }

            Console.WriteLine(idDev + " : id developer");
            Console.WriteLine(lingua + " : id lingua dev");
            Console.WriteLine(lang.ITLabel+" : label");
            Console.WriteLine(lang.idIT+" : id Lang");
            //Console.WriteLine(ITLabel); //non riesce a recuperare il valore con il 'For'


        }
    }
}
