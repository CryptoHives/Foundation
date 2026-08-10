| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  4.295 ns |  0.74 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  5.787 ns |  1.00 |         - | 
| SignalAndWait · CountdownEvent · System         | 1                |  6.401 ns |  1.11 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 13.402 ns |  2.32 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 14.133 ns |  2.44 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 34.716 ns |  6.00 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 15.277 ns |  0.69 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 16.036 ns |  0.72 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 21.003 ns |  0.95 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 22.133 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 22.524 ns |  1.02 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 45.687 ns |  2.06 |         - |