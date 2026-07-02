| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  4.335 ns |  0.78 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  5.562 ns |  1.00 |         - | 
| SignalAndWait · CountdownEvent · System         | 1                |  6.269 ns |  1.13 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 13.525 ns |  2.43 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 14.005 ns |  2.52 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 34.500 ns |  6.20 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 15.245 ns |  0.71 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 15.914 ns |  0.74 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 20.970 ns |  0.98 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 21.507 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 22.497 ns |  1.05 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 46.979 ns |  2.18 |         - |