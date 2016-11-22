﻿using Newtonsoft.Json;
using SotosWoodwork.Models;
using SotosWoodwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SotosWoodwork.Controllers
{
    public class OrcamentoProdutosController : Controller
    {
        public ActionResult OrcamentoList()
        {
            return View();
        }

        public ActionResult OrcamentoForm()
        {
            return View();
        }


        [HttpGet]
        public string FindAll()
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                IList<Sts_orcamentoprodutos> listSts_orcamento = repository.ToList<Sts_orcamentoprodutos>();
                return JsonConvert.SerializeObject(listSts_orcamento);
            }
        }

        [HttpGet]
        public string GetById(int id)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                Sts_orcamentoprodutos sts_orcamentoprodutos = (Sts_orcamentoprodutos)repository.GetById(typeof(Sts_orcamentoprodutos), id);
                return JsonConvert.SerializeObject(sts_orcamentoprodutos);
            }
        }

        public string Save(string json)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    Sts_orcamentoprodutos sts_orcamentoprodutos = JsonConvert.DeserializeObject<Sts_orcamentoprodutos>(json);
                    repository.Save(sts_orcamentoprodutos);

                    return JsonConvert.SerializeObject(sts_orcamentoprodutos);
                }
                catch
                {
                    repository.RollbackTransaction();

                    return "Erro";
                }
            }
        }

        public string Delete(int id)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    Sts_orcamentoprodutos sts_orcamentoprodutos = (Sts_orcamentoprodutos)repository.GetById(typeof(Sts_orcamentoprodutos), id);
                    repository.Delete(sts_orcamentoprodutos);

                    return JsonConvert.SerializeObject(sts_orcamentoprodutos);
                }
                catch
                {
                    repository.RollbackTransaction();

                    return "Erro";
                }
            }
        }
    }
}