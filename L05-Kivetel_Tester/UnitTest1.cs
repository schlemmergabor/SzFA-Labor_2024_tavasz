using L05_Kivetel;
using Moq;

namespace L05_Kivetel_Tester
{
    [TestFixture]
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToStringTest()
        {
            FoodIngredient f = new FoodIngredient("zsemle", 1, Egyseg.Darab);

            string vart = "zsemle - 1 - Darab";

            Assert.That(f.ToString(), Is.EqualTo(vart));
        }

        [Test]
        public void EmptyTest()
        {
            // példányosítás
            // Empty() -> true
            IngredientStack s = new IngredientStack(2);

            Assert.That(s.Empty(), Is.EqualTo(true));
        }
        [Test]
        public void MockEmptyTest()
        {
            // EmptyTest Mock-al
            Mock<IStack> mock = new Mock<IStack>();

            mock.Setup(m => m.Empty()).Returns(true);

            Assert.That(mock.Object.Empty(), Is.EqualTo(true));
        }
        [Test]
        public void MockPopTest()
        {
            // Pop Test Mock-al

            Mock<IStack> mock = new Mock<IStack>();
            IngredientStack s = new IngredientStack(2);
            mock.Setup(m => m.Empty()).Returns(true);
            mock.Setup(m => m.Pop()).Throws(new StackEmptyException(s));

            Assert.Throws<StackEmptyException>(() => mock.Object.Pop());

        }


        [Test]
        public void EmptyTest2()
        {
            IngredientStack s = new IngredientStack(2);
            FoodIngredient food =
                new FoodIngredient("zsemle", 2, Egyseg.Darab);

            s.Push(food);

            Assert.That(s.Empty(), Is.EqualTo(false));
        }

        [Test]
        public void PushTest()
        {
            // ha tele -> dobódik-e kivétel?

            IngredientStack s = new IngredientStack(0);
            FoodIngredient food =
                new FoodIngredient("zsemle", 2, Egyseg.Darab);
            // Így is lehet...
            //try
            //{
            //    s.Push(food);
            //}
            //catch (StackFullException)
            //{
            //    Assert.Pass();
            //}
            //Assert.Fail();

            Assert.Throws<StackFullException>(() => s.Push(food));
        }

        [Test]
        public void PopTest()
        {
            IngredientStack s = new IngredientStack(0);
            Assert.Throws<StackEmptyException>(() => s.Pop());
        }

        [Test]
        public void TopTest()
        {
            IngredientStack s = new IngredientStack(1);
            FoodIngredient food =
                new FoodIngredient("zsemle", 2, Egyseg.Darab);

            s.Push(food);

            Assert.That(s.Top(), Is.EqualTo(food));
        }
        [Test]
        public void HandlerTest()
        {
            IngredientStack stack =
               new IngredientStack(2);

            FoodIngredient[] food =
                new FoodIngredient[]
                {
            new FoodIngredient("zsemle", 1, Egyseg.Darab),
            new FoodIngredient("tej", 1, Egyseg.Darab),
            new FoodIngredient("vaj", 1, Egyseg.Darab),
            new FoodIngredient("paprika", 1, Egyseg.Darab),
            new FoodIngredient("kolbász", 1, Egyseg.Darab)
        };

            IngredientStackHandler handler =
                new IngredientStackHandler(stack);

            FoodIngredient[] nemFertBele = handler.AddItems(food);

            FoodIngredient[] vart =
            {
                food[2], food[3], food[4]
            };

            Assert.That(nemFertBele, Is.EqualTo(vart));
        }
        
    }
}