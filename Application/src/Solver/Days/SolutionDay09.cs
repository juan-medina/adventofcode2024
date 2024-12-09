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
        }// the data is lenght of [file,free space,file, free space, ...] the id increases only in files

        var compacted = new List<(ulong id, ulong len)>();
        for (var i = 0; i < blocks.Count; i++) // all blocks to compact
        {
            var block = blocks[i];
            if (block.len == 0) continue;
            if (block.id != ulong.MaxValue) compacted.Add(block); // is a file is already compacted
            else
            {
                var target = block.len; // how big this empty space is
                while (target > 0)
                {
                    var any = false; // do we get at least a file, full or part, in this free space?
                    for (var j = blocks.Count - 1; j >= i; j--) // all blocks from the end to front
                    {
                        var back = blocks[j]; // possible file block

                        if (back.id == ulong.MaxValue || back.len <= 0) continue; // is free space or empty
                        if (part == 2 && back.len > target) continue; // in part 2 we take only full files

                        var effective = Math.Min(back.len, target); // how much we take from the file
                        compacted.Add((back.id, effective));
                        target -= effective; // close to the target

                        if (part == 1) back.len -= effective; // in part 1 we can take a part of a file
                        else back.id = ulong.MaxValue; // in part 2 the whole file block is empty now

                        blocks[j] = back; // update the file block

                        any = true;
                        break;
                    }

                    if (any) continue; // if we get anything we try for more, if we already at target it will end
                    if (part == 2 && target > 0) compacted.Add((blocks[i].id, target)); // remaining as free space
                    break; // we haven't got anything, there is nothing to do for this free space
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