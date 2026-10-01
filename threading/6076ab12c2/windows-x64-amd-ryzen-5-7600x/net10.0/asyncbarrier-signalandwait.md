| Description                            | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     15.55 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     36.66 ns |  2.36 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |    490.40 ns | 31.55 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |    943.14 ns | 60.67 |    5488 B | 
|                                        |                  |              |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    337.04 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,637.48 ns |  4.86 |    7270 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  2,577.22 ns |  7.65 |    1192 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 16,444.69 ns | 48.80 |    1392 B |