using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_test;

namespace Task1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static string Word = "Hello world!";
        private static int SizeWord = Word.Length;
        private static int SetContainerValue = 1;
        private static string MyColor = "Green";

        //Меняем только значение контейнера

        [TestMethod]
        public void WriteDefoltContainerValue()
        {
            Pen obj = new Pen(10000);
            string c = obj.write(Word);
            Console.WriteLine(c);
            Assert.AreEqual(c, Word);  //должно вывести слово полностью
        }

        [TestMethod]
        public void WriteZeroContainerValue()
        {
            Pen obj = new Pen(0);
            string c = obj.write(Word);
            Console.WriteLine(c);
            Assert.AreEqual(c, "");  // слово должно быть пустым
        }

        [TestMethod]
        public void WriteEqualWordContainerValue()
        {
            Pen obj = new Pen(SizeWord);
            string c = obj.write(Word);
            Console.WriteLine(Word);
            Console.WriteLine(c);
            Assert.AreEqual(c, Word); //должно вывести слово полностью
        }

        [TestMethod]
        public void WriteSetContainerValue()
        {
            Pen obj = new Pen(SetContainerValue);
            string c = obj.write(Word);
            string partOfWord = Word.Substring(0, SetContainerValue);
            Console.WriteLine(partOfWord);
            Console.WriteLine(c);
            Assert.AreEqual(c, partOfWord); // должно вывести заданное количество символов
        }


        // Меняем значение контейнера и размер письма

        [TestMethod]
        public void WriteSetWordContainerValueWithLargeLetter()
        {
            Pen obj = new Pen(SizeWord * 2, SizeWord * 2.0001);
            string c = obj.write(Word);
            Console.WriteLine(c);
            Assert.AreEqual(c, Word);  //должен ввести неполное слово (бросает в исключение) - баг
        }
        [TestMethod]
        public void WriteEqualWordContainerValueWithLargeLetter()
        {
            Pen obj = new Pen(SizeWord, SizeWord * 1.5);
            string c = obj.write(Word);
            Console.WriteLine(c);
            Assert.Fail(c, Word);  //должен вывести неполное слово (выводит полное) - баг (размер шрифта не влияет на расход чернила)
        }

        [TestMethod]
        public void WriteLessContainerValueWithLargeLetter()
        {
            Pen obj = new Pen(SizeWord - 2, SizeWord * 5);
            string c = obj.write(Word);
            string partOfWord = Word.Substring(0, 10);
            Console.WriteLine(partOfWord);
            Console.WriteLine(c);
            Assert.Fail(c, partOfWord);  //должен вывести слово, количество символов которого меньше размера слова -2
        }

        [TestMethod]
        public void W_________riteLessContainerValueWithLessLetter()
        {
            Pen obj = new Pen(SizeWord - 2, SizeWord * 0.0001);
            string c = obj.write(Word);
            Console.WriteLine(c);
            Assert.AreEqual(c, Word);  //должен вывести полное слово
        }

        [TestMethod]
        public void TestGetColorHavingColor()
        {
            Pen obj = new Pen(SizeWord, 1.0, MyColor);
            string c = obj.getColor();
            Console.WriteLine(c);
            Assert.AreEqual(c, MyColor);  // должен поменять цвет нашей ручки (не меняет) - баг
        }

        [TestMethod]
        public void TestGetColor()
        {
            Pen obj = new Pen();
            string c = obj.getColor();
            Console.WriteLine(c);
            Assert.AreEqual(c, "BLUE");
        }
        [TestMethod]
        public void TestIsWorkZero()
        {
            Pen obj = new Pen(0);
            bool c = obj.isWork();
            Console.WriteLine(c);
            Assert.AreEqual(c, false);
        }
        [TestMethod]
        public void TestIsWorkValid()
        {
            Pen obj = new Pen(10);
            bool c = obj.isWork();
            Console.WriteLine(c);
            Assert.AreEqual(c, true);
        }
        [TestMethod]
        public void TestDoSomethingElse()
        {
            Pen obj = new Pen(SizeWord, 1.0, MyColor);
            obj.doSomethingElse();
        }
        [TestMethod]
        public void TestDoSomethingElseWithoutColor()
        {
            Pen obj = new Pen(SizeWord, 1.0);
            obj.doSomethingElse();
        }
    }
}
