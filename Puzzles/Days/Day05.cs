using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day05 : PuzzleBase<Day05.PrintConfig, int, int>
{
    protected override string Filename => "Input/day05.txt";
    protected override string PuzzleTitle => "--- Day 5: Print Queue ---";
    
    public override int PartOne(PrintConfig input)
    {
        var sum = 0;

        foreach (var page in input.Pages)
        {
            var correct = true;
            var relevantRules = input.Rules.Where(rule => rule.Intersect(page).Count() == 2).ToList();

            for (var i = 0; i < page.Length; i++)
            {
                var rulesToApply = relevantRules.Where(rule => rule[1] == page[i]).ToList();
                if (rulesToApply.Any(rule => !(Array.IndexOf(page, rule[0]) < i)))
                {
                    correct = false;
                    break;
                }
            }

            if (correct) sum += page[page.Length / 2];
        }
        
        return sum;
    }

    public override int PartTwo(PrintConfig input)
    {
        var sum = 0;

        foreach (var page in input.Pages)
        {
            var correct = true;
            var relevantRules = input.Rules.Where(rule => rule.Intersect(page).Count() == 2).ToList();

            for (var i = 0; i < page.Length; i++)
            {
                var rulesToApply = relevantRules.Where(rule => rule[1] == page[i]).ToList();
                if (rulesToApply.Any(rule => !(Array.IndexOf(page, rule[0]) < i)))
                {
                    correct = false;
                    break;
                }
            }

            if (correct) continue;

            var newOrder = new int[page.Length];
            foreach (var number in page)
            {
                var index = relevantRules.Count(rule => rule[1] == number);
                newOrder[index] = number;
            }
            sum += newOrder[newOrder.Length / 2];
        }
        
        return sum;
    }
    
    public override PrintConfig Preprocess(IPuzzleInput input, int part = 1)
    {
        var rules = input.GetAllLines().Where(x => x.Contains('|'))
            .Select(x => x.Split("|").Select(int.Parse).ToArray());
        
        var pages = input.GetAllLines().Where(x => x.Contains(','))
            .Select(x => x.Split(",").Select(int.Parse).ToArray());

        return new PrintConfig(rules, pages);
    }

    public class PrintConfig(IEnumerable<int[]> rules, IEnumerable<int[]> pages)
    {
        public IEnumerable<int[]> Rules => rules;
        public IEnumerable<int[]> Pages => pages;
    }
}