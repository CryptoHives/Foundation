| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |  6.939 ns |  0.80 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  7.493 ns |  0.86 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  8.691 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 16.718 ns |  1.92 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 19.096 ns |  2.20 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 41.424 ns |  4.77 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 17.113 ns |  0.73 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 20.424 ns |  0.87 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 23.508 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 28.820 ns |  1.23 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 29.256 ns |  1.24 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 57.756 ns |  2.46 |         - |
