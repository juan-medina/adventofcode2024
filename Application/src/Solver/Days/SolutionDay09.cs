namespace Application.Solver.Days;

public class SolutionDay09() : DaySolver(9)
{
    public override ulong Resolve(int part, string input)
    {
        var blocks = new List<(ulong id, ulong len)>();

        var id = 0ul;
        var isFile = true;
        foreach (var len in input.Select(d => ulong.Parse(d.ToString())))
        {
            blocks.Add((isFile ? id++ : ulong.MaxValue, len));
            isFile = !isFile;
        }

        var compacted = new List<(ulong id, ulong len)>();
        for (var i = 0; i < blocks.Count; i++)
        {
            var block = blocks[i];
            if (block.len == 0) continue;
            if (block.id != ulong.MaxValue) compacted.Add(block); // is a file is already compacted
            else
            {
                var target = block.len; // how much space we need to fill
                while (target > 0)
                {
                    var any = false;
                    for (var j = blocks.Count - 1; j >= i; j--)
                    {
                        var back = blocks[j]; // possible block

                        if (back.id == ulong.MaxValue || back.len <= 0) continue;
                        if (part == 2 && back.len > target) continue; // in part 2 we take only full blocks

                        var effective = Math.Min(back.len, target); // how much we take from the block
                        compacted.Add((back.id, effective));
                        target -= effective; // close to the target

                        if (part == 1) back.len -= effective; // in part 1 we can take a part of a block
                        else back.id = ulong.MaxValue; // in part 2 the whole block is empty now

                        blocks[j] = back; // update the block

                        any = true; // at least we got a block in the space
                        break;
                    }

                    if (any) continue; // if we didnt got a block there is nothing more, continue to next space
                    if (part == 2 && target > 0) compacted.Add((blocks[i].id, target)); // remaining as free space
                    break;
                }
            }
        }

        return compacted.Aggregate((hash: 0ul, pos: 0ul), (state, block) =>
        {
            var pos = state.pos + block.len;
            var total = block.id != ulong.MaxValue
                ? state.hash + block.id * (block.len * (2 * state.pos + block.len - 1) / 2)
                : state.hash;
            return (total, pos);
        }).hash; // hash calculation
    }
}