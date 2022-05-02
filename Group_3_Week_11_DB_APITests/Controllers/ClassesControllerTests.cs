using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group_3_Week_11_DB_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group_3_Week_11_DB_API.Data;
using Group_3_Week_11_DB_API.Models;

namespace Group_3_Week_11_DB_API.Controllers.Tests
{
    [TestClass()]
    public class ClassesControllerTests
    {
        [TestMethod()]
        public void GetClassesTest()
        {
        

            Wossamotta_UContext SampleContest = new Wossamotta_UContext();

            Controllers.ClassesController classesController = new ClassesController(SampleContest);

            String? Test = classesController.GetClasses().ToString();

            Assert.IsNotNull(Test);

        

        }

        [TestMethod()]
        public void GetFacultiesTest()
        {
            Wossamotta_UContext SampleContest = new Wossamotta_UContext();

            Controllers.FacultiesController facultiesController = new FacultiesController(SampleContest);

            String? Test = facultiesController.GetFaculties().ToString();

            Assert.IsNotNull(Test);
        }


        [TestMethod()]
        public void GetStudentsTest()
        {
            Wossamotta_UContext SampleContest = new Wossamotta_UContext();

            Controllers.StudentsController studentsController = new StudentsController(SampleContest);

            String? Test = studentsController.GetStudents().ToString();



            Assert.IsNotNull(Test);

            
        }

    }
}