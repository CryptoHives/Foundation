| Description                            | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     34.64 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     66.96 ns |  1.93 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |    921.01 ns | 26.59 |     240 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,801.72 ns | 52.02 |    5336 B | 
|                                        |                  |              |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    945.93 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  3,060.08 ns |  3.23 |    6589 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  6,530.03 ns |  6.90 |    1192 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 24,014.81 ns | 25.39 |    1392 B |