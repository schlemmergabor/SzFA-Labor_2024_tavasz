using L12_MintaZH2;

namespace L12_MintaZH2_Tester
{
    public class Tests
    {
        [TestCase("02:13:46", 2, 13, 46)]
        [TestCase("13:46", 0, 13, 46)]
        public void ParseSuccessful(string input, int hour, int minute, int second)
        {
            Time actual = Time.Parse(input);
            Assert.That(actual.Ora, Is.EqualTo(hour));
            Assert.That(actual.Perc, Is.EqualTo(minute));
            Assert.That(actual.Masodperc, Is.EqualTo(second));
        }

        [TestCase("")]
        [TestCase("2:13:46")]
        [TestCase("4:13:46")]
        [TestCase("2:76:46")]
        [TestCase("2:13:98")]
        [TestCase("1:46")]
        [TestCase("0:1:2:34")]
        public void ParseFailed(string input)
        {
            Assert.Throws<TimeException>(() => Time.Parse(input));
        }

        [TestCase("00:00:00", "01:00", -1)]
        [TestCase("01:13:46", "01:13:46", 0)]
        [TestCase("02:34:21", "01:56:17", +1)]
        public void CompareTo(string input1, string input2, int expected)
        {
            Assert.That(Time.Parse(input1).CompareTo(Time.Parse(input2)), Is.EqualTo(expected));
        }
    }
}