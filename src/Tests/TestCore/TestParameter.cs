using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace TestCore;
/// <summary>
/// Класс для тестирования класса <see cref="Parameter"/>.
/// </summary>
[TestFixture]
public class TestParameter
{
    [TestCase(TestName = "Проверка ввода негативного значения")]
    public void TestNegativeValueToZero_InCorrectValue()
    {
        var parameter = new Parameter();
        parameter.MinValue = -10;
        parameter.MaxValue = -10;
        Assert.That(
                    parameter.MinValue,
                    Is.EqualTo(0),
                    "Негативное значение превратилось в ноль.");
        Assert.That(
            parameter.MaxValue,
            Is.EqualTo(0),
            "Негативное значение превратилось в ноль.");

    }

    [TestCase(TestName = "Проверка получения Name")]
    public void TestGetValueName_CorrectValue()
    {
        var parameter = new Parameter();
        var expected = "Name";

        parameter.Name = "Name";
        
        Assert.That(
            parameter.Name,
            Is.EqualTo(expected),
            "Корректное имя параметра");
    }

    [TestCase(TestName = "Проверка получения ErrorMessage")]
    public void TestGetValueErrorMessage_CorrectValue()
    {
        var parameter = new Parameter();
        var expected = "ErrorMessage";

        parameter.ErrorMessage = "ErrorMessage";

        Assert.That(
            parameter.ErrorMessage,
            Is.EqualTo(expected),
            "Корректное имя ошибки параметра");
    }
}
