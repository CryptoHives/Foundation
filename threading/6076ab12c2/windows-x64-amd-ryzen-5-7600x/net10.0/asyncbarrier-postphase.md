| Description                                        | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------------------- |----------------- |-------------:|------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |     15.40 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     42.96 ns |  2.79 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    471.90 ns | 30.64 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |    951.31 ns | 61.76 |     240 B | 
|                                                    |                  |              |       |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    342.88 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    381.89 ns |  1.11 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    815.34 ns |  2.38 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 17,463.86 ns | 50.93 |    1392 B |