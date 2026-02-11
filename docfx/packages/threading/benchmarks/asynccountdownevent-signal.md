| Method                              | ParticipantCount | Mean       | Ratio | Allocated | 
|------------------------------------ |----------------- |-----------:|------:|----------:|
| SignalAndWaitCountdownEventStandard | 1                |   6.776 ns |  0.38 |         - | 
| SignalAndWaitRefImplAsync           | 1                |  17.113 ns |  0.96 |      96 B | 
| SignalAndWaitPooledAsync            | 1                |  17.839 ns |  1.00 |         - | 
| WaitAndSignalPooledAsync            | 1                |  58.850 ns |  3.30 |         - | 
|                                     |                  |            |       |           | 
| SignalAndWaitCountdownEventStandard | 10               |  20.122 ns |  0.34 |         - | 
| SignalAndWaitRefImplAsync           | 10               |  28.387 ns |  0.48 |      96 B | 
| SignalAndWaitPooledAsync            | 10               |  58.640 ns |  1.00 |         - | 
| WaitAndSignalPooledAsync            | 10               | 104.738 ns |  1.79 |         - |