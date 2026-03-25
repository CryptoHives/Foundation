| Description                                     | ParticipantCount | Mean       | Ratio | Allocated | 
|------------------------------------------------ |----------------- |-----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |   7.065 ns |  0.79 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |   7.971 ns |  0.90 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |   8.902 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                |  17.093 ns |  1.92 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                |  42.434 ns |  4.77 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 437.338 ns | 49.13 |     205 B | 
|                                                 |                  |            |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               |  17.694 ns |  0.73 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               |  20.818 ns |  0.86 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               |  24.149 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               |  29.803 ns |  1.23 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               |  59.234 ns |  2.45 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 431.504 ns | 17.87 |     207 B |