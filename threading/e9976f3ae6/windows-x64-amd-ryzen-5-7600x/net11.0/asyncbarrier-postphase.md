| Description                                        | ParticipantCount | Mean          | Error        | StdDev       | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |--------------:|-------------:|-------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |      12.98 ns |     0.022 ns |     0.020 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |      32.48 ns |     0.053 ns |     0.047 ns |   2.50 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |     464.74 ns |     0.694 ns |     0.615 ns |  35.80 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |     601.58 ns |     0.354 ns |     0.314 ns |  46.34 |     184 B | 
|                                                    |                  |               |              |              |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |     300.45 ns |     1.070 ns |     0.894 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |     370.86 ns |     1.366 ns |     1.278 ns |   1.23 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |     786.32 ns |     1.643 ns |     1.456 ns |   2.62 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 126,806.04 ns | 1,676.193 ns | 1,567.912 ns | 422.06 |    1270 B |