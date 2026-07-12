| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |  6.854 ns |  0.89 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  7.608 ns |  0.99 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  7.715 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 17.102 ns |  2.22 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 18.916 ns |  2.45 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 46.483 ns |  6.03 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 18.720 ns |  0.81 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 20.697 ns |  0.90 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 23.114 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 28.899 ns |  1.25 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 29.663 ns |  1.28 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 64.409 ns |  2.79 |         - |