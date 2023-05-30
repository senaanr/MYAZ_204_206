using DisjointSet;

namespace DisjonitSetTests
{
    public class DisjointSetTests
    {
        [Fact]
        public void Smoke_Test_DisJointSet()
        {
            var disjointSet = new DisjointSet<int>();

            for (int i = 1; i <= 7; i++)
            {
                disjointSet.MakeSet(i);
            }

            //IEnumerable test
            Assert.Equal(disjointSet.Count, disjointSet.Count());

            disjointSet.Union(1, 2);
            Assert.Equal(1, disjointSet.FindSet(2));

            disjointSet.Union(2, 3);
            Assert.Equal(1, disjointSet.FindSet(3));

            disjointSet.Union(4, 5);
            Assert.Equal(4, disjointSet.FindSet(4));

            disjointSet.Union(5, 6);
            Assert.Equal(4, disjointSet.FindSet(5));

            disjointSet.Union(6, 7);
            Assert.Equal(4, disjointSet.FindSet(6));

            Assert.Equal(4, disjointSet.FindSet(4));
            disjointSet.Union(3, 4);
            Assert.Equal(1, disjointSet.FindSet(4));

            //IEnumerable test
            Assert.Equal(disjointSet.Count, disjointSet.Count());

        }

        [Fact]
        public void DisJointSet()
        {
            var disjointSet = new DisjointSet<int>();

            for (int i = 1; i <= 8; i++)
            {
                disjointSet.MakeSet(i);
            }

            disjointSet.Union(1, 2);
            Assert.Equal(1, disjointSet.FindSet(2));
            Assert.Equal(1, disjointSet.FindSet(1));

            disjointSet.Union(2, 3);
            Assert.Equal(1, disjointSet.FindSet(3));

            disjointSet.Union(3, 4);
            Assert.Equal(1, disjointSet.FindSet(4));

            disjointSet.Union(5, 6);

            disjointSet.Union(1, 5);
            Assert.Equal(1, disjointSet.FindSet(5));
            Assert.Equal(1, disjointSet.FindSet(6));


            disjointSet.Union(7, 8);

            disjointSet.Union(1, 7);
            Assert.Equal(1, disjointSet.FindSet(7));
            Assert.Equal(1, disjointSet.FindSet(8));



            Assert.Equal(disjointSet.Count, disjointSet.Count());

        }

        [Fact]
        public void DisJointSet_TestPathCompression()
        {
            DisjointSet<int> disjointSet = new DisjointSet<int>();

            // Düðümler oluþturma
            disjointSet.MakeSet(1);
            disjointSet.MakeSet(2);
            disjointSet.MakeSet(3);
            disjointSet.MakeSet(4);
            disjointSet.MakeSet(5);

            // Union iþlemleri
            disjointSet.Union(1, 2);
            disjointSet.Union(3, 4);
            disjointSet.Union(1, 3);
            disjointSet.Union(4, 5);

            // Path compression iþlemi
            disjointSet.PathCompression(1);
            disjointSet.PathCompression(2);
            disjointSet.PathCompression(3);
            disjointSet.PathCompression(4);
            disjointSet.PathCompression(5);

            // Kök düðümleri kontrol etme
            Assert.Equal(1, disjointSet.FindSet(1));
            Assert.Equal(1, disjointSet.FindSet(2));
            Assert.Equal(1, disjointSet.FindSet(3));
            Assert.Equal(1, disjointSet.FindSet(4));
            Assert.Equal(1, disjointSet.FindSet(5));

        }
    }
}