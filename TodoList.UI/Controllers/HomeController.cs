using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using TodoList.BLL.UnitOfWork.Interfaces;
using TodoList.DAL.Entities;
using TodoList.DTO.Models.Todo;
using TodoList.UI.Extensions;
using TodoList.UI.Filters;
using TodoList.UI.Models;

namespace TodoList.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.TodoRepository.GetAll().OrderByDescending(x => x.Id).AsQueryable().ProjectTo<TodoDto>();
            return View(model);
        }

        [ValidateModelState]
        [HttpPost]
        public JsonResult AddOrUpdate(TodoDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != null)
                {
                    var entity = _unitOfWork.TodoRepository.GetById((int)model.Id);
                    entity.Description = model.Description;
                    entity.DueDate = model.DueDate;
                    _unitOfWork.TodoRepository.Update(entity);
                }
                else
                {
                    var entity = model.Map<Todo>();
                    _unitOfWork.TodoRepository.Add(entity);
                }
                _unitOfWork.Save();
            }

            return Json(new Result{ Success = true });
        }

        [HttpPost]
        public JsonResult CheckStatus(TodoDto model)
        {
            var result = new Result();
            try
            {
                var entity = _unitOfWork.TodoRepository.GetById((int)model.Id);
                entity.Status = model.Status;
                _unitOfWork.TodoRepository.Update(entity);
                _unitOfWork.Save();
                result.Success = true;
            }
            catch (Exception x)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = "Err-Excp",
                    Message = x.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteTodo(int id)
        {
            var result = new Result();
            try
            {
                _unitOfWork.TodoRepository.Delete(id);
                _unitOfWork.Save();
                result.Success = true;
            }
            catch (Exception x)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = "Err-Excp",
                    Message = x.Message
                };
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult OutDatedTodo()
        {
            var result = new Result<TodoDto>();

            var data = _unitOfWork.TodoRepository.GetAll()
                .Where(x => EntityFunctions.TruncateTime(x.DueDate) == EntityFunctions.TruncateTime(DateTime.Now)).ProjectTo<TodoDto>();

            return Json(new Result<IEnumerable<TodoDto>>
            {
                Data = data
            }, JsonRequestBehavior.AllowGet);
        }
    }
}