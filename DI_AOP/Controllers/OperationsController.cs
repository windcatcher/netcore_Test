using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_AOP.Interfaces;
using DI_AOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI_AOP.Controllers {
    public class OperationsController : Controller {
        private readonly OperationService _operationService;
        private readonly IOperationTransient _operTransient;
        private readonly IOperationScoped _operScope;
        private readonly IOperationSingleton _operSigle;
        private readonly IOperationSingletonInstance _operInstance;
        public OperationsController (IOperationTransient transientOperation,
            OperationService operationService,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation) {
            _operTransient = transientOperation;
            _operScope = scopedOperation;
            _operSigle = singletonOperation;
            _operInstance = singletonInstanceOperation;
            _operationService = operationService;
        }

        public IActionResult Index () {

            
            ViewBag.Transient = _operTransient;
            ViewBag.Scoped = _operScope;
            ViewBag.Singleton = _operSigle;
            ViewBag.SingletonInstance = _operInstance;
            // operation service has its own requested services
            ViewBag.Service = _operationService;
            return View ();
        }

    }

}