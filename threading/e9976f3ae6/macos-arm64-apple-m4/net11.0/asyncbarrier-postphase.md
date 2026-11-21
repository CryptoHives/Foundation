| Description                                        | ParticipantCount | Mean         | Error      | StdDev       | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |-------------:|-----------:|-------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |     10.40 ns |   0.015 ns |     0.014 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     22.97 ns |   0.015 ns |     0.014 ns |   2.21 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    354.82 ns |   1.116 ns |     1.044 ns |  34.12 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |    831.05 ns |  13.584 ns |    12.706 ns |  79.92 |     183 B | 
|                                                    |                  |              |            |              |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    245.06 ns |   2.692 ns |     2.518 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    288.71 ns |   3.262 ns |     3.051 ns |   1.18 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    581.58 ns |   2.377 ns |     2.223 ns |   2.37 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 48,700.03 ns | 955.239 ns | 1,022.095 ns | 198.74 |    1264 B |