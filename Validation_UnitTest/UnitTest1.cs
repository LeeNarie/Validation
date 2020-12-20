using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Validation_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FIO_Test1()
        {
            bool fio1 =  ValLib.Validation_Class.FIO_Check("Долгушина Ирина Сергеевна");
            bool fio2 = ValLib.Validation_Class.FIO_Check("иванов иван иванович");
            bool fio3 = ValLib.Validation_Class.FIO_Check("Владимиров Владимир");
            bool fio4 = ValLib.Validation_Class.FIO_Check("Владимир");
            bool fio5 = ValLib.Validation_Class.FIO_Check("Иванов Иван Иван Иванов");

            Assert.AreEqual(true, fio1);
            Assert.AreEqual(false, fio2);
            Assert.AreEqual(true, fio3);
            Assert.AreEqual(false, fio4);
            Assert.AreEqual(false, fio5);
        }

        [TestMethod]
        public void DR_Test1()
        {
            bool dr1 = ValLib.Validation_Class.DR_Check("29.12.2001");
            bool dr2 = ValLib.Validation_Class.DR_Check("12/10/2000");
            bool dr3 = ValLib.Validation_Class.DR_Check("29.02.2020");
            bool dr4 = ValLib.Validation_Class.DR_Check("29.02.2019");
            bool dr5 = ValLib.Validation_Class.DR_Check("95.12.1999");

            Assert.AreEqual(true, dr1);
            Assert.AreEqual(false, dr2);
            Assert.AreEqual(true, dr3);
            Assert.AreEqual(false, dr4);
            Assert.AreEqual(false, dr5);
        }

        [TestMethod]
        public void PH_Test1()
        {
            bool ph1 = ValLib.Validation_Class.PH_Check("+79224733931");
            bool ph2 = ValLib.Validation_Class.PH_Check("88005553535");
            bool ph3 = ValLib.Validation_Class.PH_Check("+89223222323");
            bool ph4 = ValLib.Validation_Class.PH_Check("+123asd123gh");
            bool ph5 = ValLib.Validation_Class.PH_Check("8-800-555-35-35");

            Assert.AreEqual(true, ph1);
            Assert.AreEqual(false, ph2);
            Assert.AreEqual(true, ph3);
            Assert.AreEqual(false, ph4);
            Assert.AreEqual(false, ph5);
        }

        [TestMethod]
        public void EM_Test1()
        {
            bool EM1 = ValLib.Validation_Class.EM_Check("dolg_iren@mail.ru");
            bool EM2 = ValLib.Validation_Class.EM_Check("123.ru");
            bool EM3 = ValLib.Validation_Class.EM_Check("a@gm.com");
            bool EM4 = ValLib.Validation_Class.EM_Check("@.ru");
            bool EM5 = ValLib.Validation_Class.EM_Check("mail@mail");

            Assert.AreEqual(true, EM1);
            Assert.AreEqual(false, EM2);
            Assert.AreEqual(true, EM3);
            Assert.AreEqual(false, EM4);
            Assert.AreEqual(false, EM5);
        }
    }
}
