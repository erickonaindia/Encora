using ConsoleApp.Model;

namespace ConsoleApp.TestProject
{
    public class Tests
    {
        private Request _request;
        private List<string> _result;

        [SetUp]
        public void Setup()
        {
            _request = new Request();
            _result = new List<string>();
        }

        [Test]
        public void TestSortStringWith2Lines_OK()
        {
            List<string> _values = new List<string>() { "abaccadcc", "xyzxy" };
            List<string> _expected = new List<string>() { "ccccaaabd", "xxyyz" };

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);

            Assert.That(_result, Is.EqualTo(_expected));
        }

        [Test]
        public void TestSortStringWith10Lines_OK()
        {
            List<string> _values = new List<string>() { "dulgvgzwqg",
                "gxtjtmtywr",
                "hnlnxiupgt",
                "gzjotckivp",
                "dpwwsdptae",
                "pcscpilknb",
                "btvyhhmflf",
                "artrtnqxcr",
                "nrtcmcoadn",
                "fkdsgnekft" };
            List<string> _expected = new List<string>() { "gggdlquvwz",
                "tttgjmrwxy",
                "nnghilptux",
                "cgijkoptvz",
                "ddppwwaest",
                "ccppbiklns",
                "ffhhblmtvy",
                "rrrttacnqx",
                "ccnnadmort",
                "ffkkdegnst" };
            List<string> result = new List<string>();

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);
        }

        [Test]
        public void TestSortStringWith5Lines_OK()
        {
            List<string> _values = new List<string>() { "wzenwebuau",
                "vokfxzynwl",
                "neldfeyrxk",
                "wqadfiodgs",
                "ykiuvzfcbc" };
            List<string> _expected = new List<string>() { "eeuuwwabnz",
                "fklnovwxyz",
                "eedfklnrxy",
                "ddafgioqsw",
                "ccbfikuvyz" };

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);

            Assert.That(_result, Is.EqualTo(_expected));
        }

        [Test]
        public void TestSortStringWith10LinesMinorLength_OK()
        {
            List<string> _values = new List<string>() { "qakmc",
                "rrtbk",
                "vaixn",
                "wmpnj",
                "uproi",
                "btska",
                "ejqwr",
                "elwlg",
                "oaoiy",
                "hrqkn"};
            List<string> _expected = new List<string>() { "ackmq",
                "rrbkt",
                "ainvx",
                "jmnpw",
                "iopru",
                "abkst",
                "ejqrw",
                "llegw",
                "ooaiy",
                "hknqr",
            };

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);

            Assert.That(_result, Is.EqualTo(_expected));
        }

        [Test]
        public void TestSortStringWith3LinesMinorLength_OK()
        {
            List<string> _values = new List<string>() { "pzjim",
                "njnfq",
                "xyohs"};
            List<string> _expected = new List<string>() { "ijmpz",
                "nnfjq",
                "hosxy",
            };

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);

            Assert.That(_result, Is.EqualTo(_expected));
        }

        [Test]
        public void TestSortStringWith5LinesMinorLength_OK()
        {
            List<string> _values = new List<string>() { "xqycs",
                "beoax",
                "afkso",
                "bldit",
                "gwrys",
            };
            List<string> _expected = new List<string>() { "cqsxy",
                "abeox",
                "afkos",
                "bdilt",
                "grswy",
            };

            _request.N = _values.Count;
            _request.Strings = _values;
            _result = SortingOperationsHelper.SortingOperations(_request);

            Assert.That(_result, Is.EqualTo(_expected));
        }

        [Test]
        public void TestStringWithNumbers_ThrowException()
        {
            List<string> _values = new List<string>() { "abaccadcc22" };
            _request.N = _values.Count;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() => {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.DifferentOfLetters, ex.Message.ToString());
        }

        [Test]
        public void TestStringWithSymbols_ThrowException()
        {
            List<string> _values = new List<string>() { "abaccadcc!$" };
            _request.N = _values.Count;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() => {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.DifferentOfLetters, ex.Message.ToString());
        }

        [Test]
        public void TestStringWithSymbolsAndNumbersAndSpaces_ThrowException()
        {
            List<string> _values = new List<string>() { "abaccadcc!$34 " };
            _request.N = _values.Count;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() => {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.DifferentOfLetters, ex.Message.ToString());
        }

        [Test]
        public void TestStringEmptyOrNull_ThrowException()
        {
            List<string> _values = new List<string>() { "", null };
            _request.N = _values.Count;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() => {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.DifferentOfLetters, ex.Message.ToString());
        }

        [Test]
        public void TestStringEmpty_ThrowException()
        {
            List<string> _values = new List<string>();
            _request.N = _values.Count;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() => {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.LinesNotFound, ex.Message.ToString());
        }

        [Test]
        public void TestSortStringNDifferentOfCountList_ThrowException()
        {
            List<string> _values = new List<string>() { "abaccadcc", "xyzxy" };
            List<string> _expected = new List<string>() { "ccccaaabd", "xxyyz" };

            _request.N = 1;
            _request.Strings = _values;

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                _result = SortingOperationsHelper.SortingOperations(_request);
            });

            StringAssert.Contains(ErrorMessages.Ndifferent, ex.Message.ToString());
        }
    }
}