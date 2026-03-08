namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place == 0) _place = place;
            }

            public void Print()
            {
                return;
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;

            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        copy[i] = _sportsmen[i];
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place == 1) sum += 5;
                        else if (place == 2) sum += 4;
                        else if (place == 3) sum += 3;
                        else if (place == 4) sum += 2;
                        else if (place == 5) sum += 1;
                    }
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    int best = 100;
                    for (int i = 0; i < _count; i++)
                    {
                        int p = _sportsmen[i].Place;
                        if (p > 0 && p < best) best = p;
                    }
                    return best == 100 ? 0 : best;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public void Add(Sportsman s)
            {
                if (_count < 6)
                {
                    _sportsmen[_count] = s;
                    _count++;
                }
            }

            public void Add(Sportsman[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Add(arr[i]);
                }
            }

            private static bool HasFirstPlace(Team t)
            {
                for (int i = 0; i < t._count; i++)
                {
                    if (t._sportsmen[i].Place == 1) return true;
                }
                return false;
            }

            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (HasFirstPlace(teams[j + 1]) && !HasFirstPlace(teams[j]))
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                return;
            }
        }
    }
}
```
