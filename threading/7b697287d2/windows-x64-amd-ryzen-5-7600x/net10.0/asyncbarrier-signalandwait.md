| Description                            | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     15.24 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     36.58 ns |  2.40 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |    468.17 ns | 30.73 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |    946.93 ns | 62.15 |    5471 B | 
|                                        |                  |              |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    338.28 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,655.06 ns |  4.89 |    7299 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  2,509.43 ns |  7.42 |    1192 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 18,006.85 ns | 53.23 |    1392 B |