using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;

namespace CDEEnablementReport.Controllers
{
    public class UploadFilesController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UploadFilesController(ILoggerManager logger, IRepositoryWrapper repository) {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public IActionResult Post(List<IFormFile> files) {
            if (ModelState.IsValid)
            {
                DataSet result = null;
                IExcelDataReader reader = null;
                if (files != null)
                {
                    var filePath = Path.GetTempFileName();
                    foreach (var formfile in files)
                    {
                        if (formfile.Length > 0 && formfile.FileName.EndsWith(".xlsx"))
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                formfile.CopyTo(stream);                                                                
                            }

                            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                                result = reader.AsDataSet(new ExcelDataSetConfiguration() {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration(){
                                        UseHeaderRow = true
                                    }
                                });
                            }

                            List<AssociateCourseDetails> associateCourseDetails = new List<AssociateCourseDetails>();
                            foreach (DataRow row in result.Tables[0].Rows)
                            {
                                associateCourseDetails.Add(new AssociateCourseDetails {
                                    AssociateID = row["AssociateID"].ToString().Trim(),
                                    AssociateName = row["AssociateName"].ToString().Trim(),
                                    Course = row["Course"].ToString().Trim(),
                                    Stack = row["Stack"].ToString().Trim(),
                                    Training_Vendor = row["Training_Vendor"].ToString().Trim(),
                                    Recommendation = row["Recommendation"].ToString().Trim(),
                                    Reporting_Status = row["Reporting_Status"].ToString().Trim(),
                                    Grade2 = row["Grade2"].ToString().Trim(),
                                    Level_Description = row["Level_Description"].ToString().Trim(),
                                    DepartmentDescription = row["DepartmentDescription"].ToString().Trim(),
                                    DepartmentGroup = row["DepartmentGroup"].ToString().Trim(),
                                    Classification = row["Classification"].ToString().Trim(),
                                    HorizontalName = row["HorizontalName"].ToString().Trim(),
                                    VerticalName = row["VerticalName"].ToString().Trim()
                                });
                            }

                            _repository.associateCourseDetailsRepository.SaveAssociateCourseDetails(associateCourseDetails);
                            ViewBag.UploadMsg = "Data Saved Successfully...";
                        }
                        else
                        {
                            ModelState.AddModelError("File", "This file format is not supported");
                            return RedirectToAction("Index", "Home");
                        }

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                                                
                        reader.Close();
                    }
                }
                else {
                    ModelState.AddModelError("File", "Please Upload your file");
                }
            }
            return RedirectToAction("Index", "Home");
        }       
    }
}