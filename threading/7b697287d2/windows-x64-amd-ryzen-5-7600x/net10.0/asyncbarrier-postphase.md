| Description                                        | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------------------- |----------------- |-------------:|------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |     15.50 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     42.82 ns |  2.76 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    328.86 ns | 21.22 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |    956.54 ns | 61.72 |     240 B | 
|                                                    |                  |              |       |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    332.82 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    399.05 ns |  1.20 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    803.31 ns |  2.41 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 16,413.16 ns | 49.32 |    1392 B |