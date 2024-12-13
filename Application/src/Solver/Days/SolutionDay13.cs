using System.Text.RegularExpressions;

namespace Application.Solver.Days;

public partial class SolutionDay13() : DaySolver(13)
{
    public override ulong Resolve(int part, string input) =>
        (ulong)Parse(input, part).Select(ButtonPushes).Sum(b => b.a * 3 + b.b);

    private static (long a, long b) ButtonPushes(((long x, long y) a, (long x, long y) b, (long X, long Y) p) m)
    {
        var tickets = TryGcd(m); // Try first with Greatest Common Divisor
        if (tickets.a != 0 && tickets.b != 0) return tickets; // return the tickets if we have a valid output

        if (m.a.x * m.b.y != m.a.y * m.a.x) return (0, 0); // if the are linearly independent, no solution exists
        if (!(m.a.x * m.p.Y != m.a.y * m.p.X || m.b.x * m.p.Y != m.b.x * m.p.X))
            return (0, 0); // if we can not reach p using a or b we can not solve

        return DiophantineApprox(m); // try to find if we can find it using approximations
    }

    private static (long a, long b) TryGcd(((long x, long y) a, (long x, long y) b, (long X, long Y) p) m)
    {
        (long a, long b) divisor = (m.a.x * m.b.y - m.a.y * m.b.x, m.a.y * m.b.x - m.a.x * m.b.y);
        (long a, long b) dividend = (m.b.y * m.p.X - m.b.x * m.p.Y, m.a.y * m.p.X - m.a.x * m.p.Y);
        (long a, long b) reminder = (dividend.a % divisor.a, dividend.b % divisor.b);
        if (reminder.a != 0 || reminder.b != 0) return (0, 0); // ig GCD do not work we return (0,0)
        return (dividend.a / divisor.a, dividend.b / divisor.b); // return our presses 
    }

    private static (long a, long b) DiophantineApprox(((long x, long y) a, (long x, long y) b, (long X, long Y) p) m)
    {
        long a = m.a.x, b = m.b.x, p = m.p.X; // for shortness store as value
        var reverse = a * 3 > b * 1; // what use less tickets, approaching using more a or b
        long l = reverse ? b : a, h = reverse ? a : b; // what are the values we need in each button [a or b]
        (long h, long l) guess = (p / h, 0); // we start approaching the value as close as we can
        while (guess.h >= 0)
        {
            var remainder = p - guess.h * h; // calculate reminder
            guess.l = remainder / l; // calculate the other button reminder
            if (remainder % l == 0) // we can not press anymore using the chosen button
            {
                (long a, long b) press = ((reverse) ? guess.h : guess.l, (reverse) ? guess.l : guess.h); // calc press
                if (press.a * m.a.x + press.b * m.b.x != m.p.Y || press.a * m.a.y + press.b * m.a.y != m.p.Y)
                    return (0, 0); // we didn't reach the target with this presses
                return press; // we reach return the presses
            }

            guess.h--; // one more press 
        }

        return (0, 0); // we couldn't reach
    }

    private static List<((long x, long y) a, (long x, long y) b, (long x, long y) p)> Parse(string input, int part)
    {
        var matches = ParseRegex().Matches(input);
        return Enumerable.Range(0, matches.Count / 3)
            .Select(i => new
            {
                a = (long.Parse(matches[i * 3].Groups[1].Value),
                    long.Parse(matches[i * 3].Groups[2].Value)),
                b = (long.Parse(matches[i * 3 + 1].Groups[1].Value),
                    long.Parse(matches[i * 3 + 1].Groups[2].Value)),
                p = (long.Parse(matches[i * 3 + 2].Groups[1].Value) + (part == 1 ? 0 : 10000000000000L),
                    long.Parse(matches[i * 3 + 2].Groups[2].Value) + (part == 1 ? 0 : 10000000000000L))
            })
            .Select(m => (m.a, m.b, m.p))
            .ToList();
    }

    [GeneratedRegex(@"(\d+), Y.(\d+)")]
    private static partial Regex ParseRegex();
}