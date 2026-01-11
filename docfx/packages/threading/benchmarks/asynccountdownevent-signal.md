| Method                              | ParticipantCount | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------------ |----------------- |-----------:|------:|----------:|------------:|
| SignalAndWaitCountdownEventStandard | 1                |   7.818 ns |  0.40 |         - |          NA |
| SignalAndWaitRefImplAsync           | 1                |  19.262 ns |  0.98 |      96 B |          NA |
| SignalAndWaitPooledAsync            | 1                |  19.577 ns |  1.00 |         - |          NA |
| WaitAndSignalPooledAsync            | 1                |  59.275 ns |  3.03 |         - |          NA |
|                                     |                  |            |       |           |             |
| SignalAndWaitCountdownEventStandard | 10               |  22.099 ns |  0.31 |         - |          NA |
| SignalAndWaitRefImplAsync           | 10               |  32.415 ns |  0.46 |      96 B |          NA |
| SignalAndWaitPooledAsync            | 10               |  70.547 ns |  1.00 |         - |          NA |
| WaitAndSignalPooledAsync            | 10               | 111.704 ns |  1.58 |         - |          NA |
